using SavioWeb.Config;
var builder = WebApplication.CreateBuilder(args);
var env = builder.Configuration["Environment"];
// Add services to the container.
builder.Services.AddScoped<IApiConfigProvider, ApiConfigProvider>();
builder.Services.AddControllersWithViews();

// Only set URLs if running on Render (where PORT env var is set)
var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(port))
{
    builder.WebHost.UseUrls($"http://*:{port}");
}

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Common middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Route config
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Transaction}/{action=TransactionList}");

app.Run();
