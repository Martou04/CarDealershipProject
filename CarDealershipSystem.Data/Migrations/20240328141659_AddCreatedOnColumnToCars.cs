using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealershipSystem.Data.Migrations
{
    public partial class AddCreatedOnColumnToCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b05c24bb-2901-490e-9f8b-bfc196742476"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e8c5686f-3e49-4b73-95d3-a6552505db3c"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("b4210193-0b3d-442f-95bc-4cf5943e4153"), null, 1, "Experience the epitome of driving pleasure with this BMW 330i. With its sleek design, powerful engine, and advanced technology, this luxury sedan offers an exhilarating driving experience.", 1, 258, "https://i.pinimg.com/originals/ce/d9/5e/ced95e743efd9f0b5b182c6d4a9d4ef7.jpg", 150000, "BMW", "330i", 15550m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 1, 2006 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("eedbbcc8-63fb-462c-abf8-c99c1f3ed8d8"), null, 3, "Unleash the ultimate driving experience with the 2022 BMW M4. Boasting a powerful twin-turbocharged inline-six engine, dynamic handling, and aggressive styling, this sports coupe is engineered to thrill at every turn. With its luxurious interior, cutting-edge technology, and track-ready performance, the BMW M4 sets the standard for exhilarating driving. Don't miss out on the opportunity to own this icon of performance and precision.", 1, 503, "https://supercars.bg/wp-content/uploads/2022/05/P90458876_highRes_new-edition-of-a-leg.jpg", 10278, "BMW", "M4", 105000m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 2, 2022 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b4210193-0b3d-442f-95bc-4cf5943e4153"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("eedbbcc8-63fb-462c-abf8-c99c1f3ed8d8"));

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("b05c24bb-2901-490e-9f8b-bfc196742476"), null, 3, "Unleash the ultimate driving experience with the 2022 BMW M4. Boasting a powerful twin-turbocharged inline-six engine, dynamic handling, and aggressive styling, this sports coupe is engineered to thrill at every turn. With its luxurious interior, cutting-edge technology, and track-ready performance, the BMW M4 sets the standard for exhilarating driving. Don't miss out on the opportunity to own this icon of performance and precision.", 1, 503, "https://supercars.bg/wp-content/uploads/2022/05/P90458876_highRes_new-edition-of-a-leg.jpg", 10278, "BMW", "M4", 105000m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 2, 2022 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "FuelTypeId", "Horsepower", "ImageUrl", "Kilometers", "Make", "Model", "Price", "SellerId", "TransmissionTypeId", "Year" },
                values: new object[] { new Guid("e8c5686f-3e49-4b73-95d3-a6552505db3c"), null, 1, "Experience the epitome of driving pleasure with this BMW 330i. With its sleek design, powerful engine, and advanced technology, this luxury sedan offers an exhilarating driving experience.", 1, 258, "https://i.pinimg.com/originals/ce/d9/5e/ced95e743efd9f0b5b182c6d4a9d4ef7.jpg", 150000, "BMW", "330i", 15550m, new Guid("03c64b16-d297-4440-a62c-216517b1c8d4"), 1, 2006 });
        }
    }
}
