using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto;

[XmlType("Gun")]
public class ExportGunsDto
{
    [XmlAttribute("Manufacturer")] 
    public string Manufacturer { get; set; } = null!;

    [XmlAttribute("GunType")]
    public string GunType { get; set; } = null!;

    [XmlAttribute("GunWeight")]
    public int GunWeight { get; set; }

    [XmlAttribute("BarrelLength")]
    public double BarrelLength { get; set; }

    [XmlAttribute("Range")]
    public int Range { get; set; }

    [XmlArray("Countries")]
    public ExportCountryDto[] Countries { get; set; }

}

[XmlType("Country")]
public class ExportCountryDto
{
    [XmlAttribute("Country")]
    public string Country { get; set; }

    [XmlAttribute("ArmySize")]
    public int ArmySize { get; set; }

}