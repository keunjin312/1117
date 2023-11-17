using System;
using System.Drawing;
using System.Windows.Forms;
using Player_pc.Manager;
using mainPC.Windows.mainPC.상품관리;
using System.Diagnostics;
using Lib.Util;
using System.Data;

namespace Player_pc.Windows.Pop {
    public partial class PlayerPcPop : Form {

        private string m_mbr_id = "";
        private string m_mbr_name = "";
        private int s_num;

        private DateTime StartTime, StartTime2;
        public PlayerPcPop() {
            InitializeComponent();
            //CreateObject();
            //InitObject();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(1505, 0);
            DoLogin();
        }

        IniAssist m_iniAssist;
        private void CreateObject() {
            m_iniAssist = new IniAssist();
        }

        private void InitObject() {
            m_iniAssist.Path = System.IO.Directory.GetCurrentDirectory() + "/information.ini";            
            App.Self().s_num = m_iniAssist.ReadInteger("db", "s_num");
            Seat_num.Text = "No." + Convert.ToString(App.Self().s_num);
        }

        //
        private void DoLogin() {
            if (m_mbr_id == "") {
                this.Visible = false;
                Loginform _log = new Loginform();
                if (_log.ShowDialog() == DialogResult.OK) {
                    m_mbr_id = App.Self().mb_ID;

                    m_mbr_name = _log.MbrName;
                    int _mbr_remain_minute = _log.MbrReMainMinute;
                    this.Visible = true;

                    //빈좌석 찾기
                    DataTable _dt_e_seat = new DataTable();
                    _dt_e_seat = App.Self().DBManager.SearchEmptySeat();

                    for (int i = 0; i < _dt_e_seat.Rows.Count; i++ ) {
                        if (_dt_e_seat.Rows[i][0] == DBNull.Value) {
                            App.Self().s_num = i+1;
                            break;
                        }                        
                    }
                    
                    App.Self().DBManager.ModifySeatLogin(App.Self().s_num, m_mbr_id, _mbr_remain_minute);
                    Left_time.Text = App.Self().DBManager.ReadRemainTime(App.Self().s_num);
                    s_name.Text = _log.MbrName;
                    RemainTimer.Start();
                    Timeover();
                    StartTime = DateTime.Now;
                    StartTime2 = DateTime.Parse(used_time.Text);
                    CurrentTimer.Enabled = !CurrentTimer.Enabled;
                    Seat_num.Text = "No." + Convert.ToString(App.Self().s_num);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            TimeSpan span = new TimeSpan(DateTime.Now.Ticks - StartTime.Ticks + StartTime2.Ticks);
            used_time.Text = span.ToString("hh\\:mm\\:ss");
        }

        private bool ValidateTest() {
            bool result = true;
            string msg = "";
            return result;
        }

        private void tbtn_start_Click(object sender, EventArgs e) {
            AddTimePop _pop = new AddTimePop();
            if (_pop.ShowDialog(this) == DialogResult.OK) {
                App.Self().DBManager.ModifyEndTime(App.Self().s_num, _pop.PassTime * 60);
                Pay_money.Text = Convert.ToString(Convert.ToInt32(Pay_money.Text) + Convert.ToInt32(_pop.PassProfit));
                Left_time.Text = App.Self().DBManager.ReadRemainTime(App.Self().s_num);
            }
        }

        private void RemainTimer_Tick(object sender, EventArgs e) {
            Left_time.Text = App.Self().DBManager.ReadRemainTime(App.Self().s_num);
        }

        private void btn_product_order_Click(object sender, EventArgs e) {
            Product_order_Pop _pop = new Product_order_Pop();
            _pop.ShowDialog(this);
        }

        private void btn_quit_Click_2(object sender, EventArgs e) {
            if (Left_time.Text != "00:00") {
                string _msg = string.Format($"{Convert.ToString(Left_time.Text)}남았습니다.\n종료하시겠습니까?");
                if (MessageBox.Show(_msg, "종료확인", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    if (ValidateTest()) {
                        m_mbr_id = App.Self().mb_ID;
                        String left_time = this.Left_time.Text;
                        DateTime _left_time = DateTime.ParseExact(left_time, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                        double _left_time_minutes = _left_time.TimeOfDay.TotalMinutes;
                        //남은시간저장
                        int _result = App.Self().DBManager.ModifyEndTime2(m_mbr_id, _left_time_minutes);
                        if (_result > 0) {
                            s_num = App.Self().s_num;
                            int __result = App.Self().DBManager.ModifySeatLogout(s_num);
                            if (__result > 0) {
                                MessageBox.Show("종료 완료.");
                                Application.Exit();
                            }
                            else {
                                MessageBox.Show("종료 실패.");
                            }
                        }
                    }
                }
                else { // "00:00" 일때, 로그인화면 출력
                    DoLogin();
                }
            }
        }      

        private void pictureBox1_Click(object sender, EventArgs e) {
        Process.Start("chrome.exe", "https://maplestory.nexon.com/Promotion/event/2023/20230615/intro/2nd");
        }

        private void Timeover() {
            if (Left_time.Text == "00:00") {
                AddTimePop _pop = new AddTimePop();
                if (_pop.ShowDialog(this) == DialogResult.OK) {
                    App.Self().DBManager.ModifyEndTime(App.Self().s_num, _pop.PassTime * 60);
                    Pay_money.Text = Convert.ToString(Convert.ToInt32(Pay_money.Text) + Convert.ToInt32(_pop.PassProfit));
                    Left_time.Text = App.Self().DBManager.ReadRemainTime(App.Self().s_num);
                }
            }
        }
    }
}                                                                               