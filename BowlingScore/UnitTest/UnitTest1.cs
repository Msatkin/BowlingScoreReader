using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingScore;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateScores()
        {
            //Arrange
            ScoreCalculator calculatorOne = new ScoreCalculator("X 7/ 72 9/ X X X 23 6/ 7/3");
            ScoreCalculator calculatorTwo = new ScoreCalculator("5/ 81 X 0/ 52 70 7/ 9/ 54 90");
            ScoreCalculator calculatorThree = new ScoreCalculator("X X X X X X X X X XXX");

            //Act
            int resultOne = calculatorOne.Calculate();
            int resultTwo = calculatorTwo.Calculate();
            int resultThree = calculatorThree.Calculate();

            //Assert
            Assert.AreEqual(168, resultOne);
            Assert.AreEqual(128, resultTwo);
            Assert.AreEqual(300, resultThree);
        }
    }
}
