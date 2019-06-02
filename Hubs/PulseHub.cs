using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;
using PulseStream.Service;
using System.Reactive.Subjects;
using PulseStream.Helper;
using PulseStream.Model;

namespace PulseStream.Hubs
{
    public class PulseHub : Hub
    {

        DataStreamerService dataStreamerService;
        public PulseHub(DataStreamerService _dataStreamerService)
        {
            this.dataStreamerService = _dataStreamerService;
        }
        public ChannelReader<PulseData> StreamPulse()
        {
            return dataStreamerService.StreamPulse().AsChannelReader(10);
        }
        public void StartPulse()
        {
            dataStreamerService.StartPulse();
        }
    }
}
