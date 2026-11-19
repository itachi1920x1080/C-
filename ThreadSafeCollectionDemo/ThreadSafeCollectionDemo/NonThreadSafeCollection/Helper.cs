namespace NonThreadSafeCollection
{
    public class Helper
    {
        private int lower;
        private int upper;
        public Helper(int lower, int upper)
        {
            this.lower = lower;
            this.upper = upper;
        }
        public void SafeGenerateTo(List<int> values)
        {
            {
                for (int value = lower; value <= upper; value++)
                {
                    lock (values) { values.Add(value); }                    
                }
            }
        }
        public void UnsafeGenerateTo(List<int> values)
        {
            for (int value = lower; value <= upper; value++)
            {
                values.Add(value);
            }
            
        }
    }
}
