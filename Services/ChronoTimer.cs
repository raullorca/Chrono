using Services.Interfaces;
using System;
using System.Windows.Threading;

namespace Services
{
    public class ChronoTimer : DispatcherTimer, IChronoTimer
    {
        private ChronoTimer()
        {
            InitializeCurrentSecond();
        }

        public int CurrentSecond { private get; set; }

        public string Value
        {
            get
            {
                CurrentSecond = RemoveIncrementDay(CurrentSecond);
                return TimeSpan.FromSeconds(CurrentSecond).ToString();
            }
        }

        public static ChronoTimer Create(EventHandler eventHandler)
        {
            const int secondsInterval = 1;
            var chrono = new ChronoTimer();

            chrono.Interval = TimeSpan.FromSeconds(secondsInterval);
            chrono.Tick += eventHandler;

            return chrono;
        }

        public void AddSecond()
        {
            CurrentSecond++;
        }

        public void InitializeCurrentSecond(int seconds)
        {
            CurrentSecond = seconds;
        }

        public void Pause()
        {
            base.Stop();
        }

        public new void Start()
        {
            base.Start();
        }

        public new void Stop()
        {
            base.Stop();
            InitializeCurrentSecond();
        }

        private static int RemoveIncrementDay(int seconds)
        {
            const int secondsDay = 86400; // 60s*60m*24h
            return seconds >= secondsDay ? seconds - secondsDay : seconds;
        }

        private void InitializeCurrentSecond()
        {
            InitializeCurrentSecond(0);
        }
    }
}