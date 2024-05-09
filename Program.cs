using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Net.Http;




namespace GeneradorToken
{
    class Program
    {

        public static void Main()
        {
            // Your code here!

            const string API_LOGIN_DEV = "";
            const string API_KEY_DEV = "";

            string server_application_code = API_LOGIN_DEV;
            string server_app_key = API_KEY_DEV;
            //long unix_timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            var unix_timestamp = Convert.ToString((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            
            string uniq_token_string = server_app_key + unix_timestamp;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(uniq_token_string));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                string uniq_token_hash = builder.ToString();
                string auth_token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{server_application_code};{unix_timestamp};{uniq_token_hash}"));

                //Console.WriteLine($"TIMESTAMP: {unix_timestamp}");
                //Console.WriteLine($"UNIQTOKENST: {uniq_token_string}");
                //Console.WriteLine($"UNIQTOHAS: {uniq_token_hash}");
                Console.WriteLine($"AUTHTOKEN: {auth_token}");
            }

            Console.ReadKey();
        }

        //static HttpListener listener = new HttpListener();
        //static HttpClient client = new HttpClient();
        //static async Task Main(string[] args)
        //{
        //    // Define la URL del webhook
        //    string url = "http://localhost/WebHook/";

        //    // Define los datos que se enviarán en la solicitud
        //    string body = "Datos de la solicitud";
        //    string contentType = "application/json";

        //    // Crea la solicitud HTTP POST
        //    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
        //    request.Content = new StringContent(body, System.Text.Encoding.UTF8, contentType);

        //    // Envía la solicitud al webhook
        //    HttpResponseMessage response = await client.SendAsync(request);

        //    // Verifica si la respuesta es exitosa
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine("Webhook enviado con éxito");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error al enviar el webhook: {0}", response.StatusCode);
        //    }
        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    // Define la URL donde el webhook recibirá las solicitudes
        //    string url = "http://localhost:8080/webhook/";

        //    // Agrega la URL al listener
        //    listener.Prefixes.Add(url);
        //    listener.Start();

        //    Console.WriteLine("Esperando solicitudes en {0}", url);

        //    while (true)
        //    {
        //        // Espera la solicitud entrante
        //        HttpListenerContext context = listener.GetContext();

        //        // Obtiene los datos de la solicitud
        //        string body = new StreamReader(context.Request.InputStream).ReadToEnd();
        //        string contentType = context.Request.ContentType;

        //        // Realiza la acción necesaria con los datos recibidos
        //        ProcesarWebhook(body);

        //        // Envía una respuesta al remitente
        //        byte[] buffer = Encoding.UTF8.GetBytes("Webhook recibido con éxito");
        //        context.Response.ContentLength64 = buffer.Length;
        //        context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        //        context.Response.OutputStream.Close();
        //    }
        //}

        //static void ProcesarWebhook(string body)
        //{
        //    // Realiza aquí la acción necesaria con los datos recibidos
        //}



        // //const string api_login = "TPP - EC - SERVER";
        // //const string api_key = "mYmEhYuLxNkCZrw8FkFVTeZxx4rfY9";

        // const string api_login = "Application Code Server";
        // const string api_key = "Application Key Server";
        // const string source = "Application Key Server1679321259";

        // static void Main(string[] args)
        // {
        //     var unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        //     var x = token();
        //     Console.WriteLine("TIMESTAMP: {0}", x.unixTimestamp);
        //     Console.WriteLine("UNIQTOKENST: {0}", x.uniq_token_string);
        //     Console.WriteLine("UNIQTOHAS: {0}", x.uniq_token_hash);
        //     Console.WriteLine("AUTHTOKEN: {0}", x.auth_token);
        //     Console.ReadLine();
        // }
        // static TokenC token()
        // {
        //     var server_application_code = api_login;
        //     SHA256 sha256 = SHA256Managed.Create();

        //     //var unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        //     //var unixTimestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
        //     var unixTimestamp = 1679321259;
        //     var uniq_token_string = api_key + unixTimestamp;


        //     var uniq_token_hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(uniq_token_string));
        //     var sBuilder = new StringBuilder();
        //     foreach (var item in uniq_token_hash)
        //     {
        //         sBuilder.Append(item.ToString("x2"));
        //     }

        //     var bytesConc = Encoding.UTF8.GetBytes(server_application_code + ";" + unixTimestamp + ";" + sBuilder);
        //     var base64 = Convert.ToBase64String(bytesConc);

        //     var obj = new TokenC { unixTimestamp = unixTimestamp.ToString(), uniq_token_string = uniq_token_string, uniq_token_hash = sBuilder.ToString(), auth_token = base64 };

        //     return obj;
        // }

        //public class TokenC
        // {
        //     public string auth_token;
        //     public string uniq_token_hash;
        //     public string uniq_token_string;
        //     public string unixTimestamp;

        // }
    }
}
