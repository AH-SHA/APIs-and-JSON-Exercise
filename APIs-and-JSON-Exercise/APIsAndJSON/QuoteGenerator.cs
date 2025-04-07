using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class QuoteGenerator
    {

        //This method is 'static' which allows you to just call the name of the method in the main program, instead of creating a constructor first
        public static void KanyeQuote()
        {
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest";

            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();



            Console.WriteLine("----------");
            Console.WriteLine($"Kanye: '{kanyeQuote}'");
            Console.WriteLine("----------");

        }


        public static void RonQuote()
        {
            var client = new HttpClient();

            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var ronResponse = client.GetStringAsync(ronURL).Result;

            //Parse the response you get back from the API/website
            //We use JArray here below and JObject above in the kanye Response
            //Use JArray because the website is sending us back an array format.  
            //** Always check the API and the format it is returning to you

            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            Console.WriteLine("----------");
            Console.WriteLine($"Ron:  {ronQuote}"); 
            Console.WriteLine("----------");

        }



    }
}
