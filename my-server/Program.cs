using Microsoft.EntityFrameworkCore;
using my_server;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using Repositories.GeneratedModels;
using Services.Users;
using Services.Travels;
using Services.CarData;
using Services.Email;
using Services.EmailData;
using Services.Alarms;
using Services.RealTime;
using Services.Volunteers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cs = builder.Configuration["MyDBConnectionString"];

builder.Services.AddDbContext<MyDBContext>(options => options.UseNpgsql(cs));

builder.Services.AddMailKit(optionBuilder =>
{
    optionBuilder.UseMailKit(new MailKitOptions()
    {
        //get options from sercets.json
        Server = builder.Configuration["Server"],
        Port = Convert.ToInt32(builder.Configuration["Port"]),
        SenderName = builder.Configuration["SenderName"],
        SenderEmail = builder.Configuration["SenderEmail"],

        // can be optional with no authentication 
        Account = builder.Configuration["Account"],
        Password = builder.Configuration["Password"],
        // enable ssl or tls
        Security = true
    });
});

  builder.Services.AddScoped<EmailManager>();
  builder.Services.AddScoped<IusersData, UsersData>();
builder.Services.AddScoped<IvolunteerData, volunteerData>();

builder.Services.AddScoped<ItravelsData, TravlesData>();
  builder.Services.AddScoped<ICars, CarsData>();
  builder.Services.AddScoped<IEmailData,EmailData>();
builder.Services.AddScoped<IAlarmData, AlarmData>();


var MyAppOrigin = "MyAppOrigin";

  builder.Services.AddCors(options =>
  {
    options.AddPolicy(name: MyAppOrigin,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader().AllowAnyMethod(); ;
        });
  });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    app.MapControllers();
//    endpoints.MapHub<MyHub>("/my-hub");
//    // ...
//});
app.UseCors(MyAppOrigin);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapHub<MyHub>("/my-hub");
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MyHub>("/hubs/chat");
});
app.Run();

//RecurringJob.AddOrUpdate<SendEmailToOpenTask>(x => x.sendRequest(), Cron.Daily(05, 00), TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
