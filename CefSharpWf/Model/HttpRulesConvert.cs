using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CefSharpWf.Model
{
    public class HttpRulesConvert
    {
        //public List<HttpRule> rules = new List<HttpRule> ();

        public static string getJson(List<HttpRule> rules)
        {
            string res = JsonConvert.SerializeObject(rules);
            return res;
        }

        public static List<HttpRule> getHttpRules(string json)
        {
            List<HttpRule> res = JsonConvert.DeserializeObject<List<HttpRule>>(json);
            return res;
        }

    }
}
