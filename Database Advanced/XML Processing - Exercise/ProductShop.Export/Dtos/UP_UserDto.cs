using System.Xml.Serialization;

namespace ProductShop.Export.Dtos
{
    [XmlType("user")]
    public class UP_UserDto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public string Age { get; set; }

        [XmlElement("sold-products")]
        public UP_SoldProductDto SoldProducts { get; set; }

    }
}