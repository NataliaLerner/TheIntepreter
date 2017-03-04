using System;

namespace Intepreter.Operations.Core
{
    public static class Constants
    {
        /// <summary>
        /// Максимальное количество бит в операции
        /// </summary>
        public const int OperationLength = 5;
        /// <summary>
        /// Максимальное количество бит в длине регистра
        /// </summary>
        public const int RegisterLength = 9;
        /// <summary>
        /// Максимальный индекс регистра
        /// </summary>
        public const int MaxRegisterIndex = 3;
        /// <summary>
        /// Минимальный индекс регистра
        /// </summary>
        public const int MinRegisterIndex = 1;
        /// <summary>
        /// Максимальный номер операции
        /// </summary>
        public const int MaxOperationCount = 24;
    }

    public static class OperationCore
    {
        /// <summary>
        /// Текущее состояние всех регистров в 32-х разрядном числе в системе счисления 2, 8, 10, 16
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
        /// Возвращает <see cref="string"/> представление операнда в 32-х разрядном числе в системе счисления 2, 8, 10, 16
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
        /// Возвращает <see cref="string"/> представление номера операции 32-х разрядного числа
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <returns></returns>
        public static string GetStringOperation(int num32)
        {
            return Convert.ToString(GetOperation(num32), 10);
        }
        
        /// <summary>
        /// Задать код операции 32-х разрядного числа
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <param name="newOperation">Новая операция</param>
        /// <returns>32-х разрядное число с новым операндом</returns>
        public static int SetOperation(int num32, int newOperation)
        {
            if (newOperation > Constants.MaxOperationCount || newOperation < 0)
            {
                throw new ArgumentException("Недопустимое значение новой операции!", nameof(newOperation));
            }

            return ((num32 >> Constants.OperationLength) << Constants.OperationLength) | newOperation;
        }

        /// <summary>
        /// Задает значение операнда 32-х разрядного числа
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <param name="newRegister">Новое значение операнда</param>
        /// <param name="registerIndex">Индекс операнда</param>
        /// <returns>32-х разрядное число с новым операндом</returns>
        public static int SetRegister(int num32, int newRegister, int registerIndex)
        {
            if (newRegister >> Constants.RegisterLength != 0)
            {
                throw new ArgumentException("Значение нового регистра задано неверно! Должны быть заполнены только первые 9 бит!", nameof(newRegister));
            }

            return (num32 ^ (GetRegister(num32, registerIndex) << ((Constants.RegisterLength * (registerIndex - 1)) + Constants.OperationLength)))
               | (newRegister << (Constants.RegisterLength * (registerIndex - 1)) + Constants.OperationLength);
        }

        /// <summary>
        /// Получает операцию из 32-х разрядного числа
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <returns>32-x разрядное числа, первые 5 бит которого - номер операции</returns>
        public static int GetOperation(int num32)
        {
            return (num32 & ((1 << Constants.OperationLength) - 1));
        }

        /// <summary>
        /// Получает операнд из 32-х разрядного числа
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <param name="registerIndex">Индекс операнда</param>
        /// <returns>32-х разрядное число, первые 9 бит которого - операнд</returns>
        public static int GetRegister(int num32, int registerIndex)
        {
            if (registerIndex > Constants.MaxRegisterIndex || registerIndex < Constants.MinRegisterIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(registerIndex), registerIndex, "Недопустимый индекс регистра! Индекс операнда не должен быть больше 3 или меньше 1");
            }

            return (((num32 >> Constants.OperationLength) >> (Constants.RegisterLength * (registerIndex - 1))) & ((1 << Constants.RegisterLength) - 1));
        }

        /// <summary>
        /// Получает последние n бит
        /// </summary>
        /// <param name="num32">32-х разрядное число</param>
        /// <param name="n">Количество бит, которые нужно получить</param>
        /// <returns></returns>
        public static int GetLastBits(int num32, int n)
        {
            return num32 & ((1 << n) - 1);
        }
    }
}
