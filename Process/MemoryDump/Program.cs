using System;
using System.Diagnostics;
using System.IO;

namespace MemoryDump
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Process process = GetTargetProcess("TargetExample");
                Console.WriteLine("ProcessID: {0}", process.Id);
                Console.WriteLine("ProcessName: {0}", process.ProcessName);

                IntPtr processHandler = process.Handle;
                IntPtr baseAddress = process.MainModule.BaseAddress;
                int moduleMemorySize = process.MainModule.ModuleMemorySize;
                Console.WriteLine("BaseAddress: {0}", baseAddress);
                Console.WriteLine("ModuleMemorySize: {0}", moduleMemorySize);

                using (StreamWriter writer = new StreamWriter(new FileStream("test.out", FileMode.Create)))
                {
                    int bufferSize = 4096;
                    byte[] buffer = new byte[bufferSize];
                    IntPtr pointer = baseAddress;
                    IntPtr endPointer = IntPtr.Add(baseAddress, moduleMemorySize);
                    while (pointer.ToInt64() < endPointer.ToInt64())
                    {
                        IntPtr zero = IntPtr.Zero;
                        IntPtr readSize = GetReadSize(pointer, endPointer, bufferSize);
                        if (NativeMethods.ReadProcessMemory(processHandler, baseAddress, buffer, readSize, ref zero))
                        {

                        }

                        pointer = IntPtr.Add(pointer, bufferSize);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        static IntPtr GetReadSize(IntPtr pointer, IntPtr endPointer, int bufferSize)
        {
            if (endPointer.ToInt64() < IntPtr.Add(pointer, bufferSize).ToInt64())
            {
                return (IntPtr)(endPointer.ToInt64() - pointer.ToInt64());
            }
            else
            {
                return new IntPtr(bufferSize);
            }
        }

        static Process GetTargetProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            if (0 < processes.Length)
            {
                return processes[0];
            }
            else
            {
                return null;
            }
        }

    }
}
