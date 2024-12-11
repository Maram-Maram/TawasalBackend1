using Microsoft.EntityFrameworkCore; // التأكد من استيراد المساحة النطاقية الصحيحة
using TawasalBackend1.Data; // المساحة النطاقية لـ ApplicationDBContext

var builder = WebApplication.CreateBuilder(args);

// تسجيل خدمات الـ DbContext
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// تسجيل الـ DbContext باستخدام AddDbContext
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
    }

    options.UseSqlServer(connectionString); // التأكد من صحة استدعاء UseSqlServer
});

var app = builder.Build();

// تكوين مسار التطبيق
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Set the new page as the startup page

// Set Home page as the default startup page
// app.MapFallbackToPage("/Home");
app.Run();
