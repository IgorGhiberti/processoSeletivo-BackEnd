using ApiProcessoSeletivo.Data;
using ApiProcessoSeletivo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProcessoSeletivo.Funcionarios
{
    public static class FuncionariosRotas
    {
        public static void AddRotasFuncionarios(this WebApplication app)
        {
            var rotasFuncionarios = app.MapGroup("funcionarios/departamento/{departamentoId}");

            //Criar funcionários
            rotasFuncionarios.MapPost("", async (AddFuncionariosRequest request, DataContext context) =>
            {

                var novoFuncionario = new Funcionario(request.nome, request.foto, request.rg, request.departamentoId);
                await context.Funcionarios.AddAsync(novoFuncionario);
                await context.SaveChangesAsync();
            });

            //Listar funcionário por departamento
            rotasFuncionarios.MapGet("", async (int departamentoId, DataContext context) =>
            {
                var funcionariosPorDepartamento = await context.Funcionarios
                    .Where(funcionario => funcionario.DepartamentoId == departamentoId)
                    .ToListAsync();

                return Results.Ok(funcionariosPorDepartamento);
            });


            //Listar apenas 1 funcionário
            rotasFuncionarios.MapGet("{id}/selecionar", async (int departamentoId, int id, DataContext context) =>
            {

                var selecionarFuncionario = await context.Funcionarios.SingleOrDefaultAsync(funcionario => funcionario.Id == id);

                if (selecionarFuncionario == null)
                    return Results.NotFound();

                return Results.Ok(selecionarFuncionario);

            });

            //Editar funcionário
            rotasFuncionarios.MapPut("{id}", async (int departamentoId, int id, UpdateFuncionarioRequest request, DataContext context) =>
            {


                var editarFuncionario = await context.Funcionarios.SingleOrDefaultAsync(funcionario => funcionario.Id == id);

                if (editarFuncionario == null)
                    return Results.NotFound();

                editarFuncionario.Nome = request.nome;
                editarFuncionario.Rg = request.rg;
                editarFuncionario.Foto = request.foto;
                editarFuncionario.DepartamentoId = request.departamentoId;

                await context.SaveChangesAsync();
                return Results.Ok(editarFuncionario);

            });

            //Desativar funcionário
            rotasFuncionarios.MapDelete("{id}/desativar", async (int departamentoId,int id, DataContext context) =>
            {

                var desativarFuncionario = await context.Funcionarios.SingleOrDefaultAsync(funcionario => funcionario.Id == id);

                if (desativarFuncionario == null)
                    return Results.NotFound();

                desativarFuncionario.Ativo = false;
                await context.SaveChangesAsync();
                return Results.Ok(desativarFuncionario);

            });

            //Reativar funcionário
            rotasFuncionarios.MapPut("{id}/reativar", async (int departamentoId,int id, DataContext context) =>
            {

                var reativarFuncionario = await context.Funcionarios.SingleOrDefaultAsync(funcionario => funcionario.Id == id);

                if(reativarFuncionario == null)
                    return Results.NotFound();

                reativarFuncionario.Ativo = true;
                await context.SaveChangesAsync();
                return Results.Ok(reativarFuncionario);

            });

            //Deletar funcionário
            rotasFuncionarios.MapDelete("{id}/excluir", async (int departamentoId,int id, DataContext context) =>
            {

                var deletarFuncionario = await context.Funcionarios.SingleOrDefaultAsync(funcionario => funcionario.Id == id);

                if (deletarFuncionario == null)
                    return Results.NotFound();

                context.Funcionarios.Remove(deletarFuncionario);
                await context.SaveChangesAsync();
                return Results.Ok(deletarFuncionario);

            });
        }
    }
}
