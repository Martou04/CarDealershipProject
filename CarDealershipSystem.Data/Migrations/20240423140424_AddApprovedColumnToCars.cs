using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealershipSystem.Data.Migrations
{
    public partial class AddApprovedColumnToCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("07ba952b-8cb0-4243-be8e-e1bc41016b6a"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c78788c2-a832-4e4c-8a38-a0b0ea7d84bc"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TransmissionTypes",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FuelTypes",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExtraTypes",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Extra",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("1374b321-88c3-4639-bd61-004215f16639"), 1, "Experience the epitome of driving pleasure with this BMW 330i. With its sleek design, powerful engine, and advanced technology, this luxury sedan offers an exhilarating driving experience.", 1, 258, "https://i.pinimg.com/originals/ce/d9/5e/ced95e743efd9f0b5b182c6d4a9d4ef7.jpg", 150000, "BMW", "330i", 15550m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 1, 2006 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("c0897352-8365-4062-95f3-be6ba249ce67"), 3, "Unleash the ultimate driving experience with the 2022 BMW M4. Boasting a powerful twin-turbocharged inline-six engine, dynamic handling, and aggressive styling, this sports coupe is engineered to thrill at every turn. With its luxurious interior, cutting-edge technology, and track-ready performance, the BMW M4 sets the standard for exhilarating driving. Don't miss out on the opportunity to own this icon of performance and precision.", 1, 503, "https://supercars.bg/wp-content/uploads/2022/05/P90458876_highRes_new-edition-of-a-leg.jpg", 10278, "BMW", "M4", 105000m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 2, 2022 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("1374b321-88c3-4639-bd61-004215f16639"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c0897352-8365-4062-95f3-be6ba249ce67"));

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TransmissionTypes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FuelTypes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExtraTypes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Extra",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "IsActive", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("07ba952b-8cb0-4243-be8e-e1bc41016b6a"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Experience the epitome of driving pleasure with this BMW 330i. With its sleek design, powerful engine, and advanced technology, this luxury sedan offers an exhilarating driving experience.", 1, 258, "https://i.pinimg.com/originals/ce/d9/5e/ced95e743efd9f0b5b182c6d4a9d4ef7.jpg", false, 150000, "BMW", "330i", 15550m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 1, 2006 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "IsActive", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("c78788c2-a832-4e4c-8a38-a0b0ea7d84bc"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unleash the ultimate driving experience with the 2022 BMW M4. Boasting a powerful twin-turbocharged inline-six engine, dynamic handling, and aggressive styling, this sports coupe is engineered to thrill at every turn. With its luxurious interior, cutting-edge technology, and track-ready performance, the BMW M4 sets the standard for exhilarating driving. Don't miss out on the opportunity to own this icon of performance and precision.", 1, 503, "https://supercars.bg/wp-content/uploads/2022/05/P90458876_highRes_new-edition-of-a-leg.jpg", false, 10278, "BMW", "M4", 105000m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 2, 2022 });
        }
    }
}
