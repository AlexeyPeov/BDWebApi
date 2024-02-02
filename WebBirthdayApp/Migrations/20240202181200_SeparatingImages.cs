using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebBirthdayApp.Migrations
{
    /// <inheritdoc />
    public partial class SeparatingImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "ImgId",
                table: "Person",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bytes = table.Column<byte[]>(type: "bytea", maxLength: 524288, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Birthday", "ImgId", "Name", "Patronymic", "SecondName" },
                values: new object[,]
                {
                    { 1, new DateOnly(1995, 3, 7), null, "Юрий", "Дмитриевич", "Цветков" },
                    { 2, new DateOnly(1972, 6, 12), null, "Вера", "Тимофеевна", "Соловьева" },
                    { 3, new DateOnly(1984, 8, 2), null, "Евгений", "Федорович", "Виноградов" },
                    { 4, new DateOnly(1985, 2, 12), null, "Галина", "Васильевна", "Соловьева" },
                    { 5, new DateOnly(2003, 9, 25), null, "Ольга", "Васильевна", "Белая" },
                    { 6, new DateOnly(1980, 7, 16), null, "Федор", "Валерьевич", "Зайцев" },
                    { 7, new DateOnly(1984, 1, 25), null, "Ольга", "Евгеньевна", "Давыдова" },
                    { 8, new DateOnly(1993, 10, 12), null, "Юрий", "Ярославович", "Быков" },
                    { 9, new DateOnly(1965, 7, 17), null, "Дмитрий", "Олегович", "Васильев" },
                    { 10, new DateOnly(1982, 6, 17), null, "Виктор", "Семёнович", "Никитин" },
                    { 11, new DateOnly(1991, 12, 1), null, "Тамара", "Игоревна", "Ефимова" },
                    { 12, new DateOnly(1985, 1, 3), null, "Светлана", "Евгеньевна", "Романова" },
                    { 13, new DateOnly(1965, 9, 21), null, "Лариса", "Григорьевна", "Борисова" },
                    { 14, new DateOnly(2006, 2, 25), null, "Светлана", "Алексеевна", "Зайцева" },
                    { 15, new DateOnly(1969, 8, 9), null, "Павел", "Юрьевич", "Ефимов" },
                    { 16, new DateOnly(1985, 7, 1), null, "Станислав", "Андреевич", "Зайцев" },
                    { 17, new DateOnly(1966, 8, 9), null, "Виктория", "Ивановна", "Маслова" },
                    { 18, new DateOnly(1993, 9, 18), null, "Олег", "Дмитриевич", "Крылов" },
                    { 19, new DateOnly(1978, 9, 23), null, "Василий", "Николаевич", "Кузнецов" },
                    { 20, new DateOnly(1990, 9, 17), null, "Владимир", "Юрьевич", "Борисов" },
                    { 21, new DateOnly(1989, 4, 10), null, "Станислав", "Викторович", "Мухин" },
                    { 22, new DateOnly(1976, 10, 9), null, "Олег", "Леонидович", "Маслов" },
                    { 23, new DateOnly(1973, 9, 13), null, "Ольга", "Романовна", "Кукушкина" },
                    { 24, new DateOnly(1983, 1, 7), null, "Игорь", "Васильевич", "Морозов" },
                    { 25, new DateOnly(1969, 12, 19), null, "Георгий", "Семёнович", "Крылов" },
                    { 26, new DateOnly(2006, 3, 23), null, "Евгения", "Федоровна", "Красная" },
                    { 27, new DateOnly(1974, 7, 18), null, "София", "Семёновна", "Давыдова" },
                    { 28, new DateOnly(1974, 7, 26), null, "Денис", "Олегович", "Цветков" },
                    { 29, new DateOnly(1995, 1, 16), null, "Людмила", "Анатольевна", "Быкова" },
                    { 30, new DateOnly(1978, 10, 21), null, "Дмитрий", "Дмитриевич", "Петров" },
                    { 31, new DateOnly(1987, 9, 4), null, "Денис", "Олегович", "Новиков" },
                    { 32, new DateOnly(1987, 5, 17), null, "София", "Олеговна", "Петухова" },
                    { 33, new DateOnly(1999, 1, 23), null, "Людмила", "Васильевна", "Красная" },
                    { 34, new DateOnly(1990, 10, 21), null, "Иван", "Сергеевич", "Виноградов" },
                    { 35, new DateOnly(2002, 2, 9), null, "Алина", "Ивановна", "Волчица" },
                    { 36, new DateOnly(1978, 2, 14), null, "Александра", "Ярославовна", "Кукушкина" },
                    { 37, new DateOnly(2002, 3, 26), null, "Михаил", "Анатольевич", "Ефимов" },
                    { 38, new DateOnly(1968, 10, 10), null, "Дмитрий", "Евгеньевич", "Егоров" },
                    { 39, new DateOnly(2005, 12, 11), null, "Михаил", "Павлович", "Сидоров" },
                    { 40, new DateOnly(1991, 1, 3), null, "Игорь", "Владимирович", "Борисов" },
                    { 41, new DateOnly(1987, 1, 24), null, "Тимофей", "Леонидович", "Виноградов" },
                    { 42, new DateOnly(1976, 10, 13), null, "Елена", "Григорьевна", "Мухина" },
                    { 43, new DateOnly(1985, 4, 3), null, "Вера", "Леонидовна", "Соловьева" },
                    { 44, new DateOnly(1965, 5, 8), null, "Евгений", "Андреевич", "Сидоров" },
                    { 45, new DateOnly(2006, 6, 9), null, "Станислав", "Леонидович", "Маслов" },
                    { 46, new DateOnly(1968, 4, 16), null, "Надежда", "Борисовна", "Виноградова" },
                    { 47, new DateOnly(1979, 4, 21), null, "Александра", "Леонидовна", "Мухина" },
                    { 48, new DateOnly(2000, 2, 8), null, "Людмила", "Васильевна", "Быкова" },
                    { 49, new DateOnly(1969, 8, 22), null, "Лариса", "Георгиевна", "Соловьева" },
                    { 50, new DateOnly(1970, 5, 15), null, "Леонид", "Георгиевич", "Борисов" },
                    { 51, new DateOnly(1968, 3, 1), null, "Борис", "Тимофеевич", "Никитин" },
                    { 52, new DateOnly(1992, 1, 4), null, "Андрей", "Леонидович", "Морозов" },
                    { 53, new DateOnly(1978, 11, 12), null, "Михаил", "Иванович", "Никитин" },
                    { 54, new DateOnly(1976, 9, 26), null, "Андрей", "Олегович", "Никитин" },
                    { 55, new DateOnly(1976, 11, 7), null, "Олег", "Иванович", "Виноградов" },
                    { 56, new DateOnly(2004, 2, 15), null, "Наталья", "Владимировна", "Красная" },
                    { 57, new DateOnly(2002, 11, 6), null, "Федор", "Владимирович", "Козлов" },
                    { 58, new DateOnly(1971, 2, 3), null, "Виктория", "Романовна", "Смирная" },
                    { 59, new DateOnly(1966, 2, 5), null, "Зоя", "Григорьевна", "Борисова" },
                    { 60, new DateOnly(1968, 9, 21), null, "Олег", "Григорьевич", "Лобанов" },
                    { 61, new DateOnly(1975, 6, 21), null, "Виктор", "Иванович", "Морозов" },
                    { 62, new DateOnly(1978, 10, 10), null, "Юрий", "Игоревич", "Быков" },
                    { 63, new DateOnly(1983, 5, 26), null, "Юлия", "Игоревна", "Белая" },
                    { 64, new DateOnly(1996, 12, 20), null, "Денис", "Сергеевич", "Егоров" },
                    { 65, new DateOnly(1995, 10, 19), null, "Оксана", "Владимировна", "Никитина" },
                    { 66, new DateOnly(1984, 1, 6), null, "Виктория", "Федоровна", "Крылова" },
                    { 67, new DateOnly(2006, 1, 3), null, "Иван", "Дмитриевич", "Белов" },
                    { 68, new DateOnly(1983, 11, 17), null, "Игорь", "Анатольевич", "Маслов" },
                    { 69, new DateOnly(1988, 11, 11), null, "Сергей", "Станиславович", "Соколов" },
                    { 70, new DateOnly(1986, 3, 2), null, "Дарья", "Андреевна", "Маслова" },
                    { 71, new DateOnly(2007, 10, 24), null, "Павел", "Евгеньевич", "Романов" },
                    { 72, new DateOnly(1979, 5, 18), null, "Алина", "Евгеньевна", "Соловьева" },
                    { 73, new DateOnly(1986, 6, 25), null, "Валерий", "Тимофеевич", "Петров" },
                    { 74, new DateOnly(2005, 8, 22), null, "Виктор", "Ярославович", "Копылов" },
                    { 75, new DateOnly(1988, 7, 4), null, "Оксана", "Романовна", "Петухова" },
                    { 76, new DateOnly(1973, 3, 7), null, "Галина", "Игоревна", "Рожкова" },
                    { 77, new DateOnly(1969, 12, 13), null, "Екатерина", "Николаевна", "Красная" },
                    { 78, new DateOnly(2005, 2, 1), null, "Иван", "Викторович", "Волков" },
                    { 79, new DateOnly(1974, 7, 8), null, "Валентина", "Павловна", "Борисова" },
                    { 80, new DateOnly(1969, 10, 23), null, "Оксана", "Ивановна", "Волчица" },
                    { 81, new DateOnly(1976, 2, 8), null, "Елена", "Федоровна", "Рожкова" },
                    { 82, new DateOnly(1987, 8, 17), null, "Леонид", "Николаевич", "Борисов" },
                    { 83, new DateOnly(1969, 9, 11), null, "Людмила", "Юрьевна", "Смирная" },
                    { 84, new DateOnly(1971, 11, 12), null, "Григорий", "Владимирович", "Мухин" },
                    { 85, new DateOnly(1966, 2, 21), null, "Елена", "Григорьевна", "Козлова" },
                    { 86, new DateOnly(2000, 7, 26), null, "Оксана", "Алексеевна", "Давыдова" },
                    { 87, new DateOnly(1987, 4, 3), null, "Елена", "Леонидовна", "Зайцева" },
                    { 88, new DateOnly(1967, 6, 26), null, "Виктория", "Юрьевна", "Попугаева" },
                    { 89, new DateOnly(2001, 2, 14), null, "Людмила", "Тимофеевна", "Маслова" },
                    { 90, new DateOnly(1996, 5, 16), null, "Борис", "Дмитриевич", "Никитин" },
                    { 91, new DateOnly(1974, 6, 1), null, "София", "Сергеевна", "Романова" },
                    { 92, new DateOnly(2007, 7, 24), null, "Владимир", "Тимофеевич", "Романов" },
                    { 93, new DateOnly(1982, 8, 9), null, "Евгения", "Анатольевна", "Белая" },
                    { 94, new DateOnly(1991, 1, 15), null, "Валерий", "Иванович", "Никитин" },
                    { 95, new DateOnly(1967, 10, 11), null, "Леонид", "Иванович", "Краснов" },
                    { 96, new DateOnly(1989, 4, 17), null, "Тимофей", "Ярославович", "Соколов" },
                    { 97, new DateOnly(1988, 7, 19), null, "Леонид", "Евгеньевич", "Мухин" },
                    { 98, new DateOnly(1969, 6, 16), null, "Денис", "Алексеевич", "Борисов" },
                    { 99, new DateOnly(1995, 4, 24), null, "Дарья", "Николаевна", "Быкова" },
                    { 100, new DateOnly(1979, 10, 23), null, "Сергей", "Иванович", "Попов" },
                    { 101, new DateOnly(1992, 10, 3), null, "Екатерина", "Игоревна", "Мухина" },
                    { 102, new DateOnly(1993, 7, 2), null, "Евгений", "Антонович", "Виноградов" },
                    { 103, new DateOnly(1968, 5, 22), null, "Татьяна", "Алексеевна", "Давыдова" },
                    { 104, new DateOnly(2005, 6, 12), null, "Евгений", "Георгиевич", "Крылов" },
                    { 105, new DateOnly(2002, 7, 18), null, "Инна", "Ярославовна", "Соколова" },
                    { 106, new DateOnly(1996, 7, 10), null, "Юлия", "Тимофеевна", "Романова" },
                    { 107, new DateOnly(1984, 12, 12), null, "Елена", "Романовна", "Маслова" },
                    { 108, new DateOnly(1985, 7, 13), null, "Елена", "Владимировна", "Соколова" },
                    { 109, new DateOnly(1979, 10, 25), null, "Инна", "Ивановна", "Ефимова" },
                    { 110, new DateOnly(2007, 5, 2), null, "Вера", "Федоровна", "Цветкова" },
                    { 111, new DateOnly(1966, 1, 6), null, "Дмитрий", "Федорович", "Кузнецов" },
                    { 112, new DateOnly(1971, 2, 9), null, "Оксана", "Андреевна", "Волчица" },
                    { 113, new DateOnly(1973, 3, 25), null, "Алексей", "Романович", "Попов" },
                    { 114, new DateOnly(1976, 4, 4), null, "Оксана", "Денисовна", "Борисова" },
                    { 115, new DateOnly(1967, 7, 14), null, "Оксана", "Сергеевна", "Попугаева" },
                    { 116, new DateOnly(2001, 1, 22), null, "Мария", "Борисовна", "Соловьева" },
                    { 117, new DateOnly(1990, 1, 15), null, "Василий", "Иванович", "Петров" },
                    { 118, new DateOnly(1990, 6, 9), null, "Анна", "Андреевна", "Соловьева" },
                    { 119, new DateOnly(1969, 2, 20), null, "Ольга", "Сергеевна", "Петухова" },
                    { 120, new DateOnly(1966, 9, 26), null, "Алина", "Валерьевна", "Быкова" },
                    { 121, new DateOnly(2006, 9, 4), null, "Татьяна", "Дмитриевна", "Смирная" },
                    { 122, new DateOnly(1980, 8, 5), null, "Олег", "Игоревич", "Борисов" },
                    { 123, new DateOnly(2001, 4, 11), null, "Елена", "Анатольевна", "Виноградова" },
                    { 124, new DateOnly(1965, 1, 14), null, "Светлана", "Борисовна", "Василькова" },
                    { 125, new DateOnly(1983, 8, 10), null, "Светлана", "Ивановна", "Романова" },
                    { 126, new DateOnly(1985, 10, 6), null, "Вера", "Олеговна", "Борисова" },
                    { 127, new DateOnly(1990, 5, 5), null, "Валерий", "Тимофеевич", "Попов" },
                    { 128, new DateOnly(1967, 1, 2), null, "Елена", "Анатольевна", "Василькова" },
                    { 129, new DateOnly(2001, 6, 15), null, "Алексей", "Романович", "Сидоров" },
                    { 130, new DateOnly(1971, 10, 10), null, "Владимир", "Евгеньевич", "Егоров" },
                    { 131, new DateOnly(1992, 11, 8), null, "Екатерина", "Станиславовна", "Василькова" },
                    { 132, new DateOnly(1974, 11, 7), null, "Борис", "Юрьевич", "Смирнов" },
                    { 133, new DateOnly(1969, 1, 5), null, "Валентина", "Анатольевна", "Давыдова" },
                    { 134, new DateOnly(1980, 8, 12), null, "Мария", "Андреевна", "Василькова" },
                    { 135, new DateOnly(1984, 3, 3), null, "Григорий", "Андреевич", "Соколов" },
                    { 136, new DateOnly(1987, 10, 12), null, "Светлана", "Евгеньевна", "Зайцева" },
                    { 137, new DateOnly(1970, 9, 20), null, "Надежда", "Васильевна", "Красная" },
                    { 138, new DateOnly(2004, 12, 11), null, "Инна", "Игоревна", "Соловьева" },
                    { 139, new DateOnly(1982, 12, 8), null, "Ольга", "Семёновна", "Давыдова" },
                    { 140, new DateOnly(1997, 7, 8), null, "Людмила", "Евгеньевна", "Кукушкина" },
                    { 141, new DateOnly(1972, 5, 8), null, "Виктор", "Романович", "Егоров" },
                    { 142, new DateOnly(1972, 8, 4), null, "Зоя", "Андреевна", "Волчица" },
                    { 143, new DateOnly(1998, 12, 6), null, "Евгений", "Алексеевич", "Кузнецов" },
                    { 144, new DateOnly(1970, 9, 6), null, "Оксана", "Олеговна", "Красная" },
                    { 145, new DateOnly(1992, 2, 13), null, "Наталья", "Сергеевна", "Василькова" },
                    { 146, new DateOnly(1965, 4, 16), null, "Григорий", "Анатольевич", "Белов" },
                    { 147, new DateOnly(2000, 1, 9), null, "Галина", "Анатольевна", "Морозова" },
                    { 148, new DateOnly(2006, 3, 21), null, "Федор", "Иванович", "Мухин" },
                    { 149, new DateOnly(1998, 12, 17), null, "Инна", "Евгеньевна", "Новикова" },
                    { 150, new DateOnly(1971, 12, 8), null, "Юрий", "Владимирович", "Новиков" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_ImgId",
                table: "Person",
                column: "ImgId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Image_ImgId",
                table: "Person",
                column: "ImgId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Image_ImgId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Person_ImgId",
                table: "Person");

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DropColumn(
                name: "ImgId",
                table: "Person");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Person",
                type: "bytea",
                maxLength: 524288,
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
