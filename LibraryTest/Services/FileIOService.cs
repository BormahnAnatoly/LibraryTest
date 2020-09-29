using LibraryTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace LibraryTest.Services
{
    class FileIOService
    {
        private readonly string PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\LibraryBookApp";
        private readonly string FILENAME = "LibraryList.json";
        public ObservableCollection<RegistryBook> LoadData()
        {
            var fileExists = File.Exists(Path.Combine(PATH, FILENAME));
            if (!fileExists)
            {
                return new ObservableCollection<RegistryBook>();
            }
            using (var reader = File.OpenText(Path.Combine(PATH, FILENAME)))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<RegistryBook>>(fileText);
            }
        }

        public void SaveData(object LibraryList)
        {
            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }

            using (StreamWriter writer = File.CreateText(Path.Combine(PATH, FILENAME)))
            {
                string output = JsonConvert.SerializeObject(LibraryList);
                writer.Write(output);
            }
        }
    }
}
