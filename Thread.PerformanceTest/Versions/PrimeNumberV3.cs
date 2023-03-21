namespace Thread.PerformanceTest.Versions
{
    public static class PrimeNumberV3
    {
        public static long PrimesInRange(long start, long end)
        {
            long result = 0;
            const long chunkSize = 100;
            var completed = 0;
            var chunks = (end - start) / chunkSize;
            var allDone = new ManualResetEvent(initialState: false);

            for (long i = 0; i < chunks; i++)
            {
                var chunkStart = start + i * chunkSize;
                var chunkEnd = i == (chunks - 1) ? end : chunkStart + chunkSize;

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    for (var number = chunkStart; number < chunkEnd; number++)
                    {
                        if (IsPrime(number))
                            Interlocked.Increment(ref result);
                    }

                    if (Interlocked.Increment(ref completed) == chunks)
                        allDone.Set();
                });
            }

            allDone.WaitOne();

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
