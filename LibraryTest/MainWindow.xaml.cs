using LibraryTest.Models;
using LibraryTest.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;


namespace LibraryTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\libraryList.json"; // путь директории по умолчанию где .exe
        private readonly ObservableCollection<RegistryBook> libraryList;
        private FileIOService fileIOService;


        public MainWindow()
        {
            InitializeComponent();

            fileIOService = new FileIOService(PATH);
            try
            {
                libraryList = fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (libraryList == null)
            {
                libraryList = new ObservableCollection<RegistryBook>();
            }

            dtGridList.ItemsSource = libraryList;
        }


        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd windowAdd = new WindowAdd
            {
                DataContext = new RegistryBook()
            };
            var showDialog = windowAdd.ShowDialog();
            if (showDialog != null && showDialog.Value)
            {
                var result = windowAdd.DataContext;
                libraryList.Add((RegistryBook)result);
            }
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dtGridList.SelectedItem == null)
            {
                MessageBox.Show("Требуется выбрать строку для редактирования", "Ошибка при редактировании",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                WindowEdit windowEdit = new WindowEdit();
                var book = (RegistryBook)dtGridList.SelectedItem;
                windowEdit.DataContext = new RegistryBook
                {
                    Title = book.Title,
                    Author = book.Author,
                    YearPublic = book.YearPublic,
                    NumOfInvent = book.NumOfInvent
                };
                var result = windowEdit.DataContext as RegistryBook;
                if (windowEdit.ShowDialog() ?? false)
                {
                    for (int i = 0; i < libraryList.Count; i++)
                    {
                        if (libraryList[i].Id == book.Id)
                        {
                            libraryList[i].Title = result.Title;
                            libraryList[i].Author = result.Author;
                            libraryList[i].YearPublic = result.YearPublic;
                            libraryList[i].NumOfInvent = result.NumOfInvent;
                        }
                    }
                }
            }            
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dtGridList.SelectedItem == null)
            {
                MessageBox.Show("Требуется выбрать строку для удаления", "Ошибка при удалении",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                libraryList.Remove(dtGridList.SelectedItem as RegistryBook);
            }
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            fileIOService = new FileIOService(PATH);
            try
            {
                fileIOService.SaveData(libraryList);
                MessageBox.Show("Сохранено в файл", "Сохранение данных",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //       this.Close();

            }
        }
    }
}
