using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB集线器节点。
    /// </summary>
    public enum UsbHubNode : uint
    {
        /// <summary>
        /// USB集线器。
        /// </summary>
        UsbHub,
        /// <summary>
        /// USB复合设备。
        /// </summary>
        UsbMIParent,
    }
}
