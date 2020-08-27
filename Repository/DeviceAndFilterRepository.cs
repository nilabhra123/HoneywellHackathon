using HoneywellHackathon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoneywellHackathon.Repository
{
    public class DeviceAndFilterRepository : IDeviceAndFilterRepository
    {
        private static List<Device> DeviceList = new List<Device>()
        {
            new Device() { Id = 1, Name = "Dev1", Filter = new Filter()},
            new Device() { Id = 2, Name = "Dev2", Filter = new Filter()},
            new Device() { Id = 3, Name = "Dev3", Filter = new Filter()},
            new Device() { Id = 4, Name = "Dev4", Filter = new Filter()},
        };

        private static List<DeviceData> DeviceDataList = new List<DeviceData>()
        {
            new DeviceData() { DeviceId = 1, DataId = 1},
            new DeviceData() { DeviceId = 2, DataId = 2},
            new DeviceData() { DeviceId = 3, DataId = 3},
            new DeviceData() { DeviceId = 4, DataId = 4}
        };

        public static List<Filter> FilterList = new List<Filter>()
        {
            new Filter() { Id = 1, FilterCondition = FilterConditionEnum.GreaterThan, Offset = 0}
        };

        public DeviceAndFilterRepository()
        {
            
        }

        public IEnumerable<Device> GetAllDeviceData()
        {
            foreach (var device in DeviceList)
            {
                var deviceDataFiltered = DeviceDataList.Where(a => a.DeviceId == device.Id).ToList();

                if (device.Filter.FilterCondition == FilterConditionEnum.GreaterThan)
                    deviceDataFiltered = deviceDataFiltered.Where(a => a.DataId > device.Filter.Offset).ToList();
                else
                    deviceDataFiltered = deviceDataFiltered.Where(a => a.DataId < device.Filter.Offset).ToList();

                var deviceDataItems = deviceDataFiltered.Select(a => a.DataId).ToList();
                device.Data = deviceDataItems.Count > 0 ? string.Join(",", deviceDataItems) : string.Empty;
            }
            return DeviceList;
        }

        public void AddDeviceData(DeviceData deviceData)
        {
            DeviceDataList.Add(deviceData);
        }

        public void AddFilter(Filter filter)
        {
            FilterList.Add(filter);
        }

        public void ApplyFilterOnDevice(Device device, Filter filter)
        {
            var index = DeviceList.IndexOf(device);
            DeviceList[index].Filter = filter;
        }

        public string GetDeviceDataById(int deviceId)
        {
            var data = this.GetAllDeviceData().FirstOrDefault(a => a.Id == deviceId).Data;
            return data;
        }

    }
}