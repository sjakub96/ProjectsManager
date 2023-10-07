using ProjectsManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectsManager.Domain.Entity
{
    public class Project : BaseEntity
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("TypeId")]
        public int TypeId { get; set; }


        public Project()
        {

        }
        public Project(int id, string name, int typeId)
        {
            Id = id;
            Name = name;
            TypeId = typeId;
        }
    }
}
