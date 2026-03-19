using CafeManagementSystem.Models;
using CafeManagementSystem.Utils;

internal class GestionCafe
{
    private List<Boisson> menu;
    private Commande commandeActuelle;
    private Assistants assistants = new Assistants();

    public GestionCafe()
    {
        menu = new List<Boisson>();
        InitialiserMenu();
    }

    private void InitialiserMenu()
    {
        menu.Add(new Cafe("Espresso", 2.50m, "Café corsé", "Espresso", false, 0));
        menu.Add(new Cafe("Cappuccino", 3.50m, "Café italien", "Cappuccino", true, 1));
        menu.Add(new The("Thé Vert", 2.75m, "Thé japonais", "Vert", false, 0));
        menu.Add(new The("Earl Grey", 3.00m, "Thé anglais", "Noir", true, 1));
        menu.Add(new BoissonFroide("Limonade", 3.00m, "Fraîche", "Limonade", true));
    }

    public void AfficherMenu()
    {
        Console.Clear();
        Console.WriteLine("\n===== MENU =====");
        for (int i = 0; i < menu.Count; i++)
            Console.WriteLine($"{i + 1}. {menu[i].Nom} - {menu[i].PrixBase:0.00}$ | {menu[i].Description}");
        Console.WriteLine("================");
    }

    public void NouvelleCommande()
    {
        commandeActuelle = new Commande();
        Console.Clear();
        Console.WriteLine("Nouvelle commande créée!");
        Console.WriteLine("Appuyez sur une touche pour continuer...");
        Console.ReadKey();
    }

    private Taille ChoisirTaille()
    {
        Console.Clear();
        assistants.GenererMenu(new string[] { "Petit", "Moyen", "Grand" });
        ConsoleKeyInfo touche = Console.ReadKey();
        return touche.Key switch
        {
            ConsoleKey.D2 or ConsoleKey.NumPad2 => Taille.Moyen,
            ConsoleKey.D3 or ConsoleKey.NumPad3 => Taille.Grand,
            _ => Taille.Petit
        };
    }

    private void AjouterItem()
    {
        if (commandeActuelle is null)
            NouvelleCommande();

        AfficherMenu();
        Console.Write("\nChoisir une boisson (numéro) : ");
        ConsoleKeyInfo touche = Console.ReadKey();
        Console.WriteLine();

        int choix = touche.Key switch
        {
            ConsoleKey.D1 or ConsoleKey.NumPad1 => 1,
            ConsoleKey.D2 or ConsoleKey.NumPad2 => 2,
            ConsoleKey.D3 or ConsoleKey.NumPad3 => 3,
            ConsoleKey.D4 or ConsoleKey.NumPad4 => 4,
            ConsoleKey.D5 or ConsoleKey.NumPad5 => 5,
            _ => -1
        };

        if (choix < 1 || choix > menu.Count)
        {
            Console.WriteLine("Choix invalide. Appuyez sur une touche...");
            Console.ReadKey();
            return;
        }

        Taille taille = ChoisirTaille();

        Console.Clear();
        Console.Write("Quantité : ");
        if (!int.TryParse(Console.ReadLine(), out int quantite) || quantite < 1)
        {
            Console.WriteLine("Quantité invalide. Appuyez sur une touche...");
            Console.ReadKey();
            return;
        }

        commandeActuelle.AjouterItem(new ItemCommande(menu[choix - 1], taille, quantite));
        Console.WriteLine("Item ajouté! Appuyez sur une touche...");
        Console.ReadKey();
    }

    private void RetirerItem()
    {
        Console.Clear();
        if (commandeActuelle is null || commandeActuelle.Items.Count == 0)
        {
            Console.WriteLine("Aucun item dans la commande. Appuyez sur une touche...");
            Console.ReadKey();
            return;
        }

        for (int i = 0; i < commandeActuelle.Items.Count; i++)
            Console.WriteLine($"{i + 1}. {commandeActuelle.Items[i].Boisson.Nom}");

        Console.Write("\nItem à retirer (numéro) : ");
        ConsoleKeyInfo touche = Console.ReadKey();
        Console.WriteLine();

        int choix = touche.Key switch
        {
            ConsoleKey.D1 or ConsoleKey.NumPad1 => 1,
            ConsoleKey.D2 or ConsoleKey.NumPad2 => 2,
            ConsoleKey.D3 or ConsoleKey.NumPad3 => 3,
            ConsoleKey.D4 or ConsoleKey.NumPad4 => 4,
            ConsoleKey.D5 or ConsoleKey.NumPad5 => 5,
            _ => -1
        };

        if (choix >= 1)
        {
            commandeActuelle.RetirerItem(choix - 1);
            Console.WriteLine("Item retiré! Appuyez sur une touche...");
            Console.ReadKey();
        }
    }

    public void Demarrer()
    {
        bool enCours = true;
        while (enCours)
        {
            Console.Clear();
            assistants.GenererMenu(new string[]
            {
                "Nouvelle commande",
                "Ajouter un item",
                "Retirer un item",
                "Voir le reçu",
                "Quitter"
            });

            ConsoleKeyInfo touche = Console.ReadKey();
            Console.WriteLine();

            switch (touche.Key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    NouvelleCommande();
                    break;
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    AjouterItem();
                    break;
                case ConsoleKey.D3 or ConsoleKey.NumPad3:
                    RetirerItem();
                    break;
                case ConsoleKey.D4 or ConsoleKey.NumPad4:
                    Console.Clear();
                    commandeActuelle?.AfficherRecu();
                    Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D5 or ConsoleKey.NumPad5:
                    enCours = false;
                    break;
                default:
                    Console.WriteLine("Choix invalide. Appuyez sur une touche...");
                    Console.ReadKey();
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine("Au revoir!");
    }
}