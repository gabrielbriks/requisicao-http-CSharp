using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace AppRequestHTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            // Create a request for the URL.   
            HttpWebRequest request = (HttpWebRequest)WebRequest.CreateHttp("https://api.github.com/users/gabrielbriks");
            request.Method = "GET";
            request.UserAgent = "RequisicaoWebDemo";

            using (var resposta = request.GetResponse())
            {
                
                var streamDados = resposta.GetResponseStream();
                
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var resp = objResponse.ToString();

                Usuario user = new Usuario();

                user = JsonConvert.DeserializeObject<Usuario>(resp);
                //dynamic result = JsonConvert.DeserializeObject(resp);                
                //Console.WriteLine(result.login);
                //Console.WriteLine(result.id);

                Console.WriteLine(user.id);
                Console.WriteLine(user.login);

                
                //Console.WriteLine(resultJSON);
                Console.ReadLine();
                streamDados.Close();
                resposta.Close();
            }
            

            

        }
    }

    public class Usuario{

        public string id { get; set; }
        public string login { get; set; }
        
    }
}
