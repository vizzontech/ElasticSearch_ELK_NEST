using ElasticSearch_ELK_NEST.Service;
using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
    .DefaultIndex("ab_nyc_2019")
    .DisableDirectStreaming(true);

builder.Services.AddSingleton<IElasticClient>(new ElasticClient(settings));
builder.Services.AddScoped<ISearchService, SearchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
