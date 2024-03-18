using PBS_React_API.BLL.BLL;
using PBS_React_API.BLL.Interface;
using PBS_React_API.DAL.DAL;
using PBS_React_API.DAL.Interface;
using PBS_React_API.DatabaseContext.DatabaseContext;
using PBS_React_API.DatabaseContext.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_ForPBSOnly";

//builder.Services.AddCors(options =>
//{
//    //1
//    //options.AddPolicy(name: MyAllowSpecificOrigins,
//    //                  policy =>
//    //                  {
//    //                      policy.WithOrigins("https://beta.pbs.com.bd",
//    //                                         "https://localhost:44354")
//    //                                          .AllowAnyHeader()
//    //                                          .AllowAnyMethod();
//    //                  });

//    ////2
//    //options.AddPolicy(MyAllowSpecificOrigins,
//    //   policy =>
//    //   {
//    //       policy.WithOrigins("https://beta.pbs.com.bd")
//    //                           .AllowAnyHeader()
//    //                           .AllowAnyMethod();
//    //   });
//});

//3
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("https://beta.pbs.com.bd", "https://pbs.com.bd", "https://localhost:44354");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<iProjectDataContext, ProjectDataContext>();
builder.Services.AddScoped<iUserPanelManager, UserPanelManager>();
builder.Services.AddScoped<iUserPanelRepository, UserPanelRepository>();
builder.Services.AddScoped<IDataSyncManager, DataSyncManager>();
builder.Services.AddScoped<IDataSyncRepository, DataSyncRepository>();
builder.Services.AddScoped<iDataAccess, DataAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//1/3
app.UseCors(MyAllowSpecificOrigins);
//2
//app.UseCors();

app.MapControllers();

app.Run();
