using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MapNav.Models
{
    public class Position
    {
        public int XPos { get; private set; }
        public int YPos { get; private set; }
        public Facing Facing { get; private set; }

        public Position(Facing facing = Facing.North, int x = 0, int y = 0)
        {
            XPos = x;
            YPos = y;
            Facing = facing;
        }

        // Total distance in blocks from (0, 0).
        public int GetDistance()
        {
            return Math.Abs(XPos) + Math.Abs(YPos);
        }

        public void ProcessInstruction(Instruction input)
        {
            if (input == null)
            {
                throw new Exception("Instruction input must not be null.");
            }

            AdjustFacing(input.Direction);
            AdjustPosition(input.Magnitude);
        }

        public void AdjustFacing(char adjustment)
        {
            int facing = (int)this.Facing;
            switch (adjustment)
            {
                case 'L':
                    facing--;
                    break;
                case 'R':
                    facing++;
                    break;
            }

            // Out of bounds correction
            if (facing < 0)
            {
                facing += 4;
            } 
            else if (facing >= 4)
            {
                facing -= 4;
            }

            this.Facing = (Facing)facing;
        }

        public void AdjustPosition(int magnitude)
        {
            switch (this.Facing)
            {
                case Facing.North:
                    this.YPos += magnitude;
                    break;
                case Facing.East:
                    this.XPos += magnitude;
                    break;
                case Facing.South:
                    this.YPos -= magnitude;
                    break;
                case Facing.West:
                    this.XPos -= magnitude;
                    break;
            }
        }
    }
}