using UCAKBİLETİ.Bussiness.Abstract;
using UCAKBİLETİ.Bussiness.Concrete;
using UCAKBİLETİ.Models;
using UCAKBİLETİ.Models.Abstract;
using UCAKBİLETİ.Models.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// CORS ayarları
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // Angular frontend URL
              .AllowAnyMethod()                    // Tüm HTTP metodlarına izin ver
              .AllowAnyHeader()                    // Tüm headerlara izin ver
              .AllowCredentials();                 // Kimlik doğrulama izinleri
    });
});

// Controller servislerini ekle
builder.Services.AddControllers();

// PostgreSQL için DbContext ayarları
builder.Services.AddDbContext<CustomerDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));  // PostgreSQL bağlantı string'i

// Repository ve Manager servislerini ekle
builder.Services.AddScoped<ITicketRepository<Flight>, FlightRepository>();  // Flight için repository
builder.Services.AddScoped<IServices<Flight>, FlightManager>();            // Flight için manager
builder.Services.AddScoped<ITicketRepository<Customer>, CustomerRepository>();  // Customer için repository
builder.Services.AddScoped<IServices<Customer>, CustomerManager>();           // Customer için manager
builder.Services.AddScoped<ITicketRepository<Reservation>, ReservationRepository>();  // Reservation için repository
builder.Services.AddScoped<IServices<Reservation>, ReservationManager>();     // Reservation için manager

// Swagger ayarları
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// CORS kullanımını aktif et
app.UseCors("CorsPolicy");

// Geliştirme ortamında Swagger UI'yi kullan
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();  // Yetkilendirme için middleware

// API Controllerları mapping et
app.MapControllers();

app.Run();  // Uygulamayı çalıştır
