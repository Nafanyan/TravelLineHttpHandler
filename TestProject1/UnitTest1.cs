namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Sum10_and20_30returned()
        {
            // arrange
            int one = 10;
            int two = 20;
            int expected = 30;

            // act
            TravelLineHttpHandler.Calc calc = new TravelLineHttpHandler.Calc();
            int actual = calc.Sum(one, two);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}