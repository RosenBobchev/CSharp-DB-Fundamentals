using System.Xml.Serialization;

namespace ProductShop.Export.Dtos
{
    [XmlType("sold-products")]
    public class UP_SoldProductDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("product")]
        public UP_ProductDto[] Product { get; set; }
    }
}