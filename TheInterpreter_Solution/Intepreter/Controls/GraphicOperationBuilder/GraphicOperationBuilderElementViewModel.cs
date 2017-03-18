using System;
using System.Windows;
using Intepreter.Model.Abstract;

using DevExpress.Mvvm;

namespace Intepreter.Controls.GraphicOperationBuilder
{
    public class GraphicOperationBuilderElementViewModel:
        ViewModelBase, IDragable
    {
        public string OperationName { get; set; }

        public int OperationCode { get; set; }

        public bool IsSelected
        {
            get { return  GetProperty(() => IsSelected); }
            set { SetProperty(() => IsSelected, value); }
        }

        public GraphicOperationBuilderElementViewModel(string name, int code)
        {
            OperationName = name;
            OperationCode = code;
        }

        public void Drag()
        {
            MessageBox.Show("Drag!");
        }

        public Type DataType => typeof(GraphicOperationBuilderElementViewModel);
    }
}
