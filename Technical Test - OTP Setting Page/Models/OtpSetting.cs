namespace TechTest.Models;

public class OtpSetting
{
    public int Id { get; set; }
    public string ActionCode { get; set; } = string.Empty;
    public string ActionName { get; set; } = string.Empty;
    public bool IsEmailEnabled { get; set; }
    public bool IsWhatsappEnabled { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public record OtpSettingItemVm(
    int Id,
    string ActionCode,
    string ActionName,
    bool IsEmailEnabled,
    bool IsWhatsappEnabled);

public class OtpSettingUpdateItem
{
    public int Id { get; set; }
    public bool IsEmailEnabled { get; set; }
    public bool IsWhatsappEnabled { get; set; }
}

public class OtpSettingUpdateModel
{
    public List<OtpSettingUpdateItem> Items { get; set; } = [];
}
