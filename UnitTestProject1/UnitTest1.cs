using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInvalidInput1()
        {
            //Act
            //invalid input (not number)
            string ret = TripCalculator.TripForm.DoCalc("A", "B", "C", "D", "2", "3");

            //Assert
            Assert.AreEqual(ret, "Input string was not in a correct format.");
        }
        [TestMethod]
        public void TestInvalidInput2()
        {
            //Act
            //invalid input (not number)
            string ret = TripCalculator.TripForm.DoCalc("A", "B", "C", "1", "E", "3");

            //Assert
            Assert.AreEqual(ret, "Input string was not in a correct format.");
        }
        [TestMethod]
        public void TestInvalidInput3()
        {
            //Act
            //invalid input (not number)
            string ret = TripCalculator.TripForm.DoCalc("A", "B", "C", "1", "2", "F");

            //Assert
            Assert.AreEqual(ret, "Input string was not in a correct format.");
        }
        [TestMethod]
        public void TestInvalidInput4()
        {
            //Act
            //invalid input (empty names)
            string ret = TripCalculator.TripForm.DoCalc("", "B", "C", "1", "2", "3");

            //Assert
            Assert.AreEqual(ret, "Names Must Not Be Empty.");
        }
        [TestMethod]
        public void Test1()
        {
            //Act
            string ret = TripCalculator.TripForm.DoCalc("A", "B", "C", "1", "2", "3");

            //Assert
            Assert.AreEqual(ret, "A Owes C $1" + System.Environment.NewLine);
        }
        [TestMethod]
        public void Test2()
        {
            //Act
            string ret = TripCalculator.TripForm.DoCalc("A", "B", "C", "11", "22", "333");

            //Assert
            Assert.AreEqual(ret, "A Owes C $111" + System.Environment.NewLine + "B Owes C $100" + System.Environment.NewLine);
        }
        [TestMethod]
        public void Test3()
        {
            //Act
            string ret = TripCalculator.TripForm.DoCalc("A", "B", "C", "111", "22", "33");

            //Assert
            Assert.AreEqual(ret, "B Owes A $33.33" + System.Environment.NewLine + "C Owes A $22.33" + System.Environment.NewLine);
        }
        [TestMethod]
        public void Test4()
        {
            //Act
            string ret = TripCalculator.TripForm.DoCalc("Louis", "Carter", "David", "$5.75 $35.00 $12.79", "$12.00 $15.00 $23.23", "$10.00 $20.00 $38.41 $45.00");

            //Assert
            Assert.AreEqual(ret, "Louis Owes David $18.85" + System.Environment.NewLine + "Carter Owes David $22.16" + System.Environment.NewLine);
        }
    }
}
