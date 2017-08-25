using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB节点。
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal struct UsbNodeUnion
    {
        /// <summary>
        /// 集线器信息。
        /// </summary>
        [FieldOffset(0)]
        public UsbHubInformation HubInformation;

        /// <summary>
        /// 复合设备信息。
        /// </summary>
        [FieldOffset(0)]
        public UsbMiParentInformation MiParentInformation;
    }
}
