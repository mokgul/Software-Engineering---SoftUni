using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor;

using Newtonsoft.Json;

using ExportDto;
using Data;

public class Serializer
{
    public static string ExportShells(ArtilleryContext context, double shellWeight)
    {

        var shells = context.Shells
            .Where(s => s.ShellWeight > shellWeight)
            .ToArray()
            .Select(s => new ExportShellsDto()
            {
                ShellWeight = s.ShellWeight,
                Caliber = s.Caliber,
                Guns = s.Guns
                    .Where(g => g.GunType.ToString() == "AntiAircraftGun")
                    .Select(g => new ExportGunForShellDto()
                    {
                        GunType = g.GunType.ToString(),
                        GunWeight = g.GunWeight,
                        BarrelLength = g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range",
                    })
                    .OrderByDescending(g => g.GunWeight)
                    .ToArray()
            })
            .OrderBy(s => s.ShellWeight)
            .ToArray();

        return JsonConvert.SerializeObject(shells, Formatting.Indented);
    }

    public static string ExportGuns(ArtilleryContext context, string manufacturer)
    {
        var guns = context.Guns
            .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
            .ToArray()
            .Select(g => new ExportGunsDto
            {
                Manufacturer = g.Manufacturer.ManufacturerName,
                GunType = g.GunType.ToString(),
                GunWeight = g.GunWeight,
                BarrelLength = g.BarrelLength,
                Range = g.Range,
                Countries = g.CountriesGuns
                    .Where(c => c.Country.ArmySize > 4_500_000)
                    .Select(c => new ExportCountryDto()
                    {
                        Country = c.Country.CountryName,
                        ArmySize = c.Country.ArmySize
                    })
                    .OrderBy(a => a.ArmySize)
                    .ToArray()
            })
            .OrderBy(b => b.BarrelLength)
            .ToArray();

        return Serialize(guns, "Guns");
    }

    private static string Serialize<T>(T dataTransferObjects, string xmlRootAttributeName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

        StringBuilder sb = new StringBuilder();
        using var write = new StringWriter(sb);

        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
        xmlNamespaces.Add(string.Empty, string.Empty);

        serializer.Serialize(write, dataTransferObjects, xmlNamespaces);

        return sb.ToString();
    }
}

