using System.Xml.Serialization;

namespace ProductShop.Export.Dtos
{
    [XmlType("user")]
    public class SP_UserDto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlArray("sold-products")]
        public SP_ProductDto[] SoldProducts { get; set; }
    }
}