using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiUtility;
using Utilities;

namespace WebApplication.Controllers
{
    // Students must not edit this file

    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            var rng = new Random();
            return "This is the default data";
        }

        [HttpGet("RemovePunctuation")]
        public string RemovePunctuation([FromForm] string data)
        {
            var utilityObject = new Utilities01();
            return utilityObject.RemovePunctuation(data);
        }
        [HttpGet("TextLines")]
        public string TextLines([FromForm] string data, [FromForm] int lineLength)
        {
            var utilityObject = new Utilities01();
            var lines = utilityObject.TextLines(data,lineLength);
            var builder = new StringBuilder();
            foreach(var item in lines)
            {
                builder.AppendLine(item);
            }
            return builder.ToString();
        }
        [HttpGet("WordFrequencies")]
        public string WordFrequencies([FromForm] string data)
        {
            var utilityObject = new Utilities01();
            var lines = utilityObject.WordFrequencies(data);
            var builder = new StringBuilder();
            foreach (var item in lines)
            {
                builder.AppendFormat("{0},{1}", item.Key, item.Value);
                builder.AppendLine();
            }
            return builder.ToString();
        }
        [HttpGet("EmboldenWords")]
        public string EmboldenWords([FromForm] string data, [FromForm] string boldWords)
        {
            var utilityObject = new Utilities01();
            return utilityObject.EmboldenWords(data,boldWords);
        }
        [HttpGet("GetComplexity")]
        public string GetComplexity([FromForm] string data)
        {
            var utilityObject = new Utilities01();
            return utilityObject.GetComplexity(data).ToString();
        }

        [HttpGet("ReverseString")]
        public string ReverseString([FromForm] string data)
        {
            var utilityObject = new Utilities02();
            var output = utilityObject.ReverseString(data);
            return output;
        }
        [HttpGet("LineJustify")]
        public string LineJustify([FromForm] string data, [FromForm] int lineLength)
        {
            var utilityObject = new Utilities02();
            var output = utilityObject.LineJustify(data,lineLength);
            return output;
        }     
        [HttpGet("Italicize")]
        public string Italicize([FromForm] string data)
        {
            var utilityObject = new Utilities02();
            var output = utilityObject.Italicize(data);
            return output;
        }
        [HttpGet("LetterFrequencies")]
        public string LetterFrequencies([FromForm] string data)
        {
            var utilityObject = new Utilities02();
            var lines = utilityObject.LetterFrequencies(data);
            var builder = new StringBuilder();
            foreach (var item in lines)
            {
                builder.AppendFormat("{0},{1}", item.Key, item.Value);
                builder.AppendLine();
            }
            return builder.ToString();
        }
        [HttpGet("GetBigrams")]
        public string GetBigrams([FromForm] string data)
        {
            var utilityObject = new Utilities02();
            var lines = utilityObject.GetBigrams(data);
            var builder = new StringBuilder();
            foreach (var item in lines)
            {
                builder.AppendFormat("{0},{1}", item.Key, item.Value);
                builder.AppendLine();
            }
            return builder.ToString(); ;
        }

        [HttpGet("SortWords")]
        public string SortWords([FromForm] string data)
        {
            var utilityObject = new Utilities03();
            var output = utilityObject.SortWords(data);
            return output;
        }
        [HttpGet("AddHeadings")]
        public string AddHeadings([FromForm] string data)
        {
            var utilityObject = new Utilities03();
            var output = utilityObject.AddHeadings(data);
            return output;
        }
        [HttpGet("GetSentiment")]
        public string GetSentiment([FromForm] string data, [FromForm] string goodWords, [FromForm] string badWords)
        {
            var utilityObject = new Utilities03();
            var output = utilityObject.GetSentiment(data,goodWords,badWords);
            return output.ToString();
        }
        [HttpGet("Sentences")]
        public string Sentences([FromForm] string data)
        {
            var utilityObject = new Utilities03();
            var lines = utilityObject.Sentences(data);
            var builder = new StringBuilder();
            foreach (var item in lines)
            {
                builder.AppendLine(item);
            }
            return builder.ToString();
        }
        [HttpGet("WordLengths")]
        public string WordLengths([FromForm] string data)
        {
            var utilityObject = new Utilities03();
            var lines = utilityObject.WordLengths(data);
            var builder = new StringBuilder();
            foreach (var item in lines)
            {
                builder.AppendFormat("{0},{1}", item.Key, item.Value);
                builder.AppendLine();
            }
            return builder.ToString();
        }


        [HttpGet("ReverseWords")]
        public string ReverseWords([FromForm] string data)
        {
            var utilityObject = new Utilities04();
            var output = utilityObject.ReverseWords(data);
            return output;
        }
        [HttpGet("Translate")]
        public string Translate([FromForm] string data)
        {
            var utilityObject = new Utilities04();
            var output = utilityObject.Translate(data);
            return output;
        }
        [HttpGet("AddParaHtml")]
        public string AddParaHtml([FromForm] string data)
        {
            var utilityObject = new Utilities04();
            var output = utilityObject.AddParaHtml(data);
            return output;
        }
        [HttpGet("Paragraphs")]
        public string Paragraphs([FromForm] string data)
        {
            var utilityObject = new Utilities04();
            var lines = utilityObject.Paragraphs(data);
            var builder = new StringBuilder();
            foreach (var item in lines)
            {
                builder.AppendLine(item);
            }
            return builder.ToString();
        }
        [HttpGet("SentenceLengths")]
        public string SentenceLengths([FromForm] string data)
        {
            var utilityObject = new Utilities04();
            var lines = utilityObject.SentenceLengths(data);
            var builder = new StringBuilder();
            foreach (var item in lines)
            {
                builder.AppendFormat("{0},{1}", item.Key, item.Value);
                builder.AppendLine();
            }
            return builder.ToString();
        }



        [HttpGet("DistinctWords")]
        public string DistinctWords([FromForm] string data)
        {
            var utilityObject = new Utilities05();
            var output = utilityObject.DistinctWords(data);
            return output;
        }
        [HttpGet("LineCentre")]
        public string LineCentre([FromForm] string data, [FromForm] int lineLength)
        {
            var utilityObject = new Utilities05();
            var output = utilityObject.LineCentre(data,lineLength);
            return output;
        }
        [HttpGet("MakeTable")]
        public string MakeTable([FromForm] string dataString, [FromForm] string dataInts)
        {
            Dictionary<string, int> methodData = new Dictionary<string, int>();
            var strings = dataString.Split("|");
            var ints = dataInts.Split("|");
            for(int i=0; i < strings.Count(); i++)
            {
                methodData.Add(strings[i], int.Parse(ints[i]));
            }
            var utilityObject = new Utilities05();
            var output = utilityObject.MakeTable(methodData);
            return output;
        }
        [HttpGet("ProperNouns")]
        public string ProperNouns([FromForm] string data)
        {
            var utilityObject = new Utilities05();
            return utilityObject.ProperNouns(data);
        }
        [HttpGet("FindContext")]
        public string FindContext([FromForm] string data, [FromForm] string targetWords)
        {
            var utilityObject = new Utilities05();
            var lines = utilityObject.FindContext(data,targetWords);
            var builder = new StringBuilder();
            foreach (var item in lines)
            {
                builder.AppendFormat("{0},{1}", item.Key, item.Value);
                builder.AppendLine();
            }
            return builder.ToString();
        }

        #region ExtraUtilities
        [HttpGet("NthSentence")]
        public string NthSentence([FromForm] string data, [FromForm] int n)
        {
            ExtraUtilities util = new ExtraUtilities();
            return util.GetNthSentence(data, n);
        }

        [HttpGet("NthLine")]
        public string NthLine([FromForm] string data, [FromForm] int lineLength, [FromForm] int n)
        {
            ExtraUtilities util = new ExtraUtilities();
            return util.GetNthLine(data,lineLength,n);
        }

        [HttpGet("JustifiedText")]
        public string JustifiedText([FromForm] string data, [FromForm] int lineLength)
        {
            ExtraUtilities util = new ExtraUtilities();
            var temp = util.GetJustifiedText(data, lineLength);
            return temp.Replace("|", Environment.NewLine);
        }

        [HttpGet("HighlightTopWords")]
        public string HighlightTopWords([FromForm] string data, [FromForm] int n)
        {
            ExtraUtilities util = new ExtraUtilities();
            var temp = util.HighlightTopWords(data, n);
            return temp;
        }

        #endregion



    }
}
