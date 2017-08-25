using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usb.Primitives
{
    [Flags]
    internal enum NativeFileAccess : uint
    {
        GENERIC_READ = (0x80000000),
        GENERIC_WRITE = (0x40000000),
        GENERIC_EXECUTE = (0x20000000),
        GENERIC_ALL = (0x10000000),
        FILE_SPECIAL = 0,
        FILE_APPEND_DATA = (0x0004),    //文件
        FILE_READ_DATA = (0x0001),      // 文件
        FILE_WRITE_DATA = (0x0002),     // 文件和管道  
        FILE_READ_EA = (0x0008),        // 文件和目录  
        FILE_WRITE_EA = (0x0010),       // 文件和目录  
        FILE_READ_ATTRIBUTES = (0x0080),    // 所有  
        FILE_WRITE_ATTRIBUTES = (0x0100),   // 所有  
        DELETE = 0x00010000,
        READ_CONTROL = (0x00020000),
        WRITE_DAC = (0x00040000),
        WRITE_OWNER = (0x00080000),
        SYNCHRONIZE = (0x00100000),
        STANDARD_RIGHTS_REQUIRED = (0x000F0000),
        STANDARD_RIGHTS_READ = (READ_CONTROL),
        STANDARD_RIGHTS_WRITE = (READ_CONTROL),
        STANDARD_RIGHTS_EXECUTE = (READ_CONTROL),
        STANDARD_RIGHTS_ALL = (0x001F0000),
        SPECIFIC_RIGHTS_ALL = (0x0000FFFF),
        FILE_GENERIC_READ = (STANDARD_RIGHTS_READ | FILE_READ_DATA | FILE_READ_ATTRIBUTES | FILE_READ_EA | SYNCHRONIZE),
        FILE_GENERIC_WRITE = (STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | SYNCHRONIZE),
        SPECIAL = 0
    }
}
