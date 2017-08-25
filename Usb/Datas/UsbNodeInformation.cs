using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usb.Primitives;

namespace Usb.Datas
{
    /// <summary>
    /// USB集线器节点信息。
    /// </summary>
    public class UsbNodeInformation
    {
        #region Constructors

        internal UsbNodeInformation()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// 设备路径。
        /// </summary>
        public String DevicePath { get; internal set; }

        /// <summary>
        /// 设备ID。
        /// </summary>
        public String PNPDeviceId { get; internal set; }

        /// <summary>
        /// 设备名称。
        /// </summary>
        public String Name { get; internal set; }

        /// <summary>
        /// 节点类型。
        /// </summary>
        public UsbHubNode NodeType { get; internal set; }

        /// <summary>
        /// 是否是总线供电。
        /// </summary>
        public Boolean HubIsBusPowered { get; internal set; }

        /// <summary>
        /// 下游端口数。
        /// </summary>
        public Int32 NumberOfPorts { get; internal set; }

        /// <summary>
        /// 集线器特征描述。
        /// </summary>
        public Int16 HubCharateristics { get; internal set; }

        /// <summary>
        /// 从端口加电到端口正常工作的时间间隔(以2ms为单位)。
        /// </summary>
        public Byte PowerOnToPowerGood{ get; internal set; }

        /// <summary>
        /// 所需最大电流。
        /// </summary>
        public Byte HuControlCurrent { get; internal set; }

        /// <summary>
        /// 接口数。
        /// </summary>
        public Int32 NumberOfInterfaces { get; internal set; }

        #endregion
    }
}
