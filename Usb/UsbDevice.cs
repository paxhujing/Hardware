using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Usb.Commands;
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
                return SelectManagementObject<HostControllerInfo>("SELECT * FROM Win32_USBController", (mo) =>
                {
                    return new HostControllerInfo
                    {
                        PNPDeviceId = mo["PNPDeviceID"] as String,
                        Name = mo["Name"] as String,
                    };
                });
            }
        }

        /// <summary>
        /// 获取所有的USB集线器。
        /// </summary>
        public static IEnumerable<UsbHubInfo> AllUsbHubs
        {
            get
            {
                return SelectManagementObject<UsbHubInfo>("SELECT * FROM Win32_USBHub", (mo) =>
                 {
                     return new UsbHubInfo
                     {
                         PNPDeviceId = mo["PNPDeviceID"] as String,
                         Name = mo["Name"] as String,
                         Status = mo["Status"] as String
                     };
                 });
            }
        }

        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// 获取主机控制器驱动键名。
        /// </summary>
        /// <param name="pnpDeviceId">USB主机控制器设备ID。</param>
        /// <returns></returns>
        public static String GetHcdDriverKeyName(String pnpDeviceId)
        {
            return QueryHcdProperty(pnpDeviceId, Win32Api.IOCTL_GET_HCD_DRIVERKEY_NAME);
        }

        /// <summary>
        /// 获取USB根集线器路径。
        /// </summary>
        /// <param name="pnpDeviceId">USB主控制器设备ID。</param>
        /// <returns>USB根集线器路径。</returns>
        public static String GetUsbRootHubPath(String pnpDeviceId)
        {
            return QueryHcdProperty(pnpDeviceId, Win32Api.IOCTL_USB_GET_ROOT_HUB_NAME);
        }

        /// <summary>
        /// 获取USB集线器名称。
        /// </summary>
        /// <param name="usbHubPath">USB集线器路径。</param>
        /// <returns>名称。</returns>
        public static String GetUsbHubName(String usbHubPath)
        {
            if (String.IsNullOrWhiteSpace(usbHubPath)) return null;
            //从路径中提取设备ID
            String deviceId = GetDeviceIdFromPath(usbHubPath);
            try
            {
                return SelectManagementObject<String>($"SELECT * FROM Win32_USBHub WHERE DeviceID LIKE '{deviceId}'",
                    (mo) => mo["Name"] as String).FirstOrDefault();
            }
            catch (ManagementException)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取USB集线器节点信息。
        /// </summary>
        /// <param name="usbHubPath">USB集线器路径。</param>
        /// <returns>USB集线器节点信息。</returns>
        public static Datas.UsbNodeInformation GetUsbHubNodeInformation(String usbHubPath)
        {
            if (String.IsNullOrWhiteSpace(usbHubPath)) return null;
            IntPtr hcdPtr = Win32Api.CreateFile($@"\\.\{usbHubPath}",
                NativeFileAccess.GENERIC_WRITE,
                NativeFileShare.FILE_SHARE_WRITE,
                IntPtr.Zero,
                NativeFileMode.OPEN_EXISTING,
                IntPtr.Zero,
                IntPtr.Zero);
            if (hcdPtr == Win32Api.INVALID_HANDLE_VALUE) return null;

            Int32 bytesReturned;
            Primitives.UsbNodeInformation buffer = new Primitives.UsbNodeInformation();
            Boolean status = Win32Api.DeviceIoControl(hcdPtr,
                Win32Api.IOCTL_USB_GET_NODE_INFORMATION,
                ref buffer,
                Marshal.SizeOf(buffer),
                ref buffer,
                Marshal.SizeOf(buffer),
                out bytesReturned,
                IntPtr.Zero);
            Win32Api.CloseHandle(hcdPtr);
            if (!status) return null;
            Datas.UsbNodeInformation nodeInfo = new Datas.UsbNodeInformation
            {
                NodeType = buffer.NodeType,
                PNPDeviceId = GetDeviceIdFromPath(usbHubPath),
                DevicePath = usbHubPath,
                Name = GetUsbHubName(usbHubPath),
            };
            if (nodeInfo.NodeType == UsbHubNode.UsbHub)
            {
                nodeInfo.NumberOfPorts = buffer.U.HubInformation.HubDescriptor.NumberOfPorts;
                nodeInfo.HubCharateristics = buffer.U.HubInformation.HubDescriptor.HubCharacteristics;
                nodeInfo.PowerOnToPowerGood = buffer.U.HubInformation.HubDescriptor.PowerOnToPowerGood;
                nodeInfo.HubControlCurrent = buffer.U.HubInformation.HubDescriptor.HubControlCurrent;
                nodeInfo.HubIsBusPowered = buffer.U.HubInformation.HubIsBusPowered;
            }
            else
            {
                nodeInfo.NumberOfInterfaces = buffer.U.MiParentInformation.NumberOfInterfaces;
            }
            return nodeInfo;
        }

        //public static IEnumerable<Datas.UsbNodeConnectionInformation> GetUsbNodeConnectionInformation(String devicePath,Int32 numberOfPorts)
        //{
        //    if (String.IsNullOrWhiteSpace(devicePath)) return null;
        //    IntPtr hcdPtr = Win32Api.CreateFile($@"\\.\{devicePath}",
        //        NativeFileAccess.GENERIC_WRITE,
        //        NativeFileShare.FILE_SHARE_WRITE,
        //        IntPtr.Zero,
        //        NativeFileMode.OPEN_EXISTING,
        //        IntPtr.Zero,
        //        IntPtr.Zero);
        //    if (hcdPtr == Win32Api.INVALID_HANDLE_VALUE) return null;
        //    Datas.UsbNodeConnectionInformation[] connections = new Datas.UsbNodeConnectionInformation[numberOfPorts];
        //    Boolean status;
        //    UsbNodeConnectionInformationEx buffer = new UsbNodeConnectionInformationEx();
        //    for (Int32 i = 1; i <= numberOfPorts; i++)
        //    {
        //        status = Win32Api.DeviceIoControl(hcdPtr,
        //            Win32Api.IOCTL_USB_GET_NODE_CONNECTION_INFORMATION_EX,
        //            ref buffer,
        //            Marshal.SizeOf(buffer),
        //            ref buffer,
        //            Marshal.SizeOf(buffer),
        //            out int bytesReturned,
        //            IntPtr.Zero);
        //        if (status)
        //        {
        //            Datas.UsbNodeConnectionInformation connection = new Datas.UsbNodeConnectionInformation
        //            {
        //                DevicePath = devicePath,
        //                ConnectionIndex = buffer.ConnectionIndex,
        //                ConnectionStatus = bucffer.ConnectionStatus,
        //            };
        //        }
        //    }
        //}

        #region Descriptors

        /// <summary>
        /// 获取字符串描述符。
        /// </summary>
        /// <param name="hubDevice"></param>
        /// <param name="connectionIndex"></param>
        /// <param name="descriptorIndex"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        public static String GetStringDescriptor(IntPtr hubDevice, Int32 connectionIndex, Byte descriptorIndex, UInt16 languageId)
        {
            UsbDescriptorRequest buffer = new UsbDescriptorRequest();
            buffer.ConnectionIndex = connectionIndex;
            buffer.SetupPacket.Value = (UInt16)((Globals.USB_STRING_DESCRIPTOR_TYPE << 8) | descriptorIndex);
            buffer.SetupPacket.Length = Globals.MAXIMUM_USB_STRING_LENGTH;
            Boolean status = Win32Api.DeviceIoControl(hubDevice,
                Win32Api.IOCTL_USB_GET_DESCRIPTOR_FROM_NODE_CONNECTION,
                ref buffer,
                Marshal.SizeOf(buffer),
                ref buffer,
                Marshal.SizeOf(buffer),
                out Int32 bytesReturned,
                IntPtr.Zero);
            return status ? buffer.Data.String : null;
        }

        #endregion

        #endregion

        #region Private

        /// <summary>
        /// 查询USB主控制器的属性。
        /// </summary>
        /// <param name="pnpDeviceId">USB主控制器设备ID。</param>
        /// <param name="value">一个int类型的常量，用于标识要查询的属性。</param>
        /// <returns>查询结果。</returns>
        private static String QueryHcdProperty(String pnpDeviceId,Int32 value)
        {
            if (String.IsNullOrWhiteSpace(pnpDeviceId)) return null;
            IntPtr hcdPtr = Win32Api.CreateFile($@"\\.\{pnpDeviceId.Replace('\\', '#')}#{{3ABF6F2D-71C4-462A-8A92-1E6861E6AF27}}",
                NativeFileAccess.GENERIC_WRITE,
                NativeFileShare.FILE_SHARE_WRITE,
                IntPtr.Zero,
                NativeFileMode.OPEN_EXISTING,
                IntPtr.Zero,
                IntPtr.Zero);
            if (hcdPtr == Win32Api.INVALID_HANDLE_VALUE) return null;

            Int32 bytesReturned;
            UsbStringBuffer buffer = new UsbStringBuffer();
            Boolean status = Win32Api.DeviceIoControl(hcdPtr,
                value,
                IntPtr.Zero,
                0,
                ref buffer,
                Marshal.SizeOf(buffer),
                out bytesReturned,
                IntPtr.Zero);
            Win32Api.CloseHandle(hcdPtr);
            return status ? buffer.Value : null;
        }

        /// <summary>
        /// 使用 ManagementObjectSearcher 查询管理器调用WMI查询。
        /// </summary>
        /// <typeparam name="T">结果类型。</typeparam>
        /// <param name="sql">查询语句。</param>
        /// <param name="callback">回调方法。</param>
        /// <returns>查询结果。</returns>
        private static IEnumerable<T> SelectManagementObject<T>(String sql, Func<ManagementObject, T> callback)
        {
            ManagementObjectCollection moc = new ManagementObjectSearcher(sql).Get();
            if (moc == null) return new T[0];
            return moc.Cast<ManagementObject>().Select(x => callback(x));
        }

        /// <summary>
        /// 从设备路径中获取设备ID。
        /// </summary>
        /// <param name="devicePath">设备路径。</param>
        /// <returns>设备ID。</returns>
        private static String GetDeviceIdFromPath(String devicePath)
        {
            return devicePath.Substring(0, devicePath.LastIndexOf('#')).Replace('#', '_');
        }

        #endregion

        #endregion
    }
}
