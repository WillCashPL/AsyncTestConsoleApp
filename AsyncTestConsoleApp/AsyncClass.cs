namespace AsyncTestConsoleApp;

public class AsyncClass
{
    public static async Task WillSitAndWaitForSomeTime(int seconds, CancellationToken token)
    {
        Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}] Async method will wait for: {seconds} s");
        await Task.Delay(seconds*1000,token);
        Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}] Done, let's go.");
    }
}