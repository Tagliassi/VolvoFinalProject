﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolvoFinalProject.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Telephone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactsID);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFK = table.Column<int>(type: "int", nullable: false),
                    ServiceFK = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryServices",
                columns: table => new
                {
                    CategoryServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceFK = table.Column<int>(type: "int", nullable: false),
                    ExecutionTime = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryServices", x => x.CategoryServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    PartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Availabity = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryServiceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.PartID);
                    table.ForeignKey(
                        name: "FK_Part_CategoryServices_CategoryServiceID",
                        column: x => x.CategoryServiceID,
                        principalTable: "CategoryServices",
                        principalColumn: "CategoryServiceID");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceFK = table.Column<int>(type: "int", nullable: false),
                    BillFK = table.Column<int>(type: "int", nullable: false),
                    ContactFK = table.Column<int>(type: "int", nullable: false),
                    VehicleFK = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Bills_BillFK",
                        column: x => x.BillFK,
                        principalTable: "Bills",
                        principalColumn: "BillID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customers_Contact_ContactFK",
                        column: x => x.ContactFK,
                        principalTable: "Contact",
                        principalColumn: "ContactsID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    DealerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactFK = table.Column<int>(type: "int", nullable: false),
                    ServiceFK = table.Column<int>(type: "int", nullable: false),
                    EmployeeFK = table.Column<int>(type: "int", nullable: false),
                    CustomerFK = table.Column<int>(type: "int", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.DealerID);
                    table.ForeignKey(
                        name: "FK_Dealers_Contact_ContactFK",
                        column: x => x.ContactFK,
                        principalTable: "Contact",
                        principalColumn: "ContactsID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Dealers_Customers_CustomerFK",
                        column: x => x.CustomerFK,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealerFK = table.Column<int>(type: "int", nullable: false),
                    ServiceFK = table.Column<int>(type: "int", nullable: false),
                    ContactFK = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    BaseSalary = table.Column<double>(type: "float", nullable: false),
                    Commission = table.Column<double>(type: "float", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Employees = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Contact_ContactFK",
                        column: x => x.ContactFK,
                        principalTable: "Contact",
                        principalColumn: "ContactsID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Employees_Dealers_DealerFK",
                        column: x => x.DealerFK,
                        principalTable: "Dealers",
                        principalColumn: "DealerID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartFK = table.Column<int>(type: "int", nullable: false),
                    EmployeeFK = table.Column<int>(type: "int", nullable: false),
                    CustomerFK = table.Column<int>(type: "int", nullable: false),
                    VehicleFK = table.Column<int>(type: "int", nullable: false),
                    CategoryServiceFK = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Situation = table.Column<int>(type: "int", nullable: false),
                    PartsFK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Services_CategoryServices_CategoryServiceFK",
                        column: x => x.CategoryServiceFK,
                        principalTable: "CategoryServices",
                        principalColumn: "CategoryServiceID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Services_Customers_CustomerFK",
                        column: x => x.CustomerFK,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Services_Employees_EmployeeFK",
                        column: x => x.EmployeeFK,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Services_Part_PartsFK",
                        column: x => x.PartsFK,
                        principalTable: "Part",
                        principalColumn: "PartID");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFK = table.Column<int>(type: "int", nullable: false),
                    ServiceFK = table.Column<int>(type: "int", nullable: false),
                    ChassisNumber = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Kilometrage = table.Column<double>(type: "float", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SystemVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicles_Customers_CustomerFK",
                        column: x => x.CustomerFK,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicles_Services_ServiceFK",
                        column: x => x.ServiceFK,
                        principalTable: "Services",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CustomerFK",
                table: "Bills",
                column: "CustomerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ServiceFK",
                table: "Bills",
                column: "ServiceFK");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryServices_ServiceFK",
                table: "CategoryServices",
                column: "ServiceFK");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BillFK",
                table: "Customers",
                column: "BillFK");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactFK",
                table: "Customers",
                column: "ContactFK");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ServiceFK",
                table: "Customers",
                column: "ServiceFK");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_VehicleFK",
                table: "Customers",
                column: "VehicleFK");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_ContactFK",
                table: "Dealers",
                column: "ContactFK");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_CustomerFK",
                table: "Dealers",
                column: "CustomerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_EmployeeFK",
                table: "Dealers",
                column: "EmployeeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_ServiceFK",
                table: "Dealers",
                column: "ServiceFK");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContactFK",
                table: "Employees",
                column: "ContactFK");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DealerFK",
                table: "Employees",
                column: "DealerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ServiceFK",
                table: "Employees",
                column: "ServiceFK");

            migrationBuilder.CreateIndex(
                name: "IX_Part_CategoryServiceID",
                table: "Part",
                column: "CategoryServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryServiceFK",
                table: "Services",
                column: "CategoryServiceFK");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CustomerFK",
                table: "Services",
                column: "CustomerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Services_EmployeeFK",
                table: "Services",
                column: "EmployeeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Services_PartsFK",
                table: "Services",
                column: "PartsFK");

            migrationBuilder.CreateIndex(
                name: "IX_Services_VehicleFK",
                table: "Services",
                column: "VehicleFK");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomerFK",
                table: "Vehicles",
                column: "CustomerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ServiceFK",
                table: "Vehicles",
                column: "ServiceFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Customers_CustomerFK",
                table: "Bills",
                column: "CustomerFK",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Services_ServiceFK",
                table: "Bills",
                column: "ServiceFK",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryServices_Services_ServiceFK",
                table: "CategoryServices",
                column: "ServiceFK",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Services_ServiceFK",
                table: "Customers",
                column: "ServiceFK",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Vehicles_VehicleFK",
                table: "Customers",
                column: "VehicleFK",
                principalTable: "Vehicles",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_Employees_EmployeeFK",
                table: "Dealers",
                column: "EmployeeFK",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_Services_ServiceFK",
                table: "Dealers",
                column: "ServiceFK",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Services_ServiceFK",
                table: "Employees",
                column: "ServiceFK",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Vehicles_VehicleFK",
                table: "Services",
                column: "VehicleFK",
                principalTable: "Vehicles",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Customers_CustomerFK",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_Customers_CustomerFK",
                table: "Dealers");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Customers_CustomerFK",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Customers_CustomerFK",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryServices_Services_ServiceFK",
                table: "CategoryServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_Services_ServiceFK",
                table: "Dealers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Services_ServiceFK",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Services_ServiceFK",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_Contact_ContactFK",
                table: "Dealers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Contact_ContactFK",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_Employees_EmployeeFK",
                table: "Dealers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "CategoryServices");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Dealers");
        }
    }
}
