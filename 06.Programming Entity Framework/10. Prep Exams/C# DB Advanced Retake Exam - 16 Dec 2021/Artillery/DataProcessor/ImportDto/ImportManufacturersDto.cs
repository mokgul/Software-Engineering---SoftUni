namespace Artillery.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Data;

[XmlType("Manufacturer")]
public class ImportManufacturersDto
{
    [Required]
    [MinLength(ValidationConstants.ManufacturerNameLengthMin)]
    [MaxLength(ValidationConstants.ManufacturerNameLengthMax)]
    [XmlElement("ManufacturerName")]
    public string ManufacturerName { get; set; }

    [Required]
    [MinLength(ValidationConstants.ManufacturerFoundedLengthMin)]
    [MaxLength(ValidationConstants.ManufacturerFoundedLengthMax)]
    [XmlElement("Founded")]
    public string Founded { get; set; }

}