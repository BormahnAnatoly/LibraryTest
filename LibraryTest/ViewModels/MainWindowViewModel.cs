using System;
using System.Collections.ObjectModel;
using System.Windows;
using LibraryTest.Models;
using LibraryTest.Services;
using LibraryTest.Views;

namespace LibraryTest.ViewModels
{
    public class MainWindowViewModel : ModelBase
    {
        private readonly FileIOService fileIOService = new FileIOService();        
        
        public MainWindowViewModel()
        {
            try
            {
                LibraryList = fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            if (LibraryList == null)
            {
                LibraryList = new ObservableCollection<RegistryBook>();
            }

            AddCommand = new Command(arg => AddCommandMethod(), () => CanAdd());
            EditCommand = new Command(arg => EditCommandMethod(), () => CanEdit());
            DeleteCommand = new Command(arg => DeleteCommandMethod(), () => CanDelete());
            SaveCommand = new Command(arg => SaveCommandMethod(), () => CanSave());

        }

        #region Properties 

        private ObservableCollection<RegistryBook> _libraryList;

        public ObservableCollection<RegistryBook> LibraryList 
        { 
            get 
            {
                return _libraryList;
            } 
            set
            {
                _libraryList = value;
                OnPropertyChanged(nameof(LibraryList));
            }
        }

        private RegistryBook _selectedBook;

        public RegistryBook SelectedBook 
        { 
            get 
            {
                return _selectedBook;
            }
            set
            {
                _selectedBook = value;
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            } 
        }

        #endregion

        #region Commands

        public Command AddCommand { get; }

        private bool CanAdd()
        {
            return true;
        }

        private void AddCommandMethod()
        {
            WindowAddView windowAdd = new WindowAddView
            {
                DataContext = new WindowAddEditViewModel()
            };
            
            var showDialog = windowAdd.ShowDialog();
            if (showDialog != null && showDialog.Value)
            {
                var result = windowAdd.DataContext as WindowAddEditViewModel;
                if (result != null )
                {
                    var book = new RegistryBook
                    {
                        Author = result.Author,
                        YearPublic = result.YearPublic,
                        Title = result.Title,
                        NumOfInvent = result.NumOfInvent
                    };

                    LibraryList.Add(book);
                }
            }
        }

        public Command EditCommand { get; }

        private bool CanEdit()
        {
            return SelectedBook != null;
        }

        private void EditCommandMethod()
        {
            if (SelectedBook != null)
            {
                WindowEditView windowEdit = new WindowEditView();
                windowEdit.DataContext = new WindowAddEditViewModel
                {
                    Title = SelectedBook.Title,
                    Author = SelectedBook.Author,
                    YearPublic = SelectedBook.YearPublic,
                    NumOfInvent = SelectedBook.NumOfInvent
                };
                var result = windowEdit.DataContext as WindowAddEditViewModel;
                if (windowEdit.ShowDialog() ?? false)
                {
                    if (result == null)
                    {
                        return;
                    }
                    for (int i = 0; i < LibraryList.Count; i++)
                    {
                        if (LibraryList[i].Id == SelectedBook.Id)
                        {
                            LibraryList[i].Title = result.Title;
                            LibraryList[i].Author = result.Author;
                            LibraryList[i].YearPublic = result.YearPublic;
                            LibraryList[i].NumOfInvent = result.NumOfInvent;
                        }
                    }
                }
            }
        }

        public Command DeleteCommand { get; }

        private bool CanDelete()
        {
            return SelectedBook != null;
        }

        private void DeleteCommandMethod()
        {
            if (SelectedBook != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить эту книгу?", "Подтвердите безвозвратное удаление книги", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    LibraryList.Remove(SelectedBook);
                }
            }

        }

       
        public Command SaveCommand { get; }

        private bool CanSave()
        {
            return true;
        }

        private void SaveCommandMethod()

        {
             try
            {
                fileIOService.SaveData(LibraryList);
                MessageBox.Show("Сохранено в файл", "Сохранение данных",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        #endregion
    }
}