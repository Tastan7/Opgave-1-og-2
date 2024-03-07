using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opgave_1_og_2;

namespace Opgave_1_og_2.Tests
{
    [TestClass]
    public class BeersRepositoryTests
    {
        [TestMethod]
        public void Add_ReturnsAddedBeer()
        {
            var repository = new BeersRepository();
            var beerToAdd = new Beer(6, "Corona", 5.0);

            var addedBeer = repository.Add(beerToAdd);

            Assert.IsNotNull(addedBeer);
            Assert.AreEqual(beerToAdd, addedBeer);
            CollectionAssert.Contains(repository.Get(), beerToAdd);
        }

        [TestMethod]
        public void Delete_RemovesBeer()
        {
            var repository = new BeersRepository();
            int beerIdToDelete = 1;

            var deletedBeer = repository.Delete(beerIdToDelete);

            Assert.IsNotNull(deletedBeer);
            Assert.AreEqual(beerIdToDelete, deletedBeer.Id);
            Assert.IsFalse(repository.Get().Contains(deletedBeer));
        }

        [TestMethod]
        public void GetBeerById_ReturnsCorrectBeer()
        {
            var repository = new BeersRepository();
            int beerIdToRetrieve = 1;
            var expectedBeer = new Beer(beerIdToRetrieve, "Carlsberg", 4.8);

            var actualBeer = repository.GetBeerById(beerIdToRetrieve);

            Assert.IsNotNull(actualBeer);
            Assert.AreEqual(expectedBeer.Id, actualBeer.Id);
            Assert.AreEqual(expectedBeer.Name, actualBeer.Name);
            Assert.AreEqual(expectedBeer.Abv, actualBeer.Abv);
        }
    }
}
