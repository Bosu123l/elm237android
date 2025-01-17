using Android.Bluetooth;
using OBDProject.Utils;
using System;
using System.Linq;
using System.Text;

namespace OBDProject.Commands
{
    public class VehicleSpeedCommand : BasicCommand
    {
        public VehicleSpeedCommand(BluetoothSocket socket, object readFromDeviceLock, int position, LogManager logManager) : base(Encoding.ASCII.GetBytes("01 0D\r"), socket, "km/h", readFromDeviceLock, position, logManager)
        {
            //01	Show current data
            //0D	1	Vehicle speed	0	255	km/h    A
            Source = "Vehicle Speed";
        }

        protected override void PrepereFindResult()
        {
            string value = NoData;
            if (base.ReadedData.Any())
            {
                value = base.ReadedData[2].ToString();
            }

            OnResponse(string.Format("{0}{1}{2} {3}", Source, Environment.NewLine, value, base.Unit));
        }
    }
}