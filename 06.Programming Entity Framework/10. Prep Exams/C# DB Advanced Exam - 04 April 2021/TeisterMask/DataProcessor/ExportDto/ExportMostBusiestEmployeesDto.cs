namespace TeisterMask.DataProcessor.ExportDto;

using Newtonsoft.Json;

public class ExportMostBusiestEmployeesDto
{
    [JsonProperty("Username")]
    public string Username { get; set; }

    [JsonProperty("Tasks")]
    public ExportTaskDto[] Tasks { get; set; }

}

public class ExportTaskDto
{
    [JsonProperty("TaskName")]
    public string TaskName { get; set; }

    [JsonProperty("OpenDate")]
    public string OpenDate { get; set; }

    [JsonProperty("DueDate")]
    public string DueDate { get; set; }

    [JsonProperty("LabelType")]
    public string LabelType { get; set; }

    [JsonProperty("ExecutionType")]
    public string ExecutionType { get; set; }
}