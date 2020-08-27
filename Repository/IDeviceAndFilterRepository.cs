using HoneywellHackathon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneywellHackathon.Repository
{
    interface IDeviceAndFilterRepository
    {
        IEnumerable<Device> GetAllDeviceData();
        void AddDeviceData(DeviceData deviceData);
        void AddFilter(Filter filter);
        void ApplyFilterOnDevice(Device device, Filter filter);
        string GetDeviceDataById(int deviceId);
    }
}
