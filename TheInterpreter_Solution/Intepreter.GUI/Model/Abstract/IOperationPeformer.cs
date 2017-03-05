using System;

namespace Intepreter.GUI.Model.Abstract
{
    public interface IOperationPeformer
    {
        void WriteToBinaryFile(string path, int  num32);
        bool TryExecuteOperation(int num32, out Tuple<int, string> resultTuple);
    }
}