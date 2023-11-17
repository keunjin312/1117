using System;
using System.Windows.Forms;

namespace Player_pc.Windows.Pop {
    public partial class AddTimePop : Form {
           private int selectedTime = 0;

            public int PassTime {
                get { return selectedTime; }

                set { selectedTime = value; }
            }

            private int selectedProfit = 0;

            public int PassProfit {
                get { return selectedProfit; }

                set { selectedProfit = value; }
            }
            public AddTimePop()
            {
            InitializeComponent();
            }

   
        public void button_click(int time, int profit) {
       
            PassTime = time;
            PassProfit = profit;
           // App.Self().DBManager.TimePluss(time);
                                  
            DialogResult = DialogResult.OK;                
        }

        private void Addtime1_Click(object sender, EventArgs e) {
            button_click(1, 1000);
            MessageBox.Show("1시간 충전되었습니다.");

        }
        private void Addtime2_Click(object sender, EventArgs e) {
            button_click(2, 2000);
            MessageBox.Show("2시간 충전되었습니다.");
        }

        private void Addtime3_Click(object sender, EventArgs e) {
            button_click(3, 3000);
            MessageBox.Show("3시간 충전되었습니다.");
        }

        private void Addtime4_Click(object sender, EventArgs e) {
            button_click(4, 4000);
            MessageBox.Show("4시간 충전되었습니다.");
        }

        private void Addtime5_Click(object sender, EventArgs e) {
            button_click(5, 5000);
            MessageBox.Show("5시간 충전되었습니다.");
        }

        private void Addtime6_Click(object sender, EventArgs e) {
            button_click(6, 6000);
            MessageBox.Show("6시간 충전되었습니다.");
        }

        private void Addtime7_Click(object sender, EventArgs e) {
            button_click(7, 7000);
            MessageBox.Show("7시간 충전되었습니다.");
        }

        private void Addtime8_Click(object sender, EventArgs e) {
            button_click(8, 8000);
            MessageBox.Show("8시간 충전되었습니다.");
        }

        private void Addtime9_Click(object sender, EventArgs e) {
            button_click(9, 9000);
            MessageBox.Show("9시간 충전되었습니다.");
        }

        private void Addtime10_Click(object sender, EventArgs e) {
            button_click(10, 10000);
            MessageBox.Show("10시간 충전되었습니다.");
        }
    }
}
