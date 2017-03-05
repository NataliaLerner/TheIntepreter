using System;
using System.Collections.Generic;
using Intepreter.Operations.Core;
using System.Collections;

namespace Intepreter.Operations
{
    public static class Operations
    {
        /// <summary>
        ///     Возвращает 32-х разрядное число с выполненной операцией.
        ///     Возвращает значение, указывающее успешно ли выполнена операция
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <param name="resultTuple">Кортеж пары компонентов <see cref="int"/> и <see cref="string"/></param>
        /// <returns></returns>
        public static bool TryExecuteOperation(int num32,  out Tuple<int, string> resultTuple)
        {
            Func<int, int> operation;

            if (OperationsFuncs.TryGetValue(OperationCore.GetOperation(num32), out operation) == false)
            {
                resultTuple = null;
                return false;
            }

            resultTuple = new Tuple<int, string>(operation(num32), operation.Method.Name);
            return true;
        }

        /// <summary>
        ///     Бинарное отрицание над содержимом 1 операнда, результат сохраняется в 3 операнд
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
            return OperationCore.SetRegister(
                num32,
                OperationCore.GetLastBits(OperationCore.GetRegister(num32, 1) | OperationCore.GetRegister(num32, 2), 9),
                3);
        }

        public static int AND_3_operation(int num32)
        {
            return OperationCore.SetRegister(
                num32,
                OperationCore.GetLastBits(OperationCore.GetRegister(num32, 1) & OperationCore.GetRegister(num32, 2), 9),
                3);
        }

        /// <summary>
        ///     Словарь операций
        /// </summary>
        public static readonly Dictionary<int, Func<int, int>> OperationsFuncs = new Dictionary<int, Func<int, int>>
        {
            {1, NOT_1_operation},
            {2, OR_2_operation},
            {3, AND_3_operation}
        };
    }
}
