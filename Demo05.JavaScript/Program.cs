using AngleSharp;
using System;
using System.Threading.Tasks;

namespace Demo05.JavaScript
{
    class Program
    {
        static async Task Main()
        {
            var source = @"<!DOCTYPE html>
<title>Sample</title>
<script>
document.title = 'Simple manipulation...';
document.write('<span class=greeting>Hello World!</span>');
</script>";

            var configuration = Configuration
                .Default
                .WithJs();

            var context = BrowsingContext.New(configuration);
            var document = await context.OpenAsync(res => res
                .Content(source)
                .Address("http://localhost:1234/demo05"));

            Console.WriteLine(document.ToHtml());
            Console.ReadKey();
        }
    }
}
