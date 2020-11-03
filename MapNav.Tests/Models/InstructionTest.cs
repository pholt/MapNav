using MapNav.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MapNav.Tests.Models
{
    [TestClass]
    class InstructionTest
    {
        [TestMethod]
        public void ValidateDirectionShouldReturnUpperCaseChar()
        {
            Assert.AreEqual('L', new Instruction("l5").Direction);
        }

        [TestMethod]
        public void ValidateDirectionShouldThrowExceptionForIllegalChar()
        {
            Assert.ThrowsException<Exception>(() => new Instruction("b3"));
        }

        [TestMethod]
        public void ValidateMagnitudeShouldReturnInt()
        {
            Assert.AreEqual(5, (new Instruction("l5").Magnitude));
        }

        [TestMethod]
        public void ValidateMagnitudeShouldHandleExcessWhitespace()
        {
            Assert.AreEqual(5, (new Instruction("l 5 ").Magnitude));
        }

        [TestMethod]
        public void ValidateMagnitudeShouldThrowExceptionForNonIntegerInput()
        {
            Assert.ThrowsException<Exception>(() => new Instruction("lu"));
        }

    }
}
