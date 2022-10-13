using System;

namespace KeLi.SkillPoint.Problems
{
    internal class PrecisionMissingProblem : IAnalyzers
    {
        public void ShowResult()
        {
            var point1 = new Xyz(1.123456789123456, 1.123456789123123, 1.123456789456456);
            var point2 = new Xyz(1.123456789123455, 1.123456789123125, 1.123456789456455);

            Console.WriteLine(point1.ToString());
            Console.WriteLine(point2.ToString());
        }

        internal class Xyz
        {
            private readonly XyzProxy proxy;

            internal Xyz(double x, double y, double z)
            {
                proxy = new XyzProxy(x, y, z);
            }

            internal double X => proxy.Px;

            internal double Y => proxy.Py;

            internal double Z => proxy.Pz;

            public override string ToString()
            {
                return proxy.ToString();
            }
        }

        internal class XyzProxy
        {
            internal XyzProxy(double x, double y, double z)
            {
                Px = x;
                Py = y;
                Pz = z;
            }

            internal double Px { get; set; }

            internal double Py { get; set; }

            internal double Pz { get; set; }

            public override string ToString()
            {
                return "(" + Px + ", " + Py + ", " + Pz + ")";
            }
        }
    }
}