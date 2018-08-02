using System.Xml.Serialization;

namespace ProductShop.Export.Dtos
{
    [XmlType("product")]
    public class UP_ProductDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}