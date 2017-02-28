using System;

using Interpreter.OperationCore;

namespace TestConsoleInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            OperationCore op = new OperationCore();
            int num32 = 260555747;
            int y = 24;
            int newOp = 15;

            num32 = op.SetOperation(num32, y);
            num32 = op.SetRegister(num32, newOp, 1);
            num32 = op.SetRegister(num32, newOp, 2);
            num32 = op.SetRegister(num32, newOp, 3);
            Console.WriteLine(op.GetRegister(num32, 3));
            Console.WriteLine(op.GetRegister(num32, 2));
            Console.WriteLine(op.GetRegister(num32, 1));
            Console.WriteLine(op.GetOperation(num32));
        }
    }
}
