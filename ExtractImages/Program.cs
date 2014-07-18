using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractImages
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running ExtractImages");

            var web = new HtmlWeb();
            HtmlDocument doc = web.Load(@"http://chasingdelicious.com/orange-cream-chocolates/");
            HtmlNodeCollection imageCollection = doc.DocumentNode.SelectNodes(@"//img");
            foreach (HtmlNode imgNode in imageCollection)
            {
                Console.WriteLine("Image found: ");

                HtmlAttribute srcAttribute = imgNode.Attributes["src"];
                Console.WriteLine(srcAttribute.Value);
            }

            var itemCollection =
                doc.DocumentNode.SelectNodes(@"//*[@itemprop='ingredients']");
            foreach (HtmlNode itemNode in itemCollection)
            {
                Console.WriteLine("Item found: ");
                Console.WriteLine(itemNode.InnerText);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
