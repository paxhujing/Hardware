using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB集线器信息。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct UsbHubInformation
    {
        /// <summary>
        /// USB集线器描述符。
        /// </summary>
        public UsbHubDescriptor HubDescriptor;

        /// <summary>
        /// 指示是否是总线供电。
        /// </summary>
        public Boolean HubIsBusPowered;
    }
}
