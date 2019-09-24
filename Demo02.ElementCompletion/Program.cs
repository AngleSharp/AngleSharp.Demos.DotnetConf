using AngleSharp;
using System;
using System.Threading.Tasks;

namespace Demo02.ElementCompletion
{
    class Program
    {
        static async Task Main()
        {
            var source = @"<!DOCTYPE html>
<ul>
<li>First item
<li>Second item
<li>Third item
</ul>
<p>I can just write paragraphs ...
<p>...without ending them?!";

            var context = BrowsingContext.New();
            var document = await context.OpenAsync(res => res
                .Content(source)
                .Address("http://localhost:1234/demo02"));

            Console.WriteLine(document.ToHtml());
            Console.ReadKey();
        }
    }
}
