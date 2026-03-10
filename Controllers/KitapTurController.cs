using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kutuphane.Models;
using Kutuphane.Data;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Controllers;

public class KitapTurController : Controller
{
    private readonly ILogger<KitapTurController> _logger;// Logger sınıfı için bir değişken tanımlıyoruz// Logger, uygulamanın çalışma zamanında oluşan olayları kaydetmek için kullanılır. Bu, hata ayıklama ve uygulama performansını izlemek için önemlidir.
    private readonly UygulamaDbContext _context;// Veritabanı context'i sınıf düzeyinde bir değişken olarak tanımlıyoruz

    public KitapTurController(ILogger<KitapTurController> logger, UygulamaDbContext context)// Dependency Injection ile logger ve veritabanı context'i alıyoruz
    {
        _logger = logger;// Veritabanı context'ini sınıf düzeyinde bir değişkene atıyoruz
        _context = context;// Logger'ı sınıf düzeyinde bir değişkene atıyoruz
    }


    public async Task<IActionResult>  Index()// Kitap türlerini listelemek için Index action'ı oluşturuyoruz
    {
        var kitapTurleri = await _context.KitapTurlari.ToListAsync();// Veritabanından kitap türlerini asenkron      çekiyoruz
        return View(kitapTurleri);
    }

    [HttpGet]
    public IActionResult Ekle()// Yeni kitap türü eklemek için Create action'ı oluşturuyoruz
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Ekle(KitapTur kitapTur)// Formdan gelen kitap
    {
    
        _context.KitapTurlari.Add(kitapTur);// Veritabanına yeni kitap türünü ekliyoruz
        await _context.SaveChangesAsync();// Değişiklikleri veritabanına kaydediyoruz
        return RedirectToAction("Index");// Index action'ına yönlendiriyoruz
    }


    public async Task<IActionResult> Sil(int id)
    {
        var kitapTur = await _context.KitapTurlari.FindAsync(id);// Veritabanından silinecek kitap türünü buluyoruz.
        if (kitapTur == null)
        {
            return NotFound();
        }

        _context.KitapTurlari.Remove(kitapTur);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Guncelle(int id)
    {
        var kitapTur = await _context.KitapTurlari.FindAsync(id);// Veritabanından güncellenecek kitap türünü buluyoruz.
        if (kitapTur == null)
        {
            return NotFound();
        }

        return View(kitapTur);
        
    }

    [HttpPost]
    public async Task<IActionResult> Guncelle(KitapTur kitapTur)
    {
        var mevcutKitapTur = await _context.KitapTurlari.FindAsync(kitapTur.TurId);// Veritabanından güncellenecek kitap türünü buluyoruz.
        if (mevcutKitapTur == null)
        {
            return NotFound();
        }
        else
        {
            mevcutKitapTur.TurAdi = kitapTur.TurAdi;// Güncellenen kitap türünün adını mevcut kitap türüne atıyoruz.
            _context.KitapTurlari.Update(mevcutKitapTur);// Veritabanında güncellenen kitap türünü işaretliyoruz.
            await _context.SaveChangesAsync();// Değişiklikleri veritabanına kaydediyoruz.
            return RedirectToAction("Index");// Index action'ına yönlendiriyoruz.
        }
    }
}
