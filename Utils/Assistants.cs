namespace CafeManagementSystem.Utils
{
    internal class Assistants
    {
        public void GenererMenu(string[] options)
        {
            if (options.Length > 0)
            {
                Console.WriteLine("\nVeuillez sélectionner une option :");
                for (int i = 0; i < options.Length; i++)
                    Console.WriteLine($"{i + 1}. {options[i]}");
                Console.Write("Votre choix : ");
            }
        }
    }
}