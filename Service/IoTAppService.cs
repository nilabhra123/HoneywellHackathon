using HoneywellHackathon.Models;
using HoneywellHackathon.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoneywellHackathon.Service
{
    public class IoTAppService : IIoTAppService
    {
        private readonly IDeviceAndFilterRepository _deviceFilterRepo;

        public IoTAppService(DeviceAndFilterRepository deviceAndFilterRepository)
        {
            this._deviceFilterRepo = deviceAndFilterRepository;
        }

        public IEnumerable<Device> GetAllDevices()
        {
            var devices = this._deviceFilterRepo.GetAllDeviceData();
            return devices;
        }

        public void SendDataByDevice(int deviceId, int dataId)
        {
            var deviceData = new DeviceData() { DataId = dataId, DeviceId = deviceId}
            this._deviceFilterRepo.AddDeviceData(deviceData);
        }

        public void AddNewFilter(Filter filter)
        {
            this._deviceFilterRepo.AddFilter(filter);
        }

        public string ApplyFilterOnDevice(int deviceId, int filterId)
        {
            var device = new Device();
            var filter = new Filter();
            var returnVal = string.Empty;
            try
            {
                device = this._deviceFilterRepo.GetDeviceById(deviceId);
                filter = this._deviceFilterRepo.GetFilterById(filterId);
                if(device != null && filter != null)
                {
                    this._deviceFilterRepo.ApplyFilterOnDevice(device, filter);
                    returnVal = "Filter Applied Successfully";
                }
            }

            catch(Exception ex)
            {
                returnVal = $"Filter couldn't apply{ex.Message}";
            }

            return returnVal;
        }

        public string GetDataByDevice(int deviceId)
        {
            var device = this._deviceFilterRepo.GetDeviceById(deviceId);
            return device.Data;
        }
    }
}