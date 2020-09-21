using LibraryTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryTest
{
    /// <summary>
    /// Interaction logic for WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        private BindingList<RegistryBook> libraryList;
        public WindowAdd()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            libraryList.Add(new RegistryBook() { Author = "John Doe" });
            libraryList.Add(new RegistryBook() { Author = "Jane Lee" });

            //   textAuthor.ItemsSource = libraryList;
            libraryList = new BindingList<RegistryBook>()
            {
                new RegistryBook(){Title="test"},
                new RegistryBook(){Title="asd"},
                new RegistryBook(){Title="Карманный справочник 8.0", Author = "Джозеф Албахари, Бен Албахари", YearPublic = 2020}
            };
        }
    }
}
