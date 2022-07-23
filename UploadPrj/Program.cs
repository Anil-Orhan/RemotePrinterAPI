using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTO;
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
builder.Services.AddSingleton<IUserLogDal,EfUserLogDal>();
builder.Services.AddSingleton<IOperationDal, EfOperationDal>();
builder.Services.AddSingleton<IOptionDal, EfOptionDal>();
builder.Services.AddSingleton<IWalletActivityDal, EfWalletActivityDal>();
builder.Services.AddSingleton<IWalletDal, EfWalletDal>();




builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IPrinterService, PrinterService>();
builder.Services.AddSingleton<IPrintModelService, PrintModelService>();
builder.Services.AddSingleton<IOperationService, OperationService>();
builder.Services.AddSingleton<IOptionService, OptionService>();
builder.Services.AddSingleton<IWalletActivityService, WalletActivityService>();
builder.Services.AddSingleton<IWalletService, WalletService>();
builder.Services.AddTransient<IReportService,ReportService>();



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
