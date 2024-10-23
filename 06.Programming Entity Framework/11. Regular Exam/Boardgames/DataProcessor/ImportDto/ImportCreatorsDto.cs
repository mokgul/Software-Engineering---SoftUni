namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Data;

[XmlType("Creator")]
public class ImportCreatorsDto
{
    [Required]
    [MinLength(ValidationConstants.CreatorFirstNameLengthMin)]
    [MaxLength(ValidationConstants.CreatorFirstNameLengthMax)]
    [XmlElement("FirstName")]
    public string FirstName { get; set; } = null!;

    [Required]
    [MinLength(ValidationConstants.CreatorLastNameLengthMin)]
    [MaxLength(ValidationConstants.CreatorLastNameLengthMax)]
    [XmlElement("LastName")]
    public string LastName { get; set; } = null!;

    [XmlArray("Boardgames")]
    public ImportBoardgameDto[] Boardgames { get; set; }

}

[XmlType("Boardgame")]
public class ImportBoardgameDto
{
    [Required]
    [MinLength(ValidationConstants.BoardgameNameLengthMin)]
    [MaxLength(ValidationConstants.BoardgameNameLengthMax)]
    [XmlElement("Name")]
    public string Name { get; set; } = null!;

    [Required]
    [Range(ValidationConstants.BoardgameRatingValueMin,ValidationConstants.BoardgameRatingValueMax)]
    [XmlElement("Rating")]
    public double Rating { get; set; }

    [Required]
    [Range(ValidationConstants.BoardgameYearMin, ValidationConstants.BoardgameYearMax)]
    [XmlElement("YearPublished")]
    public int YearPublished { get; set; }

    [Required]
    [XmlElement("CategoryType")]
    public string CategoryType { get; set; } = null!;

    [Required]
    [XmlElement("Mechanics")]
    public string Mechanics { get; set; } = null!;
}