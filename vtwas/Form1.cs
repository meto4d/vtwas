using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vtwas
{
    public partial class vtwas : Form
    {

        private ClipboardViewer.MyClipboardViewer clipViewer;

        public vtwas()
        {
            InitializeComponent();
            CharCodeComboBox.SelectedIndex = 0;

            LoadSetting();

            this.Name = vtwasay.AppName + "/" + vtwasay.Version;
            this.Text = this.Name;
            dataGridView.Rows.Add("", "");
            ClipEventCheckBox.Enabled = ClipboardEnableCheckBox.Checked;

            // クリップボード監視イベント
            clipViewer = new ClipboardViewer.MyClipboardViewer(this);
            clipViewer.ClipboardHandler += new ClipboardViewer.cbEventHandler(this.OnClipBoardChanged);

        }


        private void vtwas_Load(object sender, EventArgs e)
        {

        }

        private void vtwas_Closing(object sender, FormClosingEventArgs e)
        {


            SaveSetting();
        }

        private void LoadSetting()
        {
            vtwasay.LoadSetting();

            URLtextBox.Text = vtwasay.url;
            TokenKeytextBox.Text = vtwasay.key;
            TokenPasstextBox.Text = vtwasay.pass;
            var code = vtwasay.charcode;
            if (CharCodeComboBox.Items.Contains(code))
            {
                CharCodeComboBox.SelectedIndex = CharCodeComboBox.Items.IndexOf(code);
            }
            else
                CharCodeComboBox.SelectedIndex = 0;

            ClipboardEnableCheckBox.Checked = vtwasay.enableclip;

            foreach(var par in vtwasay.param_list)
            {
                dataGridView.Rows.Add(par.param, par.text);
            }

            this.Location = new Point(vtwasay.form.X, vtwasay.form.Y);
            this.Size = new Size(vtwasay.form.W, vtwasay.form.H);

        }

        private void SaveSetting()
        {
            vtwasay.url = URLtextBox.Text;
            vtwasay.key = TokenKeytextBox.Text;
            vtwasay.pass = TokenPasstextBox.Text;
            vtwasay.charcode = (string)CharCodeComboBox.SelectedItem;
            vtwasay.enableclip = ClipboardEnableCheckBox.Checked;
            vtwasay.param_list.Clear();
            for(int index = 0; index < dataGridView.Rows.Count; index++)
            {
                vtwasay.Params par;
                DataGridViewCellCollection cell = dataGridView.Rows[index].Cells;
                par.param = (string)cell[0].Value;
                par.text = (string)cell[1].Value;
                vtwasay.param_list.Add(par);
            }

            vtwasay.form.X = this.Location.X;
            vtwasay.form.Y = this.Location.Y;
            vtwasay.form.W = this.Size.Width;
            vtwasay.form.H = this.Size.Height;

            vtwasay.SaveSetting();
        }

        private void TokenShowCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            TokenShowCheckBox.Text =
                TokenShowCheckBox.Checked ? "非表示" : "表示";
            TokenKeytextBox.PasswordChar = 
                TokenShowCheckBox.Checked ? '\0' : '*';
            TokenPasstextBox.PasswordChar =
                TokenShowCheckBox.Checked ? '\0' : '*';

        }

        private void AddListButton_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Add("", "");
        }

        private void RemoveListButton_Click(object sender, EventArgs e)
        {
            int index = dataGridView.Rows.Count;
            if(index > 0)
                dataGridView.Rows.RemoveAt(index - 1);
        }

        private void TestRunButton_Click(object sender, EventArgs e)
        {
            SaveSetting();

            TestRun();
        }

        private void TestRun()
        {
            System.IO.Stream st;
            string status = "";

#if DEBUG
            string wav = "newinfo.wav";
            vtwasay.StreamPlayTst(wav);
#endif

            st = vtwasay.GetStream(out status);

            StatusLabel.Text = status;

            if(status == "200" && st != null)
            {
                vtwasay.StreamPlay(st);
            }

            if (st != null) st.Close();
        }

        private void SettingSaveButton_Click(object sender, EventArgs e)
        {
            SaveSetting();
        }

        private void ClipboardEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ClipEventCheckBox.Enabled = ClipboardEnableCheckBox.Checked;
        }

        private void ClipEventCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool check = !ClipEventCheckBox.Checked;
            URLtextBox.Enabled =              check;
            TokenKeytextBox.Enabled =         check;
            TokenPasstextBox.Enabled =        check;
            CharCodeComboBox.Enabled =        check;
            AddListButton.Enabled =           check;
            RemoveListButton.Enabled =        check;
            dataGridView.Enabled =            check;
            ClipboardEnableCheckBox.Enabled = check;


        }

        // クリップボード変更時
        private void OnClipBoardChanged(object sender, ClipboardViewer.ClipboardEventArgs e)
        {
            if(ClipEventCheckBox.Checked && e.Text != "")
            {
#if DEBUG
                System.Diagnostics.Trace.WriteLine("Clip:" + e.Text);
#endif

                string status;
                vtwasay.AutoGetPlay(out status, e.Text);
                this.StatusLabel.Text = status;
            }
        }
    }
}
