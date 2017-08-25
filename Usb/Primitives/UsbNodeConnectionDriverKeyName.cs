using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// 用于检索连接到指定端口的设备的驱动程序键名。
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct UsbNodeConnectionDriverKeyName
    {
        /// <summary>
        /// 设备连接到的端口号。
        /// </summary>
        public Int32 ConnectionIndex;

        /// <summary>
        /// 驱动程序键名的字符串长度（以字节为单位）。
        /// </summary>
        public Int32 ActualLength;

        /// <summary>
        /// 驱动程序键名。
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Globals.MAXIMUM_USB_STRING_LENGTH)]
        public String DriverKeyName;
    }
}
