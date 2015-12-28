using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace TimerApp_Tutorial.ViewModels
{
    public class TimerPresenter : BindableBase
    {
        // PROPERTIES
        // UI CAN ONLY READ
        private string displayTime;

        public string DisplayTime
        {
            get { return displayTime; }
            set
            {
                displayTime = value;
                RaisePropertyChanged("DisplayTime");
            }
        }

        private string selectedTime;

        public string SelectedTime
        {
            get { return selectedTime; }
            set
            {
                selectedTime = value;
                bool success = TimeSpan.TryParse(selectedTime, out totalCountdownTime);
            }
        }

        // totalCountdownTime is what sets how long the timer will run for
        TimeSpan totalCountdownTime;

        public bool IsRunning { get; set; } = false;

        // The timer which ticks and calls the UpdateDisplayTime method
        DispatcherTimer mainTimer;

        // Create time variables used during countdown
        DateTime startingTime;
        TimeSpan remainingTime;

        public TimerPresenter()
        {
            mainTimer = new DispatcherTimer();
            mainTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            mainTimer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, object e)
        {

            TimeSpan elapsedTime = (DateTime.Now - startingTime);

            if (elapsedTime < totalCountdownTime)
            {
                UpdateDisplayTime(elapsedTime);
            }
            else
            {
                DisplayTime = TimeSpan.FromSeconds(0).ToString();
                IsRunning = false;
                mainTimer.Stop();
            }
        }

        private void UpdateDisplayTime(TimeSpan elapsedTime)
        {
            // Calculate the decreasing gap between the totalCountdownTIme and ElpasedTime
            remainingTime = totalCountdownTime - elapsedTime;
            // Show only the appropriate level of detail on the timer, by trimming the last few characters
            DisplayTime = remainingTime.ToString().Substring(0, 11);
        }

        public void StartTimer(DateTime startTime)
        {
            this.startingTime = startTime;
            IsRunning = true;
            mainTimer.Start();
        }

        public void ResetTimer()
        {
            IsRunning = false;
            mainTimer.Stop();
            DisplayTime = null;
            SelectedTime = null;
            DisplayTime = "";
        }
    }
}
