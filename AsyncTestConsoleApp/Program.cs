using System.Diagnostics;
using AsyncTestConsoleApp;

var cancellationToken = new CancellationToken();

var stopwatch = Stopwatch.StartNew();
stopwatch.Start();
var integerNotParallel = await AsyncClass.WillWaitAndReturnInt(5, cancellationToken);
var textNotParallel = await AsyncClass.WillWaitAndReturnString(2, cancellationToken);
Console.WriteLine($"Here are results for non parallels. Integer:{integerNotParallel}, Text: {textNotParallel} .");
stopwatch.Stop();
var notParallelTimeSpan = stopwatch.Elapsed;

stopwatch.Restart();
var task1 = AsyncClass.WillWaitAndReturnInt(5, cancellationToken);
var task2 = AsyncClass.WillWaitAndReturnString(2, cancellationToken);
await Task.WhenAll(task1, task2);
var integerParallel = await task1;
var textParallel = await task2;
Console.WriteLine($"Here are results for parallels. Integer:{integerParallel}, Text: {textParallel} .");
stopwatch.Stop();
var parallelTimeSpan = stopwatch.Elapsed;

Console.WriteLine("Here comes results.");
Console.WriteLine($"Non Parallel methods took {notParallelTimeSpan.TotalSeconds} seconds");
Console.WriteLine($"Parallel methods took {parallelTimeSpan.TotalSeconds} seconds");
Console.WriteLine("That's all folks!");