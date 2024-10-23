using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Data;

namespace Theatre.DataProcessor.ImportDto;

[XmlType("Play")]
public class ImportPlaysDto
{
    [Required]
    [MinLength(ValidationConstants.PlayTitleLengthMin)]
    [MaxLength(ValidationConstants.PlayTitleLengthMax)]
    [XmlElement("Title")]
    public string Title { get; set; }

    [Required]
    [XmlElement("Duration")]
    public string Duration { get; set; }

    [Required]
    [Range(0.00, ValidationConstants.PlayRatingRangeMax)]
    [XmlElement("Raiting")]
    public double Rating { get; set; }

    [Required]
    [XmlElement("Genre")]
    public string Genre { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PlayDescriptionLengthMax)]
    [XmlElement("Description")]
    public string Description { get; set; }

    [Required]
    [MinLength(ValidationConstants.PlayScreenwriterNameMin)]
    [MaxLength(ValidationConstants.PlayScreenwriterNameMax)]
    [XmlElement("Screenwriter")]
    public string Screenwriter { get; set; }
}