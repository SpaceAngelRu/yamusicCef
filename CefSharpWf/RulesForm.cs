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
    public partial class RulesForm : Form
    {
        public List<HttpRule> httpRules = new List<HttpRule>();

        public RulesForm()
        {
            InitializeComponent();
            lvRules.FullRowSelect = true;
            lvRules.MultiSelect = false;
            lvRules.SelectedIndexChanged += lvRules_SelectedIndexChanged;
            btnDelete.Enabled = lvRules.SelectedItems.Count > 0;
            btnEdit.Enabled = lvRules.SelectedItems.Count > 0;
        }

        public void Init(List<HttpRule> rules)
        {
            httpRules = rules;
            UpdateListView(httpRules);
        }

        private void lvRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = lvRules.SelectedItems.Count > 0;
            btnEdit.Enabled = lvRules.SelectedItems.Count > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RuleForm form = new RuleForm();
            HttpRule rule = new HttpRule()
            {
                Name = "Новое правило",
                Active = true,
                RequestResponse = RequestResponce.Request,
                Action = HttpAction.FindReplace,
                UrlSearchPattern = "Шаблон Url",
                SearchPattern = "Шаблон поиска",
                ReplaceStr = "строка для замены"
            };
            form.Init(rule);
            if (form.ShowDialog() == DialogResult.OK)
            {
                httpRules.Add(rule);
                UpdateListView(httpRules);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(lvRules.SelectedItems.Count > 0)
            {
                int index = (int)lvRules.SelectedItems[0].Tag;
                if (index < lvRules.Items.Count)
                {
                    RuleForm form = new RuleForm();
                    HttpRule rule = httpRules[index];
                    form.Init(rule);
                    if (form.ShowDialog() == DialogResult.OK)
                    {                        
                        UpdateListView(httpRules);
                    }
                }
            }                        
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvRules.SelectedItems.Count > 0)
            {
                int index = (int)lvRules.SelectedItems[0].Tag;
                if (index < lvRules.Items.Count)
                {
                    DialogResult result = MessageBox.Show("Удалить правило?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {

                        httpRules.RemoveAt(index);
                        UpdateListView(httpRules);
                    }
                }
            }                        
        }

        private void UpdateListView(List<HttpRule> rules)
        {
            lvRules.Items.Clear();
            foreach (HttpRule rule in rules)
            {
                ListViewItem lvi = lvRules.Items.Add(rule.Name);

                lvi.Tag = httpRules.IndexOf(rule);

                lvi.SubItems.Add(rule.Active.ToString());
                lvi.SubItems.Add(rule.RequestResponse.ToString());
                lvi.SubItems.Add(rule.UrlSearchPattern);
                lvi.SubItems.Add(rule.Action.ToString());
                lvi.SubItems.Add(rule.SearchPattern);
                lvi.SubItems.Add(rule.ReplaceStr);
                ColorListItem(lvi, rule.Active);
            }
        }

        private ListViewItem GetItemByTag(ListView listView, int tag)
        {
            foreach (ListViewItem li in listView.Items)
            {
                if ((int)li.Tag == tag)
                {
                    return li;
                }
            }
            return null;
        }

        private void ColorListItem(ListViewItem lvi, bool flag)
        {
            if (flag)
            {
                lvi.ForeColor = Color.Red;
            }
            else
            {
                lvi.ForeColor = Color.Black;
            }
        }

        private void lvRules_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
