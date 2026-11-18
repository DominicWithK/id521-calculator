using DominikADigitalNumeracyAssignment;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void AdditionTest()
        {
            string result = Parser.Process("2 + 2");
            Assert.AreEqual("4", result);
        }
        [TestMethod]
        public void SubtractionTest()
        {
            string result = Parser.Process("2 + 2");
            Assert.AreEqual("4", result);
        }
        [TestMethod]
        public void MultiplicationTest()
        {
            string result = Parser.Process("2 * 2");
            Assert.AreEqual("4", result);
        }
        [TestMethod]
        public void DivsionTest()
        {
            string result = Parser.Process("8 / 2");
            Assert.AreEqual("4", result);
        }
        [TestMethod]
        public void ModuloTest()
        {
            string result = Parser.Process("6 % 4");
            Assert.AreEqual("2", result);
        }
        [TestMethod]
        public void ExponentTest()
        {
            string result = Parser.Process("2^3");
            Assert.AreEqual("8", result);
        }
        [TestMethod]
        public void BEDMASTest()
        {
            string result = Parser.Process("(2 + 3)^2 * 2 - 6 + 4");
            Assert.AreEqual("48", result);
        }
        [TestMethod]
        public void CaesarEncryptTest()
        {
            string result = Cryptography.CaesarEncrypt("cake", 3);
            Assert.AreEqual("FDNH", result);
        }
        [TestMethod]
        public void CaesarDecryptTest()
        {
            string result = Cryptography.CaesarEncrypt("FDNH", 26 - 3);
            Assert.AreEqual("CAKE", result);
        }
        [TestMethod]
        public void AffineEncryptTest()
        {
            string result = Cryptography.AffineEncrypt("Cake", 3, 3);
            Assert.AreEqual("JDHP", result);
        }
        [TestMethod]
        public void AffineDecryptTest()
        {
            string result = Cryptography.AffineDecrypt("JDHP", 3, 3);
            Assert.AreEqual("CAKE", result);
        }
        [TestMethod]
        public void IsPrimeTestNo()
        {
            string result = NTheory.isPrime(6);
            Assert.AreEqual("6 > Is not a prime", result);
        }
        [TestMethod]
        public void IsPrimeTestYes()
        {
            string result = NTheory.isPrime(7);
            Assert.AreEqual("7 > Is a prime", result);
        }
    }
}
