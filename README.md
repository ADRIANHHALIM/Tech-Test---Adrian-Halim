# Tech Test - Adrian Halim

This repository contains the technical test submission by **Adrian Halim**, consisting of an ASP.NET Core MVC OTP Setting application, database scripts, and solutions for the written test sections.

---

## Repository Structure

```
.
├── Technical Test - OTP Setting Page/
│   ├── Controllers/             # OtpSettingController
│   ├── Data/                    # AppDbContext (EF Core)
│   ├── Models/                  # OtpSetting domain & view models
│   ├── Views/                   # Razor Views (OtpSetting/Index, Layout)
│   ├── Written Test/            # Solutions for written test sections
│   │   ├── 1_SQL.sql            # SQL queries & atomic CRUD output
│   │   ├── 2_JavaScript.js      # JS bitwise logic & prototype extension
│   │   └── 3_CSharp.cs          # OOP properties & reference type analysis
│   ├── appsettings.json         # Configuration (SQLite & SQL Server connection strings)
│   ├── otp_setting.sql          # T-SQL table creation, seed data & stored procedure
│   ├── otpsetting.db            # Pre-seeded SQLite database for zero-config local run
│   └── TechTest.csproj          # ASP.NET Core project file (.NET 8/9)
├── Technical Test - Quiz Test.pdf # Original quiz test reference document
└── .gitignore                   # Standard .NET & macOS ignore rules
```

---

## 1. OTP Setting Page (Web Application)

### Technologies
- **Framework**: ASP.NET Core MVC
- **ORM**: Entity Framework Core
- **Database Support**: Dual-mode (SQLite by default for zero-setup local execution; SQL Server supported via connection string)
- **Frontend**: Clean semantic HTML5, responsive CSS layout, anti-forgery protection

### Getting Started

1. Navigate to the project directory:
   ```bash
   cd "Technical Test - OTP Setting Page"
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

3. Open your browser and navigate to `http://localhost:5000` (or the port displayed in the console).

---

## 2. Written Test Solutions

The solutions to the written quiz can be found under `Technical Test - OTP Setting Page/Written Test/`:
- **`1_SQL.sql`**: Duplicate city search query and atomic CRUD statement using SQL Server `OUTPUT INTO`.
- **`2_JavaScript.js`**: Bitwise shift vs repeated addition, and custom `String.prototype.repeat` implementation.
- **`3_CSharp.cs`**: OOP explicit getter/setter implementation and reference type memory behavior explanation.
