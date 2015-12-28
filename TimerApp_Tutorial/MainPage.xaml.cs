using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TimerApp_Tutorial.Views;
using TimerApp_Tutorial.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TimerApp_Tutorial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        TimerPresenter currentContext;

        public MainPage()
        {
            this.InitializeComponent();
            // Cache this page
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

            // Instantiate Data Context
            currentContext = new TimerPresenter();

            // Navigate to Home on Initialize
            frmMainFrame.Navigate(typeof(Home), currentContext);
        }

        private void Timer_Click(object sender, RoutedEventArgs e)
        {
            frmMainFrame.Navigate(typeof(Timer), currentContext);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            frmMainFrame.Navigate(typeof(Home), currentContext);
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            frmMainFrame.Navigate(typeof(About), currentContext);
        }
    }
}
