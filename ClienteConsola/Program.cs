using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
                    var httpclient = new HttpClient();
                    string URI = "http://localhost:38107/api/EmoUploaderAPI";
                    var filestream = File.OpenRead("c:/3.jpg");
                    StreamContent Contenido = new StreamContent(filestream);

                    //ntenido.Headers.ContentDisposition.FileName = filestream.Name;
                    var Respuesta = await httpclient.PostAsync(URI, Contenido);
                    // var Respuesta = await httpclient.GetAsync(URI);
                    Respuesta.EnsureSuccessStatusCode();
                    var contenido = await Respuesta.Content.ReadAsStringAsync();
                    Console.WriteLine("respuesta get a" + URI + "" + Environment.NewLine + (contenido.Replace("{", Environment.NewLine + "\t{")).Replace("[", "[" + Environment.NewLine + "\t\t "));
                    Console.WriteLine("Programa para obtener Post API");
                    filestream.Close();
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
