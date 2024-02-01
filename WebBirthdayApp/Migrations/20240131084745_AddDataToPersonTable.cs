using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebBirthdayApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToPersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Birthday", "Name", "Patronymic", "SecondName" },
                values: new object[,]
                {
                    { 1, new DateOnly(1971, 9, 16), "Игорь", "Ярославович", "Белов" },
                    { 2, new DateOnly(1971, 5, 3), "Людмила", "Ивановна", "Волчица" },
                    { 3, new DateOnly(1975, 5, 15), "Виктория", "Викторовна", "Виноградова" },
                    { 4, new DateOnly(1994, 1, 8), "Елена", "Евгеньевна", "Волчица" },
                    { 5, new DateOnly(1967, 12, 20), "Станислав", "Павлович", "Смирнов" },
                    { 6, new DateOnly(2001, 9, 15), "Екатерина", "Анатольевна", "Зайцева" },
                    { 7, new DateOnly(1994, 9, 3), "Зоя", "Леонидовна", "Копылова" },
                    { 8, new DateOnly(1988, 4, 13), "Елена", "Евгеньевна", "Соловьева" },
                    { 9, new DateOnly(1986, 3, 3), "Евгения", "Евгеньевна", "Василькова" },
                    { 10, new DateOnly(1995, 5, 17), "Анна", "Станиславовна", "Борисова" },
                    { 11, new DateOnly(1966, 5, 26), "Станислав", "Георгиевич", "Козлов" },
                    { 12, new DateOnly(1975, 8, 10), "Светлана", "Игоревна", "Соловьева" },
                    { 13, new DateOnly(1972, 8, 12), "Игорь", "Борисович", "Маслов" },
                    { 14, new DateOnly(1966, 8, 10), "Вера", "Олеговна", "Смирная" },
                    { 15, new DateOnly(1998, 7, 20), "Григорий", "Дмитриевич", "Рожков" },
                    { 16, new DateOnly(2007, 10, 7), "Григорий", "Борисович", "Копылов" },
                    { 17, new DateOnly(1995, 7, 17), "Алексей", "Андреевич", "Лобанов" },
                    { 18, new DateOnly(1976, 6, 19), "Олег", "Иванович", "Романов" },
                    { 19, new DateOnly(1975, 6, 12), "Людмила", "Дмитриевна", "Соловьева" },
                    { 20, new DateOnly(1999, 11, 18), "Владимир", "Валерьевич", "Васильев" },
                    { 21, new DateOnly(1974, 10, 9), "Борис", "Антонович", "Виноградов" },
                    { 22, new DateOnly(1990, 11, 17), "Станислав", "Валерьевич", "Соловьев" },
                    { 23, new DateOnly(2007, 4, 4), "Сергей", "Владимирович", "Никитин" },
                    { 24, new DateOnly(1985, 1, 25), "Анна", "Владимировна", "Смирная" },
                    { 25, new DateOnly(1996, 4, 11), "Юлия", "Николаевна", "Петухова" },
                    { 26, new DateOnly(1991, 8, 26), "Светлана", "Евгеньевна", "Петухова" },
                    { 27, new DateOnly(1994, 8, 1), "Лариса", "Алексеевна", "Попугаева" },
                    { 28, new DateOnly(1989, 10, 8), "Сергей", "Семёнович", "Копылов" },
                    { 29, new DateOnly(1970, 7, 13), "Николай", "Иванович", "Крылов" },
                    { 30, new DateOnly(1975, 6, 14), "Дмитрий", "Тимофеевич", "Лобанов" },
                    { 31, new DateOnly(1998, 6, 26), "Денис", "Олегович", "Никитин" },
                    { 32, new DateOnly(1980, 5, 21), "Александра", "Дмитриевна", "Виноградова" },
                    { 33, new DateOnly(1976, 2, 25), "Алина", "Романовна", "Кукушкина" },
                    { 34, new DateOnly(2006, 10, 10), "Лариса", "Ярославовна", "Рожкова" },
                    { 35, new DateOnly(1999, 7, 9), "Юлия", "Игоревна", "Ефимова" },
                    { 36, new DateOnly(1991, 10, 7), "Ольга", "Романовна", "Романова" },
                    { 37, new DateOnly(2001, 5, 11), "Андрей", "Георгиевич", "Смирнов" },
                    { 38, new DateOnly(2007, 11, 23), "Тимофей", "Евгеньевич", "Попов" },
                    { 39, new DateOnly(1968, 9, 21), "Олег", "Евгеньевич", "Белов" },
                    { 40, new DateOnly(1982, 9, 26), "Лариса", "Георгиевна", "Кукушкина" },
                    { 41, new DateOnly(1965, 4, 14), "Марина", "Сергеевна", "Маслова" },
                    { 42, new DateOnly(1978, 4, 9), "Борис", "Юрьевич", "Новиков" },
                    { 43, new DateOnly(2002, 2, 18), "Тамара", "Викторовна", "Никитина" },
                    { 44, new DateOnly(1973, 5, 23), "Федор", "Владимирович", "Соловьев" },
                    { 45, new DateOnly(1999, 12, 12), "Ольга", "Андреевна", "Цветкова" },
                    { 46, new DateOnly(1993, 1, 14), "Анна", "Валерьевна", "Маслова" },
                    { 47, new DateOnly(2002, 8, 12), "Елена", "Георгиевна", "Копылова" },
                    { 48, new DateOnly(1985, 3, 6), "София", "Ивановна", "Борисова" },
                    { 49, new DateOnly(2007, 6, 13), "Анатолий", "Федорович", "Соколов" },
                    { 50, new DateOnly(1985, 11, 26), "Тамара", "Романовна", "Петухова" },
                    { 51, new DateOnly(1970, 3, 10), "Денис", "Романович", "Белов" },
                    { 52, new DateOnly(1971, 4, 5), "Анна", "Евгеньевна", "Козлова" },
                    { 53, new DateOnly(2004, 12, 18), "Олег", "Анатольевич", "Цветков" },
                    { 54, new DateOnly(1982, 5, 17), "Олег", "Игоревич", "Борисов" },
                    { 55, new DateOnly(1983, 10, 5), "Юрий", "Евгеньевич", "Крылов" },
                    { 56, new DateOnly(2006, 3, 2), "Тамара", "Ярославовна", "Смирная" },
                    { 57, new DateOnly(1977, 9, 4), "Дмитрий", "Алексеевич", "Егоров" },
                    { 58, new DateOnly(2002, 5, 20), "Виктор", "Иванович", "Крылов" },
                    { 59, new DateOnly(1971, 1, 12), "Мария", "Евгеньевна", "Ефимова" },
                    { 60, new DateOnly(1986, 8, 26), "Денис", "Георгиевич", "Сидоров" },
                    { 61, new DateOnly(1980, 8, 3), "Галина", "Григорьевна", "Соловьева" },
                    { 62, new DateOnly(1984, 10, 23), "Юлия", "Евгеньевна", "Зайцева" },
                    { 63, new DateOnly(1999, 8, 16), "Дарья", "Денисовна", "Зайцева" },
                    { 64, new DateOnly(1965, 1, 3), "Валентина", "Алексеевна", "Кукушкина" },
                    { 65, new DateOnly(1976, 8, 11), "Анатолий", "Андреевич", "Васильев" },
                    { 66, new DateOnly(2000, 7, 7), "Виктор", "Борисович", "Петров" },
                    { 67, new DateOnly(1966, 8, 6), "Анатолий", "Семёнович", "Борисов" },
                    { 68, new DateOnly(1983, 1, 19), "Галина", "Евгеньевна", "Рожкова" },
                    { 69, new DateOnly(2002, 12, 16), "Федор", "Сергеевич", "Никитин" },
                    { 70, new DateOnly(1965, 12, 1), "Антон", "Олегович", "Мухин" },
                    { 71, new DateOnly(1997, 5, 5), "Инна", "Анатольевна", "Мухина" },
                    { 72, new DateOnly(1985, 6, 21), "Виктория", "Григорьевна", "Соловьева" },
                    { 73, new DateOnly(1982, 12, 17), "Юлия", "Олеговна", "Василькова" },
                    { 74, new DateOnly(1994, 2, 1), "Ольга", "Дмитриевна", "Мухина" },
                    { 75, new DateOnly(1982, 1, 16), "Валентина", "Сергеевна", "Новикова" },
                    { 76, new DateOnly(1987, 11, 22), "Людмила", "Евгеньевна", "Ефимова" },
                    { 77, new DateOnly(1994, 2, 1), "Евгений", "Семёнович", "Ефимов" },
                    { 78, new DateOnly(2005, 12, 3), "Елена", "Юрьевна", "Романова" },
                    { 79, new DateOnly(1970, 5, 24), "Валентина", "Дмитриевна", "Красная" },
                    { 80, new DateOnly(1999, 1, 23), "Станислав", "Станиславович", "Зайцев" },
                    { 81, new DateOnly(1967, 6, 4), "Мария", "Ивановна", "Козлова" },
                    { 82, new DateOnly(1965, 4, 10), "Иван", "Ярославович", "Козлов" },
                    { 83, new DateOnly(2007, 8, 7), "Александра", "Ярославовна", "Соколова" },
                    { 84, new DateOnly(1985, 10, 18), "Николай", "Владимирович", "Цветков" },
                    { 85, new DateOnly(1981, 12, 14), "Ольга", "Николаевна", "Давыдова" },
                    { 86, new DateOnly(1987, 5, 8), "Наталья", "Сергеевна", "Крылова" },
                    { 87, new DateOnly(1993, 6, 7), "Денис", "Валерьевич", "Козлов" },
                    { 88, new DateOnly(1994, 12, 2), "Николай", "Иванович", "Рожков" },
                    { 89, new DateOnly(1978, 7, 11), "Владимир", "Олегович", "Борисов" },
                    { 90, new DateOnly(1973, 10, 13), "Анатолий", "Георгиевич", "Соколов" },
                    { 91, new DateOnly(2005, 4, 17), "Павел", "Игоревич", "Копылов" },
                    { 92, new DateOnly(1978, 6, 19), "Олег", "Леонидович", "Васильев" },
                    { 93, new DateOnly(1967, 8, 14), "Олег", "Иванович", "Соколов" },
                    { 94, new DateOnly(1966, 11, 18), "Дмитрий", "Сергеевич", "Сидоров" },
                    { 95, new DateOnly(1982, 4, 21), "Тамара", "Григорьевна", "Рожкова" },
                    { 96, new DateOnly(1971, 8, 16), "Галина", "Николаевна", "Зайцева" },
                    { 97, new DateOnly(1979, 9, 3), "Оксана", "Ярославовна", "Зайцева" },
                    { 98, new DateOnly(1979, 5, 8), "Валентина", "Денисовна", "Смирная" },
                    { 99, new DateOnly(1989, 11, 26), "Иван", "Борисович", "Лобанов" },
                    { 100, new DateOnly(1982, 3, 20), "Сергей", "Романович", "Быков" },
                    { 101, new DateOnly(1996, 10, 21), "Виктор", "Евгеньевич", "Копылов" },
                    { 102, new DateOnly(1984, 11, 25), "Инна", "Олеговна", "Рожкова" },
                    { 103, new DateOnly(1979, 11, 25), "Александра", "Ивановна", "Красная" },
                    { 104, new DateOnly(1990, 10, 10), "Алина", "Георгиевна", "Красная" },
                    { 105, new DateOnly(2005, 7, 9), "Олег", "Ярославович", "Романов" },
                    { 106, new DateOnly(1981, 9, 15), "Анна", "Николаевна", "Кукушкина" },
                    { 107, new DateOnly(1999, 6, 21), "Екатерина", "Григорьевна", "Мухина" },
                    { 108, new DateOnly(1985, 8, 2), "Татьяна", "Игоревна", "Мухина" },
                    { 109, new DateOnly(2004, 12, 23), "Александра", "Георгиевна", "Попугаева" },
                    { 110, new DateOnly(1981, 8, 9), "Павел", "Ярославович", "Волков" },
                    { 111, new DateOnly(1996, 8, 8), "Иван", "Семёнович", "Цветков" },
                    { 112, new DateOnly(2006, 7, 1), "Галина", "Валерьевна", "Соловьева" },
                    { 113, new DateOnly(2004, 7, 9), "Виктория", "Игоревна", "Попугаева" },
                    { 114, new DateOnly(2007, 2, 23), "Зоя", "Игоревна", "Соловьева" },
                    { 115, new DateOnly(1974, 6, 19), "Оксана", "Юрьевна", "Лобанова" },
                    { 116, new DateOnly(1991, 2, 20), "Иван", "Сергеевич", "Волков" },
                    { 117, new DateOnly(1974, 10, 14), "Ирина", "Денисовна", "Петухова" },
                    { 118, new DateOnly(1990, 5, 26), "Ярослав", "Дмитриевич", "Белов" },
                    { 119, new DateOnly(1970, 12, 3), "София", "Андреевна", "Цветкова" },
                    { 120, new DateOnly(1975, 12, 8), "Владимир", "Павлович", "Кузнецов" },
                    { 121, new DateOnly(1993, 3, 3), "Александра", "Денисовна", "Копылова" },
                    { 122, new DateOnly(1995, 8, 25), "Николай", "Евгеньевич", "Соловьев" },
                    { 123, new DateOnly(2002, 2, 9), "Олег", "Романович", "Копылов" },
                    { 124, new DateOnly(2007, 10, 5), "Тимофей", "Романович", "Быков" },
                    { 125, new DateOnly(1972, 3, 22), "Олег", "Алексеевич", "Романов" },
                    { 126, new DateOnly(1967, 12, 20), "Мария", "Георгиевна", "Соколова" },
                    { 127, new DateOnly(1979, 6, 4), "Роман", "Георгиевич", "Ефимов" },
                    { 128, new DateOnly(1980, 2, 16), "Светлана", "Денисовна", "Морозова" },
                    { 129, new DateOnly(1999, 9, 6), "Алексей", "Тимофеевич", "Волков" },
                    { 130, new DateOnly(1979, 7, 20), "Сергей", "Павлович", "Зайцев" },
                    { 131, new DateOnly(2007, 9, 2), "Николай", "Иванович", "Копылов" },
                    { 132, new DateOnly(1991, 3, 8), "Ольга", "Леонидовна", "Красная" },
                    { 133, new DateOnly(2006, 7, 12), "Галина", "Викторовна", "Василькова" },
                    { 134, new DateOnly(2006, 1, 23), "Ирина", "Григорьевна", "Морозова" },
                    { 135, new DateOnly(1998, 2, 10), "Сергей", "Олегович", "Лобанов" },
                    { 136, new DateOnly(1977, 8, 1), "Виктор", "Игоревич", "Краснов" },
                    { 137, new DateOnly(2000, 5, 21), "Елена", "Ярославовна", "Маслова" },
                    { 138, new DateOnly(1997, 8, 22), "София", "Дмитриевна", "Василькова" },
                    { 139, new DateOnly(1981, 10, 3), "Федор", "Андреевич", "Сидоров" },
                    { 140, new DateOnly(1975, 9, 20), "Алина", "Евгеньевна", "Василькова" },
                    { 141, new DateOnly(1975, 10, 1), "София", "Ивановна", "Лобанова" },
                    { 142, new DateOnly(1987, 4, 25), "Юрий", "Ярославович", "Соколов" },
                    { 143, new DateOnly(1993, 12, 20), "Андрей", "Владимирович", "Виноградов" },
                    { 144, new DateOnly(1970, 9, 11), "Тимофей", "Иванович", "Никитин" },
                    { 145, new DateOnly(1980, 2, 22), "Ярослав", "Евгеньевич", "Соколов" },
                    { 146, new DateOnly(2001, 9, 8), "Сергей", "Евгеньевич", "Маслов" },
                    { 147, new DateOnly(1997, 10, 18), "Мария", "Тимофеевна", "Василькова" },
                    { 148, new DateOnly(1986, 4, 12), "Тамара", "Васильевна", "Ефимова" },
                    { 149, new DateOnly(2007, 10, 1), "Виктор", "Павлович", "Рожков" },
                    { 150, new DateOnly(2002, 5, 10), "Тимофей", "Романович", "Копылов" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
