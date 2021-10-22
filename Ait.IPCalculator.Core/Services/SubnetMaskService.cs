using Ait.IPCalculator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ait.IPCalculator.Core.Services
{
   public class SubnetMaskService
    {
        public static List<SubnetMask> SubMasks = new List<SubnetMask>();

       

        public static void InitialiseList()
        {
            SubMasks.Add(new SubnetMask { part1 = 0, part2 = 0, part3 = 0, part4 = 0, prefix = 0 });
            SubMasks.Add(new SubnetMask { part1 = 128, part2 = 0, part3 = 0, part4 = 0, prefix = 1 });
            SubMasks.Add(new SubnetMask { part1 = 192, part2 = 0, part3 = 0, part4 = 0, prefix = 2 });
            SubMasks.Add(new SubnetMask { part1 = 224, part2 = 0, part3 = 0, part4 = 0, prefix = 3 });
            SubMasks.Add(new SubnetMask { part1 = 240, part2 = 0, part3 = 0, part4 = 0, prefix = 4 });
            SubMasks.Add(new SubnetMask { part1 = 248, part2 = 0, part3 = 0, part4 = 0, prefix = 5 });
            SubMasks.Add(new SubnetMask { part1 = 252, part2 = 0, part3 = 0, part4 = 0, prefix = 6 });
            SubMasks.Add(new SubnetMask { part1 = 254, part2 = 0, part3 = 0, part4 = 0, prefix = 7 });

            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 0, part3 = 0, part4 = 0, prefix = 8 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 128, part3 = 0, part4 = 0, prefix = 9 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 192, part3 = 0, part4 = 0, prefix = 10 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 224, part3 = 0, part4 = 0, prefix = 11 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 240, part3 = 0, part4 = 0, prefix = 12 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 248, part3 = 0, part4 = 0, prefix = 13 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 252, part3 = 0, part4 = 0, prefix = 14 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 254, part3 = 0, part4 = 0, prefix = 15 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 0, part4 = 0, prefix = 16 });

            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 128, part4 = 0, prefix = 17 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 192, part4 = 0, prefix = 18 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 224, part4 = 0, prefix = 19 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 240, part4 = 0, prefix = 20 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 248, part4 = 0, prefix = 21 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 252, part4 = 0, prefix = 22 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 254, part4 = 0, prefix = 23 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 255, part4 = 0, prefix = 24 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 255, part4 = 128, prefix = 25 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 255, part4 = 192, prefix = 26 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 255, part4 = 224, prefix = 27 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 255, part4 = 240, prefix = 28 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 255, part4 = 248, prefix = 29 });
            SubMasks.Add(new SubnetMask { part1 = 255, part2 = 255, part3 = 255, part4 = 252, prefix = 30 });
        }
    }
}
