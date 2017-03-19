using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Xml;
using System.Xml.Linq;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Intepreter.Behavior;
using Intepreter.Model.Abstract;

namespace Intepreter.Controls.GraphicOperationEditor
{
    public class GraphicOperationEditorViewModel : 
        ViewModelBase, IOperationEditor, IDropable
    {
        public Type DataType { get; }

        public XmlDataProvider XmlData
        {
            get { return GetProperty(() => XmlData); }
            set { SetProperty(() => value, XmlData); }
        }

        public GraphicOperationEditorViewModel()
        {
            XmlData = new XmlDataProvider
            {
                XPath = "File"
            };
        }

        public XmlReader CreateXmlReader(XmlReaderSettings settings)
        {
            throw new NotImplementedException();
        }

        public void LoadXmlMarkup(XmlDocument markup)
        {
            throw new NotImplementedException();
        }

        public void Drop(object data, int index = -1)
        {
            throw new NotImplementedException();
        }

        private void XmlMarkupChangedCallBack()
        {
            
        }

    }
}
