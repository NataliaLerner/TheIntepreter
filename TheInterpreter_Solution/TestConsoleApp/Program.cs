using System;
using System.IO;
using System.Collections.Generic;

using System.Xml;
using Intepreter.Model.Operations;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int num32 = 0;
            int operation = 1;
            int register = 15;



            num32 = OperationCore.SetOperation(num32, operation);
            num32 = OperationCore.SetRegister(num32, register, 1);

            num32 = Operations.ExecuteOperation(num32);

            Console.WriteLine(OperationCore.GetRegister(num32, 3));
            Console.WriteLine(OperationCore.GetRegister(num32, 2));
            Console.WriteLine(OperationCore.GetRegister(num32, 1));
            Console.WriteLine(OperationCore.GetOperation(num32));
        }
    }
}
