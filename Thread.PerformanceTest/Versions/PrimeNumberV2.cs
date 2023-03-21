namespace Thread.PerformanceTest.Versions
{
    public static class PrimeNumberV2
    {
        public static long PrimesInRange(long start, long end)
        {
            long result = 0;
            var lockObject = new object();

            var range = end - start;
            var numberOfThreads = (long)Environment.ProcessorCount;

            var threads = new System.Threading.Thread[numberOfThreads];
            var chunkSize = range / numberOfThreads;

            for (var i = 0; i < numberOfThreads; i++)
            {
                var chunkStart = start + i * chunkSize;
                var chunkEnd = i == (numberOfThreads - 1) ? end : chunkStart + chunkSize;

                threads[i] = new System.Threading.Thread(() =>
                {
                    for (var number = chunkStart; number < chunkEnd; number++)
                    {
                        if (IsPrime(number))
                        {
                            lock (lockObject)
                            {
                                result++;
                            }
                        }
                    }
                });

                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

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
