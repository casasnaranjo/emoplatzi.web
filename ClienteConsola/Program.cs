using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            metodo();
            Console.ReadLine();
        }

        static async void metodo()
        {
            while(Console.ReadLine()!="1")
            {
                try
                {

                    string URI = "http://localhost:38107/api/EmoUploaderAPI";
                  

                    var httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.TransferEncodingChunked = true;

                    var content = new MultipartFormDataContent();
                    var imageContent = new StreamContent(new FileStream("c:/3.jpg", FileMode.Open, FileAccess.Read, FileShare.Read));
                    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                    content.Add(imageContent, "3", "c:/3.jpg");

                    var Respuesta=await httpClient.PostAsync(URI, content);
                    // var Respuesta = await httpclient.GetAsync(URI);
                    Respuesta.EnsureSuccessStatusCode();
                    var contenido = await Respuesta.Content.ReadAsStringAsync();
                    Console.WriteLine("respuesta get a" + URI + "" + Environment.NewLine + (contenido.Replace("{", Environment.NewLine + "\t{")).Replace("[", "[" + Environment.NewLine + "\t\t "));
                    Console.WriteLine("Programa para obtener Post API");

                    Console.ReadLine();

                }
                catch (HttpRequestException hre)
                {
                    string Text = hre.ToString();

                }

                catch (Exception EX)
                {
                    string Text = EX.ToString();

                }
            }

        } 
    }
}
