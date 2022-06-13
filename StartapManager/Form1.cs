using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace StartapManager {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

        private void Form1_Load(object sender, EventArgs e) {
            Update();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (listBox1.SelectedItem == null)
                    throw new Exception("Select item first");

                var name = listBox1.SelectedItem.ToString();

                var res = MessageBox.Show($"You realy want to delete \"{name}\" from Startup Applications?", "Delete", MessageBoxButtons.OKCancel);

                if (res == DialogResult.OK) {
                    key.DeleteValue(name);
                    Update();
                    MessageBox.Show($"{name} deleted from Startup Apps");
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private new void Update() {
            listBox1.Items.Clear();
            foreach (var name in key.GetValueNames())
                listBox1.Items.Add(name);
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            try {
                var add = new NewValue();
                var res = add.ShowDialog();

                if (res == DialogResult.OK) {
                    key.SetValue(add.Name, add.Path);
                    Update();
                    MessageBox.Show($"{add.Name} successfully added!");
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
