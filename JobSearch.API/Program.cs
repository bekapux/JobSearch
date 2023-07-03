var builder = WebApplication.CreateBuilder(args);

ServiceRegistration.ConfigureApplicationServices(builder);
ServiceRegistration.AddSwaggerDoc(builder.Services);
ServiceRegistration.AddDotNetServices(builder);
ServiceRegistration.AddCors(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Default");

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
