using System.ComponentModel.DataAnnotations;

public class KitapTur
{
    [Key]
    [Required]
    public int TurId { get; set; }
    [Required]
    public string TurAdi { get; set; }
}