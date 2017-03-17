using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;
using Intepreter.Model;
using Intepreter.Behavior;
using Intepreter.Model.Operations;

using Intepreter.Model.Abstract;
using DevExpress.Mvvm;

namespace Intepreter.ViewModel.Editors.GraphicEditor
{
    public class OperationListElementViewModel :
        ViewModelBase, IDragable
    {
        public string OperationName
        {
            get { return _operationName;}
            set { _operationName = value; }
        }

        public int OperationCode
        {
            get { return _operationCode; }
            set { _operationCode = value; }
        }

        public bool IsSelected
        {
            get { return  GetProperty(() => IsSelected); }
            set { SetProperty(() => IsSelected, value); }
        }

        public OperationListElementViewModel(string name, int code)
        {
            OperationName = name;
            OperationCode = code;
        }

        private bool _isSelected;

        private string _operationName;
        private int _operationCode;

        public Type DataType
        {
            get { return typeof(OperationListElementViewModel); }
        }
    }
}
