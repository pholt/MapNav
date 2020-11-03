using MapNav.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MapNav.Tests.Models
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void GetDistanceShouldReturnXAndYAddedTogether()
        {
            Position position = new Position();
            position.ProcessInstruction(new Instruction("R3"));
            position.ProcessInstruction(new Instruction("L3"));

            Assert.AreEqual(6, position.GetDistance());
        }

        [TestMethod]
        public void GetDistanceShouldCountAnyCoordinateAsPositive()
        {
            Position position = new Position();
            position.ProcessInstruction(new Instruction("L2"));
            position.ProcessInstruction(new Instruction("L5"));

            Assert.AreEqual(7, position.GetDistance());
        }

        [TestMethod]
        public void ProcessInstructionShouldThrowExceptionForNullInput()
        {
            Position position = new Position();

            Assert.ThrowsException<Exception>(() => position.ProcessInstruction(null));
        }

        [TestMethod]
        public void AdjustFacingShouldTurnRightWhenGivenR()
        {
            Position position = new Position(Facing.North);
            position.AdjustFacing('R');

            Assert.AreEqual(Facing.East, position.Facing);
        }

        [TestMethod]
        public void AdjustFacingShouldTurnRightWhenGivenRAndWrapDirections()
        {
            Position position = new Position(Facing.West);
            position.AdjustFacing('R');

            Assert.AreEqual(Facing.North, position.Facing);
        }

        [TestMethod]
        public void AdjustFacingShouldTurnLeftWhenGivenL()
        {
            Position position = new Position(Facing.South);
            position.AdjustFacing('L');

            Assert.AreEqual(Facing.East, position.Facing);
        }

        [TestMethod]
        public void AdjustFacingShouldTurnLeftWhenGivenLAndWrapDirections()
        {
            Position position = new Position(Facing.North);
            position.AdjustFacing('L');

            Assert.AreEqual(Facing.West, position.Facing);
        }

        [TestMethod]
        public void AdjustPositionShouldAddToYPosWhenFacingNorth()
        {
            Position positionFacingNorth = new Position(Facing.North);
            positionFacingNorth.AdjustPosition(5);

            Assert.AreEqual(0, positionFacingNorth.XPos);
            Assert.AreEqual(5, positionFacingNorth.YPos);
        }

        [TestMethod]
        public void AdjustPositionShouldAddToXPosWhenFacingEast()
        {
            Position positionFacingEast = new Position(Facing.East);
            positionFacingEast.AdjustPosition(4);

            Assert.AreEqual(4, positionFacingEast.XPos);
            Assert.AreEqual(0, positionFacingEast.YPos);
        }

        [TestMethod]
        public void AdjustPositionShouldSubtractFromYPosWhenFacingSouth()
        {
            Position positionFacingSouth = new Position(Facing.South);
            positionFacingSouth.AdjustPosition(9);

            Assert.AreEqual(0, positionFacingSouth.XPos);
            Assert.AreEqual(-9, positionFacingSouth.YPos);
        }

        [TestMethod]
        public void AdjustPositionShouldSubtractFromXPosWhenFacingWest()
        {
            Position positionFacingWest = new Position(Facing.West);
            positionFacingWest.AdjustPosition(6);

            Assert.AreEqual(-6, positionFacingWest.XPos);
            Assert.AreEqual(0, positionFacingWest.YPos);
        }
    }
}
