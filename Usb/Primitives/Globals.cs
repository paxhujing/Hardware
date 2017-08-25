using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    public static class Globals
    {
        /// <summary>
        /// USB使用的最大字符串长度。
        /// </summary>
        internal const Int32 MAXIMUM_USB_STRING_LENGTH = 255;

        internal const Int32 USB_STRING_DESCRIPTOR_TYPE = 3;
    }
}
