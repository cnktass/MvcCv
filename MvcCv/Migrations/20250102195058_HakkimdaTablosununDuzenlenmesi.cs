using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcCv.Migrations
{
    /// <inheritdoc />
    public partial class HakkimdaTablosununDuzenlenmesi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tarih",
                table: "Hakkimda",
                newName: "Telefon");

            migrationBuilder.RenameColumn(
                name: "Baslik",
                table: "Hakkimda",
                newName: "Soyad");

            migrationBuilder.RenameColumn(
                name: "AltBaslik",
                table: "Hakkimda",
                newName: "Mail");

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Hakkimda",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Hakkimda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Hakkimda");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Hakkimda");

            migrationBuilder.RenameColumn(
                name: "Telefon",
                table: "Hakkimda",
                newName: "Tarih");

            migrationBuilder.RenameColumn(
                name: "Soyad",
                table: "Hakkimda",
                newName: "Baslik");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Hakkimda",
                newName: "AltBaslik");
        }
    }
}
