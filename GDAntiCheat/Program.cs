using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Globalization;

namespace GDAntiCheat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started! Loading data...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var set = new HashSet<string>()
            {
                "8uViTwfQvisalVWhwSz/pA==",
                "Q5GVhlo7YfXcVtQjGttKVQ==",
                "OjaKo3kOqtA7NxXOzffmHA==",
                "+xGOJD4ha4Szg4My2o9WZQ==",
                "T1Q79Yu/SBEmpVb8jWQkFQ==",
                "rDFvEdcw0UaSDywEr98BTw==",
                "sgUMEDETd7g7J46VFNf9+g==",
                "XlXeAl5Zn3tLyn8I6IFrWQ==",
                "tiDxa1vnka3nPsOVx+wbUw==",
                "XYHckDUv2NV8C9YeaPqq8g==",
                "m6G1nMPbkGZPbuipI1z6xA==",
                "ZsCvfojIjfjMX5smSoEDMg==",
                "nuiTT+ks62k5wI3BMmu1qg==",
                "s/ujQl0aocgJB4sKBdRfBQ==",
                "kaGi8BQyvUkgEaHUyBp6WA==",
                "2a+KO6V3UynEn6r1z7hKyg==",
                "cK96AUffhJ+4QziCspQp3A==",
                "134IEUt1rqhrtSxySyGJfg==",
                "UoKd+6PtXd3mCca9gyeYog==",
                "3nuR+rWBO5/8YQ9YId2iNQ==",
                "IzY70JJG/fMU+OkNOCHULQ==",
                "fCrakvLa/NB9eNaBZCheFw==",
                "ph0qdIPSI8xLo0eqtdXjVw==",
                "2JKhZDLSR1gdRZmcFPNKnw==",
                "RaGmdF+f/a7QRVVYh3r6HA==",
                "4pxWZkR/2p+jYDAN169s/A==",
                "zumdu8qBuM71o/KDFFZxEw==",
                "21ELAS/Wrs6n8nDMHydWew==",
                "oXzWj8okX6rlU0A7Mw0cAg==",
                "p5L4QK84WpQ9qK3HoBLR1Q==",
                "xdt7cS8oDDrk9zGtfV6hcQ==",
                "XfJyYrT7a0Slp10WBMOhJw==",
                "978v6Q8VYV0XxH+r57jvxA==",
                "oxXNjot81YGEE4Vx1W4WeQ==",
                "b/IWcIUVqUQi5rjfalYk2w==",
                "NEfCL0P08E+P0BfvDIifRA==",
                "HBOTWu/5TSRzl4SCZEzFmQ==",
                "rH2BLsiL1wlkCeHbNChN9w==",
                "55VpZMYpwgxiDNfuxNDhsQ==",
                "vRE4Cxeqjqmc0npROWJmRQ==",
                "Au9S5pLlxxb8Vk9BIpLJkg==",
                "j3LqTtxSSi0N99iDVsyQpA==",
                "+aMgTteA0VgxNQRDsrLnGw==",
                "i3+Slx8pldSE93e1odKW8A==",
                "ToZMpfpqwjVN1PFg1lecgg==",
                "Z/GSX+s2Z8Sc21O+LvOHYg==",
                "dWErDUrSKGwY5F1Nmc9FuA==",
                "SDkRpl7fsdM5+4a8M4jEdw==",
                "gLu8qt6X+Y09Sun0AgQ8DQ==",
                "jsTZSY74zZiBD44Cym/DOw==",
                "5Q27iK7h3QoIz9zR4DaSzQ==",
                "eXaWEJskSnCDrBaZt9HiIA==",
                "r/0mvxhpFaMiGKhVl25mlw==",
                "7rRHKMv9bXA73WziFv7r8g==",
                "F/HaSi0Bw8zWZ9pUcv9hSg==",
                "4PV/gyBR+2ZO5wTRiwDbrg==",
                "VgGj7oqPI7CT43IEedWykw==",
                "YdO00hlYeMPdwhiKG1jsSg==",
                "YMl/iWA5PVY0EF39hLLhcA=="
            };

            var utcdate = DateTime.UtcNow;
            Console.WriteLine("Session time: " + utcdate);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine("Finished loading in " + elapsedMs + "ms" + "! This program will now perfrom checking every 10 seconds.");
            Console.WriteLine("------------------");
            while (true)
            {
                Console.WriteLine("Checking all running processes...");
                var allproc = Process.GetProcesses();
                var numberOfGDInstances = 0;
                int nProcessID = Process.GetCurrentProcess().Id;
                foreach (Process proc in allproc)
                {
                    var name = proc.ProcessName;
                    try
                    {
                        var path = proc.MainModule.FileName;
                        var size = new System.IO.FileInfo(path).Length;
                        if (size < 10000000)
                        {
                            var md5 = MD5.Create();
                            var stream = File.OpenRead(path);
                            var hash = Convert.ToBase64String(md5.ComputeHash(stream));

                            if (!set.Contains(hash))
                            {
                                Console.WriteLine(name);
                                try
                                {

                                    Console.WriteLine(name);
                                    Console.WriteLine(hash);
                                    proc.Kill();
                                }
                                catch
                                {
                                    Console.WriteLine("Cannot kill " + name + ". Maybe access is denied.");
                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                }
                if(numberOfGDInstances == 0)
                {
                    Console.WriteLine("Geometry Dash is not running.");
                }
                Console.WriteLine("Done!");
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}