using System;
using System.Windows.Forms;
using Lib.Util;
using Lib.DB;

namespace PC.Windows.mainPC {
    public partial class SetupPop : Form {
        IniAssist m_iniAssist;
       
        public string Addr { get { return this.tbox_addr.Text; } }
        public int Port { get { return Convert.ToInt32(this.tbox_port.Text); } }
        public string Id { get { return this.tbox_id.Text; } }
        public string Pwd { get { return this.tbox_pwd.Text; } }
        public string Database { get { return this.tbox_database.Text; } }
        public SetupPop() {
            InitializeComponent();
            CreateObject();
            InitObject();
        }
        private void CreateObject() {
            m_iniAssist = new IniAssist();
        }
        private void InitObject() {
            //16 현재폴더 + ini파일명
            m_iniAssist.Path = System.IO.Directory.GetCurrentDirectory() + "/information.ini";
            tbox_addr.Text = m_iniAssist.ReadString("db", "addr");
            tbox_port.Text = m_iniAssist.ReadInteger("db", "port").ToString();
            tbox_id.Text = m_iniAssist.ReadString("db", "id");
            tbox_pwd.Text = m_iniAssist.ReadString("db", "pwd");
            tbox_database.Text = m_iniAssist.ReadString("db", "database");
        }

        private void tbn_save_Click(object sender, EventArgs e) {

            m_iniAssist.WriteString("db", "addr", this.tbox_addr.Text);
            m_iniAssist.WriteInteger("db", "port", Convert.ToInt32(this.tbox_port.Text));
            m_iniAssist.WriteString("db", "id", this.tbox_id.Text);
            m_iniAssist.WriteString("db", "pwd", this.tbox_pwd.Text);
            m_iniAssist.WriteString("db", "database", this.tbox_database.Text);

            DialogResult = DialogResult.OK;
        }


        private void btn_close_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_test_Click(object sender, EventArgs e) {
                OracleAssist _OracleAssist = new OracleAssist(Addr, Port, Id, Pwd, Database);
                bool _Success = _OracleAssist.TestConnection();
                if (_Success) {
                    MessageBox.Show("오라클 접속성공");
                }
                else {
                    MessageBox.Show("오라클 접속실패");
                }
        }

        private void tbn_save_Click_1(object sender, EventArgs e) {

            m_iniAssist.WriteString("db", "addr", this.tbox_addr.Text);
            m_iniAssist.WriteInteger("db", "port", Convert.ToInt32(this.tbox_port.Text));
            m_iniAssist.WriteString("db", "id", this.tbox_id.Text);
            m_iniAssist.WriteString("db", "pwd", this.tbox_pwd.Text);
            m_iniAssist.WriteString("db", "database", this.tbox_database.Text);

            DialogResult = DialogResult.OK;
        }

        private void btn_close_Click_1(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }
    }
}
