using System.Diagnostics;
using AsyncTestConsoleApp;

var cancellationToken = new CancellationToken();

var stopwatch = Stopwatch.StartNew();
stopwatch.Start();
await AsyncClass.WillSitAndWaitForSomeTime(5, cancellationToken);
await AsyncClass.WillSitAndWaitForSomeTime(2, cancellationToken);
stopwatch.Stop();
var fakeAsyncTimeSpan = stopwatch.Elapsed;

stopwatch.Restart();
var task1 = AsyncClass.WillSitAndWaitForSomeTime(5, cancellationToken);
var task2 = AsyncClass.WillSitAndWaitForSomeTime(2, cancellationToken);
await Task.WhenAll(task1, task2);
stopwatch.Stop();
var trulyAsyncTimeSpan = stopwatch.Elapsed;

Console.WriteLine("Here comes results.");
Console.WriteLine($"FakeAsync methods took {fakeAsyncTimeSpan.TotalSeconds} seconds");
Console.WriteLine($"TrulyAsync methods took {trulyAsyncTimeSpan.TotalSeconds} seconds");
Console.WriteLine("That's all folks!");