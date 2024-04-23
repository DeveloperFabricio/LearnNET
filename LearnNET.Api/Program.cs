using FluentValidation;
using LearnNET.Application.Commands.AssinaturaCommand.AtualizarAssinaturaCommand;
using LearnNET.Application.Commands.AssinaturaCommand.CriarAssinaturaCommand;
using LearnNET.Application.Commands.AssinaturaCommand.ExcluirAssinaturaCommand;
using LearnNET.Application.Commands.AulaCommand.AtualizarAulaCommand;
using LearnNET.Application.Commands.AulaCommand.CriarAulaCommand;
using LearnNET.Application.Commands.AulaCommand.ExcluirAulaCommand;
using LearnNET.Application.Commands.CursoCommand.AtualizarCursoCommand;
using LearnNET.Application.Commands.CursoCommand.CriarCursoCommand;
using LearnNET.Application.Commands.CursoCommand.ExcluirCursoCommand;
using LearnNET.Application.Commands.ModuloCommand.AtualizarModuloCommand;
using LearnNET.Application.Commands.ModuloCommand.CriarModuloCommand;
using LearnNET.Application.Commands.ModuloCommand.ExcluirModuloCommand;
using LearnNET.Application.Commands.UsuarioCommand.AtualizarUsuarioCommand;
using LearnNET.Application.Commands.UsuarioCommand.CriarUsuarioCommand;
using LearnNET.Application.Commands.UsuarioCommand.ExcluirUsuarioCommand;
using LearnNET.Application.DTO_s;
using LearnNET.Application.Queries.AssinaturaQuery.ObterAssinaturaPorIdQuery;
using LearnNET.Application.Queries.AssinaturaQuery.ObterTodasAssinaturasQuery;
using LearnNET.Application.Queries.AulaQuery.ObterAulaPorIdQuery;
using LearnNET.Application.Queries.AulaQuery.ObterTodasAulasQuery;
using LearnNET.Application.Queries.CursoQuery.ObterCursoPorIdQuery;
using LearnNET.Application.Queries.CursoQuery.ObterTodosCursosQuery;
using LearnNET.Application.Queries.ModuloQuery.ObterModuloPorIdQuery;
using LearnNET.Application.Queries.ModuloQuery.ObterTodosModulosQuery;
using LearnNET.Application.Queries.UsuarioQuery.ObterTodosUsuariosQuery;
using LearnNET.Application.Queries.UsuarioQuery.ObterUsuarioPorIdQuery;
using LearnNET.Application.Validations;
using LearnNET.Core.Repositories;
using LearnNET.Infra.Persistence;
using LearnNET.Infra.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IAssinaturaRepository, AssinaturaRepository>();
builder.Services.AddScoped<IAulaRepository, AulaRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IModuloRepository, ModuloRepository>();
builder.Services.AddScoped<IPagamentoAssinaturaRepository, PagamentoAssinaturaRepository>();
builder.Services.AddScoped<IUsuarioAssinaturaRepository, UsuarioAssinaturaRepository>();
builder.Services.AddScoped<IUsuarioAulaConcluidaRepository, UsuarioAulaConcluidaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IValidator<AssinaturaDTO>, AssinaturaDTOValidator>();
builder.Services.AddTransient<IValidator<CursoDTO>, CursoDTOValidator>();
builder.Services.AddTransient<IValidator<ModuloDTO>, ModuloDTOValidator>();
builder.Services.AddTransient<IValidator<AulaDTO>, AulaDTOValidator>();
builder.Services.AddTransient<IValidator<UsuarioDTO>, UsuarioDTOValidator>();

