using System.Xml.Serialization;

namespace CarDealer.DTOs.Export;

[XmlType("car")]
public class ExportCarsWithTheirPartsDto
{
    [XmlAttribute("make")]
    public string Make { get; set; }

    [XmlAttribute("model")]
    public string Model { get; set; }

    [XmlAttribute("traveled-distance")]
    public long Distance { get; set; }

    [XmlArray("parts")]
    public CarPartDto[] Parts { get; set; }

}

[XmlType("part")]
public class CarPartDto
{
    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("price")]
    public decimal Price { get; set; }
}