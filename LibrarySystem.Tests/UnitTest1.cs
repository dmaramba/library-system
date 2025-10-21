namespace LibrarySystem.Tests
{
    public class UnitTest1
    {

        int AddNumber(int number, int number2) => number + number2;
        [Fact]
        public void Adding_Numbers_Should_Return_A_Total()
        {
            var sum = AddNumber(1, 2);

            Assert.Equal(3, sum);
        }
    }
}