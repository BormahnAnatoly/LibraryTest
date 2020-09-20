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
        private BindingList<RegistryBook> libraryList;
        private FileIOService fileIOService;
        private readonly string PATH = $"{Environment.CurrentDirectory}"; // путь директории по умолчанию где .exe
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {

            WindowAdd windowAdd = new WindowAdd();
            windowAdd.Show();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            WindowEdit windowEdit = new WindowEdit();
            windowEdit.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            libraryList = new BindingList<RegistryBook>()
            {
                new RegistryBook(){Title="test"},
                new RegistryBook(){Title="asd"},
                new RegistryBook(){Title="Карманный справочник 8.0", Author = "Джозеф Албахари, Бен Албахари", YearPublic = 2020}
            };

            dtGridList.ItemsSource = libraryList;
            libraryList.ListChanged += LibraryList_ListChanged;
        }

        private void LibraryList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemDeleted)
        }
            
        {
            
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
