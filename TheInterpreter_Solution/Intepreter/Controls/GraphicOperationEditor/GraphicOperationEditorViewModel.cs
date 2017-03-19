using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Data;
using System.Xml;

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
            set { SetProperty(() => XmlData, value); }
        }

        public GraphicOperationEditorViewModel()
        {
            XmlData = new XmlDataProvider();
        }

        public XmlReader CreateXmlReader(XmlReaderSettings settings)
        { 
            return XmlReader.Create(new StringReader(XmlData.Document.OuterXml));
        }

        public void LoadXmlMarkup(XmlDocument markup)
        {
            var testElem = markup.CreateElement("Test");
            XmlData.Document = markup;
        }

        public void Drop(object data, int index = -1)
        {
            throw new NotImplementedException();
        }

        public XmlDocument UpdateXmlMarkup()
        {
            throw new NotImplementedException();
        }
    }
}
