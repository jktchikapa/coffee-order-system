namespace CafeManagementSystem.Models
{
    internal class BoissonFroide : Boisson
    {
        public string TypeBoisson { get; private set; }
        public bool AvecGlace { get; private set; }

        public BoissonFroide(string nom, decimal prixBase, string description, string typeBoisson, bool avecGlace) : base(nom, prixBase, description)
        {
            TypeBoisson = typeBoisson;
            AvecGlace = avecGlace;
        }

        public override decimal CalculerPrix(Taille taille)
        {
            decimal prix = base.CalculerPrix(taille);
            if (!AvecGlace) prix -= 0.25m;
            return prix;
        }
    }
}