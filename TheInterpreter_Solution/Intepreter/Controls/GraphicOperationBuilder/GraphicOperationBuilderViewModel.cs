using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml.Linq;
using Intepreter.Model.Operations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Intepreter.ViewModel;

namespace Intepreter.Controls.GraphicOperationBuilder
{
    public class GraphicOperationBuilderViewModel :
        ViewModelBase, ISupportParameter
    {
        public List<GraphicOperationBuilderElementViewModel> List
        {
            get { return GetProperty(() => List); }
            private set { SetProperty(() => List, value); }
        }

        public GraphicOperationBuilderViewModel()
        {
            List = new List<GraphicOperationBuilderElementViewModel>();

            foreach (var operationFunc in Operations.OperationFuncs)
            {
                List.Add(new GraphicOperationBuilderElementViewModel(operationFunc.Value.Method.Name, operationFunc.Key));
            }
        }
    }
}