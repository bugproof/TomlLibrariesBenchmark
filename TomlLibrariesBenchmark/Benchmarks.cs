using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Tomlyn;

namespace TomlLibrariesBenchmark
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class Benchmarks
    {
        private string _tomlData;
        
        [GlobalSetup]
        public void Setup()
        {
            _tomlData = @"
# This is a TOML document.

title = ""TOML Example""

[owner]
name = ""Tom Preston-Werner""
dob = 1979-05-27T07:32:00-08:00 # First class dates

[database]
server = ""192.168.1.1""
ports = [ 8000, 8001, 8002 ]
connection_max = 5000
enabled = true

[servers]

  # Indentation (tabs and/or spaces) is allowed but not required
  [servers.alpha]
  ip = ""10.0.0.1""
  dc = ""eqdc10""

  [servers.beta]
  ip = ""10.0.0.2""
  dc = ""eqdc10""

[clients]
data = [ [""gamma"", ""delta""], [1, 2] ]

# Line breaks are OK when inside arrays
hosts = [
  ""alpha"",
  ""omega""
]";
        }

        [Benchmark]
        public object TomlynParse()
        {
            var doc = Tomlyn.Toml.Parse(_tomlData);
            var table = doc.ToModel();
            return table;
        }

        [Benchmark]
        public object TommyParse()
        {
            using var reader = new StringReader(_tomlData);
            var table = Tommy.TOML.Parse(reader);
            return table;
        }

        [Benchmark]
        public object NettParse()
        {
            var table = Nett.Toml.ReadString(_tomlData);
            return table;
        }

        [Benchmark]
        public object TomenParse()
        {
            var table = Tomen.Tomen.ReadString(_tomlData);
            return table;
        }
        
        [Benchmark]
        public object TomletParse()
        {
            return new Tomlet.TomlParser().Parse(_tomlData);
        }
    }
}