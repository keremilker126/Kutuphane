using Microsoft.EntityFrameworkCore;
using Kutuphane.Models; // Modellerinin olduğu klasörü ekle

namespace Kutuphane.Data
{
    public class UygulamaDbContext : DbContext
    {
        // 1. Yapılandırıcı (Constructor)
        // Program.cs'den gelen bağlantı ayarlarını base sınıfa iletir.
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options)
            : base(options)
        {
        }

        // 2. DbSet Tanımları
        // Buraya eklediğin her DbSet, veritabanında bir TABLOya dönüşür.
        public DbSet<KitapTur> KitapTurlari { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<OduncKitap> OduncKitaplar { get; set; }

        // 3. (Opsiyonel) Model Oluşturma Ayarları
        // Tablo isimlerini özelleştirmek veya varsayılan veriler (Seed Data) eklemek için kullanılır.
       
    }
}