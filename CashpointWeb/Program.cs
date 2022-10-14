using CashpointWeb.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.RegisterPagesServices();
builder.Services.RegisterCore();
builder.Services.RegisterDAL();
builder.Services.RegisterValidators();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
