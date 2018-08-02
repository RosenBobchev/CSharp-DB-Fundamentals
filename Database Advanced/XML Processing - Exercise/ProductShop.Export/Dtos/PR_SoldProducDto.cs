﻿using System.Xml.Serialization;

namespace ProductShop.Export.Dtos
{
    [XmlType("product")]
    public class PR_SoldProducDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("buyer")]
        public string Buyer { get; set; }
    }
}