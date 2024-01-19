using ApiProcessoSeletivo.Data;
using ApiProcessoSeletivo.Departamentos;
using ApiProcessoSeletivo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProcessoSeletivo.Departamentos
{
    public static class DepartamentosRotas
    {
        public static void AddRotasDepartamentos(this WebApplication app)
        {
            var rotasDepartamentos = app.MapGroup("departamentos");

            //Criar departamentos
            rotasDepartamentos.MapPost("", async (AddDepartamentosRequest request, DataContext context) =>
            {

                var novoDepartamento = new Departamento(request.nome, request.sigla);
                await context.Departamentos.AddAsync(novoDepartamento);
                await context.SaveChangesAsync();
            });

            //Listar todos os departamentos
            rotasDepartamentos.MapGet("", async (DataContext context) =>
            {

                var listarDepartamentos = await context.Departamentos.Include(t => t.Funcionarios).ToListAsync();
                return listarDepartamentos;

            });

            //Listar apenas 1 departamento
            rotasDepartamentos.MapGet("{id}/selecionar", async (int id, DataContext context) =>
            {

                var selecionarDepartamento = await context.Departamentos.Include(t => t.Funcionarios).SingleOrDefaultAsync(departamento => departamento.Id == id);

                if (selecionarDepartamento == null)
                    return Results.NotFound();


                return Results.Ok(selecionarDepartamento);

            });

            //Editar o departamento
            rotasDepartamentos.MapPut("{id}", async (int id, UpdateDepartamentoRequest request, DataContext context) => 
            {

                var editarDepartamento = await context.Departamentos.SingleOrDefaultAsync(departamento => departamento.Id == id);

                if (editarDepartamento == null)
                    return Results.NotFound();

                editarDepartamento.Nome = request.nome;
                editarDepartamento.Sigla = request.sigla;

                await context.SaveChangesAsync();
                return Results.Ok(editarDepartamento);

            });

            //Desativar departamento
            rotasDepartamentos.MapDelete("{id}/desativar", async (int id, DataContext context) => 
            {

                var desativarDepartamento = await context.Departamentos.SingleOrDefaultAsync(departamento => departamento.Id==id);

                if (desativarDepartamento == null)
                    return Results.NotFound();

                desativarDepartamento.Ativo = false;
                await context.SaveChangesAsync();
                return Results.Ok(desativarDepartamento);

            });

            //Reativar departamento
            rotasDepartamentos.MapPut("{id}/reativar", async (int id, DataContext context) => 
            {

                var reativarDepartamento = await context.Departamentos.SingleOrDefaultAsync(departamento => departamento.Id == id);

                if (reativarDepartamento == null)
                    return Results.NotFound();

                reativarDepartamento.Ativo = true;
                await context.SaveChangesAsync();
                return Results.Ok(reativarDepartamento);

            });

            //Deletar departamento
            rotasDepartamentos.MapDelete("{id}/deletar", async (int id, DataContext context) =>
            {
                var deletarDepartamento = await context.Departamentos.SingleOrDefaultAsync(departamento => departamento.Id == id);

                if (deletarDepartamento == null)
                    return Results.NotFound();

                context.Departamentos.Remove(deletarDepartamento);
                await context.SaveChangesAsync();
                return Results.Ok(deletarDepartamento);
            });
        }
    }
}
