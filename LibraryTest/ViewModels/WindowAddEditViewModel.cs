
using LibraryTest.Views;

namespace LibraryTest.ViewModels
{
    public class WindowAddEditViewModel : ModelBase
    {
        public Command OkCommand { get; }
        public Command CancelCommand { get; }

        public WindowAddEditViewModel()
        {
            OkCommand = new Command(arg => OkMethod(arg), () => CanOkClick());
            CancelCommand = new Command(arg => CancelMethod(arg), () => CanCancelClick());
        }

        private void OkMethod(object arg)
        {
            var window = arg as IClosable;
            if (window != null)
            {
                window.DialogResult = true;
                window.Close();
            }
        }

        private bool CanOkClick()
        {
            return true;
        }

        private void CancelMethod(object arg)
        {
            var window = arg as IClosable;
            if (window != null)
            {
                window.DialogResult = false;
                window.Close();
            }
        }

        private bool CanCancelClick()
        {
            return true;
        }

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
    }
}
