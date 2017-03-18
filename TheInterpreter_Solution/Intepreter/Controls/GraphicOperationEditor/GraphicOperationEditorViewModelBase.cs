using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace Intepreter.Controls.GraphicOperationEditor
{
    public class GraphicOperationEditorViewModelBase : 
        ViewModelBase
    {
        public virtual object Parameter { get; set; }
    }
}
