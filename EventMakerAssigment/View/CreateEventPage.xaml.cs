using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace EventMakerAssigment.View
{
    public sealed partial class CreateEventPage : Page
    {
        public CreateEventPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EventPage));
        }
    }
}
