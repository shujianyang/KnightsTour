using System;
using KnightsTour.KnightsTourGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnightsTourTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            KnightsTourGame game = new KnightsTourGame();
            game.setUpChessBoard(8);
            game.cb.Square();
        }
    }
}
