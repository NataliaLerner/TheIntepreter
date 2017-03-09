namespace Intepreter.Model.Operations
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
}