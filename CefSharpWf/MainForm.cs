using CefSharp;
using CefSharp.WinForms;
using CefSharpWf.ChromeExt;
using CefSharpWf.Model;
using CefSharpWf.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharpWf
{
    public partial class MainForm : Form
    {
        private bool _isCefShutdown = false;
        private const string CACHE_PATH = "cache";
        private const string CONFIG_PATH = "config";
        private const string RULES_FILENAME = "rules.json";

        //private const string START_URL = "https://gisauto.ru/search?q=3087-LF-PCS-MS";
        private const string START_URL = "https://yandex.ru";

        //private ChromiumWebBrowser _chromeBrowser;
        //LifespanHandler _lifespanHandler = new LifespanHandler();

        private List<HttpRule> _httpRules;

        public MainForm()
        {
            InitializeComponent();            

            InitializeChromium();
            Icon = Resources.Browser_chromium;

            LoadConfig();

            createChromeBrowser(this.tabControl.TabPages[0], START_URL);
            edtUrl.Text = START_URL;
            btnBack.Enabled = false;

            btnForward.Enabled = false;
            FormClosing += MainForm_FormClosing;
            tabControl.MouseDown += TabControl_MouseDown;
            
        }



        public void InvokeOnUiThreadIfRequired(Action action)
        {
            if (InvokeRequired)
            {
                BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }


        private void TabControl_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabControl.TabPages.Count; i++)
            {
                Rectangle r = tabControl.GetTabRect(i);
                
                if (e.Button == MouseButtons.Middle && r.Contains(e.Location) && i != 0)
                {
                    this.tabControl.TabPages.RemoveAt(i);
                    break;                    
                }
            }

        }

        private void InitializeChromium()
        {
            string exeLocation = AppDomain.CurrentDomain.BaseDirectory;
            CefSettings cfsettings = new CefSettings
            {
                UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko",
                CachePath = exeLocation + CACHE_PATH,
            };

            cfsettings.SetOffScreenRenderingBestPerformanceArgs();

            cfsettings.CefCommandLineArgs.Add("disable-web-security", "true");

            //cfsettings.CefCommandLineArgs.Add("proxy-bypass-list", tecDocConfig.ProxyBypassList);
            //cfsettings.CefCommandLineArgs.Add("proxy-server", tecDocConfig.ProxyServer);

            if (!Cef.IsInitialized)
                Cef.Initialize(cfsettings);
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!_isCefShutdown && Cef.IsInitialized)
                {
                    CefShutdown();
                }
            }
            finally
            {
                Application.Exit();
            }
        }



        private void _lifespanHandler_onPopup(string url)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                TabPage tab = new TabPage();
                tab.ToolTipText = "Нажмите среднюю кнопку мыши для закрытия вкладки.";
                this.tabControl.Controls.Add(tab);
                createChromeBrowser(tab, url);
                tabControl.SelectTab(tabControl.TabCount - 1);
            });                                    
        }

        private void ChromeBrowser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() => {
                if (sender is ChromiumWebBrowser)
                {
                    var parent = (sender as ChromiumWebBrowser).Parent as TabPage;
                    parent.Text = e.Title;
                }
            });
        }
        //

        private void ChromeBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                this.InvokeOnUiThreadIfRequired(() => {
                    ChromiumWebBrowser chromeBrowser = getCurrentBrowser(tabControl.SelectedTab);
                    if (chromeBrowser == sender)
                    {
                        edtUrl.Text = chromeBrowser.Address;
                        btnBack.Enabled = chromeBrowser.CanGoBack;
                        btnForward.Enabled = chromeBrowser.CanGoForward;
                    }
                });
            };
        }


        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {            
            ChromiumWebBrowser chromeBrowser = getCurrentBrowser(tabControl.SelectedTab);
            if(chromeBrowser != null)
            {
                edtUrl.Text = chromeBrowser.Address;
                btnBack.Enabled = chromeBrowser.CanGoBack;
                btnForward.Enabled = chromeBrowser.CanGoForward;
            }
            else
            {
                edtUrl.Text = "";
                btnBack.Enabled = false;
                btnForward.Enabled = false;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chromeBrowser = getCurrentBrowser(tabControl.SelectedTab);
            if (chromeBrowser != null)
            {               
                if(chromeBrowser.CanGoBack)
                    chromeBrowser.Back();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chromeBrowser = getCurrentBrowser(tabControl.SelectedTab);
            if (chromeBrowser != null)
            {
                if (chromeBrowser.CanGoForward)
                    chromeBrowser.Forward();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Navigate(edtUrl.Text);
        }

        private void edtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(edtUrl.Text);
            }
        }

        private void Navigate(string url)
        {
            if (!String.IsNullOrEmpty(edtUrl.Text))
            {
                ChromiumWebBrowser chromeBrowser = getCurrentBrowser(tabControl.SelectedTab);
                if (chromeBrowser != null)
                {
                    chromeBrowser.Load(url);
                }
            }
        }

        private void createChromeBrowser(TabPage parent, string url)
        {
            ChromiumWebBrowser chromeBrowser = new ChromiumWebBrowser(url);
            chromeBrowser.Parent = parent;            
            chromeBrowser.Dock = DockStyle.Fill;            
            chromeBrowser.LoadingStateChanged += ChromeBrowser_LoadingStateChanged;
            chromeBrowser.TitleChanged += ChromeBrowser_TitleChanged;

            LifespanHandler _lifespanHandler = new LifespanHandler();
            _lifespanHandler.onPopup += _lifespanHandler_onPopup;
            chromeBrowser.LifeSpanHandler = _lifespanHandler;

            chromeBrowser.RequestHandler = new CustomRequestHandler(_httpRules);
        }

        private ChromiumWebBrowser getCurrentBrowser(TabPage tabPage)
        {            
            foreach(var control in tabPage.Controls) {
                if(control is ChromiumWebBrowser)
                {
                    ChromiumWebBrowser res = control as ChromiumWebBrowser;
                    return res;
                }                                      
            }
            return null;
        }

        

        private void CefShutdown()
        {
            _isCefShutdown = true;
            Cef.Shutdown();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            RulesForm rulesForm = new RulesForm();
            rulesForm.Init(_httpRules);
            if (rulesForm.ShowDialog() == DialogResult.OK)
            {
                SaveConfig();
            }
        }

        private void LoadConfig()
        {
            string exeLocation = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(exeLocation, CONFIG_PATH);
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName = Path.Combine(exeLocation, CONFIG_PATH, RULES_FILENAME);
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                _httpRules = HttpRulesConvert.getHttpRules(json);
            }
            else
            {
                _httpRules = new List<HttpRule>();
                string json = HttpRulesConvert.getJson(_httpRules);
                File.WriteAllText(fileName, json);
            }
        }

        private void SaveConfig()
        {
            string exeLocation = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(exeLocation, CONFIG_PATH);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName = Path.Combine(exeLocation, CONFIG_PATH, RULES_FILENAME);
            
            string json = HttpRulesConvert.getJson(_httpRules);
            File.WriteAllText(fileName, json);
        }

        private void btnNewTab_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.ToolTipText = "Нажмите среднюю кнопку мыши для закрытия вкладки.";
            this.tabControl.Controls.Add(tab);
            createChromeBrowser(tab, "");
            tabControl.SelectTab(tabControl.TabCount - 1);
        }        
    }
}
