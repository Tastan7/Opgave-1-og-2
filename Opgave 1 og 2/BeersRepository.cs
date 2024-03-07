using Opgave_1_og_2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Opgave_1_og_2
{
    public class BeersRepository
    {
        private readonly List<Beer> _beers;

        // Konstruktør der initialiserer en liste af øl-objekter
        public BeersRepository()
        {
            _beers = new List<Beer>
            {
                new Beer(1, "Carlsberg", 4.8),
                new Beer(2, "Tuborg", 4.6),
                new Beer(3, "Heineken", 5.0),
                new Beer(4, "Pilsner", 4.5),
                new Beer(5, "IPA", 6.0)
            };
        }

        // Hent alle øl med valgfri filtrering og sortering
        public List<Beer> Get(double? minAbv = null, double? maxAbv = null, string? sortBy = null)
        {
            IEnumerable<Beer> result = _beers;

            // Filtrer efter minimum ABV (Alcohol By Volume)
            if (minAbv != null)
                result = result.Where(b => b.Abv >= minAbv);

            // Filtrer efter maksimum ABV (Alcohol By Volume)
            if (maxAbv != null)
                result = result.Where(b => b.Abv <= maxAbv);

            // Sorter efter navn eller ABV (Alcohol By Volume)
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = sortBy.ToLower();
                switch (sortBy)
                {
                    case "name":
                        result = result.OrderBy(b => b.Name);
                        break;
                    case "abv":
                        result = result.OrderBy(b => b.Abv);
                        break;
                }
            }

            return new List<Beer>(result);
        }

        // Hent øl efter ID
        public Beer? GetBeerById(int id)
        {
            // Finder og returnerer øl-objektet med det angivne ID, eller null hvis ikke fundet
            return _beers.FirstOrDefault(b => b.Id == id);
        }

        // Tilføj en ny øl til repository
        public Beer Add(Beer beer)
        {
            // Tildeler et ID til det nye øl-objekt og tilføjer det til listen
            beer.Id = _beers.Count + 1;
            _beers.Add(beer);
            return beer;
        }

        // Slet øl efter ID
        public Beer? Delete(int id)
        {
            // Finder og fjerner øl-objektet med det angivne ID fra listen
            Beer? beerToDelete = GetBeerById(id);
            if (beerToDelete != null)
            {
                _beers.Remove(beerToDelete);
            }
            return beerToDelete;
        }

        // Opdater øl efter ID
        public Beer? Update(int id, Beer values)
        {
            // Finder og opdaterer øl-objektet med det angivne ID med de angivne værdier
            Beer? beerToUpdate = GetBeerById(id);
            if (beerToUpdate != null)
            {
                beerToUpdate.Name = values.Name;
                beerToUpdate.Abv = values.Abv;
            }
            return beerToUpdate;
        }
    }
}
