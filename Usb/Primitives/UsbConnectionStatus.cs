using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// USB连接状态。
    /// </summary>
    public enum UsbConnectionStatus
    {
        /// <summary>
        /// 没有连接到端口的设备。
        /// </summary>
        NoDeviceConnected,

        /// <summary>
        /// 设备已成功连接到端口。
        /// </summary>
        DeviceConnected,

        /// <summary>
        /// 尝试将设备连接到端口, 但设备的枚举失败。
        /// </summary>
        DeviceFailedEnumeration,

        /// <summary>
        /// 尝试将设备连接到端口, 但由于一般故障, 连接失败。
        /// </summary>
        DeviceGeneralFailure,

        /// <summary>
        ///尝试将设备连接到端口, 但由于电流过载而失败。
        /// </summary>
        DeviceCasedOvercurrent,

        /// <summary>
        /// 尝试将设备连接到端口, 但没有足够的电源来驱动设备, 并且连接失败。
        /// </summary>
        DeviceNotEnoughPower,

        /// <summary>
        /// 尝试将设备连接到端口, 但没有足够的带宽可供设备正常工作, 并且连接失败。
        /// </summary>
        DeviceNotEnoughBandwidth,

        /// <summary>
        /// 尝试将设备连接到端口, 但 USB 集线器的嵌套太深, 因此连接失败。
        /// </summary>
        DeviceHubNestedTooDeeply,

        /// <summary>
        /// 尝试将设备连接到不受支持的旧式集线器的端口, 并且连接失败。
        /// </summary>
        DeviceInLegacyHub,

        /// <summary>
        /// 正在枚举连接到端口的设备。在 Windows Vista 和更高版本的操作系统中是受支持的。
        /// </summary>
        DeviceEnumerating,

        /// <summary>
        /// 正在复位连接到端口的设备。在 Windows Vista 和更高版本的操作系统中是受支持的。
        /// </summary>
        DeviceReset,
    }
}
