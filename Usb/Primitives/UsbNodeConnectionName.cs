using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// 连接到集线器下游端口的设备名称。
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct UsbNodeConnectionName
    {
        /// <summary>
        /// 指示下游设备连接此USB集线器的端口索引号（大于或等于1的值）。
        /// </summary>
        public Int32 ConnectionIndex;

        /// <summary>
        /// 集线器名字的字符串长度（以字节为单位）。
        /// </summary>
        public Int32 ActualLength;

        /// <summary>
        /// 下游端口索引号所连接的设备名称。如果没有连接设备或者连接的设备不是集线器，则为null（Unicode字符串）。
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Globals.MAXIMUM_USB_STRING_LENGTH)]
        public String NodeName; 
    }
}
