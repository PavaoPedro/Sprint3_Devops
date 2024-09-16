using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAI.Migrations
{
    /// <inheritdoc />
    public partial class MAI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_MAI_ESTADO",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EstadoNome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Sigla = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAI_ESTADO", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "TB_MAI_LOGIN",
                columns: table => new
                {
                    IdLogin = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAI_LOGIN", x => x.IdLogin);
                });

            migrationBuilder.CreateTable(
                name: "TB_MAI_CIDADE",
                columns: table => new
                {
                    IdCidade = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CidadeNome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdEstado = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EstadoIdEstado = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAI_CIDADE", x => x.IdCidade);
                    table.ForeignKey(
                        name: "FK_TB_MAI_CIDADE_TB_MAI_ESTADO_EstadoIdEstado",
                        column: x => x.EstadoIdEstado,
                        principalTable: "TB_MAI_ESTADO",
                        principalColumn: "IdEstado");
                });

            migrationBuilder.CreateTable(
                name: "TB_MAI_REGIAO",
                columns: table => new
                {
                    IdRegiao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RegiaoNome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdCidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CidadeIdCidade = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAI_REGIAO", x => x.IdRegiao);
                    table.ForeignKey(
                        name: "FK_TB_MAI_REGIAO_TB_MAI_CIDADE_CidadeIdCidade",
                        column: x => x.CidadeIdCidade,
                        principalTable: "TB_MAI_CIDADE",
                        principalColumn: "IdCidade");
                });

            migrationBuilder.CreateTable(
                name: "TB_MAI_EMPRESA",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CNPJ = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdLogin = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    LoginIdLogin = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    IdRegiao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RegiaoIdRegiao = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAI_EMPRESA", x => x.IdEmpresa);
                    table.ForeignKey(
                        name: "FK_TB_MAI_EMPRESA_TB_MAI_LOGIN_LoginIdLogin",
                        column: x => x.LoginIdLogin,
                        principalTable: "TB_MAI_LOGIN",
                        principalColumn: "IdLogin");
                    table.ForeignKey(
                        name: "FK_TB_MAI_EMPRESA_TB_MAI_REGIAO_RegiaoIdRegiao",
                        column: x => x.RegiaoIdRegiao,
                        principalTable: "TB_MAI_REGIAO",
                        principalColumn: "IdRegiao");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAI_CIDADE_EstadoIdEstado",
                table: "TB_MAI_CIDADE",
                column: "EstadoIdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAI_EMPRESA_LoginIdLogin",
                table: "TB_MAI_EMPRESA",
                column: "LoginIdLogin");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAI_EMPRESA_RegiaoIdRegiao",
                table: "TB_MAI_EMPRESA",
                column: "RegiaoIdRegiao");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAI_REGIAO_CidadeIdCidade",
                table: "TB_MAI_REGIAO",
                column: "CidadeIdCidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MAI_EMPRESA");

            migrationBuilder.DropTable(
                name: "TB_MAI_LOGIN");

            migrationBuilder.DropTable(
                name: "TB_MAI_REGIAO");

            migrationBuilder.DropTable(
                name: "TB_MAI_CIDADE");

            migrationBuilder.DropTable(
                name: "TB_MAI_ESTADO");
        }
    }
}
