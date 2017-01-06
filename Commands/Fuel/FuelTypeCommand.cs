﻿using Android.Bluetooth;
using OBDProject.Utils;
using System.Linq;
using System.Text;

namespace OBDProject.Commands
{
    public class FuelTypeCommand : BasicCommand
    {
        public FuelTypeCommand(BluetoothSocket socket, object readFromDeviceLock) : base(Encoding.ASCII.GetBytes("01 51\r"), socket, " ", readFromDeviceLock)
        {
            Source = "FuelTypeCommand";
        }

        protected override void PrepereFindResult()
        {
            if (base.ReadedData.Any())
            {
                var value = (FuelType)base.ReadedData[2];
                OnResponse(string.Format("{0} {1} {2}", Source, value, base.Unit));
            }
        }
    }
}