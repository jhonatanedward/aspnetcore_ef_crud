using Microsoft.EntityFrameworkCore.Migrations;

namespace Mvc_EFCore2.Migrations
{
    public partial class SeedDataBase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Alunos(nome, sexo,email, nascimento) VALUES('Edward', 'Masculino', 'edward@dev.com', '1998-08-24')");
            migrationBuilder.Sql("INSERT INTO Alunos(nome, sexo,email, nascimento) VALUES('Antonio', 'Masculino', 'antonio@dev.com', '1999-09-25')");
            migrationBuilder.Sql("INSERT INTO Alunos(nome, sexo,email, nascimento) VALUES('Rosivraldo', 'Masculino', 'Rosi.valdo@dev.com', '1996-09-25')");
            migrationBuilder.Sql("INSERT INTO Alunos(nome, sexo,email, nascimento) VALUES('Fabiana','Feminino', 'feminina@dev.com', '1990-09-25')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM alunos");
        }
    }
}
