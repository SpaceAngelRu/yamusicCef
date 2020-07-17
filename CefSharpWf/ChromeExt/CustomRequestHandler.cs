using CefSharp;
using CefSharp.Handler;
using CefSharp.ResponseFilter;
using CefSharpWf.ChromeExt.Filters;
using CefSharpWf.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CefSharpWf.ChromeExt
{
    public class CustomResourceRequestHandler : ResourceRequestHandler
    {
        private MemoryStream memoryStream;
        private List<HttpRule> _httpRules { get; set; }

        public CustomResourceRequestHandler(List<HttpRule> rules)
        {
            _httpRules = rules;
        }

        protected override CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            foreach(HttpRule rule in _httpRules)
            {
                // Request - block
                if(rule.Active && rule.RequestResponse == RequestResponce.Request  && rule.Action == HttpAction.Block)
                {
                    Match match = Regex.Match(request.Url, rule.UrlSearchPattern, RegexOptions.IgnoreCase);
                    if(match.Success)
                    {
                        return CefReturnValue.Cancel;
                    }
                }
                // Request - change POST body
                if (rule.Active && rule.RequestResponse == RequestResponce.Request && rule.Action == HttpAction.FindReplace)
                {
                    Match match = Regex.Match(request.Url, rule.UrlSearchPattern, RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        if (!callback.IsDisposed)
                        {
                            using (callback)
                            {
                                if (request.Method == "POST")
                                {
                                    using (var postData = request.PostData)
                                    {
                                        if (postData != null)
                                        {
                                            var elements = postData.Elements;

                                            var charSet = request.GetCharSet();

                                            foreach (var element in elements)
                                            {
                                                if (element.Type == PostDataElementType.Bytes)
                                                {
                                                    var body = element.GetBody(charSet);

                                                    Console.WriteLine($"==POSTPOSTPOST=====================================================================POSTPOSTPOST==\n" +
                                                                      $"{body}" +
                                                                      $"==POSTPOSTPOST=====================================================================POSTPOSTPOST==\n");

                                                    body = Regex.Replace(body, rule.SearchPattern, rule.ReplaceStr, RegexOptions.IgnoreCase);
                                                    element.Bytes = Encoding.UTF8.GetBytes(body);

                                                    return CefReturnValue.Continue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }                        
                    }
                }
            }                
            return CefReturnValue.Continue;
        }       

        protected override IResponseFilter GetResourceResponseFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            var url = new Uri(request.Url);
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            foreach (HttpRule rule in _httpRules)
            {
                if (rule.Active && rule.RequestResponse == RequestResponce.Response && rule.Action == HttpAction.FindReplace)
                {
                    Match match = Regex.Match(request.Url, rule.UrlSearchPattern, RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        list.Add(new KeyValuePair<string, string>(rule.SearchPattern, rule.ReplaceStr)); 
                    }
                }
            }            
            if(list.Count > 0)
            {
                return new RexExpResponseFilter(list);
            }
            return null;
        }        

        protected override void Dispose()
        {
            memoryStream?.Dispose();
            memoryStream = null;

            base.Dispose();
        }
    }

    

    public class CustomRequestHandler : RequestHandler
    {
        private List<HttpRule> _httpRules { get; set; }

        public CustomRequestHandler(List<HttpRule> rules)
        {
            _httpRules = rules;
        }
        protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            return new CustomResourceRequestHandler(_httpRules);           
        }

    }


}
