using System;
using System.Collections.Generic;

namespace Intepreter.Core
{
    public static class Constants
    {
        /// <summary>
        ///     Максимальное количество бит в операции
        /// </summary>
        public const int OperationLength = 5;

        /// <summary>
        ///     Максимальное количество бит в длине регистра
        /// </summary>
        public const int RegisterLength = 9;

        /// <summary>
        ///     Максимальный индекс регистра
        /// </summary>
        public const int MaxRegisterIndex = 3;

        /// <summary>
        ///     Минимальный индекс регистра
        /// </summary>
        public const int MinRegisterIndex = 1;

        /// <summary>
        ///     Максимальный номер операции
        /// </summary>
        public const int MaxOperationCount = 24;
    }

    public static class OperationCore
    {
        /// <summary>
        ///     Текущее состояние всех регистров в 32-х разрядном числе в системе счисления 2, 8, 10, 16
        /// </summary>
        /// <param name="num32">32-x разрядное число</param>
        /// <param name="outPutBase">Система счисления</param>
        /// <returns>Массив строк, где каждая строка - регистр 32-х битного числа</returns>
        public static string[] GetAllRegisters(int num32, int outPutBase)
        {
            return new[]
            {
                GetStringRegister(num32, 3, outPutBase),
                GetStringRegister(num32, 2, outPutBase),
                GetStringRegister(num32, 1, outPutBase)
            };
        }

        /// <summary>
        ///     Возвращает <see cref="string" /> представление операнда в 32-х разрядном числе в системе счисления 2, 8, 10, 16
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <param name="registerIndex">Индекс операнда</param>
        /// <param name="outputBase">Основание системы счисления</param>
        /// <returns>Строковое представление операнда</returns>
        public static string GetStringRegister(int num32, int registerIndex, int outputBase)
        {
            return Convert.ToString(GetRegister(num32, registerIndex), outputBase);
        }

        /// <summary>
        ///     Возвращает <see cref="string" /> представление номера операции 32-х разрядного числа
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <returns></returns>
        public static string GetStringOperation(int num32)
        {
            return Convert.ToString(GetOperation(num32), 10);
        }

        /// <summary>
        ///     Задать код операции 32-х разрядного числа
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <param name="newOperation">Новая операция</param>
        /// <returns>32-х разрядное число с новым операндом</returns>
        public static int SetOperation(int num32, int newOperation)
        {
            if (newOperation > Constants.MaxOperationCount || newOperation < 0)
                throw new ArgumentException("Недопустимое значение новой операции!", nameof(newOperation));

            return ((num32 >> Constants.OperationLength) << Constants.OperationLength) | newOperation;
        }

        /// <summary>
        ///     Задает значение операнда 32-х разрядного числа
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <param name="newRegister">Новое значение операнда</param>
        /// <param name="registerIndex">Индекс операнда</param>
        /// <returns>32-х разрядное число с новым операндом</returns>
        public static int SetRegister(int num32, int newRegister, int registerIndex)
        {
            if (newRegister >> Constants.RegisterLength != 0)
                throw new ArgumentException(
                    "Значение нового регистра задано неверно! Должны быть заполнены только первые 9 бит!",
                    nameof(newRegister));

            return (num32 ^
                    (GetRegister(num32, registerIndex) <<
                     (Constants.RegisterLength * (registerIndex - 1) + Constants.OperationLength)))
                   | (newRegister << (Constants.RegisterLength * (registerIndex - 1) + Constants.OperationLength));
        }

        /// <summary>
        ///     Получает операцию из 32-х разрядного числа
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <returns>32-x разрядное числа, первые 5 бит которого - номер операции</returns>
        public static int GetOperation(int num32)
        {
            return num32 & ((1 << Constants.OperationLength) - 1);
        }

        /// <summary>
        ///     Получает операнд из 32-х разрядного числа
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <param name="registerIndex">Индекс операнда</param>
        /// <returns>32-х разрядное число, первые 9 бит которого - операнд</returns>
        public static int GetRegister(int num32, int registerIndex)
        {
            if (registerIndex > Constants.MaxRegisterIndex || registerIndex < Constants.MinRegisterIndex)
                throw new ArgumentOutOfRangeException(nameof(registerIndex), registerIndex,
                    "Недопустимый индекс регистра! Индекс операнда не должен быть больше 3 или меньше 1");

            return (num32 >> Constants.OperationLength >> (Constants.RegisterLength * (registerIndex - 1))) &
                   ((1 << Constants.RegisterLength) - 1);
        }

        /// <summary>
        ///     Получает последние n бит
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <param name="n">Количество бит, которые нужно получить</param>
        /// <returns></returns>
        public static int GetLastBits(int num32, int n)
        {
            return num32 & ((1 << n) - 1);
        }
    }

    public static class Operations
    {
        /// <summary>
        ///     Возвращает 32-х разрядное число с выполненной операцией.
        ///     Возвращает значение, указывающее успешно ли выполнена операция
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <param name="resultTuple">Кортеж пары компонентов <see cref="int" /> и <see cref="string" /></param>
        /// <returns></returns>
        public static bool TryExecuteOperation(int num32, out Tuple<int, string> resultTuple)
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
        /// <returns>32-х разрядное число (<see cref="int" />)</returns>
        public static int NOT_1_operation(int num32)
        {
            return OperationCore.SetRegister(
                num32,
                OperationCore.GetLastBits(OperationCore.GetRegister(num32, 1), 9),
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
