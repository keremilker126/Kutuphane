using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kutuphane.Models;
using Microsoft.EntityFrameworkCore;
using Kutuphane.Data;

namespace Kutuphane.Controllers;

public class OgrenciController : Controller
{
    private readonly ILogger<OgrenciController> _logger;
    private readonly UygulamaDbContext _context;
    public OgrenciController(ILogger<OgrenciController> logger, UygulamaDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var ogrenciler = await _context.Ogrenciler.ToListAsync();
        return View(ogrenciler);
    }
    [HttpGet]
    public IActionResult Ekle()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Ekle(Ogrenci ogrenci)
    {
        if (ModelState.IsValid)
        {
            _context.Ogrenciler.Add(ogrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(ogrenci);
    }

    public async Task<IActionResult> Sil(int id)
    {
        var ogrenci = await _context.Ogrenciler.FindAsync(id);
        if (ogrenci != null)
        {
            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Guncelle(int id)
    {
        var ogrenci = await _context.Ogrenciler.FindAsync(id);
        if (ogrenci == null)
        {
            return NotFound();
        }
        return View(ogrenci);
    }
    [HttpPost]
    public async Task<IActionResult> Guncelle (Ogrenci ogrenci)
    {
        var DegistirilenOgrenci =await _context.Ogrenciler.FindAsync(ogrenci.OgrenciId);
        if (DegistirilenOgrenci == null)
        {
            return NotFound();
        }
        DegistirilenOgrenci.OgrenciAdi = ogrenci.OgrenciAdi;
        DegistirilenOgrenci.OgrenciSoyAdi = ogrenci.OgrenciSoyAdi;
        DegistirilenOgrenci.Cinsiyet = ogrenci.Cinsiyet;
        DegistirilenOgrenci.Sinifi = ogrenci.Sinifi;
        DegistirilenOgrenci.TelNo = ogrenci.TelNo;
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }


}
