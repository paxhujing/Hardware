using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB设备速度。
    /// </summary>
    public enum UsbDeviceSpeed : byte
    {
        /// <summary>
        /// 低速USB 1.1。
        /// </summary>
        UsbLowSpeed,

        /// <summary>
        /// 全速USB 1.1。
        /// </summary>
        UsbFullSpeed,

        /// <summary>
        /// 高速USB 2.0。
        /// </summary>
        UsbHighSpeed,

        /// <summary>
        /// 极速USB 3.0。
        /// </summary>
        UsbSuperSpeed,
    }
}
