using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Intepreter.Model
{
    public class Node
    {
        public int Id { get; set; }
        public XElement Element { get; set; }
    }
}
