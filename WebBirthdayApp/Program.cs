using System.Data.Common;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.Configuration;
using Npgsql;
using WebBirthdayApp;


/*
 
 Json GetAllBirthdays(Enum SortType);
 where SortType{
    NONE,
    ALL_BD_SOON_FIRST,
    ONLY_PAST_THIS_YEAR,
    ONLY_FUTURE_THIS_YEAR
 }
 
 CreatePerson(Person p);
 ReadPeople(Enum SortType)
 UpdatePerson(Person p);
 DeletePerson(Person p);
 
 SPA веб-приложение, сервер предоставляет АПИ (ASP.NET Core Web API), 
 информация хранится в объектах, персистентность которых реализуется 
 с помощью использования БД. 
 Корневая страница выводит список сегодняшних и ближайших ДР, 
 остальная функциональность доступна на отдельных страницах, 
 ссылки на которые ведут с корневой. 
 Необходимо реализовать хранение и отображение фотографий именинников.
 
 Создать приложение "Поздравлятор". Функциональность приложения - 
 ведение списка дней рождения (далее ДР) друзей/знакомых/сотрудников, а именно:
  
	• Отображение всего списка ДР 
	    (дополнительные возможности, такие как сортировка, 
	    выделение текущих и просроченных и т.п. - остаются на усмотрение реализующего)  
	• Отображение списка сегодняшних и ближайших ДР (дополнительные возможности, такие как сортировка, выделение текущих и просроченных и т.п. - остаются на усмотрение реализующего)  
	• Добавление записей в список ДР
	• Удаление записей из списка ДР
	• Редактирование записей в списке ДР 
	
	
	
	
	
	Person:
	id int not null auto increment,
	name varchar(50) not null
	second_name varchar(50) not null
	patronymic varchar(50)
	birthday Date not null
	
*/

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddControllers(options => options.ReturnHttpNotAcceptable = true)
	.AddNewtonsoftJson()
	.AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
