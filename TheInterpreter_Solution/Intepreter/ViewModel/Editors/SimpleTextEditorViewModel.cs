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
            if (num32 < 0)
            {
                throw new ArgumentException("32-х разрядное число не может быть меньше нуля", nameof(num32));
            }

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
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            Text = string.Concat(Text, Environment.NewLine, line);
        }

        public SimpleTextEditorViewModel(string initLine)
        {
            if (initLine == null)
            {
                throw new ArgumentNullException(nameof(initLine));
            }

            _text = initLine + Environment.NewLine;
        }

        public SimpleTextEditorViewModel() : this("")
        { }

        public void ClearAll()
        {
            if (Text != "\r\n")
                Text = "\r\n";
        }

        private string _text;
    }
}