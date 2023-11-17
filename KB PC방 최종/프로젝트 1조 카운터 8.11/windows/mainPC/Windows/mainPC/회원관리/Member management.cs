using Lib.Util;
using mainPC.Windows.mainPC.회원관리;
using PC.Manager;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PC.Windows.mainPC.회원관리 {
    public partial class Member_Management : Form {

        private DataRow m_mb_row = null;
        public Member_Management() {
            InitializeComponent();
        }               

        private void SearchByAll() {
            string _seed = tbox_MBM_search.Text;
            DataTable _dt = App.Self().DBManager.ReadMemberByAll(_seed);
            if (_dt != null) {
                DataTable _dp_member = DisplaySet.Tables["table_member"];
                _dp_member.Rows.Clear();
                foreach (DataRow row in _dt.Rows) {
                    DataRow _dp_row = _dp_member.NewRow();
                    _dp_row["mb_name"] = row["mb_name"];
                    _dp_row["mb_id"] = row["mb_id"];
                    _dp_row["mb_ph"] = row["mb_ph"];
                    _dp_member.Rows.Add(_dp_row);
                }
            }
        }

        private void MBM_search_btn_Click(object sender, EventArgs e) {
            SearchByAll(); // row[0]가 선택되게 고정
        }

        private void MBM_Read_mblist() {
            string _seed = tbox_MBM_search.Text;
            DataTable _dt = App.Self().DBManager.ReadMember(_seed);
            if (_dt != null) {
                DataTable _dp_member = DisplaySet.Tables["table_member"];
                _dp_member.Rows.Clear();
                foreach (DataRow row in _dt.Rows) {
                DataRow _dp_row = _dp_member.NewRow();
                _dp_row["mb_name"] = row["mb_name"];
                _dp_row["mb_id"] = row["mb_id"];
                _dp_row["mb_ph"] = row["mb_ph"];
                _dp_member.Rows.Add(_dp_row);
                }
            }
        }

        private void DisplayMember() {
            if (m_mb_row == null) {
                tbox_MBM_member_num.Text = "";
                tbox_MBM_member_name.Text = "";
                tbox_MBM_member_id.Text = "";
                tbox_MBM_member_pw.Text = "";
                tbox_MBM_member_ph.Text = "";
                date_MBM_member_birthdate.Value = DateTime.Now;
                date_MBM_member_newdate.Value = DateTime.Now;
                tbox_MBM_member_memo.Text = "";
            }
            else {
            tbox_MBM_member_num.Text = Convert.ToString(m_mb_row["mb_num"]);
            tbox_MBM_member_name.Text = Convert.ToString(m_mb_row["mb_name"]);
            tbox_MBM_member_pw.Text = Convert.ToString(m_mb_row["mb_pw"]);
            tbox_MBM_member_ph.Text = Convert.ToString(m_mb_row["mb_ph"]);
            tbox_MBM_member_memo.Text = Convert.ToString(m_mb_row["mb_memo"]);
            tbox_MBM_member_id.Text = Convert.ToString(m_mb_row["mb_id"]);
            date_MBM_member_birthdate.Value = Convert.ToDateTime(m_mb_row["mb_birth"]);
            date_MBM_member_newdate.Value = Convert.ToDateTime(m_mb_row["mb_join"]);
            }
        }

        private void MBM_add_btn_Click(object sender, EventArgs e) {
            MBM_add_member pop = new MBM_add_member();
            pop.ShowDialog(this);
            SearchByAll();
        }

        private void grid_main_SelectionChanged_1(object sender, EventArgs e) { // selected
            if (grid_member_view.CurrentRow != null) {
                DataRow _SelectedRow = GridAssist.SelectedRow(grid_member_view);
                String _mb_id = _SelectedRow["mb_id"].ToString();
                DataRow _mb_row = App.Self().DBManager.ReadMember_byid(_mb_id);
                if (_mb_row != null) {
                    m_mb_row = _mb_row;
                    DisplayMember();
                }
            }
        }

        private void Member_Management_Load(object sender, EventArgs e) {
            MBM_Read_mblist();
        }

        // 회원 선택삭제
        private void btn_MBM_delete_Click(object sender, EventArgs e) {
            DataTable _dp_member = DisplaySet.Tables["table_member"];
            DataRow[] _rows = _dp_member.Select("grid_select=true");

            ArrayList _ides = new ArrayList();
            foreach (DataRow row in _rows) {
                _ides.Add($"'{row["mb_id"]}'");
            }

            string _mb_ides = "(";
            foreach (DataRow _row in _rows) {
                if (_mb_ides.Length > 1) { _mb_ides += ","; }
                _mb_ides += "'" + _row["mb_id"].ToString() + "'";
            }
            _mb_ides += ")";

            if (_ides.Count > 0) {
                DataRow _dp_row = GridAssist.SelectedRow(grid_member_view);

                if (_dp_row != null) {
                    string _msg = string.Format("정말로 삭제하시겠습니까?");

                    if (MessageBox.Show(_msg, "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        int _result = App.Self().DBManager.DeleteMember(_mb_ides);

                        if (_result > 0) {
                            string _message = string.Join(", ", _ides.ToArray());
                            MessageBox.Show(_message + "삭제되었습니다.");
                            MBM_Read_mblist();
                        }
                        else {
                            MessageBox.Show("삭제중 오류가 발생했습니다.");
                        }
                    }
                }
            }
        }

        private void btn_MBM_member_modify_Click(object sender, EventArgs e) {        
            tbox_MBM_member_name.ReadOnly = false;
            tbox_MBM_member_name.BorderStyle = BorderStyle.Fixed3D;
            tbox_MBM_member_name.BackColor = Color.White;
            panel16.BackColor = Color.White;

            tbox_MBM_member_pw.ReadOnly = false;
            tbox_MBM_member_pw.BorderStyle = BorderStyle.Fixed3D;
            tbox_MBM_member_pw.BackColor = Color.White;
            tbox_MBM_member_pw.PasswordChar = '\0';
            panel20.BackColor = Color.White;

            tbox_MBM_member_ph.ReadOnly = false;
            tbox_MBM_member_ph.BorderStyle = BorderStyle.Fixed3D;
            tbox_MBM_member_ph.BackColor = Color.White;
            panel22.BackColor = Color.White;

            tbox_MBM_member_memo.ReadOnly = false;
            tbox_MBM_member_memo.BorderStyle = BorderStyle.Fixed3D;
            tbox_MBM_member_memo.BackColor = Color.White;
            panel28.BackColor = Color.White;
           
            btn_MBM_member_save.Enabled = true;
            btn_MBM_member_modify.Enabled = false;
            btn_MBM_member_cancle.Enabled = true;
        }

        private void btn_MBM_member_save_Click(object sender, EventArgs e) {        
            string _mb_id = Convert.ToString(m_mb_row["mb_id"]);
            string _mb_name = tbox_MBM_member_name.Text;
            string _mb_pw = tbox_MBM_member_pw.Text;
            string _mb_ph = tbox_MBM_member_ph.Text;
            string _mb_memo = tbox_MBM_member_memo.Text;
            
            int _result = App.Self().DBManager.save_member(
                _mb_id, _mb_name, _mb_pw, _mb_ph, _mb_memo);

            if (_result > 0) {
                MessageBox.Show("수정성공");
                MBM_Read_mblist();
            }
            else {
                MessageBox.Show("수정실패");
            }

            tbox_MBM_member_name.ReadOnly = true;
            tbox_MBM_member_name.BorderStyle = BorderStyle.None;
            tbox_MBM_member_name.BackColor = Color.DarkGray;
            panel16.BackColor = Color.DarkGray;

            tbox_MBM_member_pw.ReadOnly = true;
            tbox_MBM_member_pw.BorderStyle = BorderStyle.None;
            tbox_MBM_member_pw.BackColor = Color.DarkGray;
            tbox_MBM_member_pw.PasswordChar = '*';
            panel20.BackColor = Color.DarkGray;

            tbox_MBM_member_ph.ReadOnly = true;
            tbox_MBM_member_ph.BorderStyle = BorderStyle.None;
            tbox_MBM_member_ph.BackColor = Color.DarkGray;
            panel22.BackColor = Color.DarkGray;

            tbox_MBM_member_memo.ReadOnly = true;
            tbox_MBM_member_memo.BorderStyle = BorderStyle.None;
            tbox_MBM_member_memo.BackColor = Color.DarkGray;
            panel28.BackColor = Color.DarkGray;

            btn_MBM_member_cancle.Enabled = false;
            btn_MBM_member_save.Enabled = false;
            btn_MBM_member_modify.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e) {
            tbox_MBM_member_name.Undo(); // 텍스트박스 수정사항 실행취소 함수
            tbox_MBM_member_name.ReadOnly = true;
            tbox_MBM_member_name.BorderStyle = BorderStyle.None;
            tbox_MBM_member_name.BackColor = Color.DarkGray;
            panel16.BackColor = Color.DarkGray;

            tbox_MBM_member_pw.Undo();
            tbox_MBM_member_pw.ReadOnly = true;
            tbox_MBM_member_pw.BorderStyle = BorderStyle.None;
            tbox_MBM_member_pw.BackColor = Color.DarkGray;
            tbox_MBM_member_pw.PasswordChar = '*';
            panel20.BackColor = Color.DarkGray;

            tbox_MBM_member_ph.Undo();
            tbox_MBM_member_ph.ReadOnly = true;
            tbox_MBM_member_ph.BorderStyle = BorderStyle.None;
            tbox_MBM_member_ph.BackColor = Color.DarkGray;
            panel22.BackColor = Color.DarkGray;

            tbox_MBM_member_memo.Undo();
            tbox_MBM_member_memo.ReadOnly = true;
            tbox_MBM_member_memo.BorderStyle = BorderStyle.None;
            tbox_MBM_member_memo.BackColor = Color.DarkGray;
            panel28.BackColor = Color.DarkGray;

            btn_MBM_member_cancle.Enabled = false;
            btn_MBM_member_modify.Enabled = true;
            btn_MBM_member_save.Enabled = false;
        }

        private void btn_MBM_close_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }
    }
}