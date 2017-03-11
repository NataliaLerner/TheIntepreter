namespace Intepreter.Model.Abstract
{
    public interface IOperationTextEditor : 
        ISimpleTextEditor
    {
        void ExecuteOperation(int num32);
    }
}

//Текстовый редактор с возможностью выполнения операций и вывода результата этих операций