builder.Services.AddScoped<IRequestHandler<AtualizarAssinaturaCommand, Unit>, AtualizarAssinaturaCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CriarAssinaturaCommand, Unit>, CriarAssinaturaCommandHandler>();
builder.Services.AddScoped<IRequestHandler<ExcluirAssinaturaCommand, Unit>, ExcluirAssinaturaCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarAulaCommand, Unit>, AtualizarAulaCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CriarAulaCommand, Unit>, CriarAulaCommandHandler>();
builder.Services.AddScoped<IRequestHandler<ExcluirAulaCommand, Unit>, ExcluirAulaCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarCursoCommand, Unit>, AtualizarCursoCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CriarCursoCommand, Unit>, CriarCursoCommandHandler>();
builder.Services.AddScoped<IRequestHandler<ExcluirCursoCommand, Unit>, ExcluirCursoCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarModuloCommand, Unit>, AtualizarModuloCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CriarModuloCommand, Unit>, CriarModuloCommandHandler>();
builder.Services.AddScoped<IRequestHandler<ExcluirModuloCommand, Unit>, ExcluirModuloCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarUsuarioCommand, Unit>, AtualizarUsuarioCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CriarUsuarioCommand, Unit>, CriarUsuarioCommandHandler>();
builder.Services.AddScoped<IRequestHandler<ExcluirUsuarioCommand, Unit>, ExcluirUsuarioCommandHandler>();

builder.Services.AddScoped<AtualizarAssinaturaCommand>();
builder.Services.AddScoped<CriarAssinaturaCommand>();
builder.Services.AddScoped<ExcluirAssinaturaCommand>();
builder.Services.AddScoped<AtualizarAulaCommand>();
builder.Services.AddScoped<CriarAulaCommand>();
builder.Services.AddScoped<ExcluirAulaCommand>();
builder.Services.AddScoped<AtualizarCursoCommand>();
builder.Services.AddScoped<CriarCursoCommand>();
builder.Services.AddScoped<ExcluirCursoCommand>();
builder.Services.AddScoped<AtualizarModuloCommand>();
builder.Services.AddScoped<CriarModuloCommand>();
builder.Services.AddScoped<ExcluirModuloCommand>();
builder.Services.AddScoped<AtualizarUsuarioCommand>();
builder.Services.AddScoped<CriarUsuarioCommand>();
builder.Services.AddScoped<ExcluirUsuarioCommand>();

builder.Services.AddTransient<IRequestHandler<ObterTodasAssinaturasQuery, List<AssinaturaDTO>>, ObterTodasAssinaturasQueryHandler>();
builder.Services.AddTransient<IRequestHandler<ObterAssinaturaPorIdQuery, AssinaturaDTO>, ObterAssinaturaPorIdQueryHandler>();
builder.Services.AddTransient<IRequestHandler<ObterTodasAulasQuery, List<AulaDTO>>, ObterTodasAulasQueryHandler>();
builder.Services.AddTransient<IRequestHandler<ObterAulaPorIdQuery, AulaDTO>, ObterAulaPorIdQueryHandler>();
builder.Services.AddTransient<IRequestHandler<ObterTodosCursosQuery, List<CursoDTO>>, ObterTodosCursosQueryHandler>();
builder.Services.AddTransient<IRequestHandler<ObterCursoPorIdQuery, CursoDTO>, ObterCursoPorIdQueryHandler>();
builder.Services.AddTransient<IRequestHandler<ObterTodosModulosQuery, List<ModuloDTO>>, ObterTodosModulosQueryHandler>();
builder.Services.AddTransient<IRequestHandler<ObterModuloPorIdQuery, ModuloDTO>, ObterModuloPorIdQueryHandler>();
builder.Services.AddTransient<IRequestHandler<ObterTodosUsuariosQuery, List<UsuarioDTO>>, ObterTodosUsuariosQueryHandler>();
builder.Services.AddTransient<IRequestHandler<ObterUsuarioPorIdQuery, UsuarioDTO>, ObterUsuarioPorIdQueryHandler>();

builder.Services.AddScoped<ObterTodasAssinaturasQuery>();
builder.Services.AddScoped<ObterAssinaturaPorIdQuery>();
builder.Services.AddScoped<ObterTodasAulasQuery>();
builder.Services.AddScoped<ObterAulaPorIdQuery>();
builder.Services.AddScoped<ObterTodosCursosQuery>();
builder.Services.AddScoped<ObterCursoPorIdQuery>();
builder.Services.AddScoped<ObterTodosModulosQuery>();
builder.Services.AddScoped<ObterModuloPorIdQuery>();
builder.Services.AddScoped<ObterTodosUsuariosQuery>();
builder.Services.AddScoped<ObterUsuarioPorIdQuery>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LearnNET.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
