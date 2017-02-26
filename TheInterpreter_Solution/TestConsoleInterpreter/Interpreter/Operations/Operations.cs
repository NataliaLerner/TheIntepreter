using System;

namespace Interpreter.Operations
{
    public class Operations
    {
        /// <summary>
        /// Выводит состояние регистров в заданной системе счисления на консоль
        /// </summary>
        /// <param name="num">32-х разрядное число</param>
        /// <param name="outPutBase">Система счисления</param>
        public void OperandsOutputToConsole(int num, int outputBase)
        {
            for (int i = 0; i != 3; ++i)
            {
                Console.WriteLine(GetStringOperand(num, i + 1, outputBase));
            }
        }

        /// <summary>
        /// Возвращает строковое представление операнда в 32-х разрядном числе в заданной системе счисления
        /// </summary>
        /// <param name="num">32-х разрядное число</param>
        /// <param name="operandIndex">Индекс операнда</param>
        /// <param name="outputBase">Система счисления</param>
        /// <returns>Строковое представление операнда</returns>
        public string GetStringOperand(int num, int operandIndex, int outputBase)
        {
            return Convert.ToString(GetOperand(num, operandIndex), outputBase);
        }

        // TODO: Задать логику для SetOperand метода

        /// <summary>
        /// Задает значение операнда 32-х разрядного числа
        /// </summary>
        /// <param name="num">32-х разрядное число</param>
        /// <param name="newOperand">Новое значение операнда</param>
        /// <param name="operandIndex">Индекс задаваемого операнда</param>
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

            return 0;
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
