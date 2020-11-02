using MapNav.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapNav.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string input10 = "L3, R2, L5, R1, L1, L2";
            string input209 = "L3, R2, L5, R1, L1, L2, L2, R1, R5, R1, L1, L2, R2, R4, L4, L3, L3, R5, L1, R3, L5, L2, R4, L5, R4, R2, L2, L1, R1, L3, L3, R2, R1, L4, L1, L1, R4, R5, R1, L2, L1, R188, R4, L3, R54, L4, R4, R74, R2, L4, R185, R1, R3, R5, L2, L3, R1, L1, L3, R3, R2, L3, L4, R1, L3, L5, L2, R2, L1, R2, R1, L4, R5, R4, L5, L5, L4, R5, R4, L5, L3, R4, R1, L5, L4, L3, R5, L5, L2, L4, R4, R4, R2, L1, L3, L2, R5, R4, L5, R1, R2, R5, L2, R4, R5, L2, L3, R3, L4, R3, L2, R1, R4, L5, R1, L5, L3, R4, L2, L2, L5, L5, R5, R2, L5, R1, L3, L2, L2, R3, L3, L4, R2, R3, L1, R2, L5, L3, R4, L4, R4, R3, L3, R1, L3, R5, L5, R1, R5, R3, L1";
            Queue<Instruction> firstInstructionSet = ParseMapInstructions(input10);
            ViewBag.DistanceFirst = CalculateDistance(firstInstructionSet);

            Queue<Instruction> secondInstructionSet = ParseMapInstructions(input209);
            ViewBag.DistanceSecond = CalculateDistance(secondInstructionSet);

            return View();
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
            while(instructions.Count > 0)
            {
                position.ConsumeInstruction(instructions.Dequeue());
            }

            return position.GetDistance();
        }

    }
}