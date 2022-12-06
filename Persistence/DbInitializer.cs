using Domain;

namespace Persistence
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // employees, organizations, buildings, rooms, rents, invoices

            context.Database.EnsureCreated();

            Random random = new Random();

            if (context.employees.Count() == 0)
            {
                string[] names = { "Иван", "Никита", "Андрей", "Костя", "Павел", "Евгений", "Вячеслав", "Алексей" };
                string[] surnames = { "Иванов", "Смирнов", "Кузнецов", "Попов", "Петров", "Соколов", "Михайлов", "васильев" };
                for (int i = 0; i < 2000; i++)
                {
                    var value1 = names[random.Next(0, names.Length - 1)];
                    var value2 = surnames[random.Next(0, surnames.Length - 1)];
                    context.employees.Add(new Employee { name = value1, surname = value2 });
                }
                context.SaveChanges();
            }


            if (context.organizations.Count() == 0)
            {
                string[] names = { "Контур", "Мясновъ", "Автовозофф", "Kelleman", "Greenfield", "Зара", "Алабама" };
                string[] emails = { "leit@mail.com", "preza@mail.com", "leiwopeu@mail.com", "cratano@mail.com", "prukagreu@mail.com", "liwai@mail.com", "pukume@mail.com" };
                for (int i = 0; i < 2000; i++)
                {
                    var name = names[random.Next(0, names.Length - 1)];
                    var email = emails[random.Next(0, emails.Length - 1)];
                    context.organizations.Add(new Organization { name = name, email = email });
                }
                context.SaveChanges();
            }

            if (context.buildings.Count() == 0)
            {
                string[] names = { "12B", "540", "P17", "67A", "17", "890E", "30Y" };
                string[] emails = { "leit@mail.com", "preza@mail.com", "leiwopeu@mail.com", "cratano@mail.com", "prukagreu@mail.com", "liwai@mail.com", "pukume@mail.com" };
                int[] floorCounts = { 2, 13, 4, 6, 17, 23, 8, 10 };
                string text = "Fusce in erat nec mi egestas cursus. In nisi orci, rutrum et neque sed, auctor malesuada felis. Phasellus auctor nibh nec placerat porttitor. Fusce facilisis lectus non nunc luctus, eu mollis nunc viverra. Duis maximus, nulla mollis cursus vulputate, sem justo ullamcorper mauris, in semper tellus nibh eget ipsum. Sed porttitor est sit amet dui cursus, nec posuere felis semper. Morbi in lectus sem. Sed id placerat tortor, non interdum quam. Fusce ornare elit nec augue malesuada, at gravida urna interdum. Curabitur cursus dui id tellus dapibus, eu tristique nulla pellentesque. Donec odio leo, ornare vel congue eu, lobortis at tortor. Nulla in porttitor mauris, at cursus elit. Fusce feugiat ultrices ultrices. Etiam at iaculis libero. Nam consequat faucibus quam sit amet ultricies. Phasellus eleifend pellentesque elit, non auctor sem tempor condimentum.";
                //string[] text = { "Здание представляет собой прямоугольник с мансардным этажом в створе, под скатно-щипцовой кровлей", "Оригинальным элементом здания является облицованная камнем стена на западной стороне дома, отделяющая здание от соседнего здания и сада", "Ряд окон,расположенных в стене на одном уровне и затенённые деревянными ламелями проёмы помогают избежать эффекта замкнутого пространства", "Восточный фасад здания представляет собой беспорядочно сменяющие друг друга поверхности из стекла и дерева на отштукатуренной основе", "Геометрически здание представляет собой два смещённых прямоугольника с мансардным этажом в створе, под скатно-щипцовой кровлей", "К гостиным на этажах прилегают просторные балконы, жилые комнаты располагают балконами меньших размеров" };
                for (int i = 0; i < 2000; i++)
                {
                    var name = names[random.Next(0, names.Length - 1)];
                    var email = emails[random.Next(0, emails.Length - 1)];
                    var floorCount = floorCounts[random.Next(0, floorCounts.Length - 1)];
                    var firstValue = random.Next(0, 20);
                    var secondValue = random.Next(firstValue, 70);
                    var desc = text.Substring(firstValue, secondValue);
                    context.buildings.Add(new Building { name = name, email = email, floorCount = floorCount, description = desc });
                }
                context.SaveChanges();
            }

            if (context.rooms.Count() == 0)
            {
                string[] numOfRooms = { "16BP2P", "LER234", "6AS89E", "PO56EA2", "NH8P012", "854E6TYU", "13C5SD0", "821QS8J" };
                //string[] text = { "Основная площадь фасада здания выкрашена в цвет слоновой кости, в оформлении доминируют стеклянные и деревянные панели", "Ограждение состоит из бетонной основы и сборной гальванизированной, металлической ограды цвета серый антрацит", "Твёрдое покрытие выполняется из каменных плит небольшого размера", "Озеленение участка проводится на трёх уровнях (кроны деревьев, кустарники и газон)", "Оригинальным элементом здания является облицованная камнем стена на западной стороне дома, отделяющая здание от соседнего здания и сада", "Ряд окон,расположенных в стене на одном уровне и затенённые деревянными ламелями проёмы помогают избежать эффекта замкнутого пространства", "Восточный фасад здания представляет собой беспорядочно сменяющие друг друга поверхности из стекла и дерева на отштукатуренной основе" };
                string text = "Fusce in erat nec mi egestas cursus. In nisi orci, rutrum et neque sed, auctor malesuada felis. Phasellus auctor nibh nec placerat porttitor. Fusce facilisis lectus non nunc luctus, eu mollis nunc viverra. Duis maximus, nulla mollis cursus vulputate, sem justo ullamcorper mauris, in semper tellus nibh eget ipsum. Sed porttitor est sit amet dui cursus, nec posuere felis semper. Morbi in lectus sem. Sed id placerat tortor, non interdum quam. Fusce ornare elit nec augue malesuada, at gravida urna interdum. Curabitur cursus dui id tellus dapibus, eu tristique nulla pellentesque. Donec odio leo, ornare vel congue eu, lobortis at tortor. Nulla in porttitor mauris, at cursus elit. Fusce feugiat ultrices ultrices. Etiam at iaculis libero. Nam consequat faucibus quam sit amet ultricies. Phasellus eleifend pellentesque elit, non auctor sem tempor condimentum.";
                int[] squares = { 370, 540, 210, 190, 445, 370, 500 };
                for (int i = 0; i < 2000; i++)
                {
                    //var value = text[random.Next(0, text.Length - 1)];

                    var numOfRoom = numOfRooms[random.Next(0, numOfRooms.Length - 1)];
                    var building = random.Next(1, 2000);
                    var firstValue = random.Next(0, 20);
                    var secondValue = random.Next(firstValue, 70);
                    var desc = text.Substring(firstValue, secondValue);
                    var square = squares[random.Next(0, squares.Length - 1)];
                    context.rooms.Add(new Room { numOfRoom = numOfRoom, buildingID = building, description = desc, square = square });
                }
                context.SaveChanges();
            }

            if (context.rents.Count() == 0)
            {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                for (int i = 0; i < 2000; i++)
                {
                    var room = random.Next(1, 2000);
                    var organization = random.Next(1, 2000);
                    var entryDate = start.AddDays(random.Next(range));
                    var exitDate = start.AddDays(random.Next(range));
                    context.rents.Add(new Rent { roomID = room, organizationID = organization, entryDate = entryDate, exitDate = exitDate });
                }
                context.SaveChanges();
            }

            if (context.invoices.Count() == 0)
            {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                //var room = random.Next(1, 2000);
                //var employee = random.Next(1, 2000);
                //var organization = random.Next(1, 2000);
                string[] values = { "16BP2P", "LER234", "6AS89E", "PO56EA2", "NH8P012", "854E6TYU", "13C5SD0", "821QS8J" };
                for (int i = 0; i < 2000; i++)
                {
                    var value = values[random.Next(0, values.Length - 1)];
                    var createDate = start.AddDays(random.Next(range));
                    var payDate = start.AddDays(random.Next(range));
                    context.invoices.Add(new Invoice { createDate = createDate, number = value, organizationID = random.Next(1, 2000), roomID = random.Next(1, 2000), puySum = random.Next(300, 1000000), payDate = payDate, employeeID = random.Next(1, 2000) });
                }
                context.SaveChanges();
            }
        }
    }
}
