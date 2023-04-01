using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto;

[XmlType("Creator")]
public class ExportCreatorsWithTheirBoardgamesDto
{
    [XmlAttribute("BoardgamesCount")]
    public int BoardgamesCount { get; set; }

    [XmlElement("CreatorName")]
    public string CreatorName { get; set; }

    [XmlArray("Boardgames")]
    public ExportBoardgameCreatorDto[] Boardgames { get; set; }

}

[XmlType("Boardgame")]
public class ExportBoardgameCreatorDto
{
    [XmlElement("BoardgameName")]
    public string BoardgameName { get; set; }

    [XmlElement("BoardgameYearPublished")]
    public int BoardgameYearPublished { get; set; }
}