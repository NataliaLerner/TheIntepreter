using System;
using System.Collections.Generic;
using Intepreter.Operations;
using Intepreter.Operations.Core;


namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var num32 = 0;
            var operation = 2;
            var register = 15;

            num32 = OperationCore.SetOperation(num32, operation);
            num32 = OperationCore.SetRegister(num32, register, 1);

            Tuple<int, string> num32OperationResultValue;

            if (Operations.TryExecuteOperation(num32, out num32OperationResultValue) == false)
            {
                num32 = 0;
            }
           
                   
            num32 = num32OperationResultValue.Item1;

            Console.WriteLine(num32OperationResultValue.Item2);
            Console.WriteLine(OperationCore.GetRegister(num32, 3));
            Console.WriteLine(OperationCore.GetRegister(num32, 2));
            Console.WriteLine(OperationCore.GetRegister(num32, 1));
            Console.WriteLine(OperationCore.GetOperation(num32));
        }
    }
}
