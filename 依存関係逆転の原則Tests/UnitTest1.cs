using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using 依存関係逆転の原則;
using 依存関係逆転の原則.Objects;

namespace 依存関係逆転の原則Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var m = new ModuleA(new ProductMock());
            Assert.AreEqual("AAA%", m.GetValue());

            var m2 = new ModuleA(new ProductMock2());
            Assert.AreEqual("AAABB", m2.GetValue());


            //Assert.AreEqual(3, m.GetAB(1, 2));
        }


        [TestMethod]
        public void Moqを使ったテスト()
        {
            var productMock = new Mock<IProduct>();
            var m = new ModuleA(productMock.Object);//Objectをつけることでインスタンスを意味する

            productMock.Setup(x => x.GetData()).Returns("BBB");
            Assert.AreEqual("BBB%", m.GetValue());

            productMock.Setup(x => x.GetData()).Returns("BBBCC");
            Assert.AreEqual("BBBCC", m.GetValue());

        }

        [TestMethod]
        public void ModuleBのテスト()
        {
            var productMock = new Mock<IProduct>();
            productMock.Setup(x => x.GetData()).Returns("AAA");
            Assert.AreEqual("AAA%", ModuleB.GetValue(productMock.Object));

        }

        [TestMethod]
        public void ViewModelのテスト()
        {
            //var productMock = new Mock<IProduct>();
            //productMock.Setup(x => x.GetData()).Returns("ABC");

            //var vm = new Form1ViewModel(productMock.Object);
            //Assert.AreEqual("", vm.Button1Text);

            //vm.Button1Click();
            //Assert.AreEqual("ABC%", vm.Button1Text);

        }


        internal sealed class ProductMock : IProduct
        {
            public string GetData()
            {
                return "AAA";
            }

            public void Save(string value)
            {
                throw new NotImplementedException();
            }
        }

        internal sealed class ProductMock2 : IProduct
        {
            public string GetData()
            {
                return "AAABB";
            }

            public void Save(string value)
            {
                throw new NotImplementedException();
            }
        }

    }
}
