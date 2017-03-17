using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Intepreter.Model.Abstract;

namespace Intepreter.ViewModel.Editors
{
    public class OperationTextEditorViewModel :
        SimpleTextEditorViewModel, IEditor
    {
        public XmlReader CreateXmlReader(XmlReaderSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            return XmlReader.Create(new StringReader(this.Text), settings);
        }

        public void LoadXmlMarkup(XDocument markup)
        {
            if (markup == null)
            {
                throw new ArgumentNullException(nameof(markup));    
            }

            this.Text = markup.ToString();
        }
    }
}
