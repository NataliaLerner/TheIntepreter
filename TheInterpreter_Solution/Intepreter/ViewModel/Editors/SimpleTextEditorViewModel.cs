using System;
using System.Text;

using Intepreter.Model.Operations;
using Intepreter.Model.Abstract;

namespace Intepreter.ViewModel.Editors
{
    public class SimpleTextEditorViewModel : 
        ViewModelBase, ISimpleTextEditor
    {
        public string Text
        {
            get { return _text;}
            set { UpdateValue(value, ref _text);}
        }

        public void AppendNum(int num32)
        {
            var strBuilder = new StringBuilder(Text);

            foreach (var line in OperationCore.GetAllRegisters(num32, 10))
            {
                strBuilder.AppendLine(line);
            }

            strBuilder.AppendLine(OperationCore.GetStringOperation(num32));

            Text = strBuilder.ToString();
        }

        public void AppendLine(string line)
        {
            Text = string.Concat(_text, Environment.NewLine, line);
        }

        public SimpleTextEditorViewModel(string initLine)
        {
            _text = initLine + Environment.NewLine;
        }

        public SimpleTextEditorViewModel() : this("")
        { }

        private string _text;
    }
}