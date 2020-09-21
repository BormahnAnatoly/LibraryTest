using LibraryTest.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace LibraryTest.Services
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            this.PATH = path;
        }

        public ObservableCollection<RegistryBook> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new ObservableCollection<RegistryBook>();
            }
            using(var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<RegistryBook>>(fileText);
            }
        }

        public void SaveData(object libraryList)
        {
            using(StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(libraryList);
                writer.Write(output);
            }
        }
    }
}
