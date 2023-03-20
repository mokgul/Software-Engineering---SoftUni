using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto;

[XmlType("Prisoner")]
public class ExportPrisonersInboxDto
{
   [XmlElement("Id")]
   public int PrisonerId { get; set; }

   [XmlElement("Name")]
   public string PrisonerName { get; set; }

   [XmlElement("IncarcerationDate")]
   public string IncarcerationDate { get; set; }

   [XmlArray("EncryptedMessages")]
   public ExportMessageDto[] Messages { get; set; }
}

[XmlType("Message")]
public class ExportMessageDto
{
    [XmlElement("Description")]
    public string Description { get; set; }
}