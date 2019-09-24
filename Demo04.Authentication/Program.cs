using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Demo04.Authentication
{
    class Program
    {
        static async Task Main()
        {
            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var cookieLocation = Path.Combine(documentsFolder, "demo.cookie");

            var configuration = Configuration
                .Default
                .WithPersistentCookies(cookieLocation)
                .WithRequesters()
                .WithDefaultLoader();

            var context = BrowsingContext.New(configuration);
            var document = await context.OpenAsync("http://localhost:8000");

            PrintState(document, "Initial");

            if (document.QuerySelector(".login") is IHtmlAnchorElement login)
            {
                document = await login.NavigateAsync();

                PrintState(document, "Login");

                document = await document.Forms.FirstOrDefault()?.SubmitAsync(new
                {
                    user = "bruce",
                    pass = "wayne",
                });

                PrintState(document, "Logged in");
            }

            Console.ReadKey();
        }

        static void PrintState(IDocument document, string state)
        {
            Console.WriteLine(string.Empty.PadRight(20, '='));
            Console.WriteLine(state);
            Console.WriteLine(string.Empty.PadRight(20, '='));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(document?.ToHtml());
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
