using LibraryTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace LibraryTest.Services
{
    class FileIOService
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\LibraryList.json";

        public ObservableCollection<RegistryBook> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                return new ObservableCollection<RegistryBook>();
            }
            using(var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<RegistryBook>>(fileText);
            }
        }

        public void SaveData(object LibraryList)
        {
            using(StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(LibraryList);
                writer.Write(output);
            }
        }
    }
}
