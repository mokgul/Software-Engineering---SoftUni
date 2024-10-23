namespace P03_SalesDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Store
{
    public Store()
    {
        Sales = new HashSet<Sale>();
    }

    [Key]
    public int StoreId { get; set; }

    [MaxLength(ValidationConstants.MaxLengthStoreName)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; }

}