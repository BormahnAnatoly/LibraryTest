using System.Windows;

namespace LibraryTest
{
    /// <summary>
    /// Interaction logic for WindowEdit.xaml
    /// </summary>
    public partial class WindowEdit : Window
    {
        public WindowEdit()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
