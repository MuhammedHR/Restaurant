using Microsoft.AspNetCore.Identity;
using System.Configuration;
using System;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using Restaurant.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(x => x.EnableEndpointRouting = false);

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.Configure<IdentityOptions>(x =>

{

    x.Password.RequireDigit = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireUppercase = false;
    x.Password.RequiredLength = 3;
    x.Password.RequireNonAlphanumeric = false;




});
builder.Services.AddScoped<IRepository<MasterCategoryMenu>, dbMasterCategoryMenuRepository>();
builder.Services.AddScoped<IRepository<MasterContactUsInformation>, dbMasterContactUsInformationRepository>();
builder.Services.AddScoped<IRepository<MasterItemMenu>, dbMasterItemMenuRepository>();
builder.Services.AddScoped<IRepository<MasterMenu>, dbMasterMenuRepository>();
builder.Services.AddScoped<IRepository<MasterOffer>, dbMasterOfferRepository>();
builder.Services.AddScoped<IRepository<MasterPartner>, dbMasterPartnerRepository>();
builder.Services.AddScoped<IRepository<MasterService>, dbMasterServiceRepository>();
builder.Services.AddScoped<IRepository<MasterSlider>, dbMasterSliderRepository>();
builder.Services.AddScoped<IRepository<MasterSocialMedium>, dbMasterSocialMediumRepository>();
builder.Services.AddScoped<IRepository<MasterWorkingHour>, dbMasterWorkingHourRepository>();
builder.Services.AddScoped<IRepository<SystemSetting>, dbSystemSettingRepository>();
builder.Services.AddScoped<IRepository<TransactionBookTable>, dbTransactionBookTableRepository>();
builder.Services.AddScoped<IRepository<TransactionContactU>, dbTransactionContactURepository>();
builder.Services.AddScoped<IRepository<TransactionNewsletter>, dbTransactionNewsletterRepository>();
builder.Services.AddScoped<IRepository<WhatPeopleSay>, dbWhatPeopleSayRepository>();
















builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Admin/Account/Login";
});







var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{


    app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}"
            );

    app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
            );

});
app.Run();
