using CefSharpWf.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharpWf
{
    public partial class RuleForm : Form
    {
        public HttpRule Rule { get; set; }

        public RuleForm()
        {
            InitializeComponent();
        }

        public void Init(HttpRule rule)
        {
            Rule = rule;

            edtName.Text = rule.Name;
            chbActive.Checked = rule.Active;
            edtUrlSearchPattern.Text = rule.UrlSearchPattern;
            cbRequestResponse.Items.Add("Request");
            cbRequestResponse.Items.Add("Response");
            cbRequestResponse.SelectedIndex = (int)rule.RequestResponse;                                   
            if (rule.RequestResponse == RequestResponce.Request)
            {
                cbRequestResponse.SelectedIndex = (int)rule.Action;
                cbAction.Items.Add("Поиск/замена");
                cbAction.Items.Add("Блокировать");                
                if(rule.Action == HttpAction.Block)
                {
                    cbAction.SelectedIndex = (int)rule.Action;
                    edtSearchPattern.Text = "";
                    edtReplaceStr.Text = "";
                    edtSearchPattern.Enabled = false;
                    edtReplaceStr.Enabled = false;
                }
                else
                {
                    cbAction.SelectedIndex = (int)rule.Action;
                    edtSearchPattern.Text = rule.SearchPattern;
                    edtReplaceStr.Text = rule.ReplaceStr;
                    edtSearchPattern.Enabled = true;
                    edtReplaceStr.Enabled = true;
                }
            }
            else
            {
                cbRequestResponse.SelectedIndex = (int)rule.Action;
                cbAction.Items.Add("Поиск/замена");
                cbAction.SelectedIndex = (int)rule.Action;
                edtSearchPattern.Text = rule.SearchPattern;
                edtReplaceStr.Text = rule.ReplaceStr;
                edtSearchPattern.Enabled = true;
                edtReplaceStr.Enabled = true;
            }
            cbRequestResponse.SelectedIndexChanged += cbRequestResponse_SelectedIndexChanged;
            cbAction.SelectedIndexChanged += cbAction_SelectedIndexChanged;
        }

        private void cbRequestResponse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAction.Items.Clear();
            if (cbRequestResponse.SelectedIndex == (int)RequestResponce.Request)
            {
                cbAction.Items.Add("Поиск/замена");
                cbAction.Items.Add("Блокировать");
                Rule.RequestResponse = RequestResponce.Request;
            }
            else
            {
                cbAction.Items.Add("Поиск/замена");                
                Rule.RequestResponse = RequestResponce.Response;
            }
            edtSearchPattern.Enabled = true;
            edtReplaceStr.Enabled = true;
        }

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAction.SelectedIndex == (int)HttpAction.Block)
            {
                edtSearchPattern.Enabled = false;
                edtReplaceStr.Enabled = false;
                edtSearchPattern.Text = "";
                edtReplaceStr.Text = "";
                Rule.Action = HttpAction.Block;
            }
            else
            {
                edtSearchPattern.Enabled = true;
                edtReplaceStr.Enabled = true;
                Rule.Action = HttpAction.FindReplace;
            }
        }

        private void edtName_TextChanged(object sender, EventArgs e)
        {
            Rule.Name = edtName.Text;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Rule.Active = chbActive.Checked;
        }

        private void edtUrlSearchPattern_TextChanged(object sender, EventArgs e)
        {
            Rule.UrlSearchPattern = edtUrlSearchPattern.Text;
        }

        private void edtSearchPattern_TextChanged(object sender, EventArgs e)
        {
            Rule.SearchPattern = edtSearchPattern.Text;
        }

        private void edtReplaceStr_TextChanged(object sender, EventArgs e)
        {
            Rule.ReplaceStr = edtReplaceStr.Text;
        }
    }
}
