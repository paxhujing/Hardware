using System;
using Usb;
using Usb.Datas;

namespace Hardware.Usb
{
    class Program
    {
        static void Main(string[] args)
        {
            String driverKeyName;
            foreach (HostControllerInfo hostController in UsbDevice.AllHostControllers)
            {
                driverKeyName = UsbDevice.GetHcdDriverKeyName(hostController.PNPDeviceId);
                Console.WriteLine($"{hostController.Name}--{hostController.PNPDeviceId}--{driverKeyName}");
            }
            Console.ReadKey();
        }
    }
}
