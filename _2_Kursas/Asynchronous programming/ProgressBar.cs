namespace Asynchronous_programming
{
    internal class ProgressBar
    {
        public int Progress = 0; 

        public async Task ProgressBarFillerAsync()
        {
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(100);
                Progress++;
            }
        }

        public async Task PrintProgressAsync()
        {
            while (Progress < 100)
            {
                Console.Clear();
                Console.WriteLine($"Progress: {Progress}%");
                await Task.Delay(300);
            }
            Console.Clear();
            Console.WriteLine($"Progress: {Progress}%");
        }
    }
}
