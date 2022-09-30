``` ini

BenchmarkDotNet=v0.13.2, OS=arch 
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.109
  [Host]     : .NET 6.0.9 (6.0.922.46401), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.9 (6.0.922.46401), X64 RyuJIT AVX2


```
| Method |     Mean |    Error |   StdDev |
|------- |---------:|---------:|---------:|
| Sha256 | 20.81 μs | 0.393 μs | 0.483 μs |
|    Md5 | 13.08 μs | 0.036 μs | 0.030 μs |
