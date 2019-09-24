using AngleSharp;
using System;
using System.Threading.Tasks;

namespace Demo03.Tables
{
    class Program
    {
        static async Task Main()
        {
            var source = @"<!DOCTYPE html>
<table>
  <tr><br></invalid-tag>
    <th>One</th>
    <td>Two</td>
  </tr>
  <iframe></iframe>
</table>
<tr></tr><div></div>";

            var context = BrowsingContext.New();
            var document = await context.OpenAsync(res => res
                .Content(source)
                .Address("http://localhost:1234/demo03"));

            Console.WriteLine(document.ToHtml());
            Console.ReadKey();
        }
    }
}
