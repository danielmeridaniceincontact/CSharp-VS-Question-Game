using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpVSQuestionGame.CoreModels
{
    public class TriviaGame
    {
        public int response_code { get; set; }
        public List<TriviaData> results { get; set; }
    }
}
