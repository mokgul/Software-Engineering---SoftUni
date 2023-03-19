using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto;

[XmlType("Despatcher")]
public class ExportDespatchersWithTheirTrucksDto
{
    [XmlAttribute("TrucksCount")]
    public int TrucksCount { get; set; }

    [XmlElement("DespatcherName")]
    public string DespatcherName { get; set; }

    [XmlArray("Trucks")]
    public TruckXmlDto[] Trucks { get; set; }
}

[XmlType("Truck")]
public class TruckXmlDto
{
    [XmlElement("RegistrationNumber")]
    public string RegistrationNumber { get; set; }

    [XmlElement("Make")]
    public string Make { get; set; } 
}