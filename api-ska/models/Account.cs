using System.ComponentModel.DataAnnotations;

namespace api_ska.models;

public class Account
{
    public int id { get; set; }
    [Range(0, 1E+17)]
    public decimal amount { get; set; }
    [Required]
    public string remark { get; set; }
    [Required]
    public DateTime date { get; set; }
}