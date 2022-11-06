using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GroupIS1024.Data;
using Gtt.Uc.EntityFramework;
var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<GroupIS1024Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GroupIS1024Context") ?? throw new InvalidOperationException("Connection string 'GroupIS1024Context' not found.")));
   // builder.Services.AddGttMem<GroupIS1024Context>("7a5f897b-2545-410d-909a-ccb776b288b3");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
