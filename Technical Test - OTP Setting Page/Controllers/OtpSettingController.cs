using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTest.Data;
using TechTest.Models;

namespace TechTest.Controllers;

public class OtpSettingController(AppDbContext db) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var items = await db.OtpSettings
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Select(x => new OtpSettingItemVm(x.Id, x.ActionCode, x.ActionName, x.IsEmailEnabled, x.IsWhatsappEnabled))
            .ToListAsync(ct);

        return View(items);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(OtpSettingUpdateModel? model, CancellationToken ct)
    {
        if (!ModelState.IsValid || model?.Items is not { Count: > 0 })
        {
            return RedirectToAction(nameof(Index));
        }

        var lookup = model.Items
            .GroupBy(i => i.Id)
            .ToDictionary(g => g.Key, g => g.Last());

        var ids = lookup.Keys.ToList();
        var entities = await db.OtpSettings
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(ct);

        var now = DateTime.UtcNow;
        foreach (var entity in entities)
        {
            if (lookup.TryGetValue(entity.Id, out var update) &&
                (entity.IsEmailEnabled != update.IsEmailEnabled ||
                 entity.IsWhatsappEnabled != update.IsWhatsappEnabled))
            {
                entity.IsEmailEnabled = update.IsEmailEnabled;
                entity.IsWhatsappEnabled = update.IsWhatsappEnabled;
                entity.UpdatedAt = now;
            }
        }

        await db.SaveChangesAsync(ct);
        TempData["SuccessMessage"] = "OTP settings updated successfully.";
        return RedirectToAction(nameof(Index));
    }
}
