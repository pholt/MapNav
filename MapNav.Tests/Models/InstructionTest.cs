using MapNav.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MapNav.Tests.Models
{
    [TestClass]
    public class InstructionTest
    {
        [TestMethod]
        public void InstructionConstructor_WithLowerCaseChar_ReturnsUpperCaseChar()
        {
            Assert.AreEqual('L', new Instruction("l5").Direction);
        }

        [TestMethod]
        public void InstructionConstructor_WithIllegalChar_ThrowsException()
        {
            Assert.ThrowsException<Exception>(() => new Instruction("b3"));
        }

        [TestMethod]
        public void InstructionConstructor_WithValidInput_ReturnsInt()
        {
            Assert.AreEqual(5, (new Instruction("l5").Magnitude));
        }

        [TestMethod]
        public void InstructionConstructor_WithWhitespaceInInput_IngestsWithoutError()
        {
            Assert.AreEqual(5, (new Instruction("l 5 ").Magnitude));
        }

        [TestMethod]
        public void InstructionConstructor_WithNonIntegerInput_ThrowsException()
        {
            Assert.ThrowsException<Exception>(() => new Instruction("lu"));
        }

    }
}
