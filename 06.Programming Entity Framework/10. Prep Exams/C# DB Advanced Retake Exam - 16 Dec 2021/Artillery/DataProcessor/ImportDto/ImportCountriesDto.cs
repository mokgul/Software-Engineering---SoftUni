namespace Artillery.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Data;

[XmlType("Country")]
public class ImportCountriesDto
{
    [Required]
    [MinLength(ValidationConstants.CountryNameLengthMin)]
    [MaxLength(ValidationConstants.CountryNameLengthMax)]
    [XmlElement("CountryName")]
    public string CountryName { get; set; }

    [Required]
    [Range(ValidationConstants.CountryArmySizeRangeMin,ValidationConstants.CountryArmySizeRangeMax)]
    [XmlElement("ArmySize")]
    public int ArmySize { get; set; }

}