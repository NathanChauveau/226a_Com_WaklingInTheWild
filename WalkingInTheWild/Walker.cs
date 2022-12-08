namespace WalkingInTheWild
{
    public class Walker
    {
        #region private attributes
        private string _pseudo;
        private Bagpack? _backpack;
        #endregion private attributes

        #region public methods
        public Walker(string pseudo)
        {
           _pseudo = pseudo;
        
        }

        public string Pseudo
        {
            get
            {
                return _pseudo;
            }
        }

        public Bagpack? Bagpack
        {
            get
            {
                return _backpack;
            }
        }

        public void TakeBagpack(Bagpack bagpack)
        {
            if (_backpack != null)
            {
                throw new WalkerNotReadyException();
            }
            _backpack = bagpack;
        }

        public void DropBagpack()
        {
            throw new NotImplementedException();
        }

        public void LoadBagpack(List<Cloth> cloths)
        {
            foreach (Cloth cloth in cloths)
            {
                _backpack.Add(cloth);
            }

        }

        public void LoadBagpack(List<Equipment> equipments)
        {
            foreach (Equipment equipment in equipments)
            {
                _backpack.Add(equipment);
            }
        }

        public void EmptyBagpack()
        {
            _backpack = null;
        }
        #endregion public methods

        #region private methods
        #endregion private methods

        #region nested classes
        public class WalkerException:Exception{}
        public class WalkerNotReadyException : WalkerException { }
        public class EmptyBagpackException : WalkerException { }
        public class BagpackNotAvailableException : WalkerException { }
        #endregion nested classes


    }
}