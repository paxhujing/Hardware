using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Commands
{
    /// <summary>
    /// USB设置请求包。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct UsbSetupPacket
    {
        /// <summary>
        /// 请求类型。
        /// （方向）D7：0表示主机到设备，1表示设备到主机；
        /// （种类）D6-D5：0表示标准，1表示类，2表示厂商，3表示保留；
        /// （目标）D4-D0：0表示设备，1表示接口，2表示端点，3表示其它
        /// </summary>
        public Byte RequestType;

        /// <summary>
        /// 命令。
        /// </summary>
        public UsbCommand Command;

        /// <summary>
        /// 值。
        /// </summary>
        public UInt16 Value;

        /// <summary>
        /// 索引。
        /// </summary>
        public UInt16 Index;

        /// <summary>
        /// 需要传输的字节总数。
        /// </summary>
        public UInt16 Length;
    }
}
