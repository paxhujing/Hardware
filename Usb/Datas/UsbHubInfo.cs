using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Datas
{
    /// <summary>
    /// USB集线器信息。
    /// </summary>
    public struct UsbHubInfo
    {
        /// <summary>
        /// 设备ID。
        /// </summary>
        public String PNPDeviceId { get; internal set; }

        /// <summary>
        /// 设备名称。
        /// </summary>
        public String Name { get; internal set; }

        /// <summary>
        /// 设备状态。
        /// </summary>
        public String Status { get; internal set; }
    }
}
