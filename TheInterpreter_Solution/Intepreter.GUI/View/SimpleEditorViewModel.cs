using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Intepreter.GUI.ViewModel;
using Intepreter.GUI.Model.Abstract;

namespace Intepreter.GUI.View
{
    public class SimpleEditorViewModel :
        ViewModelBase, IEditor

    {
        public string Text
        {
            get { return _text; }
            set { UpdateValue(value, ref _text);}
        }

        public SimpleEditorViewModel(string intialText)
        {
            Text = intialText;
        }

        public SimpleEditorViewModel() : this("")
        { }

        public void AppendText(string appendedtext)
        {
            Text = string.Concat(Text, appendedtext);
        }

        private string _text;
    }
}
