using System;

namespace Interpreter.Operations
{
    public class Operations
    {
        /// <summary>
        /// Текущее состояние всех регистров в 32-х разрядном числе в системе счисления 2, 8, 10, 16
        /// </summary>
        /// <param name="num">32-x разрядное число</param>
        /// <param name="outPutBase">Система счисления</param>
        /// <returns>Массив строк, где каждая строка - регистр 32-х битного числа</returns>
        public string[] GetAllOperands(int num, int outPutBase)
        {
            return new string[] 
            {
                GetStringOperand(num, 3, outPutBase),
                GetStringOperand(num, 2, outPutBase),
                GetStringOperand(num, 1, outPutBase)
            };
        }

        /// <summary>
        /// Возвращает <see cref="string"/> представление операнда в 32-х разрядном числе в системе счисления 2, 8, 10, 16
        /// </summary>
        /// <param name="num">32-х разрядное число</param>
        /// <param name="operandIndex">Индекс операнда</param>
        /// <param name="outputBase">Основание системы счисления</param>
        /// <returns>Строковое представление операнда</returns>
        public string GetStringOperand(int num, int operandIndex, int outputBase)
        {
            return Convert.ToString(GetOperand(num, operandIndex), outputBase);
        }

        /// <summary>
        /// Возвращает <see cref="string"/> представление номера операции 32-х разрядного числа
        /// </summary>
        /// <param name="num">32-х разрядное число</param>
        /// <returns></returns>
        public string GetStringOperation(int num)
        {
            return Convert.ToString(GetOperation(num), 10);
        }
        
        /// <summary>
        /// Задать код операции 32-х разрядного числа
        /// </summary>
        /// <param name="num">32-х разрядное число</param>
        /// <param name="newOperation">Новая операция</param>
        /// <returns>32-х разрядное число с новым операндом</returns>
        public int SetOperation(int num, int newOperation)
        {
            if (newOperation > 24 || newOperation < 0)
            {
                throw new ArgumentException("Недопустимое значение новой операции!", "newOperation");
            }

            return ((num >> 5) << 5) | newOperation;
        }

        /// <summary>
        /// Задает значение операнда 32-х разрядного числа
        /// </summary>
        /// <param name="num">32-х разрядное число</param>
        /// <param name="newOperand">Новое значение операнда</param>
        /// <param name="operandIndex">Индекс операнда</param>
        /// <returns>32-х разрядное число с новым операндом</returns>
        public int SetOperand(int num, int newOperand, int operandIndex)
        {
            if (newOperand >> 9 != 0)
            {
                throw new ArgumentException("Значение нового операнда задано неверно! Должны быть заполнены только первые 9 бит!", "newOperand");
            }

            if (operandIndex > 3 || operandIndex < 1)
            {
                throw new ArgumentOutOfRangeException("operandIndex", operandIndex, "Недопустимый индекс операнда! Индекс операнда не должен быть больше 3 или меньше 1");
            }

            return (num ^ GetOperand(num, operandIndex) << ((9 * operandIndex - 1) + 5)) | (newOperand << (9 * operandIndex - 1) + 5);
        }

        /// <summary>
        /// Получает операцию из 32-х разрядного числа
        /// </summary>
        /// <param name="num">32-х разрядное число</param>
        /// <returns>32-x разрядное числа, первые 5 бит которого - номер операции</returns>
        public int GetOperation(int num)
        {
            return (num & ((1 << 5) - 1));
        }

        /// <summary>
        /// Получает операнд из 32-х разрядного числа
        /// </summary>
        /// <param name="num">32-х разрядное число</param>
        /// <param name="operandIndex">Индекс операнда</param>
        /// <returns>32-х разрядное число, первые 9 бит которого - операнд</returns>
        public int GetOperand(int num, int operandIndex)
        {
            if (operandIndex > 3 || operandIndex < 1)
            {
                throw new ArgumentOutOfRangeException("operandIndex", operandIndex, "Недопустимый индекс операнда! Индекс операнда не должен быть больше 3 или меньше 1");
            }

            return (((num >> 5) >> (9 * (operandIndex - 1))) & ((1 << 9) - 1));
        }
    }
}
