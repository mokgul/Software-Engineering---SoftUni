using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto
{
    public class ImportGunsDto
    {   
        //Taken from Alex cause for some reason mine does not work even though its pretty much the same
        public int ManufacturerId { get; set; }
                
        [Range(100, 1_350_000)]
        public int GunWeight { get; set; }
                
        [Range(2.00, 35.00)]
        public double BarrelLength { get; set; }
        
        public int? NumberBuild { get; set; }
        
        [Range(1, 100_000)]
        public int Range { get; set; }
        
        public string GunType { get; set; }
        
        public int ShellId { get; set; }
        
        public ImportCountryIdsDto[] Countries { get; set; }
    }

    public class ImportCountryIdsDto
    {
        public int Id { get; set; }
    }
}