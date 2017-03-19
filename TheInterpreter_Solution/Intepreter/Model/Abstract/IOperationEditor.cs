using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Intepreter.Model.Abstract
{
    public interface IOperationEditor
    {
        /// <summary>
        ///     Создает XmlReader из данных, содержащихся в Editor
        /// </summary>
        XmlReader CreateXmlReader(XmlReaderSettings settings);

        /// <summary>
        ///     Загружает Xml разметку в Editor
        /// </summary>
        /// <param name="markup"></param>
        void LoadXmlMarkup(XmlDocument markup);
    }
}
