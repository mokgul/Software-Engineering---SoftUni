using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Artillery.Data;

namespace Artillery.DataProcessor.ImportDto;

[XmlType("Shell")]
public class ImportShellsDto
{
    [Required]
    [Range(ValidationConstants.ShellWeightValueMin, ValidationConstants.ShellWeightValueMax)]
    [XmlElement("ShellWeight")]
    public double ShellWeight { get; set; }

    [Required]
    [MinLength(ValidationConstants.ShellCaliberSizeMin)]
    [MaxLength(ValidationConstants.ShellCaliberSizeMax)]
    [XmlElement("Caliber")]
    public string Caliber { get; set; } = null!;

}