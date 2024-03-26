```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
AMD Ryzen 9 7950X3D, 1 CPU, 32 logical and 16 physical cores
.NET SDK 8.0.103
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
```


| Method      | Mean      | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|------------ |----------:|----------:|----------:|-------:|-------:|----------:|
| TommyParse  |  7.329 us | 0.0792 us | 0.0741 us | 0.3128 |      - |  15.67 KB |
| TomlynParse | 27.086 us | 0.2190 us | 0.1942 us | 1.0376 | 0.1221 |  51.47 KB |
| NettParse   | 35.401 us | 0.3405 us | 0.3019 us | 2.7466 | 0.1221 | 136.81 KB |
| TomletParse | 63.994 us | 0.7469 us | 0.6987 us | 0.8545 |      - |  44.23 KB |
