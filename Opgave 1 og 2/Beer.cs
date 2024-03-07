using System;

namespace Opgave_1_og_2
{
    public class Beer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Abv { get; set; }

        // Konstruktør der initialiserer et nyt øl-objekt med angivet id, navn og ABV (Alcohol By Volume)
        public Beer(int id, string name, double abv)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name), "Navn kan ikke være null.");
            if (Name.Length < 3)
            {
                throw new ArgumentException("Navnet skal være mindst 3 tegn langt.", nameof(name));
            }

            Abv = abv;
            if (abv < 0 || abv > 67)
            {
                throw new ArgumentOutOfRangeException(nameof(abv), "ABV skal være mellem 0 og 67.");
            }
        }

        // Returnerer en strengrepræsentation af øl-objektet
        public override string ToString() => $"{Id}, {Name}, {Abv}";

        // Validerer navnet på øl-objektet
        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException(nameof(Name), "Navn kan ikke være null.");
            }

            if (Name.Length < 3)
            {
                throw new ArgumentException("Navnet skal være mindst 3 tegn langt.", nameof(Name));
            }
        }

        // Validerer ABV (Alcohol By Volume) af øl-objektet
        public void ValidateAbv()
        {
            if (Abv < 0 || Abv > 67)
            {
                throw new ArgumentOutOfRangeException(nameof(Abv), "ABV skal være mellem 0 og 67.");
            }
        }
    }
}

