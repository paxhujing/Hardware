using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usb.Primitives;
using System.Runtime.InteropServices;
using System.Security;

namespace Usb.Primitives
{
    internal static class Win32Api
    {
        #region Fields

        /// <summary>
        /// 用于在注册表中检索USB主机控制器驱动的驱动键名。
        /// </summary>
        public const Int32 IOCTL_GET_HCD_DRIVERKEY_NAME = 0x220424;

        /// <summary>
        /// 用于检索根集线器名称。
        /// </summary>
        public const Int32 IOCTL_USB_GET_ROOT_HUB_NAME = 0x220408;

        /// <summary>
        /// 用于检索连接到集线器下游端口的设备名称。
        /// </summary>
        public const Int32 IOCTL_USB_GET_NODE_CONNECTION_NAME = 0x220414;

        /// <summary>
        /// 用于检索有关父设备的信息。
        /// </summary>
        public const Int32 IOCTL_USB_GET_NODE_INFORMATION = 0x220408;

        /// <summary>
        /// USB连接信息。
        /// </summary>
        public const Int32 IOCTL_USB_GET_NODE_CONNECTION_INFORMATION_EX = 0x220448;

        /// <summary>
        /// 用于检索与指定端口索引关联的设备的一个或多个描述符。
        /// </summary>
        public const Int32 IOCTL_USB_GET_DESCRIPTOR_FROM_NODE_CONNECTION = 0x220410;

        public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        #endregion

        #region Methods

        #region DeviceIoControl

        /// <summary>
        /// 设备IO控制。
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="dwIoControlCode">设备控制命令。</param>
        /// <param name="lpInBuffer">设备控制请求数据的缓冲区地址，如果没有请求参数则为null。</param>
        /// <param name="nInBufferSize">请求数据的缓冲区大小。</param>
        /// <param name="lpOutBuffer">设备控制响应数据的缓冲区地址，如果没有响应数据则为null。</param>
        /// <param name="nOutBufferSize">响应数据缓冲区的大小。</param>
        /// <param name="nBytesReturned">实际发送的数据大小。</param>
        /// <param name="lpOverlapped">忽略，始终未null。</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Boolean DeviceIoControl(IntPtr hDevice, 
            Int32 dwIoControlCode, 
            IntPtr lpInBuffer, 
            Int32 nInBufferSize, 
            ref UsbHcdDriverKeyName lpOutBuffer, 
            Int32 nOutBufferSize, 
            out Int32 nBytesReturned, 
            IntPtr lpOverlapped);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Boolean DeviceIoControl(IntPtr hDevice,
            Int32 dwIoControlCode,
            ref UsbNodeInformation lpInBuffer,
            Int32 nInBufferSize,
            ref UsbNodeInformation lpOutBuffer,
            Int32 nOutBufferSize,
            out Int32 lpBytesReturned,
            IntPtr lpOverlapped);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        internal static extern Boolean DeviceIoControl(IntPtr hDevice,
            Int32 dwIoControlCode,
            ref UsbNodeConnectionInformationEx lpInBuffer,
            Int32 nInBufferSize,
            ref UsbNodeConnectionInformationEx lpOutBuffer,
            Int32 nOutBufferSize,
            out Int32 lpBytesReturned,
            IntPtr lpOverlapped);

        #endregion

        #region File

        [SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile(String fileName,
            [MarshalAs(UnmanagedType.U4)]NativeFileAccess fileAccess,
            [MarshalAs(UnmanagedType.U4)]NativeFileShare fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)]NativeFileMode creationDisposition,
            NativeFileFlag flags,
            IntPtr template);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile(String fileName,
            [MarshalAs(UnmanagedType.U4)]NativeFileAccess fileAccess,
            [MarshalAs(UnmanagedType.U4)]NativeFileShare fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)]NativeFileMode creationDisposition,
            IntPtr flags,
            IntPtr template);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean CloseHandle(IntPtr hFile);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean ReadFile(IntPtr hFile,
            [Out]Byte[] lpBuffer,
            Int32 nNumberOfBytesToRead,
            out Int32 lpNumberOfBytesRead,
            [In]ref System.Threading.NativeOverlapped lpOverlapped);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean ReadFile(IntPtr hFile,
            [Out]Byte[] lpBuffer,
            Int32 nNumberOfBytesToRead,
            IntPtr lpNumberOfBytesRead,
            [In]ref System.Threading.NativeOverlapped lpOverlapped);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean ReadFile(IntPtr hFile,
            [Out]Byte[] lpBuffer,
            Int32 nNumberOfBytesToRead,
            out Int32 lpNumberOfBytesRead,
            IntPtr lpOverlapped);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll")]
        public static extern Boolean WriteFile(IntPtr hFile,
            Byte[] lpBuffer,
            Int32 nNumberOfBytesToWrite,
            out Int32 lpNumberOfBytesWritten,
            [In]ref System.Threading.NativeOverlapped lpOverlapped);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll")]
        public static extern Boolean WriteFile(IntPtr hFile,
            Byte[] lpBuffer,
            Int32 nNumberOfBytesToWrite,
            IntPtr lpNumberOfBytesWritten,
            [In]ref System.Threading.NativeOverlapped lpOverlapped);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll")]
        public static extern Boolean WriteFile(IntPtr hFile,
            Byte[] lpBuffer,
            Int32 nNumberOfBytesToWrite,
            IntPtr lpNumberOfBytesWritten,
            IntPtr lpOverlapped);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Boolean GetOverlappedResult(IntPtr hFile,
            [In]ref System.Threading.NativeOverlapped lpOverlapped,
            out Int32 lpNumberOfBytesTransferred,
            Boolean bWait);

        #endregion

        #endregion
    }
}
