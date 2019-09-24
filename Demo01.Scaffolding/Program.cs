using AngleSharp;
using System;
using System.Threading.Tasks;

namespace Demo01.Scaffolding
{
    class Program
    {
        static async Task Main()
        {
            var source = @"<!DOCTYPE html>
<meta charset=utf-8>
<title>Sample Document</title>
<style>/* ... */</style>
<div id=app>Hello World!</div>
<script src=""app.js""></script>";

            var context = BrowsingContext.New();
            var document = await context.OpenAsync(res => res
                .Content(source)
                .Address("http://localhost:1234/demo01"));

            Console.WriteLine(document.ToHtml());
            Console.ReadKey();
        }
    }
}
