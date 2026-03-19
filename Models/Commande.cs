namespace CafeManagementSystem.Models
{
    internal class Commande
    {
        private static int numeroCommande = 1;
        public int NumeroCommande { get; private set; }
        public List<ItemCommande> Items { get; private set; }
        public DateTime DateCommande { get; private set; }
        public decimal TauxTaxe { get; private set; }

        public Commande()
        {
            NumeroCommande = numeroCommande++;
            Items = new();
            DateCommande = DateTime.Now;
            TauxTaxe = 0.15m;
        }

        public void AjouterItem(ItemCommande item) => Items.Add(item);

        public void RetirerItem(int index)
        {
            if (index >= 0 && index < Items.Count)
                Items.RemoveAt(index);
        }

        public decimal CalculerSousTotal() => Items.Sum(item => item.CalculerSousTotal());
        public decimal CalculerTaxes() => CalculerSousTotal() * TauxTaxe;
        public decimal CalculerTotal() => CalculerSousTotal() + CalculerTaxes();

        public void AfficherRecu()
        {
            Console.WriteLine("------ REÇU ------");
            Console.WriteLine($"Commande #{NumeroCommande:D3}");
            Console.WriteLine($"Date : {DateCommande:yyyy/MM/dd HH:mm}");
            Console.WriteLine();
            foreach (ItemCommande item in Items)
                Console.WriteLine($"{item.Quantite}x {item.Boisson.Nom} ({item.Taille}) - {item.CalculerSousTotal():0.00}$");
            Console.WriteLine("------------------");
            Console.WriteLine($"Sous-total : {CalculerSousTotal():0.00}$");
            Console.WriteLine($"Taxes (15%) : {CalculerTaxes():0.00}$");
            Console.WriteLine($"TOTAL : {CalculerTotal():0.00}$");
        }
    }
}