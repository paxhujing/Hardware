using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB复合设备信息。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct UsbMiParentInformation
    {
        /// <summary>
        /// 接口数量。
        /// </summary>
        public Int32 NumberOfInterfaces;
    }
}
