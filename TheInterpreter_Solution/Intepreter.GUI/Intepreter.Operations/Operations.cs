using System;
using System.Collections.Generic;
using Intepreter.Operations.Core;


namespace Intepreter.Operations
{
    public static class Operations
    {
        public static int ExecuteOperation(int num32)
        {
            Func<int, int> operation;

            if (OperationsFuncs.TryGetValue(OperationCore.GetOperation(num32), out operation))
            {
                return operation(num32);
            }

            return -1;
        }

        /// <summary>
        /// Бинарное отрицание над содержимом 1 операнда, результат сохраняется в 3 операнд
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <returns></returns>
        public static int NOT_1_operation(int num32)
        {
            return OperationCore.SetRegister(
                num32, 
                OperationCore.GetLastBits(~OperationCore.GetRegister(num32, 1), 9), 
                3);
        }

        public static int OR_2_operation(int num32)
        {
            var register = OperationCore.GetLastBits(OperationCore.GetRegister(num32, 1) | OperationCore.GetRegister(num32, 2), 9);

            return OperationCore.SetRegister(
                num32,
                register,
                3);
        }

        public static int AND_3_operation(int num32)
        {
            var register = OperationCore.GetLastBits(OperationCore.GetRegister(num32, 1) & OperationCore.GetRegister(num32, 2), 9);

            return OperationCore.SetRegister(
                num32,
                register,
                3);
        }

        /// <summary>
        /// Словарь операций
        /// </summary>
        public static readonly Dictionary<int, Func<int, int>> OperationsFuncs = new Dictionary<int, Func<int, int>>()
        {
            {1, NOT_1_operation },
            {2, OR_2_operation },
            {3, AND_3_operation }
        };
    }
}
