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
                Process process = GetTargetProcess("notepad");
                if (process != null)
                {
                    Console.WriteLine("ProcessID: {0}", process.Id);
                    Console.WriteLine("ProcessName: {0}", process.ProcessName);
                    using (Stream stream = new FileStream("process.out", FileMode.Create))
                    {
                        OutputModuleMemory(process, process.MainModule, stream);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        static void OutputModuleMemory(Process process, ProcessModule processModule, Stream stream)
        {
            IntPtr processHandler = process.Handle;
            IntPtr baseAddress = processModule.BaseAddress;
            int moduleMemorySize = processModule.ModuleMemorySize;
            Console.WriteLine("BaseAddress: {0}", baseAddress);
            Console.WriteLine("ModuleMemorySize: {0}", moduleMemorySize);

            int bufferSize = 4096;
            byte[] buffer = new byte[bufferSize];
            IntPtr pointer = baseAddress;
            IntPtr endPointer = IntPtr.Add(baseAddress, moduleMemorySize);
            while (pointer.ToInt64() < endPointer.ToInt64())
            {
                IntPtr readSizeResult = IntPtr.Zero;
                IntPtr readSize = GetReadSize(pointer, endPointer, bufferSize);
                if (NativeMethods.ReadProcessMemory(processHandler, pointer, buffer, readSize, ref readSizeResult))
                {
                    stream.Write(buffer, 0, readSizeResult.ToInt32());
                }

                pointer = IntPtr.Add(pointer, bufferSize);
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
