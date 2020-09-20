using System;
using System.ComponentModel;

namespace LibraryTest.Models
{
    class RegistryBook : INotifyPropertyChanged


    /* мож тут добавить public RegistryBook(uint numOfInvent, string title, string author, uint yearPublic) {
      this.numOfInvent = numOfInvent;
      this.title =  title;
    this.author = author;
    this.yearPublic = yearPublic;
    }
    и иинициализировать констукторы через this. потом подтянуть в геттеры и сеттеры */
    {
        private uint numOfInvent; // колонка номер инвентаря

        /* public uint NumOfInvent
         {
             get { return numOfInvent; }
         } */

        private string title; // колонка название

        public string Title { get; set; }

        private string author; // колонка автор

        public string Author { get; set; }

        private uint yearPublic; // колонка год издания

        public uint YearPublic { get; set; }

        public DateTime CreationDateYear { get; set; } = DateTime.Now; // дата поступления

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //проверка на null             
        }

    }
}
