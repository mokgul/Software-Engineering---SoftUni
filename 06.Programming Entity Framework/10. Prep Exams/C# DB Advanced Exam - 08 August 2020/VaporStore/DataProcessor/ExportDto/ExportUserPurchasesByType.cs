using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ExportDto;

[XmlType("User")]
public class ExportUserPurchasesByType
{
    [XmlAttribute("username")]
    public string Username { get; set; }

    [XmlArray("Purchases")]
    public ExportPurchaseDto[] Purchases { get; set; }

    [XmlElement("TotalSpent")]
    public decimal TotalSpent { get; set; }

}

[XmlType("Purchase")]
public class ExportPurchaseDto
{
    [XmlElement("Card")]
    public string Card { get; set; }

    [XmlElement("Cvc")]
    public string Cvc { get; set; }

    [XmlElement("Date")]
    public string Date { get; set; }

    [XmlElement("Game")]
    public ExportGameXMLDto Game { get; set; }
}

[XmlType("Game")]
public class ExportGameXMLDto
{
    [XmlAttribute("title")]
    public string Title { get; set; }

    [XmlElement("Genre")]
    public string Genre { get; set; }

    [XmlElement("Price")]
    public decimal Price { get; set; }
}
