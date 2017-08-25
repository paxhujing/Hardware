using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB设备描述符。
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct UsbDeviceDescriptor
    {
        /// <summary>
        /// 描述符长度（以字节为单位）。
        /// </summary>
        public Byte Length;

        /// <summary>
        /// 描述符类型。
        /// </summary>
        public UsbDescriptorType DescriptorType;

        /// <summary>
        /// USB版本号（BCD码）。
        /// </summary>
        public UInt16 UsbVersion;

        /// <summary>
        /// 由USB规范组指派的设备的类代码。
        /// </summary>
        public DeviceClass DeviceClass;

        /// <summary>
        /// 由USB规范组指派的设备的子类代码。
        /// </summary>
        public Byte DeviceSubClass;

        /// <summary>
        /// 由USB规范组指派的设备的协议代码。
        /// </summary>
        public Byte DeviceProtocol;

        /// <summary>
        /// 设备端点0所能接受的最大包大小（以字节为单位）。该值必须是8、16、32或64。
        /// </summary>
        public Byte MaxPacketSize0;

        /// <summary>
        /// 由USB规范委员会指派的设备的供应商标识符。
        /// </summary>
        public UInt16 VendorId;

        /// <summary>
        /// 产品标识符。此值由制造商指定, 且特定于设备。
        /// </summary>
        public UInt16 ProductId;

        /// <summary>
        /// 设备版本号（BCD码）。
        /// </summary>
        public UInt16 DeviceVersion;

        /// <summary>
        /// 用于描述厂商的字符串描述符索引。如果没有字符串描述符，则为0x00。
        /// </summary>
        public Byte ManufacturerIndex;

        /// <summary>
        /// 用于描述产品的字符串描述符索引。如果没有字符串描述符，则为0x00。
        /// </summary>
        public Byte ProductIndex;

        /// <summary>
        ///  用于描述产品序列号的字符串描述符索引。如果没有字符串描述符，则为0x00。
        /// </summary>
        public Byte SerialNumberIndex;

        /// <summary>
        /// 配置描述符数量。
        /// </summary>
        public Byte NumConfigurations;
    }
}
