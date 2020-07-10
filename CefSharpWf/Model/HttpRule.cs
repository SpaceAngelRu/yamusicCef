using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharpWf.Model
{
    public enum RequestResponce { Request = 0, Response = 1}
    public enum HttpAction { FindReplace = 0, Block = 1 }
    public class HttpRule
    {        
        public string Name { get; set; }
        public bool Active { get; set; }
        public string UrlSearchPattern { get; set; }
        public RequestResponce RequestResponse { get; set; }
        public HttpAction Action { get; set; }
        public string SearchPattern { get; set; }
        public string ReplaceStr { get; set; }
    }
}
