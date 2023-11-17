using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player_pc.Windows.Pop {
    public partial class FindPwPop : Form {
        public FindPwPop() {
            InitializeComponent();
        }
        private void ptbn_close_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }
    }
}
