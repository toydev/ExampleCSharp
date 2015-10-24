using System;
using System.Runtime.InteropServices;

namespace MemoryDump
{
    public class NativeMethods
    {
        [DllImport("kernel32.dll")]
        internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, IntPtr nSize, ref IntPtr lpNumberOfBytesRead);
    }
}
