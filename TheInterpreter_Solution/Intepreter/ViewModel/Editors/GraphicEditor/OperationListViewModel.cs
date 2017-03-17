using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Intepreter.Model.Operations;
namespace Intepreter.ViewModel.Editors.GraphicEditor
{
    public class OperationListViewModel : 
        ViewModelBase
    {
        public List<OperationListElementViewModel> List { get; private set; }

        public OperationListViewModel()
        {

            List = new List<OperationListElementViewModel>();

            foreach (var operationFunc in Operations.OperationFuncs)
            {
                List.Add(new OperationListElementViewModel(operationFunc.Value.Method.Name, operationFunc.Key));
            }
        }
    }
}
