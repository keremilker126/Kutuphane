using System.ComponentModel.DataAnnotations;
using Microsoft.SqlServer.Server;

public class OduncKitap
{
    [Required]
    [Key]
    
    public int Id { get; set; }
    [Required]

    public int KitapId { get; set; }
    [Required]

    public int OgrenciId { get; set; }
    [Required]

    public int SayfaSayisi { get; set; }
    [Required]


    public DateTime AlinmaTarihi { get; set; }
[Required]
    public DateTime GetirilmeTarihi { get; set; }
    [Required]

    public DateTime GetirilmesiIstenenTarih { get; set; }
    
}