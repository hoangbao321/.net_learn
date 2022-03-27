using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class TestOptions
{
    public string opt_key1 { get; set; }
    public Sub_TestOptions opt_key2 { get; set; }
}

public class Sub_TestOptions
{
    public string k1 { get; set; }
    public string k2 { get; set; }
    public string[]  k3 { get; set; }
}