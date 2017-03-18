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
        public string MarkUp
        {
            get { return GetProperty(() => MarkUp); }
            set { SetProperty(() => value, MarkUp); }
        }

        public List<GraphicOperationBuilderElementViewModel> List
        {
            get { return GetProperty(() => List); }
            set { SetProperty(() => List, value); }
        }

        public GraphicOperationBuilderViewModel()
        {
            base.OnInitializeInRuntime();
            List = new List<GraphicOperationBuilderElementViewModel>();

            foreach (var operationFunc in Operations.OperationFuncs)
            {
                List.Add(new GraphicOperationBuilderElementViewModel(operationFunc.Value.Method.Name, operationFunc.Key));
            }
        }

        [Command]
        public void Test()
        {
            Messenger.Default.Send<string>("Message from control!");
        }
    }
}