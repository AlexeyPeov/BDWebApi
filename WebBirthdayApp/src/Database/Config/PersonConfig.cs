using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebBirthdayApp.Models;
using WebBirthdayApp.Validators;

namespace WebBirthdayApp.Database.Config;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).UseIdentityColumn();

        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.SecondName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Patronymic).IsRequired(false).HasMaxLength(50);
        builder.Property(p => p.Birthday).IsRequired();
        builder.Property(p => p.ImgId);

        builder.HasData(_GenerateRandomPeople(150));

        builder.HasOne(p=>p.Img)
            .WithOne()
            .HasForeignKey<Person>(p => p.ImgId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
    
     private static List<Person> _GenerateRandomPeople(int amount)
    {
        var list = new List<Person>(amount);
        
        for (int i = 1; i <= amount; ++i)
        {
            bool isMen = Random.Shared.Next(0, 2) == 1;
            var people = isMen ? RandomMen : RandomWomen;
            
            int size = people.Count - 1;
            int nameIndex = Random.Shared.Next(0, size);
            int patronymicIndex = Random.Shared.Next(0, size);
            int secondNameIndex = Random.Shared.Next(0, size);

            int randYear = Random.Shared.Next(1965, 2008);
            int randMonth = Random.Shared.Next(1,13);
            int randDay = Random.Shared.Next(1,27);
            
            list.Add(new Person
            {
                Id = i,
                Name = people[nameIndex].Item1,
                Patronymic = people[patronymicIndex].Item2,
                SecondName = people[secondNameIndex].Item3,
                Birthday = new DateOnly(randYear, randMonth, randDay),
                
            });
        }

        return list;
    }
    
    private static readonly List<(string, string, string)> RandomMen = 
        new List<(string, string, string)> {
        ("Михаил", "Семёнович", "Краснов"),
        ("Алексей", "Иванович", "Петров"),
        ("Владимир", "Алексеевич", "Сидоров"),
        ("Андрей", "Владимирович", "Кузнецов"),
        ("Сергей", "Андреевич", "Попов"),
        ("Иван", "Сергеевич", "Васильев"),
        ("Дмитрий", "Иванович", "Смирнов"),
        ("Антон", "Дмитриевич", "Новиков"),
        ("Олег", "Антонович", "Морозов"),
        ("Виктор", "Олегович", "Волков"),
        ("Евгений", "Викторович", "Егоров"),
        ("Николай", "Евгеньевич", "Соколов"),
        ("Павел", "Николаевич", "Белов"),
        ("Станислав", "Павлович", "Романов"),
        ("Георгий", "Станиславович", "Зайцев"),
        ("Леонид", "Георгиевич", "Соловьев"),
        ("Валерий", "Леонидович", "Борисов"),
        ("Игорь", "Валерьевич", "Козлов"),
        ("Федор", "Игоревич", "Виноградов"),
        ("Ярослав", "Федорович", "Цветков"),
        ("Тимофей", "Ярославович", "Никитин"),
        ("Григорий", "Тимофеевич", "Крылов"),
        ("Роман", "Григорьевич", "Маслов"),
        ("Борис", "Романович", "Ефимов"),
        ("Евгений", "Борисович", "Лобанов"),
        ("Юрий", "Евгеньевич", "Рожков"),
        ("Василий", "Юрьевич", "Копылов"),
        ("Анатолий", "Васильевич", "Мухин"),
        ("Денис", "Анатольевич", "Быков"),
        ("Геннадий", "Денисович", "Давыдов")
    };
    
    private static readonly List<(string, string, string)> RandomWomen = 
        new List<(string, string, string)> {
            ("Мария", "Семёновна", "Красная"),
            ("Анна", "Ивановна", "Петухова"),
            ("Виктория", "Алексеевна", "Соловьева"),
            ("Елена", "Владимировна", "Кукушкина"),
            ("Светлана", "Андреевна", "Попугаева"),
            ("Ирина", "Сергеевна", "Василькова"),
            ("Ольга", "Ивановна", "Смирная"),
            ("Татьяна", "Дмитриевна", "Новикова"),
            ("Наталья", "Олеговна", "Морозова"),
            ("Екатерина", "Викторовна", "Волчица"),
            ("Юлия", "Евгеньевна", "Соколова"),
            ("Дарья", "Николаевна", "Белая"),
            ("Елена", "Павловна", "Романова"),
            ("Александра", "Станиславовна", "Зайцева"),
            ("Валентина", "Георгиевна", "Соловьева"),
            ("Надежда", "Леонидовна", "Борисова"),
            ("Людмила", "Валерьевна", "Козлова"),
            ("Галина", "Игоревна", "Виноградова"),
            ("Оксана", "Федоровна", "Цветкова"),
            ("Инна", "Ярославовна", "Никитина"),
            ("София", "Тимофеевна", "Крылова"),
            ("Вера", "Григорьевна", "Маслова"),
            ("Алина", "Романовна", "Ефимова"),
            ("Евгения", "Борисовна", "Лобанова"),
            ("Зоя", "Евгеньевна", "Рожкова"),
            ("Лариса", "Юрьевна", "Копылова"),
            ("Тамара", "Васильевна", "Мухина"),
            ("Ольга", "Анатольевна", "Быкова"),
            ("Марина", "Денисовна", "Давыдова"),
            ("Нина", "Геннадиевна", "Краснова")
        };
}