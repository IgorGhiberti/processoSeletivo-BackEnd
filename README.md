# API Back End - Projeto Processo Seletivo
Este projeto consiste em uma API  para gerenciamento de departamentos e funcionários. Foi desenvolvido utilizando o formato Minimal API com ASP.NET Core, e emprega o Entity Framework Core para a camada de persistência, utilizando o banco de dados SQL Server. A API é documentada e testada utilizando o Swagger.
## Funcionalidades Principais da API
### Departamentos
1. **Criar Departamentos:**
- Cria um departamento a partir das suas propriedades necessárias, que no caso são apenas Nome e Sigla.
2. **Filtrar Departamentos:**
- Filtra um departamento específico a partir do seu ID.
3. **Editar Departamento:**
- Edita um departamento específico a partir do seu ID, pode editar apenas uma propriedade ou ambas.
4. **Desativar/Reativar Departamento:**
- Pensando na necessidade de um negócio de manter os seus registros salvos no banco de dados, eu decidi criar essas duas funcionalidades para que caso um funcionário seja desligado ou um departamento não exista mais, seus dados se mantenham íntegros dentro do banco.
5. **Deletar Departamento:**
- Como exigência do projeto, criei uma funcionalidade que delete o departamento do banco de dados e do sistema.
### Funcionários
Para os funcionários, foram criados basicamente as mesmas funcionalidades, porém, como a relação entre ambas as entidades é de um para muitos, ou seja, para cada um departamento podem existir muitos funcionários, tudo que é feito através dos funcionários tem que, antes, indicar qual o ID do departamento, que é a Foreign Key que conecta os funcionários dentro do seu departamento específico.

## Tecnologias Utilizadas
- ASP.NET Core (Minimal API)
- Entity Framework Core (ORM)
- SQL Server (Banco de Dados)
- Swagger (Documentação e Teste da API)
