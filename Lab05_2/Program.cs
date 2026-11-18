using System.Globalization;
using Lab05_2.Services;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    // Thong bao loi mac dinh cua Model Binding -> tieng Viet
    var p = options.ModelBindingMessageProvider;
    p.SetValueMustNotBeNullAccessor(_ => "Vui lòng nhập giá trị cho trường này.");
    p.SetValueIsInvalidAccessor(v => $"Giá trị '{v}' không hợp lệ.");
    p.SetAttemptedValueIsInvalidAccessor((v, f) => $"Giá trị '{v}' không hợp lệ cho trường {f}.");
    p.SetValueMustBeANumberAccessor(f => $"Trường {f} phải là một số hợp lệ (chỉ nhập chữ số).");
    p.SetMissingBindRequiredValueAccessor(f => $"Vui lòng nhập {f}.");
    p.SetMissingKeyOrValueAccessor(() => "Vui lòng nhập giá trị.");
    p.SetUnknownValueIsInvalidAccessor(f => $"Giá trị không hợp lệ cho trường {f}.");
    p.SetNonPropertyAttemptedValueIsInvalidAccessor(v => $"Giá trị '{v}' không hợp lệ.");
    p.SetNonPropertyUnknownValueIsInvalidAccessor(() => "Giá trị không hợp lệ.");
    p.SetNonPropertyValueMustBeANumberAccessor(() => "Giá trị phải là một số hợp lệ.");
});

// Du lieu luu trong bo nho (thay cho CSDL)
builder.Services.AddSingleton<StoreData>();

var app = builder.Build();

// Dung culture co dinh de dau thap phan la dau cham, tranh loi khi nhap so
var culture = new CultureInfo("en-US");
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture),
    SupportedCultures = new[] { culture },
    SupportedUICultures = new[] { culture }
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
