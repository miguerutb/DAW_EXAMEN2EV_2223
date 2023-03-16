using LotoClassNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LotoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValorRepetido()
        {
            int[] entrada = { 1, 1, 2, 3, 4, 5 };

            MTB2223 res = new MTB2223(entrada);

            Assert.IsFalse(res.Ok);
        }

        [TestMethod]
        public void FueraRangoArriba()
        {
            int[] entrada = { 1, 2, 4, 6, 90 };

            MTB2223 res = new MTB2223(entrada);

            Assert.IsFalse(res.Ok);
        }
        
        [TestMethod]
        public void FueraRangoAbajo()
        {
            int[] entrada = { 0, 1, 2, 3, 4, 5 };

            MTB2223 res = new MTB2223(entrada);

            Assert.IsFalse(res.Ok);
        }

        [TestMethod]
        public void FueraRangoLimite()
        {
            int[] entrada = { 50, 1, 2, 3, 4, 0 };

            MTB2223 res = new MTB2223(entrada);

            Assert.IsFalse(res.Ok);
        }

        /*
        [TestMethod]
        public void ValoresLimiteOK()
        {
            int[] entrada = { 1, 2, 4, 48, 49, 6 };

            MTB2223 res = new MTB2223(entrada);

            Assert.IsTrue(res.Ok);
        }

        [TestMethod]
        public void ValorNormal()
        {
            int[] entrada = { 1, 2, 3, 4, 5, 6 };

            MTB2223 res = new MTB2223(entrada);

            Assert.IsTrue(res.Ok);
        }
        */
    }
}
