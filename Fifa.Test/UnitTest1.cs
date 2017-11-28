using System;
using FifaApp.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fifa.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var myService = new MyHttpService();
            myService.Get("").GetAwaiter().GetResult();
        }
        [TestMethod]
        public void TestMethod2()
        {
            var myService = new MyHttpService();
            myService.Post().GetAwaiter().GetResult();
        }
    }
}
