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

            int x = 260555747;
            int y = 24;
            int newOp = 15;

            x = op.SetOperation(x, y);
            x = op.SetOperand(x, newOp, 1);
            Console.WriteLine(op.GetOperand(x, 3));
            Console.WriteLine(op.GetOperand(x, 2));
            Console.WriteLine(op.GetOperand(x, 1));
            Console.WriteLine(op.GetOperation(x));    
            
                    
        }
    }
}
