using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable LocalizableElement

namespace ClientApplication {
    public partial class FrmMain : Form {
        public FrmMain() {
            this.InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            // Make some calls
            this.textBox1.Text += $"Pinging interactor: {Program.Interactor.GetHelloFromInteractor("Console Application")}\r\n";
            this.textBox1.Text += $"Pinging interactor: {Program.Interactor.GetHelloFromInteractorPlugin("Console Application")}\r\n";
            this.textBox1.Text += $"Pinging interactor: {Program.Interactor.GetHelloFromDataStore("Console Application")}\r\n";
        }
    }
}
