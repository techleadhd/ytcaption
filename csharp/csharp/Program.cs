using csharp.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string youtubeURL = args.Length > 0 ? args[0].ToString() : "https://www.youtube.com/watch?v=r7SO-Oq3d5E&t=12s";
            var sourceCodeOfYoutubePage = GetPageSourceCode(youtubeURL);
            var urlOfTimedText = GetTimedTextURL(sourceCodeOfYoutubePage);
            var sourceCodeOfTimedTextPage = GetPageSourceCode(urlOfTimedText);
            XmlDocument document = new XmlDocument();
            document.LoadXml(sourceCodeOfTimedTextPage);
            string jsonText = JsonConvert.SerializeXmlNode(document);
            Root textTranscriptContainer = JsonConvert.DeserializeObject<Root>(jsonText);

            string script = string.Empty;
            foreach (var textContainer in textTranscriptContainer.Transcript.TextContainer)
            {
                script += WebUtility.HtmlDecode(textContainer.Text) + " ";
            }
            Console.WriteLine(script);
            Console.ReadLine();

        }
        private static string GetPageSourceCode(string url)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string pageSourceCode = string.Empty;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (string.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                pageSourceCode = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            return pageSourceCode;
        }

        private static string GetTimedTextURL(string sourceCode)
        {
            return "https://www.youtube.com/api/timedtext" + BetweenStrings(sourceCode, "https://www.youtube.com/api/timedtext", "\"").Replace("\\u0026", "&") + "&kind=asr&lang=en";
        }

        public static string BetweenStrings(string text, string start, string end)
        {
            int p1 = text.IndexOf(start) + start.Length;
            int p2 = text.IndexOf(end, p1);
            if (end == "") return (text.Substring(p1));
            else return text.Substring(p1, p2 - p1);
        }
    }
}
