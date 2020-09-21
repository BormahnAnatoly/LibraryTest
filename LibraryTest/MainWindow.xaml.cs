using LibraryTest.Models;
using LibraryTest.Services;
using System;
using System.ComponentModel;
using System.Windows;


namespace LibraryTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\libraryList.json"; // путь директории по умолчанию где .exe
        private BindingList<RegistryBook> libraryList;
        private FileIOService fileIOService;

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileIOService = new FileIOService(PATH);
            libraryList = new BindingList<RegistryBook>()
            {
                new RegistryBook(){Title="test"},
                new RegistryBook(){Title="asd"},
                new RegistryBook(){Title="Карманный справочник 8.0", Author = "Джозеф Албахари, Бен Албахари", YearPublic = 2020}
            };

            try
            {
                libraryList = fileIOService.LoadData();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
         //       this.Close();
            }
            

            dtGridList.ItemsSource = libraryList;
            libraryList.ListChanged += LibraryList_ListChanged;
        }

        private void LibraryList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                try
                {
                    fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //       this.Close();
                }
            }
        }


        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd windowAdd = new WindowAdd();
            windowAdd.Show();
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowEdit windowEdit = new WindowEdit();
            windowEdit.Show();
        }

        private void bDelite_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
