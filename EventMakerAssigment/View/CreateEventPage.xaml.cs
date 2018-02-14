using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace EventMakerAssigment.View
{
    public sealed partial class CreateEventPage : Page
    {
        public CreateEventPage()
        {
            this.InitializeComponent();
            BackBtn.Background = new SolidColorBrush(Colors.DarkOrange);
            CreateBtn.Background = new SolidColorBrush(Colors.DarkOrange);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("MainStackPanel", MainStackPanel);
            Frame.Navigate(typeof(MenuPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ConnectedAnimation imageAnimation =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("CreateEllipse");
            if (imageAnimation != null)
            {
                imageAnimation.TryStart(MainStackPanel);
            }
        }
    }
}
