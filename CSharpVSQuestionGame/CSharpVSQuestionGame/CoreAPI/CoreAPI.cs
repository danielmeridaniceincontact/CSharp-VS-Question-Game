using CSharpVSQuestionGame.CoreModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharpVSQuestionGame.CoreAPI
{
    public static class CoreAPI
    {
        private static readonly string urlAPI = @"https://opentdb.com/api.php?amount=10&category=18&difficulty=medium&type=multiple";

        public static TriviaGame GetTriviaGame()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAPI);

            using HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            using Stream stream = response.GetResponseStream();
            using StreamReader reader = new(stream, Encoding.ASCII);
            string responseString = reader.ReadToEnd();            

            TriviaGame triviaGame = JsonConvert.DeserializeObject<TriviaGame>(responseString);

            return triviaGame;
        }
    }
}
