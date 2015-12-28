using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TimerApp_Tutorial.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TimerApp_Tutorial.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
        }

        TimerPresenter CurrentContext
        {
            get { return this.DataContext as TimerPresenter; }
            set { this.DataContext = value; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.CurrentContext = e.Parameter as TimerPresenter;
        }

        private void btnStartTimer_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentContext.SelectedTime != null)
            {
                CurrentContext.StartTimer(DateTime.Now);
                this.Frame.Navigate(typeof(Timer), CurrentContext);
            } 
        }

        private void cbxSelectedTimeSpan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxSelectedTimeSpan.SelectedValue != null)
            {
                ComboBoxItem selectedTimeItem = (ComboBoxItem)cbxSelectedTimeSpan.SelectedValue;
                CurrentContext.SelectedTime = selectedTimeItem.Content.ToString();
            }
        }
    }
}
