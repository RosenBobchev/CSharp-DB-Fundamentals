using System.Xml.Serialization;

namespace ProductShop.Export.Dtos
{
    [XmlType("users")]
    public class UP_UsersDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("user")]
        public UP_UserDto[] Users { get; set; }
    }
}