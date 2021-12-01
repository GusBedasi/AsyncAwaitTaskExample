# Using async methods more effectively

In this code example we gonna show two different ways to use async methods and how the way you do it so is important

### First method:

In this first example we use the best way for this scenario, because we take advantage of asyncronous method, we ran both method at the same time, gain more effiency

```c#
async Task MainMethod1()
{
    var stopwatch = new Stopwatch();
    
    stopwatch.Start();
    
    // Call both method together
    var act1 = Method1(); // This will take 5 seconds to end
    var act2 = Method2(); // This will take 2 seconds to end

    await act1;
    await act2;
    
    // The time elapsed will be only 5 seconds because Method2 finished within the time of Method1
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
```

### Second method:

In the this example we ran it one after another, so we take all the time each one takes to run e sum it

```c#
async Task MainMethod2()
{
    var stopwatch = new Stopwatch();
    
    stopwatch.Start();
    
    // Call one after another is finished
    await Method1(); // This will take 5 seconds to end
    await Method2(); // This will take 2 seconds to end

    
    // The time elapsed will be 7 seconds because Method2 awaited Method1 finish to do it's job
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
```

### Code running GIF

![Alt Text](https://github.com/GusBedasi/AsyncAwaitTaskExample/blob/main/TestTask/assets/code.gif?raw=true)

As you can see, the first one only took 5s and the second one took 7s.
