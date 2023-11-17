using Player_pc.Manager;
using System;
using System.Data;
using System.Windows.Forms;

namespace Player_pc.Windows.Pop {
    public partial class JoinPop : Form {
        public JoinPop() {
            InitializeComponent();
        }

        private void jbtn_double_check_Click(object sender, EventArgs e) {

            string _admb_id = Join_tbox_id.Text;

            DataRow _row = App.Self().DBManager.ReadMember_byid(_admb_id);
            if (_row != null) {
                MessageBox.Show(String.Format("{0}는(은) 사용중인 아이디입니다.", _admb_id));
                Join_tbox_id.Focus(); Join_tbox_id.SelectAll();
                return;
            }
            else {
                MessageBox.Show(String.Format("사용가능한 아이디입니다.", _admb_id));
                jbtn_join.Enabled = true;
            }

        }


        private void jbtn_join_Click(object sender, EventArgs e) {

            string _addmb_name = Join_tbox_name.Text;
            string _addmb_id = Join_tbox_id.Text;
            string _addmb_pw = Join_tbox_pw.Text;
            string _addmb_ph = Join_tbox_ph.Text;
            DateTime _addmb_birthdate = Join_tbox_birth.Value;

            DataRow _row = App.Self().DBManager.ReadMember_byid2(_addmb_name, _addmb_ph, _addmb_birthdate);
            //이름, 휴대폰, 생일이 같은 회원이 있는지 검색
            if (_row != null) { //검색결과 있음
                MessageBox.Show(String.Format("이미 존재하는 회원입니다.", _addmb_name, _addmb_ph, _addmb_birthdate));
                Join_tbox_id.Focus(); Join_tbox_id.SelectAll();
                return;
            }
            else { //검색결과 없음
                string _msg = string.Format("가입하시겠습니까?");
                if (MessageBox.Show(_msg, "가입", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    int _result = App.Self().DBManager.Addmember(_addmb_name,
                        _addmb_id, _addmb_pw, _addmb_ph, _addmb_birthdate);
                    if (_result > 0) {
                        MessageBox.Show($"{_addmb_name}님 환영합니다");
                        //MBM_add_member.
                        DialogResult = DialogResult.Cancel;
                    }
                    else {
                        MessageBox.Show("가입실패");
                    }
                }
            }
        }
    }

    
 }
