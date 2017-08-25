using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB字符串描述符。
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct UsbStringDescriptor
    {
        /// <summary>
        /// 此描述符的长度 (以字节为单位)。
        /// </summary>
        public Byte Length;

        /// <summary>
        /// 描述符类型。
        /// </summary>
        public UsbDescriptorType DescriptorType;

        /// <summary>
        /// 字符串。
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst = Globals.MAXIMUM_USB_STRING_LENGTH)]
        public String String;
    }
}
