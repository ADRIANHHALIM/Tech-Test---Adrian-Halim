using Microsoft.EntityFrameworkCore;
using TechTest.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var isSqlServer = !string.IsNullOrWhiteSpace(connectionString) &&
        (connectionString.Contains("Server=", StringComparison.OrdinalIgnoreCase) ||
         connectionString.Contains("Initial Catalog=", StringComparison.OrdinalIgnoreCase) ||
         connectionString.Contains("Database=", StringComparison.OrdinalIgnoreCase));

    if (isSqlServer)
    {
        options.UseSqlServer(connectionString);
    }
    else
    {
        var sqliteConn = string.IsNullOrWhiteSpace(connectionString)
            ? "Data Source=otpsetting.db"
            : connectionString;
        options.UseSqlite(sqliteConn);
    }
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/OtpSetting/Index");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=OtpSetting}/{action=Index}/{id?}");

app.Run();
