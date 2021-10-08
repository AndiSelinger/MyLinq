using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLinq.Logic.UnitTest
{
    [TestClass]
    public class ObjectExtensionsUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckArgument_NullReference_ExpectedArgumentNullException() //Tests sind immer void
        {
            string name = null;
            name.CheckArgument(nameof(name));
        }
        [TestMethod]
        public void CheckArgument_StringReference_ExpectedNoneArgumentException() //Tests sind immer void
        {
            string name = "Max";
            name.CheckArgument(nameof(name));
        }
        [TestMethod]
        public void CheckArgument_NullArgumentWithTestName_ExpectedArgumentNullExceptionWithTestName()
        {
            object testName = null;
            string expected = $"Value cannot be null. (Parameter '{nameof(testName)}')";
            try
            {
                testName.CheckArgument(nameof(testName));
            }
            catch (ArgumentNullException anex)
            {
                Assert.AreEqual(expected, anex.Message);
            }
        }
        [TestMethod]
        public void CheckArgument_NullArgumentWithTestLastName_ExpectedArgumentNullExceptionWithTestName()
        {
            object lastName = null; //eigentlich nix neues.
            string expected = $"Value cannot be null. (Parameter '{nameof(lastName)}')";
            try
            {
                lastName.CheckArgument(nameof(lastName));
            }
            catch (ArgumentNullException anex)
            {
                Assert.AreEqual(expected, anex.Message);
            }
        }
    }
}
