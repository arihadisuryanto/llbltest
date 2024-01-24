using AutoMapper;
using llbltest;
using llbltest.API.AutoMapperProfiles;
using llbltest.Repositories;
using llbltest.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// config cors
builder.Services.AddCors(options =>
{
    //options.AddDefaultPolicy(builder =>
    //{
    //    builder.AllowAnyOrigin()
    //    .AllowAnyMethod()
    //    .AllowAnyHeader();
    //});

    options.AddPolicy("CorsPolicy", builder => builder
       .WithOrigins("https://localhost:7041")
       .AllowAnyMethod()
       .AllowAnyHeader()
       .AllowCredentials());
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LlbltestDataContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("TestDBConnection")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//Repo
builder.Services.AddScoped<IDealerRepository, DealerRepository>();
builder.Services.AddScoped<IAzureBlobStorageRepository, AzureBlobStorageRepository>();
builder.Services.AddScoped<IAttachmentRepository, AttachmentRepository>();

//Service
builder.Services.AddScoped<IDealerService, DealerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
//if (app.Environment.IsDevelopment())
//{
   
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
