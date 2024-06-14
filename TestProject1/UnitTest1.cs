using ClassLibraryLab10;
using ClassLibrary12_4;
using Lab14;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dictionary<int, Animals> flat1 = new Dictionary<int, Animals>();
            flat1 = Program.CreateCollection(flat1);
            Queue<Dictionary<int, Animals>> house = new Queue<Dictionary<int, Animals>>();
            house.Enqueue(flat1);
            List<Mammals> animals = new List<Mammals>();
            animals = Program.AllMammalsLINQ(house);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Dictionary<int, Animals> flat1 = new Dictionary<int, Animals>();
            flat1 = Program.CreateCollection(flat1);
            Queue<Dictionary<int, Animals>> house = new Queue<Dictionary<int, Animals>>();
            house.Enqueue(flat1);
            List<Mammals> animals = new List<Mammals>();
            animals = Program.AllMammalsMethod(house);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Dictionary<int, Animals> flat1 = new Dictionary<int, Animals>();
            flat1 = Program.CreateCollection(flat1);
            Queue<Dictionary<int, Animals>> house = new Queue<Dictionary<int, Animals>>();
            house.Enqueue(flat1);
            int animals;
            animals = Program.MaxAgeLINQ(house);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Dictionary<int, Animals> flat1 = new Dictionary<int, Animals>();
            flat1 = Program.CreateCollection(flat1);
            Queue<Dictionary<int, Animals>> house = new Queue<Dictionary<int, Animals>>();
            house.Enqueue(flat1);
            int animals;
            animals = Program.MaxAgeMethod(house);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod5()
        {
            List<Cats> animals = new List<Cats>();
            Dictionary<int, Animals> flat1 = new Dictionary<int, Animals>();
            flat1 = Program.CreateCollection(flat1);
            Queue<Dictionary<int, Animals>> house = new Queue<Dictionary<int, Animals>>();
            house.Enqueue(flat1);
            animals = Program.OrderByLINQ(house);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod6()
        {
            List<Cats> animals = new List<Cats>();
            Dictionary<int, Animals> flat1 = new Dictionary<int, Animals>();
            flat1 = Program.CreateCollection(flat1);
            Queue<Dictionary<int, Animals>> house = new Queue<Dictionary<int, Animals>>();
            house.Enqueue(flat1);
            animals = Program.OrderByMethod(house);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod7()
        {
            List<int> animals = new List<int>();
            Dictionary<int, Animals> flat1 = new Dictionary<int, Animals>();
            flat1 = Program.CreateCollection(flat1);
            Queue<Dictionary<int, Animals>> house = new Queue<Dictionary<int, Animals>>();
            house.Enqueue(flat1);
            animals = Program.LetFishLINQ(house);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod8()
        {
            List<int> animals = new List<int>();
            Dictionary<int, Animals> flat1 = new Dictionary<int, Animals>();
            flat1 = Program.CreateCollection(flat1);
            Queue<Dictionary<int, Animals>> house = new Queue<Dictionary<int, Animals>>();
            house.Enqueue(flat1);
            animals = Program.LetFishMethod(house);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod9()
        {
            Dictionary<int, Animals> flat1 = new Dictionary<int, Animals>();
            flat1 = Program.CreateCollection(flat1);
            Queue<Dictionary<int, Animals>> house = new Queue<Dictionary<int, Animals>>();
            house.Enqueue(flat1);
            IEnumerable<IGrouping<string, Animals>> animals = Program.GroupByLINQ(house);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod10()
        {
            Dictionary<int, Animals> flat1 = new Dictionary<int, Animals>();
            flat1 = Program.CreateCollection(flat1);
            Queue<Dictionary<int, Animals>> house = new Queue<Dictionary<int, Animals>>();
            house.Enqueue(flat1);
            IEnumerable<IGrouping<string, Animals>> animals = Program.GroupByMethod(house);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod11()
        {
            List<MyCollection<Animals>> tables = new List<MyCollection<Animals>>();
            tables = Program.CreatingListCollections(tables);
            List<Mammals> animals = new List<Mammals>();
            animals = Program.AllMammalsLINQMyCollection(tables);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod12()
        {
            List<MyCollection<Animals>> tables = new List<MyCollection<Animals>>();
            tables = Program.CreatingListCollections(tables);
            List<Mammals> animals = new List<Mammals>();
            animals = Program.AllMammalsMethodMyCollection(tables);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod13()
        {
            List<MyCollection<Animals>> tables = new List<MyCollection<Animals>>();
            tables = Program.CreatingListCollections(tables);
            int animals;
            animals = Program.CountLINQMyCollection(tables);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod14()
        {
            List<MyCollection<Animals>> tables = new List<MyCollection<Animals>>();
            tables = Program.CreatingListCollections(tables);
            int animals;
            animals = Program.CountMethodMyCollection(tables);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod15()
        {
            List<MyCollection<Animals>> tables = new List<MyCollection<Animals>>();
            tables = Program.CreatingListCollections(tables);
            int animals;
            animals = Program.MaxAgeLINQMyCollection(tables);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod16()
        {
            List<MyCollection<Animals>> tables = new List<MyCollection<Animals>>();
            tables = Program.CreatingListCollections(tables);
            int animals;
            animals = Program.MaxAgeMethodMyCollection(tables);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod17()
        {
            List<MyCollection<Animals>> tables = new List<MyCollection<Animals>>();
            tables = Program.CreatingListCollections(tables);
            IEnumerable<IGrouping<string, Animals>> animals = Program.GroupByLINQMyCollection(tables);
            Assert.AreEqual(animals, animals);
        }
        [TestMethod]
        public void TestMethod18()
        {
            List<MyCollection<Animals>> tables = new List<MyCollection<Animals>>();
            tables = Program.CreatingListCollections(tables);
            IEnumerable<IGrouping<string, Animals>> animals = Program.GroupByMethodMyCollection(tables);
            Assert.AreEqual(animals, animals);
        }
    }
}