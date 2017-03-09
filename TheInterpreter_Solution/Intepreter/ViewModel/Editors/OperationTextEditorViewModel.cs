using Intepreter.Model.Abstract;

namespace Intepreter.ViewModel.Editors
{
    public class OperationTextEditorViewModel : 
        SimpleTextEditorViewModel, IOperationTextEditor
    {
        public OperationTextEditorViewModel(string initLine) : base(initLine)
        { }

        public OperationTextEditorViewModel() : base("")
        { }

        public int ExecuteOperation(int num32)
        {
            return 0;
        }
    }
}