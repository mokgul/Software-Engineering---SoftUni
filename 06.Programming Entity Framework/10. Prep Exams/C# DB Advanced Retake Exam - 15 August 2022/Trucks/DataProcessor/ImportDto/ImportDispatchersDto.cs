using System.ComponentModel.DataAnnotations;
using Trucks.Data;

namespace Trucks.DataProcessor.ImportDto;

using System.Xml.Serialization;

[XmlType("Despatcher")]
public class ImportDispatchersDto
{
    [Required]
    [MinLength(ValidationConstants.DespatcherNameMinLength)]
    [MaxLength(ValidationConstants.DespatcherNameMaxLength)]
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Position")]
    public string Position { get; set; }

    [XmlArray("Trucks")]
    public TruckDto[] Trucks { get; set; }
}

[XmlType("Truck")]
public class TruckDto
{
    [Required]
    [StringLength(ValidationConstants.RegistrationNumberLength)]
    [RegularExpression(@"[A-Z]{2}\d{4}[A-Z]{2}")]
    [XmlElement("RegistrationNumber")]
    public string RegistrationNumber { get; set; }

    [Required]
    [StringLength(ValidationConstants.VinNumberLength)]
    [XmlElement("VinNumber")]
    public string VinNumber { get; set; }

    [Range(ValidationConstants.TankCapacityMinRange, ValidationConstants.TankCapacityMaxRange)]
    [XmlElement("TankCapacity")]
    public int TankCapacity { get; set; }

    [Range(ValidationConstants.CargoCapacityMinRange, ValidationConstants.CargoCapacityMaxRange)]
    [XmlElement("CargoCapacity")]
    public int CargoCapacity { get; set; }

    [Required]
    [Range(ValidationConstants.CategoryTypeRangeValueMin, ValidationConstants.CategoryTypeRangeValueMax)]
    [XmlElement("CategoryType")]
    public int CategoryType { get; set; }

    [Required]
    [Range(ValidationConstants.MakeTypeRangeValueMin, ValidationConstants.MakeTypeRangeValueMax)]
    [XmlElement("MakeType")]
    public int MakeType { get; set; }

}