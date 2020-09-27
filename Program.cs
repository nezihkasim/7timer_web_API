using System;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace final_q3
{
    /*
    public class Location
    {
        public List<weathers> data { get; set;}
    }*/

    public class weather
    {
        public int cloudcover { get; set; }
        public int timepoint { get; set; }
        public int seeing { get; set; }
        public int transparency { get; set; }
        public int lifted_index { get; set; }
        public int rh2m { get; set; }
        public string direction { get; set; }
        public int speed { get; set; }
        public int temp2m { get; set; }
        public string prec_type { get; set; }
    }


    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Type Longitude: ");
            double longitude = double.Parse(Console.ReadLine());
            Console.WriteLine("\nType Latitude: ");
            double latitude = double.Parse(Console.ReadLine());       //  INPUTS FROM USER FOR LONGITUDE AND LATITUDE VALUES


            string requestURL = "http://www.7timer.info/bin/astro.php?lon=" + longitude.ToString() + "&lat=" + latitude.ToString() + "&ac=0&unit=metric&output=json&tzshift=0";    // LINK STRING CREATION ACCORDING TO LONG. LAT. VALUES IN

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestURL);         // WEB REQUEST
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();   // WEB RESPONSE

            Stream receiveStream = response.GetResponseStream();            // STORING THE RESPONSE IN A STREAM
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);       // DEFINITION OF STREAMREADER TO ENCODE STREAM AND TO CONVERT STRING

            string json = await readStream.ReadToEndAsync();        // JSON DATA TO STRING

            JObject jsonObj = JObject.Parse(json);          // PARSING JSON STRING TO OBJECT

            IList<JToken> dataseries = jsonObj["dataseries"].Children().ToList();      // PARSING JSON OBJECTS WITH ITS CHILDREN TO A JTOKEN LIST
            IList<weather> weathers = new List<weather>();      // A LIST OF WEATHER CLASS 
            foreach (JToken data in dataseries)
            {
                weather dataweather = data.ToObject<weather>();     // DATA ASSIGNING TO WEATHERS
                weathers.Add(dataweather);
            }
            foreach (var item in weathers)
            {
                Console.WriteLine($"Timepoint: {item.timepoint}\nCloud Cover: {item.cloudcover}\nSeeing: {item.seeing}\nTransparency: {item.transparency}\nLifted Index: {item.lifted_index}\nrh2m: {item.rh2m}\nWind Direction: {item.direction}\nWind Speed: {item.speed}\nTemp2m: {item.temp2m}\nPrecipitation Type: {item.prec_type}\n\n\n");
            }
            //Console.WriteLine();









            //List<Newtonsoft.Json.Linq.JObject> jObjectList = new List<Newtonsoft.Json.Linq.JObject>;
            //Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(readStream.ReadLine());
            //Console.WriteLine((string)jObject["dataseries"][0]["timepoint"]);
            //receiveStream.Close();



            /*
            string json = await readStream.ReadToEndAsync();
            var comic = JsonSerializer.Deserialize<MyModel>(json);               //  ORIGINAL
            Console.WriteLine(comic.title);
            Console.WriteLine(comic.img);
            */




            //List<weathers> weatherList = new List<weathers>();

            //weatherList = JsonSerializer.Deserialize<weathers>(json);
            //weatherList.Add(JsonSerializer.Deserialize<weathers>(json));
            /*
            Console.WriteLine(weatherList[0].timepoint.ToString());
            Console.WriteLine(weatherList[0].cloudcover.ToString());
            Console.WriteLine(weatherList[0].seeing.ToString());
            Console.WriteLine(weatherList[0].transparency.ToString());
            Console.WriteLine(weatherList[0].lifted_index.ToString());
            Console.WriteLine(weatherList[0].rh2m.ToString());
            Console.WriteLine(weatherList[0].wind_direction);
            Console.WriteLine(weatherList[0].wind_speed.ToString());
            Console.WriteLine(weatherList[0].temp2m.ToString());
            Console.WriteLine(weatherList[0].prec_type);  */


        }
    }
}
