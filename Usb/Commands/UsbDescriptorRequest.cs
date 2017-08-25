using Usb.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Commands
{
    /// <summary>
    /// 用于检索与指定连接索引关联的设备的描述符。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct UsbDescriptorRequest
    {
        /// <summary>
        /// 需要检索描述符的端口。
        /// </summary>
        public Int32 ConnectionIndex;

        /// <summary>
        /// UsbSetupPacket 结构。
        /// </summary>
        public UsbSetupPacket SetupPacket;

        /// <summary>
        /// 字符串描述符。
        /// </summary>
        public UsbStringDescriptor Data;
    }
}
