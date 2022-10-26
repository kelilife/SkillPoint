using System;
using System.Collections.Generic;
using System.Linq;

namespace KeLi.SkillPoint.Problems
{
    internal class UvSortingProblem : IAnalyzers
    {
        public void ShowResult()
        {
            var uvs = new List<Uv>
            {
                new(11, 10),
                new(8, 6),
                new(8, 9),
                new(7, 11)
            };

            // Solution 1.
            Sort(uvs);

            // Solution 2.
            uvs.Sort(new UvCompare());
        }

        internal List<Uv> Sort(List<Uv> uvs)
        {
            if (uvs is null)
                return new List<Uv>();

            if (!uvs.Any())
                return new List<Uv>();

            return uvs.OrderBy(o => o.U).ThenBy(t => t.V).ToList();
        }

        internal class UvCompare : IComparer<Uv>
        {
            public int Compare(Uv uv1, Uv uv2)
            {
                if (uv1 is null || uv2 is null)
                    throw new Exception();

                return uv1.U.CompareTo(uv2.U) switch
                {
                    > 0 => 1,
                    0 when uv1.V.CompareTo(uv2.V) > 0 => 1,
                    0 when uv1.V.CompareTo(uv2.V) == 0 => 0,
                    0 => -1,
                    _ => -1
                };
            }
        }

        internal class Uv
        {
            internal Uv(double u, double v)
            {
                U = u;
                V = v;
            }

            internal double U { get; }

            internal double V { get; }
        }
    }
}