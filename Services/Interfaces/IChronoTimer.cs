namespace Services.Interfaces
{
    public interface IChronoTimer
    {
        string Value { get; }

        void Start();

        void Pause();

        void Stop();

        void AddSecond();

        void InitializeCurrentSecond(int seconds);
    }
}