using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

using Interpreter.Operations;

namespace TestConsoleInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations op = new Operations();

            int x = 260046848;
            //Console.WriteLine(op.GetOperand(x, 3));

            //Console.WriteLine(op.GetStringOperand(x, 4, 2));

            op.OperandsOutputToConsole(x, 10);
            //Console.WriteLine(op.GetOperation(x));
        }
    }
}
