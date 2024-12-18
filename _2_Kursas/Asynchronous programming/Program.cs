namespace Asynchronous_programming
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var progressBar = new ProgressBar();

            Task fillerTask = progressBar.ProgressBarFillerAsync();
            Task printTask = progressBar.PrintProgressAsync();

            await Task.WhenAll(fillerTask, printTask);
        }
    }
}
