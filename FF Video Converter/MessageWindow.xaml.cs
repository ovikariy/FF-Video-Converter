using System.Windows;

namespace FFVideoConverter
{
    public partial class MessageWindow : Window
    {
        private string title = "Message";
        private string subTitle = "Details";
        private string message = "Oh hey there";

        public MessageWindow(string title, string subTitle, string message)
        {
            InitializeComponent();

            this.title = title;
            this.subTitle = subTitle;
            this.message = message;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            labelTitle.Content = this.title;
            textBoxSubtitle.Content = this.subTitle;
            gridSubtitle.Visibility = string.IsNullOrEmpty(this.subTitle) ? Visibility.Hidden : Visibility.Visible;
            textBoxMessage.AppendText(this.message);
            textBoxMessage.ScrollToEnd();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}