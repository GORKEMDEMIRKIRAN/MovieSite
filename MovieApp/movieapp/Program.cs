




using Repositories.ServerRepository.Abstract;
using Repositories.ServerRepository.Concrete.EfCore;

// tmdb yolları
using Repositories.TmdbApi.Abstract;// ınterface yolu
using Repositories.TmdbApi.Concrete;// repository yolu


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//AddScoped() metodu, her HTTP isteği için yeni bir servis örneği oluşturur. Bu, servislerin her istekte farklı verilerle çalışmasını sağlar.
builder.Services.AddScoped<IMovieRepository,EfCoreMovieRepository>();
builder.Services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();

// tmdb api kullanmak için "TmdbApi" altındaki abstract,concrete bölümlerini ekleyelim.
builder.Services.AddHttpClient<TmdbRepository>();
builder.Services.AddScoped<ITmdbService,TmdbRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseStaticFiles();

// database veri ekleme
//using movieapp.Data.Concrete.EfCore; yolu ile bağlandı.
SeedDatabase.Seed();


app.UseAuthorization();

app.MapStaticAssets();

// apı controller yönlendirmeyi sağlar.
//app.MapControllers();
// app.MapControllerRoute(
//     name:"tmdb",
//     pattern:"tmdb/{action=Index}/{id?}",
//     defaults: new {controller="Tmdb",action="Index"});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tmdb}/{action=MoviePopular}/{page?}")
    .WithStaticAssets();


app.Run();
