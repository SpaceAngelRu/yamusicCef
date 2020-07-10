using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharpWf.ChromeExt
{
    public class LifespanHandler : ILifeSpanHandler
    {
        
        public event Action<string> onPopup;
        bool ILifeSpanHandler.OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {            
            if (this.onPopup != null)
                this.onPopup(targetUrl);
            
            newBrowser = null;
            return true;
        }
        bool ILifeSpanHandler.DoClose(IWebBrowser browserControl, IBrowser browser)
        { return false; }

        void ILifeSpanHandler.OnBeforeClose(IWebBrowser browserControl, IBrowser browser) { }

        void ILifeSpanHandler.OnAfterCreated(IWebBrowser browserControl, IBrowser browser) { }
    }
}
