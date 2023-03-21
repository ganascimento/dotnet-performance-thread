namespace Thread.PerformanceTest.Versions
{
    public static class PrimeNumberV4
    {
        public static long PrimesInRange(long start, long end)
        {
            long result = 0;

            Parallel.For(start, end, number =>
            {
                if (IsPrime(number))
                    Interlocked.Increment(ref result);
            });

            return result;
        }

        private static bool IsPrime(long number)
        {
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            for (long divisor = 3; divisor < (number / 2); divisor += 2)
            {
                if (number % divisor == 0)
                    return false;
            }

            return true;
        }
    }
}
