using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;
using Intepreter.Model.Abstract;

namespace Intepreter.ViewModel.Editors
{
    public class OperationTextEditorViewModel :
        SimpleTextEditorViewModel, IOperationEditor
    {
        public XmlReader CreateXmlReader(XmlReaderSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            return XmlReader.Create(new StringReader(this.Text), settings);
        }

        public void LoadXmlMarkup(XmlDocument markup)
        {
            if (markup == null)
            {
                throw new ArgumentNullException(nameof(markup));
            }

            using (var strWriter = new StringWriter())
            {
                using (var xmlWriter = new XmlTextWriter(strWriter))
                {
                    xmlWriter.Formatting = Formatting.Indented;
                    markup.WriteTo(xmlWriter);
                    this.Text = strWriter.ToString();
                }
            }
        }
    }
}
