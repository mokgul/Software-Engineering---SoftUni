using System.Xml.Serialization;

namespace CarDealer.DTOs.Export;

[XmlType("supplier")]
public class ExportLocalSuppliersDto
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("parts-count")]
    public int Count { get; set; }
}