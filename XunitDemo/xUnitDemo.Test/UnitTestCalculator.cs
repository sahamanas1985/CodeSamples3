using Xunit;
using XunitDemo;

namespace xUnitDemo.Test
{
    public class UnitTestCalculator
    {
        MyCalc calc;

        public UnitTestCalculator()
        {
            calc = new MyCalc(2, 3);
        }

        [Fact]
        public void TestAdd()
        {            
            //Arrange

            int a = 10;
            int b = 7;
            int expectedValue = 17;

            //Act
            int sum = calc.sum(a, b);

            //Assert
            Assert.Equal(expectedValue, sum);
        }

        [Fact]
        public void TestMulti()
        {           
            //Arrange

            int expectedValue = 6;

            //Act
            int multi = calc.multi();

            //Assert
            Assert.Equal(expectedValue, multi);

        }


    }
}