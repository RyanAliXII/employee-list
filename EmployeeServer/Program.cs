using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

var builder = WebApplication.CreateBuilder(args);

/* 
 Add services to the container.
 Make camel case the default key of json responses.
*/
builder.Services.AddControllersWithViews(options=>{
    options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
}).AddJsonOptions(options=>{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
});
//Configure cors to accept request from specific origin and allow specific headers
var corsPolicyName = "FrontEndCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
    policy  =>
    {
        policy.WithOrigins("http://localhost:5173");
        policy.WithHeaders("Content-Type");
    });
});
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
app.UseCors(corsPolicyName);
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
