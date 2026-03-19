namespace CafeManagementSystem.Models
{
    internal class Boisson
    {
        public string Nom { get; private set; }
        public decimal PrixBase { get; private set; }
        public string Description { get; private set; }
        public bool EstDisponible { get; private set; }

        public Boisson(string nom, decimal prixBase, string description)
        {
            Nom = nom;
            PrixBase = prixBase;
            Description = description;
            EstDisponible = true;
        }

        public virtual void AfficherInfos()
        {
            Console.WriteLine($"Nom : {Nom}");
            Console.WriteLine($"Prix de base : {PrixBase:0.00}$");
            Console.WriteLine($"Description : {Description}");
            Console.WriteLine($"Disponibilité : {(EstDisponible ? "disponible" : "non disponible")}");
        }

        public virtual decimal CalculerPrix(Taille taille)
        {
            return taille switch
            {
                Taille.Moyen => PrixBase + 1.00m,
                Taille.Grand => PrixBase + 2.00m,
                _ => PrixBase
            };
        }
    }
}