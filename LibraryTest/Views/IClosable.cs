namespace LibraryTest.Views
{
    public interface IClosable
    {
        bool? DialogResult { get; set; }

        void Close();
    }
}
