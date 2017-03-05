using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intepreter.GUI.View;

namespace Intepreter.GUI.ViewModel
{
    internal class MainViewModel :
        ViewModelBase
    {
        #region Properties

        #endregion


        public SimpleEditorViewModel testEditor { get; set; } = new SimpleEditorViewModel("Hello, World!");

        public MainViewModel()
        {
            testEditor.AppendText(" Append");
        }
    }
}
