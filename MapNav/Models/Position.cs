using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MapNav.Models
{
    public class Position
    {
        private int XPos { get; set; }
        private int YPos { get; set; }
        private Facing Facing { get; set; }

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

        public void ConsumeInstruction(Instruction input)
        {
            AdjustFacing(input.Direction);
            AdjustPosition(input.Magnitude);
        }

        private void AdjustFacing(char adjustment)
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

        private void AdjustPosition(int magnitude)
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