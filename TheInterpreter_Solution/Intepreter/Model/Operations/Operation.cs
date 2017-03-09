using System;
using System.Collections.Generic;

namespace Intepreter.Model.Operations
{
    public static class Operations
    {
        /// <summary>
        ///     Возвращает 32-х разрядное число с выполненной операцией.
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <returns></returns>
        public static int ExecuteOperation(int num32)
        {
            Func<int, int> operation;

            if (OperationsFuncs.TryGetValue(OperationCore.GetOperation(num32), out operation) == false)
            {
                return -1;
            }

            return operation(num32);
        }

        public static int FindOperationCodeByName(string operationName)
        {
            int result;

            if (NameKeyDictionary.TryGetValue(operationName, out result) == false)
            {
                return -1;
            }

            return result;
        }

        /// <summary>
        ///     Бинарное отрицание над содержимом 1 операнда, результат сохраняется в 3 операнд
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <returns>32-х разрядное число (<see cref="int" />)</returns>
        private static int NOT_1_operation(int num32)
        {
            return OperationCore.SetRegister(
                num32,
                OperationCore.GetLastBits(OperationCore.GetRegister(num32, 1), 9),
                3);
        }

        private static int OR_2_operation(int num32)
        {
            return OperationCore.SetRegister(
                num32,
                OperationCore.GetLastBits(OperationCore.GetRegister(num32, 1) | OperationCore.GetRegister(num32, 2), 9),
                3);
        }

        private static int AND_3_operation(int num32)
        {
            return OperationCore.SetRegister(
                num32,
                OperationCore.GetLastBits(OperationCore.GetRegister(num32, 1) & OperationCore.GetRegister(num32, 2), 9),
                3);
        }

        private static readonly Dictionary<string, int> NameKeyDictionary = new Dictionary<string, int>
        {
            {"NOT", 1 },
            {"OR",  2 },
            {"AND", 3 }
        };

        /// <summary>
        ///     Словарь операций
        /// </summary>
        private static readonly Dictionary<int, Func<int, int>> OperationsFuncs = new Dictionary<int, Func<int, int>>
        {
            {1, NOT_1_operation},
            {2, OR_2_operation},
            {3, AND_3_operation}
        };
    }
}