using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Commands
{
    /// <summary>
    /// USB命令。
    /// </summary>
    public enum UsbCommand : byte
    {
        /// <summary>
        /// 获取状态。
        /// </summary>
        GetStatus = 0x00,

        /// <summary>
        /// 
        /// </summary>
        ClearFeature = 0x01,

        /// <summary>
        /// 
        /// </summary>
        SetFeature = 0x03,

        /// <summary>
        /// 设置地址。
        /// </summary>
        SetAddress = 0x05,

        /// <summary>
        /// 获取描述符。
        /// </summary>
        GetDescriptor = 0x06,

        /// <summary>
        /// 设置描述符。
        /// </summary>
        SetDescriptor = 0x07,

        /// <summary>
        /// 获取配置。
        /// </summary>
        GetConfiguration = 0x08,

        /// <summary>
        /// 设置配置。
        /// </summary>
        SetConfiguration = 0x09,

        /// <summary>
        /// 获取接口。
        /// </summary>
        GetInterface = 0x0A,

        /// <summary>
        /// 设置接口。
        /// </summary>
        SetInterface = 0x0B,

        /// <summary>
        /// 同步帧。
        /// </summary>
        SynchFrame = 0x0C,
    }
}
