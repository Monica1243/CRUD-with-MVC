using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    MembershipType = table.Column<bool>(name: "Membership Type", type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<decimal>(name: "Discount%", type: "decimal(5,2)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(name: "Modified At", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__65D16264C60AAFE8", x => x.MembershipType);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(name: "Category Id", type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModifiedAt = table.Column<DateTime>(name: "Modified At", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductC__788261CC1D8521BF", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesAmount = table.Column<decimal>(name: "Sales Amount", type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TaxCalculation",
                columns: table => new
                {
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Tax = table.Column<decimal>(name: "Tax%", type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MembershipType = table.Column<bool>(name: "Membership Type", type: "bit", nullable: true, defaultValue: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "user"),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModifiedAt = table.Column<DateTime>(name: "Modified At", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserDeta__1788CC4C93743731", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__UserDetai__Membe__5535A963",
                        column: x => x.MembershipType,
                        principalTable: "Discounts",
                        principalColumn: "Membership Type");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(name: "Product ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(name: "Product Name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductDescription = table.Column<string>(name: "Product Description", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductImage = table.Column<string>(name: "Product Image", type: "text", nullable: false),
                    CategoryID = table.Column<int>(name: "Category ID", type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    AvailableQuantity = table.Column<int>(name: "Available Quantity", type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(name: "Modified At", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__AF0FD00BD433A4E9", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK__Products__Catego__3A81B327",
                        column: x => x.CategoryID,
                        principalTable: "ProductCategory",
                        principalColumn: "Category Id");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(name: "Product ID", type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__3214EC27F57AFA38", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Cart__Product ID__628FA481",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Product ID");
                });

            migrationBuilder.CreateTable(
                name: "Order Details",
                columns: table => new
                {
                    OrderID = table.Column<int>(name: "Order ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(name: "Product ID", type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(name: "Modified At", type: "datetime2", nullable: false),
                    ReasonforCancellation = table.Column<string>(name: "Reason for Cancellation", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order De__81BDAE1E552627B1", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK__Order Det__Produ__5812160E",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Product ID");
                });

            migrationBuilder.CreateTable(
                name: "Order Summary",
                columns: table => new
                {
                    OrderID = table.Column<int>(name: "Order ID", type: "int", nullable: false),
                    UserID = table.Column<int>(name: "User ID", type: "int", nullable: false),
                    InvoiceAmount = table.Column<decimal>(name: "Invoice Amount", type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(name: "Tax Amount", type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(name: "Total Amount", type: "decimal(20,2)", nullable: true, computedColumnSql: "(([Invoice Amount]+[Tax Amount])-[Discount])", stored: false),
                    PaymentType = table.Column<string>(name: "Payment Type", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedAt = table.Column<DateTime>(name: "Modified At", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Order Sum__Order__5EBF139D",
                        column: x => x.OrderID,
                        principalTable: "Order Details",
                        principalColumn: "Order ID");
                    table.ForeignKey(
                        name: "FK__Order Sum__User __5FB337D6",
                        column: x => x.UserID,
                        principalTable: "UserDetails",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "RefundDetails",
                columns: table => new
                {
                    OrderID = table.Column<int>(name: "Order ID", type: "int", nullable: false),
                    ProductID = table.Column<int>(name: "Product ID", type: "int", nullable: false),
                    RefundStatus = table.Column<string>(name: "Refund Status", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RefundAmount = table.Column<decimal>(name: "Refund Amount", type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__RefundDet__Order__6477ECF3",
                        column: x => x.OrderID,
                        principalTable: "Order Details",
                        principalColumn: "Order ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Product ID",
                table: "Cart",
                column: "Product ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order Details_Product ID",
                table: "Order Details",
                column: "Product ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order Summary_Order ID",
                table: "Order Summary",
                column: "Order ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order Summary_User ID",
                table: "Order Summary",
                column: "User ID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category ID",
                table: "Products",
                column: "Category ID");

            migrationBuilder.CreateIndex(
                name: "IX_RefundDetails_Order ID",
                table: "RefundDetails",
                column: "Order ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_Membership Type",
                table: "UserDetails",
                column: "Membership Type");

            migrationBuilder.CreateIndex(
                name: "UQ__UserDeta__5C7E359E9BA166E4",
                table: "UserDetails",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__UserDeta__A9D105349E6DF4BC",
                table: "UserDetails",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Order Summary");

            migrationBuilder.DropTable(
                name: "RefundDetails");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "TaxCalculation");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "Order Details");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
