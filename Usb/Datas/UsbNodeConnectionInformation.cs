using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usb.Primitives;

namespace Usb.Datas
{
    /// <summary>
    /// USB节点连接信息。
    /// </summary>
    public class UsbNodeConnectionInformation
    {
        #region Constructors

        internal UsbNodeConnectionInformation()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// 设备路径。
        /// </summary>
        public String DevicePath { get; internal set; }

        /// <summary>
        /// 指示下游设备连接此USB集线器的端口索引号（大于或等于1的值）。
        /// </summary>
        public Int32 ConnectionIndex { get; internal set; }

        /// <summary>
        /// 设备描述符。
        /// </summary>
        public UsbDeviceDescriptor DeviceDescriptor { get; internal set; }

        /// <summary>
        /// 与SetConfiguration请求一起使用的值。用于设置连接到指定端口的设备的当前配置。
        /// </summary>
        public Byte CurrentConfigurationValue { get; internal set; }

        /// <summary>
        ///设备速度。
        /// </summary>
        public Byte Speed { get; internal set; }

        /// <summary>
        /// 是否是集线器。
        /// </summary>
        public Boolean DeviceIsHub { get; internal set; }

        /// <summary>
        /// 设备的总线地址。
        /// </summary>
        public UInt16 DeviceAddress { get; internal set; }

        /// <summary>
        /// 连接状态。
        /// </summary>
        public UsbConnectionStatus ConnectionStatus { get; internal set; }

        /// <summary>
        /// 管道列表。
        /// </summary>
        public UsbPipeInfo[] PipeList { get; internal set; }

        #endregion
    }
}
