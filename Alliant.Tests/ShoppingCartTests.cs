using Alliant.Shopping;
using Alliant.Shopping.Models;
using Autofac;
using Autofac.Extras.Moq;
using NUnit.Framework;
using System.Linq;

namespace Alliant.Tests
{
    public class Tests
    {
        [Test]
        public void ShoppingCartDiscountCalculationOne()
        {
            string Test1 = "ABCDABAA";
            
            using (var mock = AutoMock.GetLoose(config => config.RegisterInstance(new Terminal()).As<ITerminal>()))
            {
                var terminal = mock.Create<ITerminal>();

                var products = Test1.ToCharArray();
                foreach (char item in products)
                {
                    terminal.Scan(item.ToString());
                }

                var actual = terminal.Total();

                Assert.AreEqual(32.40M, actual);
            }
        }

        [Test]
        public void ShoppingCartDiscountCalculationTwo()
        {
            string Test2 = "CCCCCCC";

            using (var mock = AutoMock.GetLoose(config => config.RegisterInstance(new Terminal()).As<ITerminal>()))
            {
                var terminal = mock.Create<ITerminal>();

                var products = Test2.ToCharArray();
                foreach (char item in products)
                {
                    terminal.Scan(item.ToString());
                }

                var actual = terminal.Total();

                Assert.AreEqual(7.25M, actual);
            }
        }
        [Test]
        public void ShoppingCartDiscountCalculationThree()
        {
            string Test3 = "ABCD";

            using (var mock = AutoMock.GetLoose(config => config.RegisterInstance(new Terminal()).As<ITerminal>()))
            {
                var terminal = mock.Create<ITerminal>();

                var products = Test3.ToCharArray();
                foreach (char item in products)
                {
                    terminal.Scan(item.ToString());
                }

                var actual = terminal.Total();

                Assert.AreEqual(15.40M, actual);
            }
        }
    }
}