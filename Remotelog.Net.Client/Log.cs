using System;
using System.Net;
using System.Threading;
using System.Web;

namespace Remotelog.Net.Client
{
    public class Log
    {
        public static void Write(string text)
        {
            Write(text, string.Empty, string.Empty);
        }

        public static void Write(string text, string type)
        {
            Write(text, type, string.Empty);
        }

        public static void Write(string text, string type, string person)
        {
            // wrap all log logic in try/catch, we don't want this exploding on us
            try
            {
                LogConfig config = LogConfig.GetConfig();

                if (string.IsNullOrEmpty(text))
                    return;

                text = HttpUtility.UrlEncode(text);
                type = HttpUtility.UrlEncode(type);
                person = HttpUtility.UrlEncode(person);

                ThreadStart ths = (delegate()
                {
                    WebClient client = new WebClient();
                    string url = string.Format("/write?log={0}&text={1}&type={2}&person={3}",
                        config.Name,
                        text,
                        type,
                        person);
                    Uri uri = new Uri(config.Endpoint.TrimEnd('/') + url);
                    client.DownloadString(uri);
                });

                ths.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    } 
}
