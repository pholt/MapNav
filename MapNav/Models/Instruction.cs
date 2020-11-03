using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace MapNav.Models
{
    public class Instruction
    {
        private const string LEGAL_DIRECTION_VALUES = "lrLR";

        public char Direction { get; private set; }
        public int Magnitude { get; private set; }

        // Instructions should start with a character determining "turn left (L)" or "turn right (R)"
        // then whole numbers representing how far to move. Example: "L43".
        public Instruction(string instruction)
        {
            this.Direction = ValidateDirection(instruction[0]);
            this.Magnitude = ValidateMagnitude(instruction.Substring(1));
        }

        private char ValidateDirection(char direction)
        {
            if (LEGAL_DIRECTION_VALUES.Contains(direction))
            {
                return Char.ToUpper(direction);
            }
            else
            {
                throw new Exception("Invalid direction. Valid directions can only be 'L' or 'R'.");
            }
        }

        private int ValidateMagnitude(string magnitude)
        {
            int result;
            if (int.TryParse(magnitude.Trim(), out result))
            {
                return result;
            }
            else
            {
                throw new Exception("Could not parse magnitude of instruction as integer.");
            }
        }
    }
}