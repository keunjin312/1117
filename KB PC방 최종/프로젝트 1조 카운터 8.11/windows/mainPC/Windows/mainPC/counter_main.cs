using PC.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Lib.Frame;
using Lib.Util;
using PC.Windows.mainPC;
using PC.Windows.mainPC.상품관리;
using PC.Windows.mainPC.회원관리;
using mainPC.Windows.mainPC.상품관리;


namespace mainPC {
    public partial class counter_main : Form {

        System.Windows.Forms.Label[] CM_mb_info;
        System.Windows.Forms.Label[] CM_time_remaining;
        System.Windows.Forms.Label[] CM_time_using;
        System.Windows.Forms.Panel[] CM_seat;

        List<MasterView> m_Views = new List<MasterView>();
        DBManager m_dbManager = null;
        SessionManager m_sessionManager = null;
        //생성&초기화 --------------------------
        public counter_main() {
            InitializeComponent();
            CreateObject();
            InitializeObject();
            ViewOrder();
            ResetSeatInfo();
        }

        public void ViewOrder() {
            DataTable dt = App.Self().DBManager.ReadOrder();
            if (dt != null) {
                DataTable dp_order = productdata.Tables["Dp_order"];
                dp_order.Rows.Clear();
                foreach (DataRow dr in dt.Rows) {
                    DataRow dp_row = dp_order.NewRow();
                    dp_row["odrp_num"] = dr["odrp_num"];
                    dp_row["S_num"] = dr["S_num"];
                    dp_row["P_name"] = dr["P_name"];
                    dp_row["odrp_memo"] = dr["odrp_memo"];
                    dp_row["odrp_amount"] = dr["odrp_amount"];
                    dp_row["odrp_time"] = dr["to_char(odrp_time,'HH24:MI:SS')"];
                    dp_order.Rows.Add(dp_row);
                }
            }
        }

        private void CreateObject() {
            m_dbManager = new DBManager();
            m_sessionManager = new SessionManager();

            CM_mb_info = new System.Windows.Forms.Label[15];
            CM_time_remaining = new System.Windows.Forms.Label[15];
            CM_time_using = new System.Windows.Forms.Label[15];
            CM_seat = new System.Windows.Forms.Panel[15];
        }
        private void InitializeObject() {
            App.Self().MainForm = this;
            ReadIniFile();
            m_dbManager.SetConnectInfo(App.Self().db_addr, App.Self().db_port, App.Self().db_id, App.Self().db_pwd, App.Self().db_database);
            App.Self().DBManager = m_dbManager;
            App.Self().SessionManager = m_sessionManager;

            CM_seat[0] = CM_seat_1;
            CM_seat[1] = CM_seat_2;
            CM_seat[2] = CM_seat_3;
            CM_seat[3] = CM_seat_4;
            CM_seat[4] = CM_seat_5;
            CM_seat[5] = CM_seat_6;
            CM_seat[6] = CM_seat_7;
            CM_seat[7] = CM_seat_8;
            CM_seat[8] = CM_seat_9;
            CM_seat[9] = CM_seat_10;
            CM_seat[10] = CM_seat_11;
            CM_seat[11] = CM_seat_12;
            CM_seat[12] = CM_seat_13;
            CM_seat[13] = CM_seat_14;
            CM_seat[14] = CM_seat_15;

            CM_mb_info[0] = CM_mb_info1;
            CM_mb_info[1] = CM_mb_info2;
            CM_mb_info[2] = CM_mb_info3;
            CM_mb_info[3] = CM_mb_info4;
            CM_mb_info[4] = CM_mb_info5;
            CM_mb_info[5] = CM_mb_info6;
            CM_mb_info[6] = CM_mb_info7;
            CM_mb_info[7] = CM_mb_info8;
            CM_mb_info[8] = CM_mb_info9;
            CM_mb_info[9] = CM_mb_info10;
            CM_mb_info[10] = CM_mb_info11;
            CM_mb_info[11] = CM_mb_info12;
            CM_mb_info[12] = CM_mb_info13;
            CM_mb_info[13] = CM_mb_info14;
            CM_mb_info[14] = CM_mb_info15;

            CM_time_remaining[0] = CM_time_remaining1;
            CM_time_remaining[1] = CM_time_remaining2;
            CM_time_remaining[2] = CM_time_remaining3;
            CM_time_remaining[3] = CM_time_remaining4;
            CM_time_remaining[4] = CM_time_remaining5;
            CM_time_remaining[5] = CM_time_remaining6;
            CM_time_remaining[6] = CM_time_remaining7;
            CM_time_remaining[7] = CM_time_remaining8;
            CM_time_remaining[8] = CM_time_remaining9;
            CM_time_remaining[9] = CM_time_remaining10;
            CM_time_remaining[10] = CM_time_remaining11;
            CM_time_remaining[11] = CM_time_remaining12;
            CM_time_remaining[12] = CM_time_remaining13;
            CM_time_remaining[13] = CM_time_remaining14;
            CM_time_remaining[14] = CM_time_remaining15;

            CM_time_using[0] = CM_time_using1;
            CM_time_using[1] = CM_time_using2;
            CM_time_using[2] = CM_time_using3;
            CM_time_using[3] = CM_time_using4;
            CM_time_using[4] = CM_time_using5;
            CM_time_using[5] = CM_time_using6;
            CM_time_using[6] = CM_time_using7;
            CM_time_using[7] = CM_time_using8;
            CM_time_using[8] = CM_time_using9;
            CM_time_using[9] = CM_time_using10;
            CM_time_using[10] = CM_time_using11;
            CM_time_using[11] = CM_time_using12;
            CM_time_using[12] = CM_time_using13;
            CM_time_using[13] = CM_time_using14;
            CM_time_using[14] = CM_time_using15;
        }
        private void ReadIniFile() {
            IniAssist _iniAssist = new IniAssist();
            _iniAssist.Path = System.IO.Directory.GetCurrentDirectory() + "/information.ini";
            App.Self().db_addr = _iniAssist.ReadString("db", "addr");
            App.Self().db_port = _iniAssist.ReadInteger("db", "port");
            App.Self().db_id = _iniAssist.ReadString("db", "id");
            App.Self().db_pwd = _iniAssist.ReadString("db", "pwd");
            App.Self().db_database = _iniAssist.ReadString("db", "database");
        }

