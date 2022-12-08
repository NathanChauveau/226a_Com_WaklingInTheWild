using static WalkingInTheWild.Bagpack;

namespace WalkingInTheWild
{
    public class Bagpack
    {
        //region private attributes
        private List<Cloth> _clothes = new List<Cloth>();
        private List<Equipment> _equipments = new List<Equipment>();
        private readonly float _maxLoad;    
        //endregion private attributes

        //region public methods
        public Bagpack(float maxLoad)
        {
            _clothes = new List<Cloth>();
            _equipments = new List<Equipment>();
            _maxLoad = maxLoad;
        }
        
        public List<Cloth> Clothes
        {
            get
            {
                return _clothes;
            }
        }

        public List<Equipment> Equipments
        {
            get
            {
                return _equipments;
            }
        }

        public float RemainingLoadCapacity
        {
            get
            {
                float totalCap = 0;
                foreach (var equip in _equipments)
                {
                    totalCap = totalCap + equip.Weight;
                }
                
                return _maxLoad - totalCap;
            }
        }

        public void Add(Cloth cloth)
        {
            _clothes.Add(cloth);
        }

        public void Add(Equipment equipment)
        {
            if (equipment.Weight > RemainingLoadCapacity){
                throw new MaximumLoadReachedException();
            }
            _equipments.Add(equipment);
         
        }
        
        //endregion public methods

        //region private methods
        private float CurrentLoad
        {
            //TODO Discussion - getter or method ? (computed property)
            get
            {
                {
                    float currentLoad = 0;
                    foreach (Equipment equipment in _equipments)
                    {
                        currentLoad += equipment.Weight;
                    }
                    return currentLoad;
                }
            }
        }
        //endregion private methods

        //region nested classes
        public class BagpackException : Exception { }
        public class MaximumLoadReachedException : BagpackException { }
        //enregion  nested classes
    }
}