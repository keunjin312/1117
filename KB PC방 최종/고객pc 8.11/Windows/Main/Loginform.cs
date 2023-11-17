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
using Player_pc.Manager;
using System.Data.OracleClient;


namespace Player_pc {
    public partial class Loginform : Form {
        IniAssist m_iniAssist;
        public string Addr { get { return Convert.ToString("192.168.0.208"); } }
        public int Port { get { return Convert.ToInt32(1521); } }
        public string Id { get { return Convert.ToString("pc"); } }
        public string Pwd { get { return Convert.ToString("kb603"); } }
        public string Database { get { return Convert.ToString("xe"); } }
               
        public string MbrName ;
        public int MbrMatchPwd;
        public int MbrReMainMinute;
        public Loginform() {
            //DBconnect();
            InitializeComponent();
            App.Self().DBManager = new DBManager();
            App.Self().DBManager.SetConnectInfo(Addr, Port,Id,Pwd,Database);
        }
        
        private void button4_Click(object sender, EventArgs e) {
            string _login_id = Log_tbox_id.Text;
            string _login_pwd = Log_tbox_pw.Text;
            DataTable _db_member = App.Self().DBManager.ReadMember(_login_id, _login_pwd);
            if (_db_member != null) {
                if (_db_member.Rows.Count > 0) {
                    DataRow _row = _db_member.Rows[0];
                    App.Self().mb_ID = Convert.ToString(_row["mb_id"]);
                    MbrName = Convert.ToString(_row["mb_name"]);
                    MbrMatchPwd = Convert.ToInt32(_row["chk_pwd"]);
                    MbrReMainMinute = Convert.ToInt32(_row["mb_remain_minute"]);
                    if (MbrMatchPwd != 1) { MessageBox.Show("비밀번호가 틀립니다."); }
                    else {
                        DataRow _db_seat = App.Self().DBManager.ReadCheckMember(_login_id);
                        if (_db_seat == null) {
                            MessageBox.Show($"{MbrName}님 로그인 하셨습니다.");

                        DialogResult = DialogResult.OK;

                        }
                        else { MessageBox.Show($"{MbrName}님 이미 로그인 되어있습니다."); }
                    }                                                        
                }
                else {
                    MessageBox.Show("해당아이디는 없습니다.");
                }
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
