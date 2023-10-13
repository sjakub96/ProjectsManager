using ProjectsManager.Domain.Common;
using System.Xml.Serialization;

namespace ProjectsManager.Domain.Entity
{
    public class Project : BaseEntity
    {
        public Project()
        {

        }

        public Project(int id, string name, int typeId)
        {
            Id = id;
            Name = name;
            TypeId = typeId;
        }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("TypeId")]
        public int TypeId { get; set; }

    }
}
