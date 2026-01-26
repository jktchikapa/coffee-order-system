using CafeManagementSystem.Models;

internal class CafeManager
{
    private List<Beverage> menu;
    private Order currentOrder;

    public CafeManager()
    {
        menu = new List<Beverage>();
        InitializeMenu();
    }

    private void InitializeMenu()
    {
        menu.Add(new Coffee("Espresso", 2.50m, "Café corsé", "Espresso", false, 0));
        menu.Add(new Coffee("Cappuccino", 3.50m, "Café italien", "Cappuccino", true, 1));
        menu.Add(new Tea("Thé Vert", 2.75m, "Thé japonais", "Vert", false, 0));
        menu.Add(new Tea("Earl Grey", 3.00m, "Thé anglais", "Noir", true, 1));
        menu.Add(new ColdDrink("Limonade", 3.00m, "Fraîche", "Limonade", true));
    }

    public void DisplayMenu()
    {
       
    }

    public void StartNewOrder()
    {
        currentOrder = new Order();
        Console.WriteLine("\nNouvelle commande créée!");
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
           
        }
    }
}