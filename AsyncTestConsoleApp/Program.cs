using System.Diagnostics;
using AsyncTestConsoleApp;

var cancellationToken = new CancellationToken();

var stopwatch = Stopwatch.StartNew();
stopwatch.Start();
var integerNotParallel = await AsyncClass.WillWaitAndReturnInt(5, cancellationToken);
var textNotParallel = await AsyncClass.WillWaitAndReturnString(2, cancellationToken);
Console.WriteLine($"Here are results for non parallels. Integer:{integerNotParallel}, Text: {textNotParallel} .");
stopwatch.Stop();
var fakeAsyncTimeSpan = stopwatch.Elapsed;

stopwatch.Restart();
var task1 = AsyncClass.WillWaitAndReturnInt(5, cancellationToken);
var task2 = AsyncClass.WillWaitAndReturnString(2, cancellationToken);
await Task.WhenAll(task1, task2);
var integerParallel = await task1;
var textParallel = await task2;
Console.WriteLine($"Here are results for non parallels. Integer:{integerParallel}, Text: {textParallel} .");
stopwatch.Stop();
var trulyAsyncTimeSpan = stopwatch.Elapsed;

Console.WriteLine("Here comes results.");
Console.WriteLine($"FakeAsync methods took {fakeAsyncTimeSpan.TotalSeconds} seconds");
Console.WriteLine($"TrulyAsync methods took {trulyAsyncTimeSpan.TotalSeconds} seconds");
Console.WriteLine("That's all folks!");