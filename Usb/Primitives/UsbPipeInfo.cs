using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// 关联的管道信息。
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct UsbPipeInfo
    {
        /// <summary>
        /// 端点描述符。
        /// </summary>
        public UsbEndpointDescriptor EndPointDescriptor;

        /// <summary>
        /// 分配给此管道的端点的计划偏移量。
        /// </summary>
        public UInt32 ScheduleOffset;
    }
}
