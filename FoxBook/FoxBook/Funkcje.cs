using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Threading;
using System.IO;

namespace FoxBook
{
    class Funkcje
    {
        static string login2;
        static string passwort2;
        static string name;
        static string surname;
        //static int rok, dzień, miesiąc;
        public static void ProsteMenu()
        {
            var ListaUżytkowników = new List<Użytkownik>();
            do
            {  
            Label:
                System.Console.Clear();
                Console.WriteLine("Witamy w FOXBOOK :-)                                                         ");
                Console.WriteLine("Zachęcamy do rejestracji, jeśli nie masz u Nas konta - jest zupełnie darmowa!");
                Console.WriteLine("Co chcesz zrobić? :)                                                         ");
                Console.WriteLine("Naciśnij '1' aby ZALOGOWAĆ                                                   ");
                Console.WriteLine("Naciśnij '2' aby ZAREJESTROWAĆ                                               ");
                int przycisk = 0;
                try
                {
                    przycisk = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Błędnie wybrana funkcja!");
                    Thread.Sleep(1500);
                    goto Label;
                }
               
                switch (przycisk)
                {
                    case 1:
                        {
                            string allUsers = "";
                            Funkcje.WczytywanieUżytkowników(out allUsers);
                            if (allUsers == null)
                                break;
                            Funkcje.SprawdźCzyWbazie(allUsers);
                            break;
                        }
                    case 2:
                        {
                            Funkcje.UtwórzUżytkownika(ListaUżytkowników);
                            Console.Write("Naciśnij 'ENTER' aby kontynuować:");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        Console.WriteLine("Błędnie wybrana funkcja!");
                        Thread.Sleep(1000);
                        break;
                }
            } while (true);
        }
        public static void UtwórzUżytkownika(List<Użytkownik> listaużytkowników)
        {
            Label2:
            Console.Write("Wprowadź login: ");
            login2 = Console.ReadLine();
            string curFile = @"C:\Users\Sebastian\Source\Repos\FoxBook\FoxBook\użytkownicy.txt";
            if (File.Exists(curFile) == true)
            {
                var AllUsers = System.IO.File.ReadAllText(@"C:\Users\Sebastian\Source\Repos\FoxBook\FoxBook\użytkownicy.txt");
                string[] CopyWithoutDot = AllUsers.Split('.');
                for (int i = 0; i < CopyWithoutDot.Length; i++)
                {
                    if (login2 == CopyWithoutDot[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Podany login już istnieje! Proszę podaj inną nazwę.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        goto Label2;
                    }
                }
            }
            Console.Write("Wprowadź hasło: ");
            passwort2 = Console.ReadLine();
            Console.Write("Wprowadź Imię: ");
            name = Console.ReadLine();
            Console.Write("Wprowadź Nazwisko: ");
            surname = Console.ReadLine();
            //Console.Write("Twój dzień urodzenia: ");
            //dzień = int.Parse(Console.ReadLine());
            //Console.Write("Twój miesiąc urodzenia: ");
            //miesiąc = int.Parse(Console.ReadLine());
            //Console.Write("Twój rok urodzenia: ");
            //rok = int.Parse(Console.ReadLine());
            Użytkownik użytkownik = new Użytkownik(login2, passwort2, name, surname);
            listaużytkowników.Add(użytkownik);
            string path = @"C:\Users\Sebastian\Source\Repos\FoxBook\FoxBook";
            if (File.Exists(curFile) == false)
            {
                using (StreamWriter sw = File.CreateText(@"C:\Users\Sebastian\Source\Repos\FoxBook\FoxBook\użytkownicy.txt"))
                {
                    sw.Write(użytkownik.Login + ".");
                    sw.Write(użytkownik.Hasło + ".");
                    sw.Write(użytkownik.Imię + ".");
                    sw.Write(użytkownik.Nazwisko + ".");
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "użytkownicy.txt"), true))
                {
                    outputFile.Write(użytkownik.Login + ".");
                    outputFile.Write(użytkownik.Hasło + ".");
                    outputFile.Write(użytkownik.Imię + ".");
                    outputFile.Write(użytkownik.Nazwisko + ".");
                    outputFile.Close();
                }
            }
        }
        public static void SprawdźCzyWbazie(string Lista)
        {
            int inkrement = 0;
            string[] UsersList = Lista.Split('.');
            Console.Write("Podaj Login:");
            var tempString = Console.ReadLine();
            for (int i = 0; i < UsersList.Length; i++)
            {
                if (tempString == UsersList[i])
                {
                    inkrement = i;
                    Console.Write("Podaj hasło:");
                    var tempString2 = Console.ReadLine();
                    if (tempString2 == UsersList[inkrement + 1])
                    {
                        Console.WriteLine("Witamy {0} !", UsersList[inkrement + 2]);
                        Console.Write("Naciśnij 'ENTER' aby kontynuować:");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Błędne hasło!");
                    }
                    Console.Write("Naciśnij 'ENTER' aby kontynuować:");
                    Console.ReadKey();
                    break;
                }
                else if (i == (UsersList.Length - 1))
                {
                    Console.WriteLine("Błędny Login!");
                    Console.Write("Naciśnij 'ENTER' aby kontynuować:");
                    Console.ReadKey();
                }
            }
        }
        public static string WczytywanieUżytkowników(out string WszyscyUżytkownicy)
        {
            string curFile = @"C:\Users\Sebastian\Source\Repos\FoxBook\FoxBook\użytkownicy.txt";
            if (File.Exists(curFile) == true)
            {
                WszyscyUżytkownicy = System.IO.File.ReadAllText(@"C:\Users\Sebastian\Source\Repos\FoxBook\FoxBook\użytkownicy.txt");
                return WszyscyUżytkownicy;
            }
            else
            {
                Console.WriteLine("Używasz FoxBook pierwszy raz - musisz się najpierw ZAREJESTROWAĆ! :)");
                Thread.Sleep(1000);
                Console.Write("Naciśnij 'ENTER' aby kontynuować:");
                Console.ReadKey();
            }
            WszyscyUżytkownicy = null;
            return WszyscyUżytkownicy;
        }
        public static void PanelUżytkownika()
        {
            Console.WriteLine();
        }
    }
}
