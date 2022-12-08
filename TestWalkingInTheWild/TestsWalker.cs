using WalkingInTheWild;
using static WalkingInTheWild.Cloth;
using static WalkingInTheWild.Walker;

namespace TestWalkingInTheWild
{
    public class TestsWalker
    {
        //region private attributes
        private Walker walker;
        private string pseudo;
        private Bagpack bagpack;
        //endregion private attributes

        [SetUp]
        public void Setup()
        {
            pseudo = "Pseudo";
            walker = new Walker(pseudo);
            bagpack = new Bagpack(25.50f);
        }

        [Test]
        public void Properties_AfterInstantiationDefaultValues_PropertiesAreCorrecltyReturned()
        {
            //given
            //refer to Setup()

            //when
            //constructor is called in Setup() 

            //then
            Assert.AreEqual(pseudo, walker.Pseudo);
            Assert.IsNull(walker.Bagpack);
        }

        [Test]
        public void TakeBagpack_WalkerReady_BagpackTaken()
        {
            //given
            //refer to Setup()
            Bagpack bagpack = new Bagpack(20.00f);
            Assert.Null(walker.Bagpack);

            //when
            this.walker.TakeBagpack(bagpack);

            //then
            Assert.AreEqual(bagpack, walker.Bagpack);
        }

        [Test]
        public void TakeBagpack_WalkerNotReady_ThrowException()
        {
            //given
            //refer to Setup()
            Bagpack bagpack = new Bagpack(20.00f);
            walker.TakeBagpack(bagpack);
            Assert.NotNull(walker.Bagpack);

            //when
            //Event is called by the assertion

            //then
            Assert.Throws<WalkerNotReadyException>(() => this.walker.TakeBagpack(bagpack));
        }
        
        [Test]        
        public void DropBagpack_WalkerIsCarringABagpack_WalkerDropsTheBagpack()
        {
            //given
            //refer to Setup()
            Assert.Null(walker.Bagpack);

            //when
            this.walker.TakeBagpack(bagpack);
            this.walker.DropBagpack();

            //then
            Assert.AreNotEqual(bagpack, walker.Bagpack);
        }

        [Test]
        public void DropBagpack_WalkerIsNotCarringABagpack_ThrowException()
        {
            //given
            //refer to Setup method
            Assert.Null(walker.Bagpack);

            //when

            //then
            Assert.Throws<WalkerException>(delegate { walker.DropBagpack(); });
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadSingleCloth_ClothIsLoadedInBagpack()
        {
            //given
            //refer to Setup method
            Cloth cloth = new Cloth("Brand");
            List<Cloth> clothes = Utils.GenerateClothes(1);
            walker.TakeBagpack(bagpack);

            //when
            this.walker.LoadBagpack(clothes);

            //then
            Assert.That(bagpack.Clothes.Count, Is.EqualTo(1));
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadMultipleCloths_ClothsAreLoadedInBagpack()
        {
            //given
            //refer to Setup method
            Cloth cloth = new Cloth("Brand");
            List<Cloth> clothes = Utils.GenerateClothes(5);
            walker.TakeBagpack(bagpack);

            //when
            this.walker.LoadBagpack(clothes);

            //then
            Assert.That(bagpack.Clothes.Count, Is.EqualTo(5));
        }

        [Test]
        public void LoadBagpack_ClothBagpackNotAvailable_ThrowException()
        {
            //given
            //refer to Setup method
            Assert.Null(walker.Bagpack);

            Cloth cloth = new Cloth("Brand");
            List<Cloth> clothes = Utils.GenerateClothes(1);

            //when
            walker.TakeBagpack(bagpack);
            this.walker.DropBagpack();

            //then
            Assert.Throws<BagpackNotAvailableException>(delegate { walker.LoadBagpack(clothes); });
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadSingleEquipment_EquipmentIsLoadedInBagpack()
        {
            //given
            //refer to Setup method
            List<Equipment> equipments = Utils.GenerateEquipment(1);
            foreach (Equipment equipment in equipments)
            {
                bagpack.Add(equipment);
            }
            walker.TakeBagpack(bagpack);
            //when
            walker.LoadBagpack(equipments);
            //then
            Assert.That(bagpack.Equipments.Count, Is.EqualTo(1));
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadMultipleEquipments_EquipmentAreLoadedInBagpack()
        {
            //given
            //refer to Setup method
            List<Equipment> equipments = Utils.GenerateEquipment(2);
            foreach (Equipment equipment in equipments)
            {
                bagpack.Add(equipment);
            }
            walker.TakeBagpack(bagpack);
            //when
            walker.LoadBagpack(equipments);
            //then
            Assert.That(bagpack.Equipments.Count, Is.EqualTo(2));
        }

        [Test]
        public void LoadBagpack_EquipmentBagpackNotAvailable_ThrowException()
        {
            //given
            //refer to Setup method
            Assert.Null(walker.Bagpack);

            List<Equipment> equipments = Utils.GenerateEquipment(5);
            foreach (Equipment equipment in equipments)
            {
                bagpack.Add(equipment);
            }

            //when
            walker.TakeBagpack(bagpack);
            this.walker.DropBagpack();

            //then
            Assert.Throws<BagpackNotAvailableException>(delegate { walker.LoadBagpack(equipments); });
        }

        [Test]
        public void EmptyBagpack_BagpackContainsClothsAndEquipment_BackpackIsEmpty()
        {
            //given
            //refer to Setup method
            List<Equipment> equipments = Utils.GenerateEquipment(1);
            foreach (Equipment equipment in equipments)
            {
                bagpack.Add(equipment);
            }

            Cloth cloth = new Cloth("Brand");
            List<Cloth> clothes = Utils.GenerateClothes(1);
            bagpack.Add(cloth);
            //when
            walker.EmptyBagpack();

            //then
            Assert.That(bagpack.Clothes.Count, Is.EqualTo(0));
            Assert.That(bagpack.Equipments.Count, Is.EqualTo(0));
        }

        [Test]
        public void EmptyBagpack_BagpackDoesntContainNeitherClothsOrEquipment_ThrowException()
        {
            //given
            //refer to Setup method

            //when


            //then
            Assert.Throws<EmptyBagpackException>(delegate { walker.EmptyBagpack(); });
        }
    }
}