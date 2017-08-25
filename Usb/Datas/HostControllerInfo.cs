using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Datas
{
    /// <summary>
    /// USB主机控制器信息。
    /// </summary>
    public struct HostControllerInfo
    {
        /// <summary>
        /// 设备ID。
        /// </summary>
        public String PNPDeviceId { get; internal set; }

        /// <summary>
        /// 设备名称。
        /// </summary>
        public String Name { get; internal set; }
    }
}
