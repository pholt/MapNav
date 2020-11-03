using MapNav.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MapNav.Tests.Models
{
    [TestClass]
    public class InstructionTest
    {
        [TestMethod]
        public void InstructionConstructorShouldReturnUpperCaseChar()
        {
            Assert.AreEqual('L', new Instruction("l5").Direction);
        }

        [TestMethod]
        public void InstructionConstructorShouldThrowExceptionForIllegalChar()
        {
            Assert.ThrowsException<Exception>(() => new Instruction("b3"));
        }

        [TestMethod]
        public void InstructionConstructorShouldReturnInt()
        {
            Assert.AreEqual(5, (new Instruction("l5").Magnitude));
        }

        [TestMethod]
        public void InstructionConstructorShouldHandleExcessWhitespace()
        {
            Assert.AreEqual(5, (new Instruction("l 5 ").Magnitude));
        }

        [TestMethod]
        public void InstructionConstructorShouldThrowExceptionForNonIntegerInput()
        {
            Assert.ThrowsException<Exception>(() => new Instruction("lu"));
        }

    }
}
