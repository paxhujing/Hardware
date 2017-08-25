using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// 端点描述符。
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct UsbEndpointDescriptor
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
        /// 端点地址。低4位表示端点编号，最高位表示OUT，次高位表示IN。
        /// </summary>
        public Byte EndpointAddress;

        /// <summary>
        /// 端点类型。
        /// （用途）D5-D4：00表示数据端点，01表示反馈端点，10表示隐式反馈数据端点，11保留；
        /// （同步）D3-D2：00表示非同步，01表示异步，10表示自适应，11表示同步；
        /// （传输）D1-D0：00表示控制传输Control Transaction，01表示同步传输Isochronous Transaction，10表示块传输Bulk Transaction，11表示中断传输Interrupt Transaction。
        /// 如果该端点不是同步端点，D5~D2保留且必须置0。
        /// </summary>
        public Byte Attributes;

        /// <summary>
        /// 端点支持的最大数据包。
        /// D10-D0：数据包长度。
        /// </summary>
        public UInt16 MaxPacketSize;

        /// <summary>
        /// 此值包含了中断和同步端点所需的轮训间隔。对于其它类型的端点应该忽略此值。此值反应固件中设备的配置。驱动程序无法更改。
        /// </summary>
        public Byte Interval;
    }
}
