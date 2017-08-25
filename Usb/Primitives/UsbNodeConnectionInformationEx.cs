using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB端口和连接设备的信息。
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct UsbNodeConnectionInformationEx
    {
        /// <summary>
        /// 指示下游设备连接此USB集线器的端口索引号（大于或等于1的值）。
        /// </summary>
        public Int32 ConnectionIndex;

        /// <summary>
        /// 设备描述符。
        /// </summary>
        public UsbDeviceDescriptor DeviceDescriptor;

        /// <summary>
        /// 与SetConfiguration请求一起使用的值。用于设置连接到指定端口的设备的当前配置。
        /// </summary>
        public Byte CurrentConfigurationValue;

        /// <summary>
        ///设备速度。
        /// </summary>
        public Byte Speed;

        /// <summary>
        /// 是否是集线器。
        /// </summary>
        public Boolean DeviceIsHub;

        /// <summary>
        /// 设备的总线地址。
        /// </summary>
        public UInt16 DeviceAddress;

        /// <summary>
        /// 与该端口关联的已打开的USB管道数量。
        /// </summary>
        public Int32 NumberOfOpenPipes;

        /// <summary>
        /// 连接状态。
        /// </summary>
        public UsbConnectionStatus ConnectionStatus;

        /// <summary>
        /// 管道列表。
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public UsbPipeInfo[] PipeList;
    }
}
