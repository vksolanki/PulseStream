using PulseStream.Model;
using System;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace PulseStream.Service
{
    public class DataStreamerService
    {
        //private readonly Subject<string> _subject = new Subject<string>();
        private readonly Subject<PulseData> _subject = new Subject<PulseData>();
        public DataStreamerService()
        {

        }

        public IObservable<PulseData> StreamPulse()
        {
            return _subject;
        }

        Timer _timer;
        bool _PulseStarted;
        static readonly object _object = new object();
        public void StartPulse()
        {
            lock (_object)
            {
                if (!_PulseStarted)
                {
                    _timer = new Timer(CheckPulse, null, 0, 500);
                    _PulseStarted = true;
                }
            }
        }

        private void CheckPulse(object state)
        {
            Random random = new Random();
            var newpulse = random.Next(100);
            var pulseData = new PulseData() { PulseType = "LiveUser", Value = newpulse };
            _subject.OnNext(pulseData);

        }
    }
}