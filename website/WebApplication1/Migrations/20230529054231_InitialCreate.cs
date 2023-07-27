using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "user",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        Email = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
            //        password = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
            //        status = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__user__3214EC071C9A28A2", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
