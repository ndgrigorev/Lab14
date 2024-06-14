using ClassLibrary12_4;
using ClassLibrary12_4.Lab12_4;
using ClassLibraryLab10;
using System.Data;
using System.Linq;
using System.Security.Cryptography;

namespace Lab14
{
    public class Program
    {
        public static Animals RandomAnimal()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, 4);
            if (x == 0)
            {
                Animals animal = new Animals();
                animal.RandomInit();
                return animal;
            }
            if (x == 1)
            {
                Mammals animal = new Mammals();
                animal.RandomInit();
                return animal;
            }
            if (x == 2)
            {
                Cats animal = new Cats();
                animal.RandomInit();
                return animal;
            }
            else
            {
                Fishes animal = new Fishes();
                animal.RandomInit();
                return animal;
            }
        }

        public static List<Mammals> AllMammalsLINQ(Queue<Dictionary<int, Animals>> house)
        {
            List<Mammals> animals = new List<Mammals>();
            var result = from item in house
                         from item2 in item
                         where item2.Value is Mammals
                         select item2;
            foreach (var item in result) animals.Add((Mammals)item.Value);
            return animals;
        }

        public static List<Mammals> AllMammalsMethod(Queue<Dictionary<int, Animals>> house)
        {
            List<Mammals> animals = new List<Mammals>();
            var result = house.SelectMany(x=>x).Where(x => x.Value is Mammals).Select(x=>x);
            foreach (var item in result) animals.Add((Mammals)item.Value);
            return animals;
        }

        public static int MaxAgeLINQ(Queue<Dictionary<int, Animals>> house)
        {
            List<Mammals> animals = new List<Mammals>();
            var result = (from item in house from item2 in item select item2.Value.Age).Max();
            return result;
        }

        public static int MaxAgeMethod(Queue<Dictionary<int, Animals>> house)
        {
            List<Mammals> animals = new List<Mammals>();
            var result = house.SelectMany(item => item.Values)
                .Select(item2 => item2.Age)
                .Max();
            return result;
        }

        public static List<Cats> OrderByLINQ(Queue<Dictionary<int, Animals>> house)
        {
            List<Cats> animals = new List<Cats>();
            var result = from item in house
                         from item2 in item
                         where item2.Value is Cats
                         orderby ((Cats)item2.Value).TailLength
                         select item2.Value;
            foreach (var item in result) animals.Add((Cats)item);
            return animals;
        }

        public static List<Cats> OrderByMethod(Queue<Dictionary<int, Animals>> house)
        {
            List<Cats> animals = new List<Cats>();
            var result = house.SelectMany(item => item.Values)
                .Where(item2 => item2 is Cats)
                .OrderBy(item2 => ((Cats)item2).TailLength)
                .Select(item2 => item2);
            foreach (var item in result) animals.Add((Cats)item);
            return animals;
        }

        public static List<int> LetFishLINQ(Queue<Dictionary<int, Animals>> house)
        {
            List<int> index = new List<int>();
            var result = from item in house
                         from item2 in item
                         where item2.Value is Fishes
                         let number2 = ((Fishes)item2.Value).NumberOfFins * item2.Value.Age
                         select number2;
            foreach (var item in result) index.Add(item);
            return index;
        }

        public static List<int> LetFishMethod(Queue<Dictionary<int, Animals>> house)
        {
            List<int> index = new List<int>();
            var result = house.SelectMany(item => item.Values)
                .Where(item2 => item2 is Fishes)
                .Select(item2 => ((Fishes)item2).NumberOfFins * item2.Age);
            foreach (var item in result) index.Add(item);
            return index;
        }

        public static IEnumerable<IGrouping<string,Animals>> GroupByLINQ(Queue<Dictionary<int, Animals>> house)
        {
            List<IGrouping<string, Animals>> groups = new List<IGrouping<string, Animals>>();
            var result = from item in house
                         from item2 in item
                         group item2.Value by item2.Value.Name;
            foreach (var item in result) groups.Add(item);
            return result;
        }

        public static IEnumerable<IGrouping<string, Animals>> GroupByMethod(Queue<Dictionary<int, Animals>> house)
        {
            List<IGrouping<string, Animals>> groups = new List<IGrouping<string, Animals>>();
            var result = house.SelectMany(item => item.Values)
                .Select(item2 => item2)
                .GroupBy(item2 => item2.Name);
            foreach (var item in result) groups.Add(item);
            return result;
        }

        public static Dictionary<int, Animals> CreateCollection(Dictionary<int, Animals> dictionary)
        {
            for (int i = 0; i < 4; i++)
            {
                Animals animal = RandomAnimal();
                dictionary.Add(animal.Id.Number, animal);
            }
            return dictionary;
        }

        public static MyCollection<Animals> CreatingCollection()
        {
            int size = 6;
            Random rnd = new Random();
            MyCollection<Animals> table = new MyCollection<Animals>();
            for (int i = 0; i < size; i++)
            {
                table.AddItem(RandomAnimal());
            }
            return table;
        }
        public static List<MyCollection<Animals>> CreatingListCollections(List<MyCollection<Animals>> list)
        {
            for (int i = 0; i < 3; i++)
            {
                list.Add(CreatingCollection());
            }
            return list;
        }

        public static List<Mammals> AllMammalsLINQMyCollection(List<MyCollection<Animals>> tables)
        {
            List<Mammals> animals = new List<Mammals>();
            var result = from item in tables
                         from item2 in item
                         where item2 is Mammals
                         select item2;
            foreach (var item in result) animals.Add((Mammals)item);
            return animals;
        }
        public static List<Mammals> AllMammalsMethodMyCollection(List<MyCollection<Animals>> tables)
        {
            List<Mammals> animals = new List<Mammals>();
            var result = tables.SelectMany(x => x).Where(x => x is Mammals).Select(x => x);
            foreach (var item in result) animals.Add((Mammals)item);
            return animals;
        }

        public static int MaxAgeLINQMyCollection(List<MyCollection<Animals>> tables)
        {
            List<Mammals> animals = new List<Mammals>();
            var result = (from item in tables from item2 in item select item2.Age).Max();
            return result;
        }

        public static int MaxAgeMethodMyCollection(List<MyCollection<Animals>> tables)
        {
            List<Mammals> animals = new List<Mammals>();
            var result = tables.SelectMany(item => item)
                .Select(item2 => item2.Age)
                .Max();
            return result;
        }

        public static IEnumerable<IGrouping<string, Animals>> GroupByLINQMyCollection(List<MyCollection<Animals>> tables)
        {
            List<IGrouping<string, Animals>> groups = new List<IGrouping<string, Animals>>();
            var result = from item in tables
                         from item2 in item
                         group item2 by item2.Name;
            foreach (var item in result) groups.Add(item);
            return result;
        }

        public static IEnumerable<IGrouping<string, Animals>> GroupByMethodMyCollection(List<MyCollection<Animals>> tables)
        {
            List<IGrouping<string, Animals>> groups = new List<IGrouping<string, Animals>>();
            var result = tables.SelectMany(item => item)
                .Select(item2 => item2)
                .GroupBy(item2 => item2.Name);
            foreach (var item in result) groups.Add(item);
            return result;
        }
        public static int CountLINQMyCollection(List<MyCollection<Animals>> tables)
        {
            List<Mammals> animals = new List<Mammals>();
            var result = (from item in tables from item2 in item select item2).Count();
            return result;
        }
        public static int CountMethodMyCollection(List<MyCollection<Animals>> tables)
        {
            List<Mammals> animals = new List<Mammals>();
            var result = tables.SelectMany(item => item)
                .Select(item2 => item2)
                .Count();
            return result;
        }
        public static void Main(string[] args)
        {
            // часть 1
            Dictionary<int, Animals> flat1 = new Dictionary<int, Animals>();
            flat1 = CreateCollection(flat1);
            Dictionary<int, Animals> flat2 = new Dictionary<int, Animals>();
            flat2 = CreateCollection(flat2);
            Dictionary<int, Animals> flat3 = new Dictionary<int, Animals>();
            flat3 = CreateCollection(flat3);

            Queue<Dictionary<int, Animals>> house = new Queue<Dictionary<int, Animals>>();
            house.Enqueue(flat1);
            house.Enqueue(flat2);
            house.Enqueue(flat3);

            var result = from item in house
                         from item2 in item
                         select item2;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();

            //запросы Where
            List<Mammals> animals = new List<Mammals>();
            animals = AllMammalsLINQ(house);
            Console.WriteLine("Все млекопитающие (LINQ):");
            foreach (Mammals animal in animals) Console.WriteLine(animal);
            Console.WriteLine();
            animals = AllMammalsMethod(house);
            Console.WriteLine("Все млекопитающие (Метод расширения):");
            foreach (Mammals animal in animals) Console.WriteLine(animal);

            //запросы Max
            Console.WriteLine();
            int result1;
            result1 = MaxAgeLINQ(house);
            Console.WriteLine($"Максимальный возраст (LINQ): {result1}");
            result1 = MaxAgeMethod(house);
            Console.WriteLine($"Максимальный возраст (Метод расширения): {result1}");

            //запросы orderby
            Console.WriteLine();
            List<Cats> animals2 = new List<Cats>();
            animals2 = OrderByLINQ(house);
            Console.WriteLine("Кошки в порядке возрастания длины хвоста (LINQ):");
            foreach (Cats animal in animals2) Console.WriteLine(animal);
            Console.WriteLine();
            animals2 = OrderByMethod(house);
            Console.WriteLine("Кошки в порядке возрастания длины хвоста (Метод расширения):");
            foreach (Cats animal in animals2) Console.WriteLine(animal);

            //запросы let
            Console.WriteLine();
            List<int> index = new List<int>();
            index = LetFishLINQ(house);
            Console.WriteLine("Индексы рыб = кол-во плавников * возраст (LINQ): ");
            foreach (int i in index) Console.WriteLine(i);
            Console.WriteLine();
            index = LetFishMethod(house);
            Console.WriteLine("Индексы рыб = кол-во плавников * возраст (Метод расширения): ");
            foreach (int i in index) Console.WriteLine(i);

            //запросы groupby
            Console.WriteLine();
            Console.WriteLine("Группировка по именам (LINQ):");
            IEnumerable<IGrouping<string, Animals>> result2 = GroupByLINQ(house);
            foreach (IGrouping<string, Animals> gr in result2)
            {
                Console.WriteLine();
                Console.WriteLine(gr.Key, gr);
                int i = 0;
                foreach (var item in gr)
                {
                    Console.WriteLine(item);
                    i++;
                }
                Console.WriteLine($"Всего в группе {i} элементов");
            }
            Console.WriteLine();
            Console.WriteLine("Группировка по именам (Метод расширения):");
            IEnumerable<IGrouping<string, Animals>> result3 = GroupByMethod(house);
            foreach (IGrouping<string, Animals> gr in result3)
            {
                Console.WriteLine();
                Console.WriteLine(gr.Key, gr);
                int i = 0;
                foreach (var item in gr)
                {
                    Console.WriteLine(item);
                    i++;
                }
                Console.WriteLine($"Всего в группе {i} элементов");
            }

            //часть 2
            List <MyCollection<Animals>> tables = new List <MyCollection<Animals>>();
            tables = CreatingListCollections(tables);
            var result4 = from item in tables
                         from item2 in item
                         select item2;
            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();

            //запросы where
            List<Mammals> animals3 = new List<Mammals>();
            animals3 = AllMammalsLINQMyCollection(tables);
            Console.WriteLine("Все млекопитающие (LINQ):");
            foreach (Mammals animal in animals3) Console.WriteLine(animal);
            Console.WriteLine();
            animals3 = AllMammalsMethodMyCollection(tables);
            Console.WriteLine("Все млекопитающие (Метод расширения):");
            foreach (Mammals animal in animals3) Console.WriteLine(animal);

            //запросы Count
            Console.WriteLine();
            int resultCount;
            resultCount = CountLINQMyCollection(tables);
            Console.WriteLine($"Кол-во элементов (LINQ): {resultCount}");
            resultCount = CountMethodMyCollection(tables);
            Console.WriteLine($"Кол-во элементов (Метод расширения): {resultCount}");

            //запросы Max
            Console.WriteLine();
            int resultMax;
            resultMax = MaxAgeLINQMyCollection(tables);
            Console.WriteLine($"Максимальный возраст (LINQ): {resultMax}");
            resultMax = MaxAgeMethodMyCollection(tables);
            Console.WriteLine($"Максимальный возраст (Метод расширения): {resultMax}");

            //запросы GroupBy
            Console.WriteLine();
            Console.WriteLine("Группировка по именам (LINQ):");
            IEnumerable<IGrouping<string, Animals>> result5 = GroupByLINQMyCollection(tables);
            foreach (IGrouping<string, Animals> gr in result5)
            {
                Console.WriteLine();
                Console.WriteLine(gr.Key);
                int i = 0;
                foreach (var item in gr)
                {
                    Console.WriteLine(item);
                    i++;
                }
                Console.WriteLine($"Всего в группе {i} элементов");
            }
            Console.WriteLine();
            Console.WriteLine("Группировка по именам (Метод расширения):");
            result5 = GroupByMethodMyCollection(tables);
            foreach (IGrouping<string, Animals> gr in result5)
            {
                Console.WriteLine();
                Console.WriteLine(gr.Key);
                int i = 0;
                foreach (var item in gr)
                {
                    Console.WriteLine(item);
                    i++;
                }
                Console.WriteLine($"Всего в группе {i} элементов");
            }
        }
    }
}
