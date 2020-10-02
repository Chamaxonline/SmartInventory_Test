using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystem.Migrations.Role
{
    public partial class Adding_SP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE[GetAllUsers] 
                AS BEGIN
    SELECT U.FirstName,U.LastName,U.UserName,U.RoleId,R.RoleName
    FROM[Users] AS U
    INNER JOIN Roles AS R ON R.RoleId = U.RoleId
END
GO";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE[GetAllUsers]";
            migrationBuilder.Sql(procedure);
        }
    }
}
