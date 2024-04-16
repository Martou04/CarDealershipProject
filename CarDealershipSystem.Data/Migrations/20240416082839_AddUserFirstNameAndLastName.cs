using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealershipSystem.Data.Migrations
{
    public partial class AddUserFirstNameAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_BuyerId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_BuyerId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("75cc2ac5-7976-4151-a4f1-ba66849baab8"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("fba91199-e65c-4baa-84fc-e387789b3198"));

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Test");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Testov");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("07ba952b-8cb0-4243-be8e-e1bc41016b6a"), 1, "Experience the epitome of driving pleasure with this BMW 330i. With its sleek design, powerful engine, and advanced technology, this luxury sedan offers an exhilarating driving experience.", 1, 258, "https://i.pinimg.com/originals/ce/d9/5e/ced95e743efd9f0b5b182c6d4a9d4ef7.jpg", 150000, "BMW", "330i", 15550m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 1, 2006 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("c78788c2-a832-4e4c-8a38-a0b0ea7d84bc"), 3, "Unleash the ultimate driving experience with the 2022 BMW M4. Boasting a powerful twin-turbocharged inline-six engine, dynamic handling, and aggressive styling, this sports coupe is engineered to thrill at every turn. With its luxurious interior, cutting-edge technology, and track-ready performance, the BMW M4 sets the standard for exhilarating driving. Don't miss out on the opportunity to own this icon of performance and precision.", 1, 503, "https://supercars.bg/wp-content/uploads/2022/05/P90458876_highRes_new-edition-of-a-leg.jpg", 10278, "BMW", "M4", 105000m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 2, 2022 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("07ba952b-8cb0-4243-be8e-e1bc41016b6a"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c78788c2-a832-4e4c-8a38-a0b0ea7d84bc"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatedOn", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "IsActive", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("75cc2ac5-7976-4151-a4f1-ba66849baab8"), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Experience the epitome of driving pleasure with this BMW 330i. With its sleek design, powerful engine, and advanced technology, this luxury sedan offers an exhilarating driving experience.", 1, 258, "https://i.pinimg.com/originals/ce/d9/5e/ced95e743efd9f0b5b182c6d4a9d4ef7.jpg", false, 150000, "BMW", "330i", 15550m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 1, 2006 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatedOn", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "IsActive", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("fba91199-e65c-4baa-84fc-e387789b3198"), null, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unleash the ultimate driving experience with the 2022 BMW M4. Boasting a powerful twin-turbocharged inline-six engine, dynamic handling, and aggressive styling, this sports coupe is engineered to thrill at every turn. With its luxurious interior, cutting-edge technology, and track-ready performance, the BMW M4 sets the standard for exhilarating driving. Don't miss out on the opportunity to own this icon of performance and precision.", 1, 503, "https://supercars.bg/wp-content/uploads/2022/05/P90458876_highRes_new-edition-of-a-leg.jpg", false, 10278, "BMW", "M4", 105000m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 2, 2022 });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BuyerId",
                table: "Cars",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_BuyerId",
                table: "Cars",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
