``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i5-7400 CPU 3.00GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


```
|               Method |         Mean |      Error |     StdDev |
|--------------------- |-------------:|-----------:|-----------:|
| FindInArrayByIndexOf | 23,942.41 ns | 318.515 ns | 297.939 ns |
|          FindInArray |  5,750.30 ns |  25.636 ns |  22.725 ns |
|        FindInHashSet |     21.29 ns |   0.138 ns |   0.122 ns |
