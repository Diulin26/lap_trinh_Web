using Microsoft.EntityFrameworkCore;
using LeThiDieuLinh_241230775.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    // thông báo khi nhập chữ vào ô NguyenGia (dùng ở Câu 5)
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(_ => "Nguyên giá phải là số");
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((_, _) => "Nguyên giá phải là số");
});

builder.Services.AddDbContext<QLTaiSanContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("QLTaiSan")));
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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
