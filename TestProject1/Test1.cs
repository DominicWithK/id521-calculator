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
        [TestMethod]
        public void ISBN13Test()
        {
            string result = NTheory.CheckDigit("978459287982");
            Assert.AreEqual("4", result);
        }
        [TestMethod]
        public void EAN13Test()
        {
            string result = NTheory.CheckDigit("296837692858");
            Assert.AreEqual("9", result);
        }
        [TestMethod]
        public void UPC11Test()
        {
            string result = NTheory.CheckDigit("19285928692");
            Assert.AreEqual("3", result);
        }
        [TestMethod]
        public void dectoBinTest()
        {
            string result = Binary.DecimalToBinary(255);
            Assert.AreEqual("11111111", result);
        }
        [TestMethod]
        public void dectoHexTest()
        {
            string result = Binary.DecimalToHexadecimal(1514);
            Assert.AreEqual("5EA", result);
        }
        [TestMethod]
        public void bintoDecTest()
        {   
            int result = Binary.BinaryToDecimal("11111111");
            Assert.AreEqual(255, result);
        }
        [TestMethod]
        public void bintoHexTest()
        {
            string result = Binary.BinaryToHex("11111111");
            Assert.AreEqual("FF", result);
        }
        [TestMethod]
        public void hextoDecTest()
        {
            int result = Binary.HexToDecimal("5EA");
            Assert.AreEqual(1514, result);
        }
        [TestMethod]
        public void hextoBinTest()
        {
            string result = Binary.HexToBinary("FF");
            Assert.AreEqual("11111111", result);
        }
        [TestMethod]
        public void dectoBCDTest()
        {
            string result = Binary.DecimalToBCD("99");
            Assert.AreEqual("1001 1001", result);
        }
    }
}
