using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using SoftJail.Data.Models;

namespace SoftJail.DataProcessor.ImportDto;

[XmlType("Officer")]
public class ImportOfficersAndPrisonersDto
{
    [Required]
    [MinLength(ValidationConstants.OfficerFullNameMinLength)]
    [MaxLength(ValidationConstants.OfficerFullNameMaxLength)]
    [XmlElement("Name")]
    public string FullName { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    [XmlElement("Money")]
    public decimal Salary { get; set; }

    [Required]
    [XmlElement("Position")]
    public string Position { get; set; }

    [Required]
    [XmlElement("Weapon")]
    public string Weapon { get; set; }

    [Required]
    [XmlElement("DepartmentId")]
    public int DepartmendId { get; set; }

    [XmlArray("Prisoners")]
    public ImportPrisonerDto[] PrisonerIds { get; set; }
}

[XmlType("Prisoner")]
public class ImportPrisonerDto
{
    [XmlAttribute("id")]
    public int Id { get; set; }
}