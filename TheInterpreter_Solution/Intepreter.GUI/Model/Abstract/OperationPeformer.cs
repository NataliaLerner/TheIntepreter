namespace Intepreter.GUI.Model.Abstract
{
    public interface IOperationPeformer
    {
        bool ReadFromBinaryFile(string path, out string outputText);
        bool WriteToBinaryFile(string path, string inputText);
        bool TryExecuteOperation(int num32);
    }
}
