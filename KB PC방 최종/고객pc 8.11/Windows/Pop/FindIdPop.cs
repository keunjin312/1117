using Player_pc.Manager;
using System;
using System.Data;
using System.Windows.Forms;

namespace Player_pc.Windows.Pop {
    public partial class FindIdPop : Form {
        public FindIdPop() {
            InitializeComponent();
        }         

        private void Fid_btn_Click(object sender, EventArgs e) {
            string _addmb_name = FidTBox_name.Text;
            string _addmb_ph = FidTBox_ph.Text;
           
            DataRow _row = App.Self().DBManager.ReadMember_byid1(_addmb_name, _addmb_ph);
            if (_row != null) {MessageBox.Show(String.Format("아이디는 {0} 입니다.", _row[0]));
                FidTBox_name.Enabled = true;                
            }
            else {
                MessageBox.Show("회원정보가 없습니다.");
                FidTBox_name.Focus(); FidTBox_name.SelectAll();
                return;
            }
        }
    }
}
