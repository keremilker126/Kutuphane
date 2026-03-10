using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kutuphane.Models;
using Kutuphane.Data;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Controllers;

public class OduncKitapController : Controller
{
    private readonly ILogger<OduncKitapController> _logger;
    private readonly UygulamaDbContext _context;
    public OduncKitapController(ILogger<OduncKitapController> logger, UygulamaDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var oduncKitaplar = await _context.OduncKitaplar.ToListAsync();
        return View(oduncKitaplar);
    }
    [HttpGet]
    public async Task<IActionResult> Ekle()
    {
        var kitaplar = await _context.Kitaplar.ToListAsync();
        var ogrenciler = await _context.Ogrenciler.ToListAsync();

        ViewBag.Kitaplar = kitaplar;
        ViewBag.Ogrenciler = ogrenciler;

        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Ekle(OduncKitap oduncKitap)
    {
        if (ModelState.IsValid)
        {
            _context.OduncKitaplar.Add(oduncKitap);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(oduncKitap);
    }

    public async Task<IActionResult> Sil(int id)
    {
        var oduncKitap = await _context.OduncKitaplar.FindAsync(id);
        if (oduncKitap != null)
        {
            _context.OduncKitaplar.Remove(oduncKitap);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Guncelle(int id)
    {
        var oduncKitap = await _context.OduncKitaplar.FindAsync(id);
        if (oduncKitap == null)
        {
            return NotFound();
        }

        var kitaplar = await _context.Kitaplar.ToListAsync();
        var ogrenciler = await _context.Ogrenciler.ToListAsync();

        ViewBag.Kitaplar = kitaplar;
        ViewBag.Ogrenciler = ogrenciler;

        return View(oduncKitap);
    }
    [HttpPost]
    public async Task<IActionResult> Guncelle(int id, OduncKitap oduncKitap)
    {
        if (id != oduncKitap.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(oduncKitap);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(oduncKitap);
    }
    [HttpGet]
    public async Task<IActionResult> KitabiAl(int id)
    {
        var oduncKitap = await _context.OduncKitaplar.FindAsync(id);
        if (oduncKitap == null)
        {
            return NotFound();
        }

         var kitaplar = await _context.Kitaplar.ToListAsync();
         var ogrenciler = await _context.Ogrenciler.ToListAsync();

         ViewBag.Kitaplar = kitaplar;
         ViewBag.Ogrenciler = ogrenciler;

        return View(oduncKitap);
    }

    [HttpPost]
    public async Task<IActionResult> KitabiAl(OduncKitap oduncKitap)
    {
        if (ModelState.IsValid)
        {
            var mevcutOdunc = await _context.OduncKitaplar.FindAsync(oduncKitap.Id);
            if (mevcutOdunc != null)
            {
                mevcutOdunc.GetirilmeTarihi = DateTime.Now;
                _context.Update(mevcutOdunc);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        return View(oduncKitap);
    }

}
