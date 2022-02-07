using Common.MultiValueDictionaryApp.Constants;
using Common.MultiValueDictionaryApp.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Common2.MultiValueDictionaryApp.Tests
{
    [TestClass]
    class ConsoleWrapperTests2
    {
        public ConsoleWrapperTests2()
        {

        }

        [TestMethod]
        public void ValidateInput()
        {
            Assert.IsTrue(ConsoleWrapper.ValidateInput(Operations.Members, 1, null));
            Assert.IsFalse(ConsoleWrapper.ValidateInput(Operations.KeyExists, null, null));
        }
    }
}
