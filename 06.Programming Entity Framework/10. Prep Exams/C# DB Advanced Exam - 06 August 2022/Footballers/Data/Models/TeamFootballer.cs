namespace Footballers.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class TeamFootballer
{
    public Team Team { get; set; }

    [ForeignKey(nameof(Team))]
    public int TeamId { get; set; }

    public Footballer Footballer { get; set; }

    [ForeignKey(nameof(Footballer))]
    public int FootballerId { get; set; }

}