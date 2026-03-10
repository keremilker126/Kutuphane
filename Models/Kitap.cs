using System.ComponentModel.DataAnnotations;

public class Kitap
{
    [Key]
    [Required]
    public int KitapId { get; set; }
    [Required]

    public int TurId { get; set; }
    [Required]

    public string KitapAdi { get; set; }
    [Required]

    public string Yazar { get; set; }
    [Required]

    public string Yayinevi { get; set; }
    [Required]

    public short SayfaSayisi { get; set; }
    
}