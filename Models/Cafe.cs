namespace CafeManagementSystem.Models
{
    internal class Cafe : Boisson
    {
        public string TypeCafe { get; private set; }
        public bool AvecLait { get; private set; }
        public int NombreSucres { get; private set; }

        public Cafe(string nom, decimal prixBase, string description, string typeCafe, bool avecLait, int nombreSucres) : base(nom, prixBase, description)
        {
            TypeCafe = typeCafe;
            AvecLait = avecLait;
            NombreSucres = nombreSucres;
        }

        public override decimal CalculerPrix(Taille taille)
        {
            decimal prix = base.CalculerPrix(taille);
            if (AvecLait) prix += 0.50m;
            prix += NombreSucres * 0.25m;
            return prix;
        }
    }
}