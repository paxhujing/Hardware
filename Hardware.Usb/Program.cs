using System;
using System.IO;
using System.Linq;
using Usb;
using Usb.Datas;

namespace Hardware.Usb
{
    class Program
    {

        static void Main(string[] args)
        {
            DriveInfo[] dis = DriveInfo.GetDrives();
            TestA();
            Console.ReadKey();
        }

        static void TestB()
        {
        }

        static void TestA()
        {
            String driverKeyName;
            String rootHubPath;
            Console.WriteLine("==============Host Controller====================");
            foreach (HostControllerInfo hostController in UsbDevice.AllHostControllers)
            {
                driverKeyName = UsbDevice.GetHcdDriverKeyName(hostController.PNPDeviceId);
                rootHubPath = UsbDevice.GetUsbRootHubPath(hostController.PNPDeviceId);
                Console.WriteLine(String.Join("\r\n\t", hostController.PNPDeviceId,
                    hostController.Name, driverKeyName, rootHubPath));
            }
            Console.WriteLine("==============Root Hub====================");
            foreach (UsbHubInfo usbHub in UsbDevice.AllUsbHubs)
            {
                Console.WriteLine(String.Join("\r\n\t", usbHub.PNPDeviceId, usbHub.Name, usbHub.Status));
            }
        }
    }
}
