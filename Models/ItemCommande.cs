namespace CafeManagementSystem.Models
{
    internal class ItemCommande
    {
        public Boisson Boisson { get; private set; }
        public Taille Taille { get; private set; }
        public int Quantite { get; private set; }

        public ItemCommande(Boisson boisson, Taille taille, int quantite)
        {
            Boisson = boisson;
            Taille = taille;
            Quantite = quantite;
        }

        public decimal CalculerSousTotal() => Boisson.CalculerPrix(Taille) * Quantite;
    }
}