using System.Diagnostics;
using System.Numerics;
/*
layers
1     2        3           4   ...   n

                           7
                           6
               5         5 5
               4         4 4
      3      3 3       3 3 3
      2      2 2       2 2 2
1   1 1    1 1 1     1 1 1 1

                     7 5 4 3
           5 4 3     5 4 3 3
    3 2    3 2 2     3 2 2 2
1   1 1    1 1 1     1 1 1 1

1   2          3           4          n
*   *          *           *          *
1   2          3           4          n
=   =          =           =          =
1   2          9          16        n^2

*/
class Program
{
    /// <summary>
    ///Constant time O(1) calculation of the sum of all odd numbers in the 
    ///sequence from 1 to n. Extremely efficient when working with large numbers
    ///(in my tests, with a value greater than 100,000).
    /// </summary>
    /// <param name="number">n</param>
    /// <returns>the sum of all odd numbers in the sequence</returns>
    public static BigInteger SumOddSequence(long number)
    {
        if (number == 0)
        {
            return 0;
        }
        else if (number > 0)
        {
            BigInteger layersCount = number % 2 == 0 ? number >> 1 : (number >> 1) + 1;
            return layersCount * layersCount;
        }
        else
        {
            number *= -1;
            BigInteger layersCount = number % 2 == 0 ? number >> 1 : (number >> 1) + 1;
            return layersCount * layersCount * -1;
        }
    }

    /// <summary>
    /// A loop with time complexity O(n) can be used to calculate the sum of all odd 
    /// numbers in the sequence from 1 to n. This method is suitable for smaller values of n.
    /// </summary>
    /// <param name="number">n</param>
    /// <returns>the sum of all odd numbers in the sequence</returns>
    public static BigInteger Proof(long number)
    {
        BigInteger proof = 0;
        if (number == 0)
        {
            return BigInteger.Zero;
        }
        else if (number > 0)
        {
            if (number % 2 == 0) number--;
            for (int i = 1; i <= number; i += 2)
            {
                proof += i;
            }
            return proof;
        }
        else
        {
            number = number *= -1;
            if (number % 2 == 0) number--;
            for (int i = 1; i <= number; i += 2)
            {
                proof += i;
            }
            return proof * -1;
        }
    }
    static void Main()
    {
        while (true)
        {
            Console.WriteLine($"Input any number from {long.MinValue} to {long.MaxValue} to calculate. Input any letter to break");
            if (long.TryParse(Console.ReadLine(), out long number))
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Console.WriteLine($"Sum of all odd numbers from 0 to {number}: {SumOddSequence(number)}");
                stopwatch.Stop(); Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds} ms\n");

                Console.WriteLine("Proof the calculatin with cycle method? y/n");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        stopwatch.Restart();
                        Console.WriteLine($"\nProofing calculation via cycle: {Proof(number)}");
                        stopwatch.Stop(); Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds} ms\n");
                        break;
                    default: Console.WriteLine(); break;
                }

            }
            else break;
        }
    }
}