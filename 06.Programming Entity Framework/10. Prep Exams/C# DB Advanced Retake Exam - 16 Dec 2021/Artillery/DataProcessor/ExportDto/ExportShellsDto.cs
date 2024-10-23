using Newtonsoft.Json;

namespace Artillery.DataProcessor.ExportDto;

public class ExportShellsDto
{
    [JsonProperty("ShellWeight")]
    public double ShellWeight { get; set; }

    [JsonProperty("Caliber")] 
    public string Caliber { get; set; } = null!;

    [JsonProperty("Guns")]
    public ExportGunForShellDto[] Guns { get; set; }

}

public class ExportGunForShellDto
{
    [JsonProperty("GunType")]
    public string GunType { get; set; } = null!;

    [JsonProperty("GunWeight")]
    public int GunWeight { get; set; }

    [JsonProperty("BarrelLength")]
    public double BarrelLength { get; set; }

    [JsonProperty("Range")] 
    public string Range { get; set; } = null!;

}