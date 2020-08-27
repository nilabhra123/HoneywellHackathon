using HoneywellHackathon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneywellHackathon.Service
{
    interface IIoTAppService
    {
        IEnumerable<Device> GetAllDevices();
        void SendDataByDevice(int deviceId, int dataId);
        void AddNewFilter(Filter filter);
        string ApplyFilterOnDevice(int deviceId, int filterId);
        string GetDataByDevice(int deviceId);
    }
}
