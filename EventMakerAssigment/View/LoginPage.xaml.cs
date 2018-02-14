using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Text.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using EventMakerAssigment.View;

namespace EventMakerAssigment
{
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();            

            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            SearchText.Foreground = new SolidColorBrush(Colors.Orange);
            CreateText.Foreground = new SolidColorBrush(Colors.Orange);
            OrText.Foreground = new SolidColorBrush(Colors.White);
            YourText.Foreground = new SolidColorBrush(Colors.White);
            EventText.Foreground = new SolidColorBrush(Colors.White);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage));
        }
    }
}
