using System.ComponentModel.DataAnnotations;

public class Ogrenci
{
    [Key]
    [Required]

    public int OgrenciId { get; set; }
    [Required]

    public string OgrenciAdi { get; set; }
    [Required]
    
    public string OgrenciSoyAdi { get; set; }
    [Required]

    public string Cinsiyet { get; set; }
    [Required]


    public byte Sinifi { get; set; }


    public string? TelNo { get; set; }

    
}