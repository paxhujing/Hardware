using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    /// <summary>
    /// 设备类别。
    /// </summary>
    public enum DeviceClass : byte
    {
        /// <summary>
        /// 表示由“接口描述符”提供来决定设备类别。
        /// </summary>
        Device = 0x00,

        /// <summary>
        /// 音频类。
        /// </summary>
        Audio = 0x01,

        /// <summary>
        /// 
        /// </summary>
        CDC_Control=0x02,

        /// <summary>
        /// 人机接口类。
        /// </summary>
        HID=0x03,

        /// <summary>
        /// 
        /// </summary>
        Physical = 0x05,

        /// <summary>
        /// 图像类。
        /// </summary>
        Image = 0x06,

        /// <summary>
        /// 打印机类。
        /// </summary>
        Printer = 0x07,

        /// <summary>
        /// 大容量存储设备类。
        /// </summary>
        MassStorage = 0x08,

        /// <summary>
        /// 集线器类。
        /// </summary>
        Hub = 0x09,

        /// <summary>
        /// 
        /// </summary>
        CDC_DATA = 0x0A,

        /// <summary>
        /// 智能卡类。
        /// </summary>
        SmartCard = 0x0B,

        /// <summary>
        /// 内容安全性类。
        /// </summary>
        ContentSecurity = 0x0D,

        /// <summary>
        /// 视频类。
        /// </summary>
        Video = 0x0E,

        /// <summary>
        /// 个人健康类。
        /// </summary>
        PersonalHealthcare = 0x0F,

        /// <summary>
        /// 诊断设备类。
        /// </summary>
        DiagnosticDevice = 0xDC,

        /// <summary>
        /// 无线控制器类。
        /// </summary>
        WirelessController = 0xE0,

        /// <summary>
        /// 其它设备类别。
        /// </summary>
        Miscellaneous = 0xEF,

        /// <summary>
        /// 应用程序定义的设备类别。
        /// </summary>
        ApplicationSpecific = 0xFE,

        /// <summary>
        /// 厂商定义的设备类别。
        /// </summary>
        VendorSpecific = 0xFF
    }
}
