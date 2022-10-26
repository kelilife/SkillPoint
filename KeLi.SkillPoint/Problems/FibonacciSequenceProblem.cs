using System;
using System.Numerics;

using KeLi.SkillPoint;

// ReSharper disable All

internal class FibonacciSequenceProblem : IAnalyzers
{
    private static readonly ulong[] cache = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };

    public void ShowResult()
    {
    }

    internal static BigInteger GetNature1(int index)
    {
        // It's very fast that provided by Shao Taihua.

        if (index < cache.Length - 1)
            return cache[index];

        if (index % 2 == 0)
        {
            var middle = GetNature1(index / 2);
            var preMiddle = GetNature1(index / 2 - 1);

            return middle * (middle + 2 * preMiddle);
        }

        else
        {
            var middle = GetNature1(index / 2);
            var nextMiddle = GetNature1(index / 2 + 1);

            return nextMiddle * nextMiddle + middle * middle;
        }
    }

    internal static BigInteger GetNature2(int index)
    {
        // f(n-1)+f(n-2)=f(n)(n>=2)

        var result = (BigInteger)0;
        var number1 = (BigInteger)1;
        var number2 = (BigInteger)1;

        for (var i = 2; i < index; ++i)
        {
            result = number1 + number2;
            number1 = number2;
            number2 = result;
        }

        return result;
    }

    internal static double GetNature3(int index)
    {
        // f(n-1)+f(n-2)=f(n)(n>=2)

        if (index is 0 or 1)
            return 1;

        return GetNature3(index - 1) + GetNature3(index - 2);
    }

    internal static double GetNature4(int index)
    {
        // 1/√5[((1+√5)/2)^n-((1-√5)/2)^n]=f(n)(n>=0)

        return 1 / Math.Sqrt(5) * (Math.Pow((1 + Math.Sqrt(5)) / 2, index) - Math.Pow((1 - Math.Sqrt(5)) / 2, index));
    }

    internal static double GetFeature1(int index)
    {
        // f(0)+f(1)+f(2)+...+f(n)=f(n+2)-1(n>=0)

        var result = 0.0;

        for (var i = 0; i <= index; i++)
            result += GetNature3(i);

        return result;
    }

    internal static double GetFeature2(int index)
    {
        // f(1)+f(3)+f(5)+...+f(2n-1)=f(2n)(n>=1)

        var result = 0.0;

        for (var i = 1; i <= index; i++)
            result += GetNature3(2 * i - 1);

        return result;
    }

    internal static double GetFeature3(int index)
    {
        // f(2)+f(4)+f(6)+...+f(2n)=f(2n+1)-1(n>=1)

        var result = 0.0;

        for (var i = 1; i <= index; i++)
            result += GetNature3(2 * i);

        return result;
    }

    internal static double GetFeature4(int index)
    {
        // [f(0)]^2+[f(1)]^2+...+[f(n)]^2=f(n)·f(n+1)(n>=0)

        var result = 0.0;

        for (var i = 0; i <= index; i++)
            result += Math.Pow(GetNature3(2 * i), 2);

        return result;
    }

    internal static double GetFeature5(int index)
    {
        // f(0)-f(1)+f(2)-...+(-1)^n·f(n)=(-1)^n·[f(n+1)-f(n)]+1(n>=0)

        var result = 0.0;

        for (var i = 1; i <= index; i++)
            result += Math.Pow(GetNature3(2 * i), 2);

        return result;
    }

    internal static double GetFeature6(int number1, int number2)
    {
        // f(m-1)·f(n-1)+f(m)·f(n)=f(m+n)(m>=1,n>=1)

        return GetNature3(number1 - 1) * GetNature3(number2 - 1);
    }

    internal static double GetFeature7(int number)
    {
        // (-1)^(n-1)+f(n-1)·f(n+1)=[f(n)]^2(n>=1)

        return Math.Pow(-1, number - 1) + GetNature3(number - 1) * GetNature3(number + 1);
    }

    internal static double GetFeature8(int number)
    {
        // [f(n)]^2-[f(n-2)]^2=f(2n-1)(n>=2)

        return Math.Pow(GetNature3(number), 2) + Math.Pow(GetNature3(number - 2), 2);
    }

    internal static double GetFeature9(int number)
    {
        // f(n+2)+f(n-2)=3f(n)(n>=2)

        return GetNature3(number - 2) + GetNature3(number + 2);
    }

    internal static double GetFeature10(int number1, int number2)
    {
        // f(2n-2m-2)[f(2n)+f(2n+2)]=f(2m+2)+f(4n-2m)(n>m>=-1,n>=1)

        return GetNature3(2 * number2 - 2 * number1 - 2) * (GetNature3(2 * number1 + 2) + GetNature3(4 * number2 - 2 * number1));
    }
}