namespace TeisterMask.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Data;

[XmlType("Project")]
public class ImportProjectsDto
{
    [Required]
    [MinLength(ValidationConstants.ProjectNameLengthMin)]
    [MaxLength(ValidationConstants.ProjectNameLengthMax)]
    [XmlElement("Name")]
    public string Name { get; set; }

    [Required]
    [XmlElement("OpenDate")]
    public string OpenDate { get; set; }

    [XmlElement("DueDate")]
    public string DueDate { get; set; }

    [XmlArray("Tasks")]
    public ImportTaskDto[] Tasks { get; set; }

}

[XmlType("Task")]
public class ImportTaskDto
{
    [Required]
    [MinLength(ValidationConstants.TaskNameLengthMin)]
    [MaxLength(ValidationConstants.TaskNameLengthMax)]
    [XmlElement("Name")]
    public string Name { get; set; }

    [Required]
    [XmlElement("OpenDate")]
    public string OpenDate { get; set; }

    [Required]
    [XmlElement("DueDate")]
    public string DueDate { get; set; }

    [Required]
    [XmlElement("ExecutionType")]
    public string ExecutionType { get; set; }

    [Required]
    [XmlElement("LabelType")]
    public string LabelType { get; set; }
}