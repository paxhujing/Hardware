using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB根集线器名。
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct UsbRootHubName
    {
        /// <summary>
        /// 整个数据结构的大小（以字节为单位）。
        /// </summary>
        public Int32 ActualLength;

        /// <summary>
        /// 根集线器的设备名称（Unicode字符串）。
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String RootHubName;
    }
}
