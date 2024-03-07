using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opgave_1_og_2;
using System;

namespace Opgave_1_og_2.Tests
{
    [TestClass]
    public class BeerTests
    {
        [TestMethod]
        public void Beer_Constructor_ValidData_DoesNotThrow()
        {
            try
            {
                new Beer(1, "Carlsberg", 4.5);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception: {ex.Message}");
            }
        }


        [TestMethod]
        public void Beer_Constructor_NullName_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Beer(1, null!, 4.5));
        }

        [TestMethod]
        public void Beer_Constructor_EmptyName_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Beer(1, string.Empty, 4.5));
        }

        [TestMethod]
        public void Beer_Constructor_ShortName_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Beer(1, "Øl", 4.5));
        }

        [TestMethod]
        public void Beer_Constructor_InvalidAbv_ThrowsArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Beer(1, "Carlsberg", -1));
        }

        [TestMethod]
        public void Beer_Constructor_MaxAbv_DoesNotThrow()
        {
            try
            {
                new Beer(1, "Carlsberg", 67);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception: {ex.Message}");
            }
        }



        [TestMethod]
        public void Beer_ValidateName_ValidName_DoesNotThrow()
        {
            var beer = new Beer(1, "Carlsberg", 4.5);

            try
            {
                beer.ValidateName();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception: {ex.Message}");
            }
        }



        [TestMethod]
        public void Beer_ValidateName_NullName_ThrowsArgumentNullException()
        {
            var beer = new Beer(1, "Carlsberg", 4.5);
            beer.Name = null;

            Assert.ThrowsException<ArgumentNullException>(() => beer.ValidateName());
        }

        [TestMethod]
        public void Beer_ValidateName_ShortName_ThrowsArgumentException()
        {
            var beer = new Beer(1, "Carlsberg", 4.5);
            beer.Name = "Øl";

            Assert.ThrowsException<ArgumentException>(() => beer.ValidateName());
        }

        [TestMethod]
        public void Beer_ValidateAbv_ValidAbv_DoesNotThrow()
        {
            var beer = new Beer(1, "Carlsberg", 4.5);

            try
            {
                beer.ValidateAbv();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception: {ex.Message}");
            }
        }



        [TestMethod]
        public void Beer_ToString_ReturnsCorrectString()
        {
            var beer = new Beer(1, "Carlsberg", 4.5);
            string expected = "1, Carlsberg, 4.5";

            string actual = beer.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}