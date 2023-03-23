using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ImportDto;

[XmlType("Purchase")]
public class ImportPurchasesDto
{
    [Required]
    [XmlAttribute("title")]
    public string Title { get; set; }

    [Required]
    [XmlElement("Type")]
    public string PurchaseType { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
    [XmlElement("Key")]
    public string ProductKey { get; set; }

    [Required]
    [XmlElement("Card")]
    public string Card { get; set; }

    [Required]
    [XmlElement("Date")]
    public string Date { get; set; }
}