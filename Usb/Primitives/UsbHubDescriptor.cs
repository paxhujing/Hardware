using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB集线器描述符。
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct UsbHubDescriptor
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
        /// 支持的下游端口数量。
        /// </summary>
        public Byte NumberOfPorts;

        /// <summary>
        /// 特征描述。
        /// </summary>
        public Int16 HubCharacteristics;

        /// <summary>
        /// 从端口加电到端口正常工作的时间间隔。
        /// </summary>
        public Byte PowerOnToPowerGood;

        /// <summary>
        /// 设备所需最大电流。
        /// </summary>
        public Byte HubControlCurrent;

        /// <summary>
        /// 指示连接在集线器端口的设备是否可以移走。
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 64)]
        public Byte[] RemoveAndPowerMask;
    }
}
