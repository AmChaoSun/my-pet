using System;
using Xunit;

namespace MyPet.Test
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(2, 2);
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(2, 3);
        }
    }
}
