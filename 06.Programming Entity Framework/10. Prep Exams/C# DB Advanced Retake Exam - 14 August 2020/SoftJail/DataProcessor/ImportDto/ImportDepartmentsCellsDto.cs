namespace SoftJail.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

using Data.Models;

public class ImportDepartmentsCellsDto
{
    [Required]
    [MinLength(ValidationConstants.DepartmentNameMinLength)]
    [MaxLength(ValidationConstants.DepartmentNameMaxLength)]
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Cells")]
    public CellImportDto[] Cells { get; set; }
}

public class CellImportDto
{
    [Required]
    [Range(ValidationConstants.CellNumberValueRangeMin,ValidationConstants.CellNumberValueRangeMax)]
    [JsonProperty("CellNumber")]
    public int CellNumber { get; set; }

    [Required]
    [JsonProperty("HasWindow")]
    public bool HasWindow { get; set; }
}