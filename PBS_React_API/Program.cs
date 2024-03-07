using PBS_React_API.DatabaseContext.DatabaseContext;
using PBS_React_API.DatabaseContext.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_ForPBSOnly";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://pbs.com.bd",
                                              "https://localhost:44354").AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors(option =>
//{
//    option.AddPolicy(name: "AllowAll", policy =>
//    {
//        policy.AllowAnyHeader();
//        policy.AllowAnyOrigin();
//        policy.AllowAnyMethod();
//    });
//});


builder.Services.AddScoped<iProjectDataContext, ProjectDataContext>();
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
app.UseCors(MyAllowSpecificOrigins); 

app.MapControllers();

app.Run();
