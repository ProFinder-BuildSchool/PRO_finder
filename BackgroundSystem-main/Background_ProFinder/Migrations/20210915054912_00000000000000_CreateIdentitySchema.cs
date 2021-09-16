using Microsoft.EntityFrameworkCore.Migrations;

namespace Background_ProFinder.Migrations
{
    public partial class _00000000000000_CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //    table: "AspNetRoleClaims");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //    table: "AspNetUserClaims");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //    table: "AspNetUserLogins");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //    table: "AspNetUserRoles");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //    table: "AspNetUserRoles");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //    table: "AspNetUserTokens");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_AspNetUserTokens",
            //    table: "AspNetUserTokens");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_AspNetUsers",
            //    table: "AspNetUsers");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_AspNetUserRoles",
            //    table: "AspNetUserRoles");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_AspNetUserLogins",
            //    table: "AspNetUserLogins");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_AspNetUserClaims",
            //    table: "AspNetUserClaims");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_AspNetRoles",
            //    table: "AspNetRoles");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_AspNetRoleClaims",
            //    table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "BackUserToken");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "BackUserData");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "BackUserRole");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "BackUserLogin");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "BackUserClaim");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "BackRole");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "BackUserRoleClaim");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "BackUserRole",
            //    newName: "IX_BackUserRole_RoleId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "BackUserLogin",
            //    newName: "IX_BackUserLogin_UserId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "BackUserClaim",
            //    newName: "IX_BackUserClaim_UserId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "BackUserRoleClaim",
            //    newName: "IX_BackUserRoleClaim_RoleId");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_BackUserToken",
            //    table: "BackUserToken",
            //    columns: new[] { "UserId", "LoginProvider", "Name" });

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_BackUserData",
            //    table: "BackUserData",
            //    column: "Id");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_BackUserRole",
            //    table: "BackUserRole",
            //    columns: new[] { "UserId", "RoleId" });

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_BackUserLogin",
            //    table: "BackUserLogin",
            //    columns: new[] { "LoginProvider", "ProviderKey" });

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_BackUserClaim",
            //    table: "BackUserClaim",
            //    column: "Id");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_BackRole",
            //    table: "BackRole",
            //    column: "Id");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_BackUserRoleClaim",
            //    table: "BackUserRoleClaim",
            //    column: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BackUserClaim_BackUserData_UserId",
            //    table: "BackUserClaim",
            //    column: "UserId",
            //    principalTable: "BackUserData",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BackUserLogin_BackUserData_UserId",
            //    table: "BackUserLogin",
            //    column: "UserId",
            //    principalTable: "BackUserData",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BackUserRole_BackRole_RoleId",
            //    table: "BackUserRole",
            //    column: "RoleId",
            //    principalTable: "BackRole",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BackUserRole_BackUserData_UserId",
            //    table: "BackUserRole",
            //    column: "UserId",
            //    principalTable: "BackUserData",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BackUserRoleClaim_BackRole_RoleId",
            //    table: "BackUserRoleClaim",
            //    column: "RoleId",
            //    principalTable: "BackRole",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BackUserToken_BackUserData_UserId",
            //    table: "BackUserToken",
            //    column: "UserId",
            //    principalTable: "BackUserData",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackUserClaim_BackUserData_UserId",
                table: "BackUserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_BackUserLogin_BackUserData_UserId",
                table: "BackUserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_BackUserRole_BackRole_RoleId",
                table: "BackUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_BackUserRole_BackUserData_UserId",
                table: "BackUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_BackUserRoleClaim_BackRole_RoleId",
                table: "BackUserRoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_BackUserToken_BackUserData_UserId",
                table: "BackUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackUserToken",
                table: "BackUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackUserRoleClaim",
                table: "BackUserRoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackUserRole",
                table: "BackUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackUserLogin",
                table: "BackUserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackUserData",
                table: "BackUserData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackUserClaim",
                table: "BackUserClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackRole",
                table: "BackRole");

            migrationBuilder.RenameTable(
                name: "BackUserToken",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "BackUserRoleClaim",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "BackUserRole",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "BackUserLogin",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "BackUserData",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "BackUserClaim",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "BackRole",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_BackUserRoleClaim_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_BackUserRole_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_BackUserLogin_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BackUserClaim_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
