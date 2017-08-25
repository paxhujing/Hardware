using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB描述符类型。
    /// </summary>
    public enum UsbDescriptorType : byte
    {
        /// <summary>
        /// 设备描述符。
        /// </summary>
        Device = 0x01,

        /// <summary>
        /// 配置描述符。
        /// </summary>
        Configuration = 0x02,

        /// <summary>
        /// 字符串描述符。
        /// </summary>
        String = 0x03,

        /// <summary>
        /// 接口描述符。
        /// </summary>
        Interface = 0x04,

        /// <summary>
        /// 端点描述符。
        /// </summary>
        Endpoint = 0x05,

        /// <summary>
        /// 集线器类描述符。
        /// </summary>
        Hub = 0x29,

        /// <summary>
        /// 人机接口类描述符。
        /// </summary>
        HID = 0x21,

        /// <summary>
        /// 厂商自定义描述符。
        /// </summary>
        Custom = 0xFF,
    }
}
