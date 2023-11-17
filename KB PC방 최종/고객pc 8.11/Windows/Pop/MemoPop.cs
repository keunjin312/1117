using Lib.Frame;
using System;
using System.Data;
using System.Windows.Forms;
using Player_pc.Manager;

namespace mainPC.Windows.mainPC.상품관리 {
    public partial class MemoPop : MasterPop {
        
        int odrp_num = 0;

        public override void Initialize(ePopMode popMode, object aParam) {
            base.Initialize(popMode, aParam);
            DisplayMemo(aParam);
        }

        private void DisplayMemo(object aParam) {
            odrp_num = (int)aParam;
            DataRow dr = App.Self().DBManager.ReadMemo(odrp_num);
            rtbox_memo.Text = Convert.ToString(dr["odrp_memo"]);
        }

        private void button2_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_orderend_Click(object sender, EventArgs e) {
            int result = App.Self().DBManager.orderend(odrp_num);
            if (result > 0) {
                MessageBox.Show("주문이 완료되었습니다.");
                DialogResult = DialogResult.Cancel;
            }
            else {
                MessageBox.Show("주문 중 에러가 발생");
            }
        }
    }
}
