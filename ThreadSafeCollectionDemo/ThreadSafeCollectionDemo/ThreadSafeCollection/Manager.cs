using System.Collections.Concurrent;

namespace ThreadSafeCollection
{
    public class Manager
    {
        private ConcurrentBag<int> values = new();
        private int lower = 0;
        private int upper = 0;
        private int length = 1;
        public Manager(int lower, int upper, int length)
        {
            this.lower = lower;
            this.upper = upper;
            this.length = length;
        }
        public void Generate()
        {
            values.Clear();
            int numbers = (upper - lower + 1);
            int chunks = numbers / length + (numbers % length == 0 ? 0 : 1);

            //creating helpers which will be joined in generating integers in a list
            List<Helper> helpers = new List<Helper>();
            int begin = lower;
            int end = lower + length - 1;
            for (int k = 1; k <= chunks; k++)
            {
                if (end > upper) end = upper;
                helpers.Add(new Helper(begin, end));
                begin = end + 1;
                end = begin + length - 1;
            }

            //every helper will asynchronously call the method GenerateTo()
            List<Task> tasks = new List<Task>();
            helpers.ForEach(helper =>
            {
                tasks.Add(Task.Run(() => { helper.GenerateTo(values); }));
            });

            //Waiting for all helpers to complete their tasks
            Task.WaitAll(tasks.ToArray());
        }
        public ConcurrentBag<int> Values => values;
    }
}