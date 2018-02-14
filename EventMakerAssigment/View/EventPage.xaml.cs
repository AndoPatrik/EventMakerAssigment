using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace EventMakerAssigment.View
{
    public sealed partial class EventPage : Page
    {
        public EventPage()
        {
            this.InitializeComponent();
            DeleteBtn.Background = new SolidColorBrush(Colors.DarkOrange);
            BackBtn.Background = new SolidColorBrush(Colors.DarkOrange);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ConnectedAnimation imageAnimation =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("SearchEllipse");
            if (imageAnimation != null)
            {
                imageAnimation.TryStart(ListStackPanel);
            }
        }

        private void BackBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("ListStackPanel", ListStackPanel);

        }
    }
}
