namespace VaporStore.Data.Models;

using System.ComponentModel.DataAnnotations;

public class User
{
    public User()
    {
        this.Cards = new HashSet<Card>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public int Age { get; set; }

    public virtual ICollection<Card> Cards { get; set; }

}