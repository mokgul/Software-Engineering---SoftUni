using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Footballers.Data;

namespace Footballers.DataProcessor.ImportDto;

[XmlType("Coach")]
public class ImportCoachesDto
{
    [Required]
    [XmlElement("Name")]
    [MinLength(ValidationConstants.CoachNameLengthMin)]
    [MaxLength(ValidationConstants.CoachNameLengthMax)]
    public string Name { get; set; }

    [Required]
    [XmlElement("Nationality")]
    public string Nationality { get; set; }

    [Required]
    [XmlArray("Footballers")]
    public ImportFootballerDto[] Footballers { get; set; }

}
[XmlType("Footballer")]
public class ImportFootballerDto
{
    [Required]
    [XmlElement("Name")]
    [MinLength(ValidationConstants.FootballerNameLengthMin)]
    [MaxLength(ValidationConstants.FootballerNameLengthMax)]
    public string Name { get; set; }

    [Required]
    [XmlElement("ContractStartDate")]
    public string ContractStartDate { get; set; }

    [Required]
    [XmlElement("ContractEndDate")]
    public string ContractEndDate { get; set; }

    [Required]
    [XmlElement("BestSkillType")]
    public string BestSkillType { get; set; }

    [Required]
    [XmlElement("PositionType")]
    public string PositionType { get; set; }

}