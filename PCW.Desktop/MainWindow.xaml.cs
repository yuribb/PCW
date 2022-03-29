using System.Windows;

namespace PCW.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello world");
        }

        private void ComboBoxTags_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ButtonTags_Click(object sender, RoutedEventArgs e)
        {
            var tagsWindow = new TagsWindow();
            tagsWindow.Show();
        }

        private void ButtonAddPostCard_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
