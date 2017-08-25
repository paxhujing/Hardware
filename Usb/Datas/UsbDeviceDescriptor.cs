using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usb.Primitives;

namespace Usb.Datas
{
    /// <summary>
    /// USB设备描述符。
    /// </summary>
    public class UsbDeviceDescriptor
    {
        #region Constructors

        internal UsbDeviceDescriptor()
        {

        }

        #endregion

        #region Properties

        /// 描述符类型。
        /// </summary>
        public UsbDescriptorType DescriptorType { get; internal set; }

        /// <summary>
        /// USB版本号。
        /// </summary>
        public String UsbVersion { get; internal set; }

        /// <summary>
        /// 由USB规范组指派的设备的类代码。
        /// </summary>
        public DeviceClass DeviceClass { get; internal set; }

        /// <summary>
        /// 由USB规范组指派的设备的子类代码。
        /// </summary>
        public Byte DeviceSubClass { get; internal set; }

        /// <summary>
        /// 由USB规范组指派的设备的协议代码。
        /// </summary>
        public Byte DeviceProtocol { get; internal set; }

        /// <summary>
        /// 设备端点0所能接受的最大包大小（以字节为单位）。该值必须是8、16、32或64。
        /// </summary>
        public Byte MaxPacketSize0 { get; internal set; }

        /// <summary>
        /// 由USB规范委员会指派的设备的供应商标识符。
        /// </summary>
        public UInt16 VendorId { get; internal set; }

        /// <summary>
        /// 产品标识符。此值由制造商指定, 且特定于设备。
        /// </summary>
        public UInt16 ProductId { get; internal set; }

        /// <summary>
        /// 设备版本号。
        /// </summary>
        public String DeviceVersion { get; internal set; }

        /// <summary>
        /// 用于描述厂商的字符串描述符索引。
        /// </summary>
        public String Manufacturer { get; internal set; }

        /// <summary>
        /// 用于描述产品的字符串描述符索引。
        /// </summary>
        public String Product { get; internal set; }

        /// <summary>
        ///  用于描述产品序列号的字符串描述符索引。
        /// </summary>
        public String SerialNumberIndex { get; internal set; }

        /// <summary>
        /// 配置描述符数量。
        /// </summary>
        public Byte NumberOfConfigurations { get; internal set; }

        #endregion
    }
}
