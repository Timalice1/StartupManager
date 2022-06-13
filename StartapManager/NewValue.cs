using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartapManager {
    public partial class NewValue : Form {
        public NewValue() {
            InitializeComponent();
        }

        public string Name { get; private set; }
        public string Path { get; private set; }

        private void btnOk_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(tbName.Text))
                    throw new Exception("Enter the name");
                if (string.IsNullOrEmpty(tbPath.Text))
                    throw new Exception("Enter the path to .exe file");
                
                Name = tbName.Text;
                Path = tbPath.Text;

                DialogResult = DialogResult.OK;
                this.Close();
            }catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExplore_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog() {
                Filter = "| *.exe"
            };
            
            ofd.ShowDialog();
            tbPath.Text = ofd.FileName;
        }

        private void btnHelp_Click(object sender, EventArgs e) {
            MessageBox.Show("Select path to .exe file for required app");
        }
    }
}
