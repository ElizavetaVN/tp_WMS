using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalOperation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    INN = table.Column<int>(nullable: false),
                    OGRN = table.Column<int>(nullable: false),
                    OKPO = table.Column<int>(nullable: false),
                    KPP = table.Column<int>(nullable: false),
                    LegalAddress = table.Column<string>(nullable: true),
                    ActuallAddress = table.Column<string>(nullable: true),
                    PostallAddress = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealizationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealizationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationWriteType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationWriteType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ArticleNumber = table.Column<int>(nullable: false),
                    ProviderId = table.Column<int>(nullable: true),
                    UnitsId = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Partners_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Internal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehousesId = table.Column<int>(nullable: true),
                    ProductsId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    OperationId = table.Column<int>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Internal_InternalOperation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "InternalOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Internal_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Internal_InternalStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "InternalStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Internal_Warehouses_WarehousesId",
                        column: x => x.WarehousesId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductsId = table.Column<int>(nullable: true),
                    QuantityFact = table.Column<string>(nullable: true),
                    QuantityAcc = table.Column<string>(nullable: true),
                    Units = table.Column<int>(nullable: false),
                    WarehousesId = table.Column<int>(nullable: true),
                    Deviation = table.Column<int>(nullable: false),
                    Employee = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory_Warehouses_WarehousesId",
                        column: x => x.WarehousesId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Moving",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehousesFromId = table.Column<int>(nullable: true),
                    WarehousesToId = table.Column<int>(nullable: true),
                    ProductsId = table.Column<int>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    UnitsId = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Employee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moving", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moving_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moving_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moving_Warehouses_WarehousesFromId",
                        column: x => x.WarehousesFromId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moving_Warehouses_WarehousesToId",
                        column: x => x.WarehousesToId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTypeId = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    PartnersId = table.Column<int>(nullable: true),
                    WarehousesId = table.Column<int>(nullable: true),
                    Employee = table.Column<string>(nullable: true),
                    ProductsId = table.Column<int>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    UnitsId = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    OrderStatusId = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderType_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "OrderType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Partners_PartnersId",
                        column: x => x.PartnersId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Warehouses_WarehousesId",
                        column: x => x.WarehousesId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationWrite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationWriteTypeId = table.Column<int>(nullable: true),
                    InventoryId = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    WarehousesId = table.Column<int>(nullable: true),
                    ProductsId = table.Column<int>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    UnitsId = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Employee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationWrite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationWrite_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationWrite_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationWrite_RegistrationWriteType_RegistrationWriteTypeId",
                        column: x => x.RegistrationWriteTypeId,
                        principalTable: "RegistrationWriteType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationWrite_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationWrite_Warehouses_WarehousesId",
                        column: x => x.WarehousesId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Realization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealizationTypeId = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderId = table.Column<int>(nullable: true),
                    Partners = table.Column<int>(nullable: false),
                    Warehouses = table.Column<int>(nullable: false),
                    Products = table.Column<int>(nullable: false),
                    Quantity = table.Column<string>(nullable: true),
                    Units = table.Column<int>(nullable: false),
                    Employee = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Realization_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Realization_RealizationType_RealizationTypeId",
                        column: x => x.RealizationTypeId,
                        principalTable: "RealizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "InternalOperation",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Оприходование" },
                    { 2, "Списание" },
                    { 3, "Заказ клиента" },
                    { 4, "Заказ поставщику" },
                    { 5, "Отгрузка" },
                    { 6, "Поступление" }
                });

            migrationBuilder.InsertData(
                table: "InternalStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Оприходование" },
                    { 2, "Списание" },
                    { 3, "К обеспечению" },
                    { 4, "Резерв" },
                    { 5, "Не в резерве" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Отменен" },
                    { 6, "Выполнен" },
                    { 5, "Принят" },
                    { 2, "Новый" },
                    { 3, "Ожидает проверки" },
                    { 1, "Без статуса" },
                    { 4, "Ожидает отгрузки" }
                });

            migrationBuilder.InsertData(
                table: "OrderType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Заказ клиента" },
                    { 2, "Заказ поставщику" }
                });

            migrationBuilder.InsertData(
                table: "RealizationType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Списание товаров" },
                    { 2, "Поступление товаров" }
                });

            migrationBuilder.InsertData(
                table: "RegistrationWriteType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Списание" },
                    { 1, "Оприходование" },
                    { 3, "Отгрузка" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Internal_OperationId",
                table: "Internal",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Internal_ProductsId",
                table: "Internal",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Internal_StatusId",
                table: "Internal",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Internal_WarehousesId",
                table: "Internal",
                column: "WarehousesId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductsId",
                table: "Inventory",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_WarehousesId",
                table: "Inventory",
                column: "WarehousesId");

            migrationBuilder.CreateIndex(
                name: "IX_Moving_ProductsId",
                table: "Moving",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Moving_UnitsId",
                table: "Moving",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Moving_WarehousesFromId",
                table: "Moving",
                column: "WarehousesFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Moving_WarehousesToId",
                table: "Moving",
                column: "WarehousesToId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderTypeId",
                table: "Orders",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PartnersId",
                table: "Orders",
                column: "PartnersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductsId",
                table: "Orders",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UnitsId",
                table: "Orders",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WarehousesId",
                table: "Orders",
                column: "WarehousesId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProviderId",
                table: "Products",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitsId",
                table: "Products",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Realization_OrderId",
                table: "Realization",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Realization_RealizationTypeId",
                table: "Realization",
                column: "RealizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationWrite_InventoryId",
                table: "RegistrationWrite",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationWrite_ProductsId",
                table: "RegistrationWrite",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationWrite_RegistrationWriteTypeId",
                table: "RegistrationWrite",
                column: "RegistrationWriteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationWrite_UnitsId",
                table: "RegistrationWrite",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationWrite_WarehousesId",
                table: "RegistrationWrite",
                column: "WarehousesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Internal");

            migrationBuilder.DropTable(
                name: "Moving");

            migrationBuilder.DropTable(
                name: "Realization");

            migrationBuilder.DropTable(
                name: "RegistrationWrite");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "InternalOperation");

            migrationBuilder.DropTable(
                name: "InternalStatus");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RealizationType");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "RegistrationWriteType");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "OrderType");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
