namespace Ait.IPCalculator.Core.Entities
{
    public class SubnetMask : IP
    {

        public int prefix { get; set; } = 0;

        public SubnetMask()
        {
            prefix++;
        }



        public override string ToString()
        {
            return $"{ part1}.{part2}.{part3}.{part4}/({prefix})";
        }
    }
}
