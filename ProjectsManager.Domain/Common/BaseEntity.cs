using System.Xml.Serialization;

namespace ProjectsManager.Domain.Common
{
    public class BaseEntity
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
    }
}
