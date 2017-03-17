using System;
using System.Collections.Generic;

using Intepreter.Model.Operations;
using DevExpress.Mvvm;

namespace Intepreter.ViewModel.Editors.GraphicEditor
{
    public class OperationListViewModel : 
        ViewModelBase
    {
        public List<OperationListElementViewModel> List
        {
            get { return GetProperty(() => List); }
            set { SetProperty(() => List, value); }
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            List = new List<OperationListElementViewModel>();

            foreach (var operationFunc in Operations.OperationFuncs)
            {
                List.Add(new OperationListElementViewModel(operationFunc.Value.Method.Name, operationFunc.Key));
            }
        }
    }
}
