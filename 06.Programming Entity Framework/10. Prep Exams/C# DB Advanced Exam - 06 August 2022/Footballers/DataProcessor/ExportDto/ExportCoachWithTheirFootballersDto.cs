using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto;

[XmlType("Coach")]
public class ExportCoachWithTheirFootballersDto
{
    [XmlAttribute("FootballersCount")]
    public int Count { get; set; }

    [XmlElement("CoachName")]
    public string CoachName { get; set; }

    [XmlArray("Footballers")]
    public ExportFootballerForCoachDto[] Footballers { get; set; }
}

[XmlType("Footballer")]
public class ExportFootballerForCoachDto
{
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Position")]
    public string Position { get; set; }
}