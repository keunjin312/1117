using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Player_pc.Windows.Pop {
    public partial class PlayerPcPop : Form {

        private string m_mbr_id = "";
        private string m_mbr_name = "";

        private DateTime StartTime, StartTime2;
        public PlayerPcPop() {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(1505, 0);
            DoLogin();

        }

        private void DoLogin() {
            if (m_mbr_id =="") { 
                this.Visible = false;
                Loginform _log = new Loginform();
                if(_log.ShowDialog() == DialogResult.OK) {
                    m_mbr_id = _log.MbrId;
                    m_mbr_name= _log.MbrName;
                    this.Visible = true;
                }
            
            }
        }
       

        private void timer1_Tick(object sender, EventArgs e) {
            TimeSpan span = new TimeSpan(DateTime.Now.Ticks - StartTime.Ticks + StartTime2.Ticks);
            label4.Text = span.ToString("hh\\:mm\\:ss");
        }

        private void label4_Click(object sender, EventArgs e) {
           
        }

        private void btn_pause_Click(object sender, EventArgs e) {
          if (btn_pause.Text == "일시정지") {
                btn_pause.Text = "재시작";
                StartTime2 = DateTime.Parse(label4.Text);
            }
            timer1.Enabled = !timer1.Enabled;
        
    }

        private void button2_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void tbtn_start_Click(object sender, EventArgs e) {
            AddTimePop _pop = new AddTimePop();
            if (_pop.ShowDialog(this) == DialogResult.OK) {

            }


        }

        private void PlayerPcPop_Load_1(object sender, EventArgs e) {
            Timeover();
            StartTime = DateTime.Now;
            StartTime2 = DateTime.Parse(label4.Text);
            timer1.Enabled = !timer1.Enabled;
        }
      

        DateTime dt;
        private void btn_info_Click_1(object sender, EventArgs e) {
            if (Left_time.Text != "00:00") {
                dt = new DateTime();
                timer2.Interval = 1000;
                timer2.Enabled = true;
                timer2.Start();
            }
        }

        private void test_add_Click(object sender, EventArgs e) {

        }

        private void panel3_Paint(object sender, PaintEventArgs e) {

        }

        private void Timeover() {
            if ( Left_time.Text == "00:00:00" ){
                AddTimePop _pop = new AddTimePop();
                if (_pop.ShowDialog(this) == DialogResult.OK) {

                 }
            }
        }

    }
    
}