using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealershipSystem.Data.Migrations
{
    public partial class AddIsActiveColumnForSoftDeletingCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("3a9a6a0e-a28f-4775-9d6e-2c679744b571"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("dfda3415-ef36-46a7-97a3-17092321a71f"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("75cc2ac5-7976-4151-a4f1-ba66849baab8"), null, 1, "Experience the epitome of driving pleasure with this BMW 330i. With its sleek design, powerful engine, and advanced technology, this luxury sedan offers an exhilarating driving experience.", 1, 258, "https://i.pinimg.com/originals/ce/d9/5e/ced95e743efd9f0b5b182c6d4a9d4ef7.jpg", 150000, "BMW", "330i", 15550m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 1, 2006 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("fba91199-e65c-4baa-84fc-e387789b3198"), null, 3, "Unleash the ultimate driving experience with the 2022 BMW M4. Boasting a powerful twin-turbocharged inline-six engine, dynamic handling, and aggressive styling, this sports coupe is engineered to thrill at every turn. With its luxurious interior, cutting-edge technology, and track-ready performance, the BMW M4 sets the standard for exhilarating driving. Don't miss out on the opportunity to own this icon of performance and precision.", 1, 503, "https://supercars.bg/wp-content/uploads/2022/05/P90458876_highRes_new-edition-of-a-leg.jpg", 10278, "BMW", "M4", 105000m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 2, 2022 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("75cc2ac5-7976-4151-a4f1-ba66849baab8"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("fba91199-e65c-4baa-84fc-e387789b3198"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatedOn", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("3a9a6a0e-a28f-4775-9d6e-2c679744b571"), null, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unleash the ultimate driving experience with the 2022 BMW M4. Boasting a powerful twin-turbocharged inline-six engine, dynamic handling, and aggressive styling, this sports coupe is engineered to thrill at every turn. With its luxurious interior, cutting-edge technology, and track-ready performance, the BMW M4 sets the standard for exhilarating driving. Don't miss out on the opportunity to own this icon of performance and precision.", 1, 503, "https://supercars.bg/wp-content/uploads/2022/05/P90458876_highRes_new-edition-of-a-leg.jpg", 10278, "BMW", "M4", 105000m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 2, 2022 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatedOn", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("dfda3415-ef36-46a7-97a3-17092321a71f"), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Experience the epitome of driving pleasure with this BMW 330i. With its sleek design, powerful engine, and advanced technology, this luxury sedan offers an exhilarating driving experience.", 1, 258, "https://i.pinimg.com/originals/ce/d9/5e/ced95e743efd9f0b5b182c6d4a9d4ef7.jpg", 150000, "BMW", "330i", 15550m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 1, 2006 });
        }
    }
}
