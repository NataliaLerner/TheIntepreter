using Intepreter.Model.Abstract;
using Intepreter.Model.Operations;

namespace Intepreter.ViewModel.Editors
{
    public class OperationTextEditorViewModel : 
        SimpleTextEditorViewModel, IOperationTextEditor
    {
        public OperationTextEditorViewModel(string initLine) : base(initLine)
        { }

        public OperationTextEditorViewModel() : base("")
        { }

        public void ExecuteOperation(int num32)
        {
            throw new System.NotImplementedException();
        }
    }
}