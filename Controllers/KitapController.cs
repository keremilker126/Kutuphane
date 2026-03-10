using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kutuphane.Models;
using Kutuphane.Data;
using Microsoft.EntityFrameworkCore;


namespace Kutuphane.Controllers;

public class KitapController : Controller
{
    private readonly ILogger<KitapController> _logger;
    private readonly UygulamaDbContext _context;
    public KitapController(ILogger<KitapController> logger ,UygulamaDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult>  Index()
    {
        var kitaplar = await _context.Kitaplar.ToListAsync();//Veritabanından kitapları çekiyoruz

        return View(kitaplar);
    }

    [HttpGet]
    public IActionResult Ekle()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Ekle(Kitap kitap)
    {
        if(ModelState.IsValid)
        {
            _context.Kitaplar.Add(kitap);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(kitap);
    }

    public async Task<IActionResult> Sil(int id)
    {
        var kitap = await _context.Kitaplar.FindAsync(id);
        if(kitap != null)
        {
            _context.Kitaplar.Remove(kitap);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Guncelle(int id)
    {
        var kitap = await _context.Kitaplar.FindAsync(id);
        if(kitap != null)
        {
            return View(kitap);
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Guncelle(Kitap kitap)
    {
        if(ModelState.IsValid)
        {
            _context.Kitaplar.Update(kitap);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(kitap);
    }



}
