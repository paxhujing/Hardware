using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// 用于DeviceIoControl操作的Buffer。
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct UsbStringBuffer
    {
        /// <summary>
        /// 驱动程序键的名称的字符串以字节为单位的长度。
        /// </summary>
        public Int32 ActualLength;

        /// <summary>
        /// 2字节，以null结尾的Unicode字符串。
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String Value;
    }
}
