using System;
using System.ComponentModel;

namespace LibraryTest.Models
{
    public class RegistryBook : INotifyPropertyChanged
    {
        public Guid Id { get; } = Guid.NewGuid();

        private uint numOfInvent; // колонка номер инвентаря
        public uint NumOfInvent
        {
            get { return numOfInvent; }
            set
            {
                numOfInvent = value;
                OnPropertyChanged(nameof(NumOfInvent));
            }
        }

        private string title; // колонка название
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string author; // колонка автор
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private uint yearPublic; // колонка год издания
        public uint YearPublic
        {
            get { return yearPublic; }
            set
            {
                yearPublic = value;
                OnPropertyChanged(nameof(YearPublic));
            }
        }

        public DateTime CreationDateYear { get; set; } = DateTime.Now; // дата поступления

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //проверка на null             
        }

    }
}
