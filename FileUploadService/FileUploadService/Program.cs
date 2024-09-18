using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Manas: increase max file size limit - for IIS
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 2L * 1024L * 1024L * 1024L; // 2GB
});

//Manas: increase max file size limit - for Kestrel
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = 2L * 1024L * 1024L * 1024L; // 2GB
});

//Manas: increase max file size limit for requestes
builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = 2L * 1024L * 1024L * 1024L; // 2GB
    options.MultipartBoundaryLengthLimit = int.MaxValue;
    options.MultipartHeadersCountLimit = int.MaxValue;
    options.MultipartHeadersLengthLimit = int.MaxValue;
});

//Manas: Add Cors support
builder.Services.AddCors(options => {
    options.AddPolicy(name: "CorsPolicy", builder => {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});




var app = builder.Build();

string SwaggerEndpoint = builder.Configuration.GetValue<string>("SwaggerEndPoint");


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(SwaggerEndpoint, "File Upload API");
    });
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
