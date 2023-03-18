using System.Xml.Serialization;

namespace CarDealer.DTOs.Export;

[XmlType("sale")]
public class ExportSalesWithDiscountDto
{
    [XmlElement("car")]
    public CarSalesNoDiscountDto CarSalesNoDiscountDto { get; set; }

    [XmlElement("discount")]
    public int Discount { get; set; }

    [XmlElement("customer-name")]
    public string CustomerName { get; set; }

    [XmlElement("price")]
    public decimal Price { get; set; }

    [XmlElement("price-with-discount")]
    public double PriceWithDiscount { get; set; }
}

[XmlType("car")]
public class CarSalesNoDiscountDto
{
    [XmlAttribute("make")]
    public string Make { get; set; }

    [XmlAttribute("model")]
    public string Model { get; set; }

    [XmlAttribute("traveled-distance")]
    public long Distance { get; set; }
}