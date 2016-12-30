using Android.Bluetooth;
using System.Linq;
using System.Text;

namespace OBDProject.Commands
{
    public class VehicleSpeedCommand : BasicCommand
    {
        public VehicleSpeedCommand(BluetoothSocket socket, object readFromDeviceLock) : base(Encoding.ASCII.GetBytes("01 0D\r"), socket, "km/h", readFromDeviceLock)
        {
            //01	Show current data
            //0D	1	Vehicle speed	0	255	km/h    A
            Source = "VehicleSpeedCommand";
        }

        protected override void PrepereFindResult()
        {
            if (base.readedData.Any())
            {
                OnResponse(string.Format("{0} {1} {2}", Source, base.readedData[2], Unit));
            }
        }
    }
}