namespace Test_cases.JaggedSort
{
    public abstract class SumOfElements
    {
        protected double Sum(int[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
