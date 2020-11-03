using MapNav.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MapNav.Controllers
{
    public class MapNavController : ApiController
    {
        [HttpGet]
        public JObject GetMapNav(string json)
        {
            var data = (JObject)JsonConvert.DeserializeObject(json);
            Queue<Instruction> instructionSet = ParseMapInstructions(data["data"].ToString());
            int output = CalculateDistance(instructionSet);
            return new JObject(new JProperty("data", output));
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