        private void btn_CM_member_mg_Click(object sender, EventArgs e) {
            Member_Management pop = new Member_Management();
            pop.ShowDialog(this);
        }       

        private void CM_product_mg_Click(object sender, EventArgs e) {
            Product_Management pop = new Product_Management();
            pop.ShowDialog(this);
        }

        private void counter_main_Load(object sender, EventArgs e) {
            timer1.Start();
            timer2.Start();
        }

        private void ResetSeatInfo() {
            DataTable _dt = App.Self().DBManager.Readseatinfo();
            int usingseat_num = 0;
            int availableseat_num = 0;
            if (_dt != null) {
                foreach (DataRow _dr in _dt.Rows) {
                int _idx = Convert.ToInt32(_dr["s_num"]) - 1;
                     if (_dr["mb_id"] != DBNull.Value) {
                         CM_mb_info[_idx].Text = Convert.ToString(_dr["mb_name"] + "(" + _dr["substr(st.mb_id,1,3)"] + "**" +")");
                         DateTime lefttime1 = Convert.ToDateTime(_dr["s_end_time"]);
                         DateTime lefttime2 = Convert.ToDateTime(DateTime.Now.ToString("yy/MM/dd HH:mm:ss"));
                         TimeSpan lefttime = lefttime1 - lefttime2;
                         CM_time_remaining[_idx].Text = lefttime.ToString();
                         CM_time_using[_idx].Text = (Convert.ToDateTime(_dr["s_end_time"])).ToString("종료시간 : " + "HH:mm");
                         usingseat_num++;
                         label_CM_usingseat.Text = usingseat_num.ToString() + " / 15";
                         CM_seat[_idx].BackColor = Color.DarkSeaGreen;
                     }
                     else {
                        CM_time_remaining[_idx].Text = "빈자리";
                        CM_mb_info[_idx].Text = "-";
                        CM_time_using[_idx].Text = "-";
                        label_CM_usingseat.Text = usingseat_num.ToString() + " / 15";
                        availableseat_num++;
                        label_CM_availableseat.Text = availableseat_num.ToString() + " / 15";
                        CM_seat[_idx].BackColor = Color.Gray;
                    }
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e) {
        ResetSeatInfo();
        }

        private void timer2_Tick(object sender, EventArgs e) {
        ViewOrder();
        }

        private void grid_order_view_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                DataRow _dr = GridAssist.SelectedRow(grid_order_view, e.RowIndex);
                if (_dr != null) {
                    int odrp_num = Convert.ToInt32(_dr["odrp_num"]);
                    MemoPop _pop = new MemoPop();
                    _pop.ShowPop(ePopMode.None, odrp_num);
                }
            }
        }

        private void btn_CM_close_Click(object sender, EventArgs e) {
        Close();
        }

        private void btn_CM_settings_Click(object sender, EventArgs e) {
        SetupPop _pop = new SetupPop();
        DialogResult _dr = _pop.ShowDialog();
        if (_dr == DialogResult.OK) {
            App.Self().db_addr = _pop.Addr;
            App.Self().db_port = _pop.Port;
            App.Self().db_id = _pop.Id;
            App.Self().db_pwd = _pop.Pwd;
            App.Self().db_database = _pop.Database;
            m_dbManager.SetConnectInfo(App.Self().db_addr,
            App.Self().db_port, App.Self().db_id, App.Self().db_pwd, App.Self().db_database);
            }
        }       
    }
}
