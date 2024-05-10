using System.Diagnostics;

namespace Text_Editor
{
    public partial class frm_Main : Form
    {
        StreamReader sreader;
        StreamWriter swriter;

        #region /// File saving Function ///
        public void saveFile()
        {
            String txtsave = "";
            saveFileDialog1.Filter = "Text File(*.txt)|*.txt|All File(*.*)|*.*";
            saveFileDialog1.InitialDirectory = @"d:\";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                swriter = new StreamWriter(saveFileDialog1.FileName);
                txtsave = txtEdit.Text.ToString();
                swriter.Write(txtsave);
                swriter.Dispose();
            }
        }
        #endregion

        #region /// File Opening Function ///
        public void openFile()
        {
            string txtopen = "";
            openFileDialog1.Filter = "Text File(*.txt)|*.txt|All File(*.*)|*.*";
            openFileDialog1.InitialDirectory = @"d:\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = openFileDialog1.FileName + " - Notepad";
                sreader = new StreamReader(openFileDialog1.FileName.ToString());
                txtopen = sreader.ReadToEnd();
                txtEdit.Text = txtopen;
                sreader.Dispose();
            }
        }
        #endregion

        public frm_Main()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtEdit.Text.ToString() == "")
            {
                txtEdit.Clear();
            }
            else
            {
                if (MessageBox.Show("There is file that have not saved yet. Do you want to save?", "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveFile();
                    txtEdit.Clear();
                }

            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font font = fontDialog1.Font;
                this.txtEdit.Font = font;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", "https://en.wikipedia.org/wiki/Windows_Notepad");
        }
    }
}
