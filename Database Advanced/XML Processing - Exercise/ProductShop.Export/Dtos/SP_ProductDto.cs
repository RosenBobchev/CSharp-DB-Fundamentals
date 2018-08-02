using System.Xml.Serialization;

namespace ProductShop.Export.Dtos
{
    [XmlType("product")]
    public class SP_ProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}