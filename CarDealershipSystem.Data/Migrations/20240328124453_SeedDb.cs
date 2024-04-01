using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealershipSystem.Data.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sedan" },
                    { 2, "Hatchback" },
                    { 3, "Coupe" }
                });

            migrationBuilder.InsertData(
                table: "ExtraTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Comfort" },
                    { 2, "Safety" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gasoline" },
                    { 2, "Diesel" },
                    { 3, "Electric" }
                });

            migrationBuilder.InsertData(
                table: "TransmissionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manual" },
                    { 2, "Automatic" },
                    { 3, "Semi-Automatic" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("b05c24bb-2901-490e-9f8b-bfc196742476"), null, 3, "Unleash the ultimate driving experience with the 2022 BMW M4. Boasting a powerful twin-turbocharged inline-six engine, dynamic handling, and aggressive styling, this sports coupe is engineered to thrill at every turn. With its luxurious interior, cutting-edge technology, and track-ready performance, the BMW M4 sets the standard for exhilarating driving. Don't miss out on the opportunity to own this icon of performance and precision.", 1, 503, "https://supercars.bg/wp-content/uploads/2022/05/P90458876_highRes_new-edition-of-a-leg.jpg", 10278, "BMW", "M4", 105000m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 2, 2022 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("e8c5686f-3e49-4b73-95d3-a6552505db3c"), null, 1, "Experience the epitome of driving pleasure with this BMW 330i. With its sleek design, powerful engine, and advanced technology, this luxury sedan offers an exhilarating driving experience.", 1, 258, "https://i.pinimg.com/originals/ce/d9/5e/ced95e743efd9f0b5b182c6d4a9d4ef7.jpg", 150000, "BMW", "330i", 15550m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 1, 2006 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b05c24bb-2901-490e-9f8b-bfc196742476"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e8c5686f-3e49-4b73-95d3-a6552505db3c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExtraTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExtraTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExtraTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
