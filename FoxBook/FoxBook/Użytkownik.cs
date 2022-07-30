using System;
using System.IO;

namespace FoxBook
{
    class Użytkownik
    {
        public string Login { get; private set; }
        public string Hasło { get; private set; }
        public string Imię { get; private set; }
        public string Nazwisko { get; private set; }
        public DateTime DataUrodzenia { get; private set; }

        public Użytkownik(string login, string hasło, string imię, string nazwisko)
        {
            Login = login;
            Hasło = hasło;
            Imię = imię;
            Nazwisko = nazwisko;
        }
    }
}


