using System;
using System.IO;
using System.Xml;
using Intepreter.Model.Operations;
using Intepreter.ViewModel.Editors;

namespace Intepreter.Service
{
    public class OperationPerfomerService
    {
        public void SyncEditorWithOutput(SimpleTextEditorViewModel editor, SimpleTextEditorViewModel output)
        {
            if (editor == null)
            {
                throw new ArgumentNullException(nameof(editor));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var splitedOperations = editor.Text.Split(';');
        }

        public void PerformAll(SimpleTextEditorViewModel editor, SimpleTextEditorViewModel output)
        {
            try
            {
                var num32 = 0;
                var registerIndex = 1;
                var tempNum32 = 0;

                using (var reader = XmlReader.Create(new StringReader(editor.Text)))
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            
                        }
                    }
                }
            }
            catch (XmlException e)
            {
                output.Text = e.Message;
                return;
            }
        }

        public string Perform(XmlNode node)
        {
            try
            {
            }
            catch (XmlException e)
            {
                return e.Message;
            }

            return "";
        }

        private const string RegisterString =  "Register";
        private const string NumberString =    "Number";
        private const string OperationString = "Operation";
    }
}