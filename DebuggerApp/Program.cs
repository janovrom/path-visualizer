using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //const string message = "D:/Temp/bash.exe.stackdump";
            const string message = @"D:\Temp\drive-download-20210103T140231Z-001\Team_01-Comatose\Last build\Comatose_Data\Resources";
            PathVisualizer.DebuggerSide.TestShowVisualizer(message);
            Console.WriteLine(message);
        }
    }
}
