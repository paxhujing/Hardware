using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB节点信息。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct UsbNodeInformation
    {
        /// <summary>
        /// USB集线器类型。
        /// </summary>
        public UsbHubNode NodeType;

        /// <summary>
        /// USB节点。
        /// </summary>
        public UsbNodeUnion U;
    }
}
