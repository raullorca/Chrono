using Services;
using Services.Interfaces;
using System;
using System.Windows;

namespace Chrono
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        IChronoTimer chrono;
        public MainWindow()
        {
            InitializeComponent();
            chrono = ChronoTimer.Create(RefreshContentEvent);
        }

        private void RefreshContentEvent(object sender, EventArgs e)
        {
            chrono.AddSecond();
            TimeLabel.Content = chrono.Value;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            chrono.Start();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            chrono.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            chrono.Stop();
        }
    }
}
