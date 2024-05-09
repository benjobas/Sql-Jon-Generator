using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string canlayon = "false";
        int ydim = 1;   
        int xdim = 1;
        int defaultdir = 0;
        int rentofferid = -1;
        int revision = 59005;
        int specialtype = 0;
        int n = 430000557;   //Your starting furniture number

        using (StreamWriter w = new StreamWriter("furnis.txt", true)) // Change the name to your .txt 
        {
            foreach (string filename in Directory.GetFiles(@"C:\your\absolute\path")) // Your Absolute Path to nitro you want to add
            {
                string f = Path.GetFileNameWithoutExtension(filename);

                Dictionary<string, object> x = new Dictionary<string, object>
                {
                    { "id", n },
                    { "classname", f },
                    { "revision", revision },
                    { "category", "unknown" },
                    { "defaultdir", defaultdir },
                    { "xdim", xdim },
                    { "ydim", ydim },
                    { "partcolors", new Dictionary<string, object> { { "color", new List<object>() } } },
                    { "name", f },
                    { "description", f },
                    { "adurl", "" },
                    { "offerid", n },
                    { "buyout", "false" },
                    { "rentofferid", rentofferid },
                    { "rentbuyout", "false" },
                    { "bc", "false" },
                    { "excludeddynamic", "false" },
                    { "customparams", "" },
                    { "specialtype", specialtype },
                    { "canstandon", "false" },
                    { "cansiton", "false" },
                    { "canlayon", canlayon },
                    { "furniline", "" },
                    { "environment", "" },
                    { "rare", "false" }
                };

                string y = Newtonsoft.Json.JsonConvert.SerializeObject(x);
                w.Write(y.Replace("\"false\"", "false").Replace(" ", "").Replace("\"rare\":false}", "\"rare\":false},"));
                w.Write("\n"); 
                n++;
            }
        }
    }
}
