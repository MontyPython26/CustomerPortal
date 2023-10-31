using BusinessLogicLayer.LogicServices;
using DataAccessLayer.DataContext;
using DataAccessLayer.DataServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICustomerLogic, CustomerLogic>();
builder.Services.AddTransient<ICustomersDataDAL, CustomersDataDAL>();
builder.Services.AddTransient <IDapperORMHelper, DapperORMHelper>();
builder.Services.AddTransient<IUserDataDAL, UserDataDAL>();
builder.Services.AddTransient<IUserLogic, UserLogic>();




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
