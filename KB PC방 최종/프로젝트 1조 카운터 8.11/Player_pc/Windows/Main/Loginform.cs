using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Player_pc.Windows.Pop;
using Lib.Util;
using Lib.DB;
using BookPro.Manager;
using System.Xml.Linq;

namespace Player_pc {
    public partial class Loginform : Form {
        IniAssist m_iniAssist;
        public string Addr { get { return Convert.ToString("192.168.0.208"); } }
        public int Port { get { return Convert.ToInt32(1521); } }
        public string Id { get { return Convert.ToString("pc"); } }
        public string Pwd { get { return Convert.ToString("kb603"); } }
        public string Database { get { return Convert.ToString("xe"); } }

        public Loginform() {
            DBconnect();
            InitializeComponent();
        }


        private void DBconnect() {            
            //19접속테스트하기
            OracleAssist _OracleAssist = new OracleAssist(Addr, Port, Id, Pwd, Database);
            bool _Success = _OracleAssist.TestConnection();
            if (_Success) {
                MessageBox.Show("오라클 접속성공");
            }
            else {
                MessageBox.Show("오라클 접속실패");
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            //20
            //MessageBox.Show(App.Self().db_addr);
            
            string _login_id = Log_tbox_id.Text;
            string _login_pwd = Log_tbox_pw.Text;
            DataTable _db_member = App.Self().DBManager.ReadMember(_login_id, _login_pwd);
            if (_db_member != null) {
                if (_db_member.Rows.Count > 0) {
                    DataRow _row = _db_member.Rows[0];
                    string _id = Convert.ToString(_row["mb_id"]);
                    string _name = Convert.ToString(_row["mb_name"]);
                    DateTime _regdate = Convert.ToDateTime(_row["mb_regdate"]);
                    string _gender = Convert.ToString(_row["mb_gender"]);
                    int _chk_pwd = Convert.ToInt32(_row["chk_pwd"]);
                    int _chk_retiredate = Convert.ToInt32(_row["chk_retiredate"]);
                    int _chk_work_state = Convert.ToInt32(_row["chk_work_state"]);
                    if (_chk_pwd != 1) { MessageBox.Show("비밀번호가 틀립니다."); }                    
                    else {
                        MessageBox.Show($"{_name}님 로그인 하셨습니다.");
                        //28세션정보저장뒤 App 보관하기
                        App.Self().SessionManager.Login(_name, _id, 1);

                        DialogResult = DialogResult.OK;
                    }
                }
                else {
                    MessageBox.Show("해당아이디는 없습니다.");
                }
            
        }

        private void Log_join_btn_Click(object sender, EventArgs e) {
            JoinPop _pop = new JoinPop();
            if (_pop.ShowDialog(this) == DialogResult.OK) {

            }
        }

        private void Log_find_id_Click(object sender, EventArgs e) {
            FindIdPop _pop = new FindIdPop();
            if (_pop.ShowDialog(this) == DialogResult.OK) {

            }
        }

        private void Log_find_pw_Click(object sender, EventArgs e) {
            FindPwPop _pop = new FindPwPop();
            if (_pop.ShowDialog(this) == DialogResult.OK) {

            }
        }
    }
}
