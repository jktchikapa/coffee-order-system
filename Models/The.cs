namespace CafeManagementSystem.Models
{
    internal class The : Boisson
    {
        public string TypeThe { get; private set; }
        public bool AvecCitron { get; private set; }
        public int NombreSucres { get; private set; }

        public The(string nom, decimal prixBase, string description, string typeThe, bool avecCitron, int nombreSucres) : base(nom, prixBase, description)
        {
            TypeThe = typeThe;
            AvecCitron = avecCitron;
            NombreSucres = nombreSucres;
        }

        public override decimal CalculerPrix(Taille taille)
        {
            decimal prix = base.CalculerPrix(taille);
            if (AvecCitron) prix += 0.75m;
            prix += NombreSucres * 0.25m;
            return prix;
        }
    }
}