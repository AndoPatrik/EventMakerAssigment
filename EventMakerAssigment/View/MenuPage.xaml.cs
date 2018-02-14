using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace EventMakerAssigment.View
{
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            this.InitializeComponent();
            //AddBtn.Background = new SolidColorBrush(Colors.Orange);
            //FindBtn.Background = new SolidColorBrush(Colors.Orange);
            LogOutBtn.BorderBrush = new SolidColorBrush(Colors.Orange);
            LogOutBtn.Background = new SolidColorBrush(Colors.DarkOrange);
            WelcomeText.Foreground = new SolidColorBrush(Colors.Orange);
            
        }

        private void AddBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EventPage));
        }

        private void FindBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateEventPage));
        }

        private void LogOutBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Ellipse_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("SearchEllipse", SearchEllipse);
            Frame.Navigate(typeof(EventPage));
        }

        private void Ellipse_PointerPressed_1(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("CreateEllipse", CreateEllipse);
            Frame.Navigate(typeof(CreateEventPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ConnectedAnimation imageAnimation =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("MainStackPanel");
            ConnectedAnimation imageAnimation1 =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("ListStackPanel");
            if (imageAnimation != null)
            {
                imageAnimation.TryStart(CreateEllipse);
                
            }

            if (imageAnimation1 != null)
            {
                imageAnimation1.TryStart(SearchEllipse);
            }
        }

    }
}
