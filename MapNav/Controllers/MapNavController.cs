using MapNav.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web.Http;

namespace MapNav.Controllers
{
    public class MapNavController : ApiController
    {
        [HttpPost]
        public string GetMapNav([FromBody] MapNavInput input)
        {
            Queue<Instruction> instructionSet = ParseMapInstructions(input.Data.ToString());
            int output = CalculateDistance(instructionSet);
            return new JObject(new JProperty("data", output)).ToString();
        }

        private Queue<Instruction> ParseMapInstructions(string input)
        {
            Queue<Instruction> result = new Queue<Instruction>();

            foreach (string instruction in input.Split(','))
            {
                result.Enqueue(new Instruction(instruction.Trim()));
            }

            return result;
        }

        private int CalculateDistance(Queue<Instruction> instructions)
        {
            Position position = new Position();
            while (instructions.Count > 0)
            {
                position.ProcessInstruction(instructions.Dequeue());
            }

            return position.GetDistance();
        }
    }
}
