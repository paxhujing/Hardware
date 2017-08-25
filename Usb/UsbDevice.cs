using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Usb.Datas;
using Usb.Primitives;

namespace Usb
{
    public class UsbDevice
    {
        #region Fields

        #endregion

        #region Properties

        /// <summary>
        /// 获取所有主机控制器。
        /// </summary>
        public static IEnumerable<HostControllerInfo> AllHostControllers
        {
            get
            {
                ManagementObjectCollection moc = new ManagementObjectSearcher("SELECT * FROM Win32_USBController").Get();
                if (moc == null) return new HostControllerInfo[0];
                return moc.Cast<ManagementObject>().Select(x => new HostControllerInfo
                {
                    PNPDeviceId = x["PNPDeviceID"] as String,
                    Name = x["Name"] as String
                });
            }
        }

        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// 获取主机控制器驱动键名。
        /// </summary>
        /// <param name="pnpDeriverId">USB主机控制器设备ID。</param>
        /// <returns></returns>
        public static String GetHcdDriverKeyName(String pnpDeriverId)
        {
            if (String.IsNullOrWhiteSpace(pnpDeriverId)) return null;
            IntPtr hcdPtr = Win32Api.CreateFile($@"\\.\{pnpDeriverId.Replace('\\', '#')}#{{3ABF6F2D-71C4-462A-8A92-1E6861E6AF27}}",
                NativeFileAccess.GENERIC_WRITE,
                NativeFileShare.FILE_SHARE_WRITE,
                IntPtr.Zero,
                NativeFileMode.OPEN_EXISTING,
                IntPtr.Zero,
                IntPtr.Zero);
            if (hcdPtr == Win32Api.INVALID_HANDLE_VALUE) return null;

            Int32 bytesReturned;
            UsbHcdDriverKeyName buffer = new UsbHcdDriverKeyName();
            Boolean status = Win32Api.DeviceIoControl(hcdPtr,
                Win32Api.IOCTL_GET_HCD_DRIVERKEY_NAME,
                IntPtr.Zero,
                0,
                ref buffer,
                Marshal.SizeOf(buffer),
                out bytesReturned,
                IntPtr.Zero);
            Win32Api.CloseHandle(hcdPtr);
            return status ? buffer.Name : null;
        }

        #endregion

        #endregion
    }
}
