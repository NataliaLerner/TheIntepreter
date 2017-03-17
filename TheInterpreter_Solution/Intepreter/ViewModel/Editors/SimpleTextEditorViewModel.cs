using System;
using System.IO;
using System.Text;
using System.Xml;

using Intepreter.Model.Operations;
using Intepreter.Model.Abstract;
using DevExpress.Mvvm.Xpf;

namespace Intepreter.ViewModel.Editors
{
    public class SimpleTextEditorViewModel :
        DevExpress.Mvvm.ViewModelBase, ISimpleTextEditor
    {
        public string Text
        {
            get { return GetProperty(() => Text); }
            set { SetProperty(() => Text, value); }
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

        public void ClearAll()
        {
            if (Text != "")
                Text = "";
        }


        public SimpleTextEditorViewModel(string initLine)
        {
            if (initLine == null)
            {
                throw new ArgumentNullException(nameof(initLine));
            }

            Text = initLine;
        }

        public SimpleTextEditorViewModel() : this("")
        { }
    }
}