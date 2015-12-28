using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TimerApp_Tutorial.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TimerApp_Tutorial.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Timer : Page
    {
        public TimerPresenter CurrentContext
        {
            get { return this.DataContext as TimerPresenter; }
            set { this.DataContext = value; }
        }

        public Timer()
        {
            this.InitializeComponent();
            // Cache this page
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        // When you navigate to this page, set the Current Context
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.CurrentContext = e.Parameter as TimerPresenter;
        }

        private void btnResetTimer_Click(object sender, RoutedEventArgs e)
        {
            CurrentContext.ResetTimer();
            this.Frame.Navigate(typeof(Home), CurrentContext);
        }
    }
}
