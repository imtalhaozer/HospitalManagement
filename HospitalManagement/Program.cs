using HospitalManagement.Contexts;
using HospitalManagement.Repository.Concretes;
using HospitalManagement.Service.Abstracts;
using HospitalManagement.Service.Concretes;
using HospitalManagement.Service.Mappers;
using HospitalManagement.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MsSqlContext>();
builder.Services.AddScoped<AppoinmentRepository>();
builder.Services.AddScoped<DoctorRepository>();
builder.Services.AddScoped<PatientRepository>();
builder.Services.AddScoped<AppoinmentValidator>();
builder.Services.AddScoped<AppoinmentMapper>();
builder.Services.AddScoped<DoctorMapper>();
builder.Services.AddScoped<PatientMapper>();
builder.Services.AddScoped<IAppoinmentService,AppoinmentService>();
builder.Services.AddScoped<IDoctorService,DoctorService>();
builder.Services.AddScoped<IPatientService,PatientService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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