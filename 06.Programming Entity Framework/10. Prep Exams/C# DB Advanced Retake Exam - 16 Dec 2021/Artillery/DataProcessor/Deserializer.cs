using System.Text;
using Artillery.Data.Models;
using Artillery.DataProcessor.ImportDto;

namespace Artillery.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            ImportCountriesDto[] countries = Deserialize<ImportCountriesDto[]>(xmlString, "Countries");

            StringBuilder sb = new StringBuilder();

            foreach (var country in countries)
            {
                if (!IsValid(country))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country currCountry = new Country()
                {
                    CountryName = country.CountryName,
                    ArmySize = country.ArmySize
                };
                context.Countries.Add(currCountry);
                sb.AppendLine(string.Format(SuccessfulImportCountry, currCountry.CountryName, currCountry.ArmySize));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            ImportManufacturersDto[] manufacturers = Deserialize<ImportManufacturersDto[]>(xmlString, "Manufacturers");

            StringBuilder sb = new StringBuilder();

            foreach (var manf in manufacturers)
            {
                if (!IsValid(manf)
                    || context.Manufacturers.FirstOrDefault(m => m.ManufacturerName == manf.ManufacturerName) != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                Manufacturer manufacturer = new Manufacturer()
                {
                    ManufacturerName = manf.ManufacturerName,
                    Founded = manf.Founded,
                };
                
                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();
                string[] foundedValues = manufacturer.Founded.Split(", ").ToArray();
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName,
                    $"{foundedValues[^2]}, {foundedValues[^1]}"
                   ));
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            return "";
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            return "";
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);
            return dtos;
        }
    }
}