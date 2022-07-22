using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using ServiceLayer.Abstract;
using ServiceLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserDal, EfUserDal>();
builder.Services.AddSingleton<IFileDal, EfFileDal>();
builder.Services.AddSingleton<IPrinterDal, EfPrinterDal>();
builder.Services.AddSingleton<IPrintModelDal, EfPrintModelDal>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IPrinterService, PrinterService>();
builder.Services.AddSingleton<IPrintModelService, PrintModelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
