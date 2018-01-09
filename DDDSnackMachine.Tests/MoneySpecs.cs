using FluentAssertions;
using SnackMachineATMAutomation.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DDDSnackMachine.Tests
{
    public class MoneySpecs
    {
        [Fact]
        public void Sum_Of_Two_Money_Produce_Correct_Result()
        {
            // Arrange
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            // Act
            var sum = money1 + money2;

            // Assert
            //Assert.Equal(2, sum.OneCentCount);
            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCentCount.Should().Be(6);
            sum.OneDollarCount.Should().Be(8);
            sum.FiveDollarCount.Should().Be(10);
            sum.TweentyDollarCount.Should().Be(12);
        }

        [Fact]
        public void Two_Money_Instances_Equal_If_Contain_The_Same_Money_Amount()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            money1.Should().Be(money2);
            money1.GetHashCode().Should().Be(money2.GetHashCode());

        }

        [Fact]
        public void Two_Money_Instances_do_not_Equal_If_Contain_The_diffrent_Money_Amount()
        {
            var oneDollar = new Money(0, 0, 0, 1, 0, 0);
            var tenCent = new Money(0, 1, 0, 0, 0, 0);

            oneDollar.Should().NotBe(tenCent);
            oneDollar.GetHashCode().Should().NotBe(tenCent.GetHashCode());

        }

        [Theory]
        [InlineData(-1, 0, 0, 0, 0, 0)]
        [InlineData(0, -2, 0, 0, 0, 0)]
        [InlineData(0, 0, -3, 0, 0, 0)]
        [InlineData(0, 0, 0, -4, 0, 0)]
        [InlineData(0, 0, 0, 0, -5, 0)]
        [InlineData(0, 0, 0, 0, 0, -6)]
        public void Cannot_Create_Money_With_Negative_Value(int oneCentCount,
            int tenCentCount,
            int quarterCentCount,
            int oneDollarCount,
            int fiveDollarCount,
            int tweentyDollarCount)
        {
            Action action = () => new Money(oneCentCount,
                tenCentCount,
                quarterCentCount,
                oneDollarCount,
                fiveDollarCount,
                tweentyDollarCount);

            action.ShouldThrow<InvalidOperationException>();


        }


        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0, 0)]
        [InlineData(1, 0, 0, 0, 0, 0, 0.01)]
        [InlineData(1, 2, 0, 0, 0, 0, 0.21)]
        [InlineData(1, 2, 3, 0, 0, 0, 0.96)]
        [InlineData(1, 2, 3, 4, 5, 0, 29.96)]
        [InlineData(0, 0, 0, 0, 0, 1, 20)]
        public void Amount_Is_Calculated_Correctly(
    int oneCentCount,
    int tenCentCount,
    int quarterCentCount,
    int oneDollarCount,
    int fiveDollarCount,
    int tweentyDollarCount,
    double expectedAmount)
        {
           Money money =  new Money(oneCentCount,
                tenCentCount,
                quarterCentCount,
                oneDollarCount,
                fiveDollarCount,
                tweentyDollarCount);

            money.Amount.ShouldBeEquivalentTo(expectedAmount);
        }


        [Fact]
        public void Sub_Of_Two_Money_Produce_Correct_Result()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            var sub = money1 - money2;

            sub.OneCentCount.Should().Be(0);
            sub.TenCentCount.Should().Be(0);
            sub.QuarterCentCount.Should().Be(0);
            sub.OneDollarCount.Should().Be(0);
            sub.FiveDollarCount.Should().Be(0);
            sub.TweentyDollarCount.Should().Be(0);
        }

        [Fact]
        public void Cannot_subtract_more_than_exists()
        {
            Money money1 = new Money(0, 1, 0, 0, 0, 0);
            Money money2 = new Money(1, 0, 0, 0, 0, 0);

            Action action = () =>
            {
                Money money = money1 - money2;
            };

            action.ShouldThrow<InvalidOperationException>();
        }

    }
}
