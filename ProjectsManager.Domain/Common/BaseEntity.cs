using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectsManager.Domain.Common
{
    public class BaseEntity
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
    }
}
