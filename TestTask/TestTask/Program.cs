// See https://aka.ms/new-console-template for more information

using System;
using System.Diagnostics;
using System.Threading.Tasks;

async Task MainMethod1()
{
    var stopwatch = new Stopwatch();
    
    stopwatch.Start();
    
    // Call both method together
    var act1 = Method1(); // This will take 5 seconds to end
    var act2 = Method2(); // This will take 2 seconds to end

    await act1;
    await act2;
    
    // The time elapsed will be only 5 seconds because Method2 finished with the time of Method1
    Console.WriteLine(stopwatch.Elapsed); 
    stopwatch.Stop();
}

async Task MainMethod2()
{
    var stopwatch = new Stopwatch();
    
    stopwatch.Start();
    
    // Call one after another is finished
    await Method1(); // This will take 5 seconds to end
    await Method2(); // This will take 2 seconds to end

    
    // The time elapsed will be 7 seconds because Method2 awaited Method1 finish it's to job to start
    Console.WriteLine(stopwatch.Elapsed); 
    stopwatch.Stop();
}

async Task Method1()
{
    Console.WriteLine("Start method 1");
    await Task.Delay(5000);
    Console.WriteLine("End method 1");
}

async Task Method2()
{
    Console.WriteLine("Start method 2");
    await Task.Delay(2000);
    Console.WriteLine("End Method 2");
}

Console.WriteLine("Example 1");
await MainMethod1();
Console.WriteLine();
Console.WriteLine("=============================================================");
Console.WriteLine();
Console.WriteLine("Example 2");
await MainMethod2();