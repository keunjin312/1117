namespace Player_pc {
    partial class Loginform {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loginform));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Log_find_id = new System.Windows.Forms.Button();
            this.Log_find_pw = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.Log_join_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.Log_start_btn = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Log_tbox_pw = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Log_tbox_id = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.Log_find_id);
            this.panel1.Controls.Add(this.Log_find_pw);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 84);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel1.Size = new System.Drawing.Size(349, 36);
            this.panel1.TabIndex = 0;
            // 
            // Log_find_id
            // 
            this.Log_find_id.BackColor = System.Drawing.SystemColors.Desktop;
            this.Log_find_id.ForeColor = System.Drawing.Color.Yellow;
            this.Log_find_id.Location = new System.Drawing.Point(175, 2);
            this.Log_find_id.Name = "Log_find_id";
            this.Log_find_id.Size = new System.Drawing.Size(72, 30);
            this.Log_find_id.TabIndex = 5;
            this.Log_find_id.Text = "ID찾기";
            this.Log_find_id.UseVisualStyleBackColor = false;
            this.Log_find_id.Click += new System.EventHandler(this.Log_find_id_Click);
            // 
            // Log_find_pw
            // 
            this.Log_find_pw.BackColor = System.Drawing.SystemColors.Desktop;
            this.Log_find_pw.ForeColor = System.Drawing.Color.Yellow;
            this.Log_find_pw.Location = new System.Drawing.Point(263, 2);
            this.Log_find_pw.Name = "Log_find_pw";
            this.Log_find_pw.Size = new System.Drawing.Size(72, 30);
            this.Log_find_pw.TabIndex = 4;
            this.Log_find_pw.Text = "PW찾기";
            this.Log_find_pw.UseVisualStyleBackColor = false;
            this.Log_find_pw.Click += new System.EventHandler(this.Log_find_pw_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel8.Controls.Add(this.Log_join_btn);
            this.panel8.Location = new System.Drawing.Point(0, 3);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel8.Size = new System.Drawing.Size(118, 30);
            this.panel8.TabIndex = 3;
            // 
            // Log_join_btn
            // 
            this.Log_join_btn.BackColor = System.Drawing.SystemColors.Desktop;
            this.Log_join_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Log_join_btn.ForeColor = System.Drawing.Color.Yellow;
            this.Log_join_btn.Location = new System.Drawing.Point(5, 0);
            this.Log_join_btn.Name = "Log_join_btn";
            this.Log_join_btn.Size = new System.Drawing.Size(113, 30);
            this.Log_join_btn.TabIndex = 3;
            this.Log_join_btn.Text = "회원가입";
            this.Log_join_btn.UseVisualStyleBackColor = false;
            this.Log_join_btn.Click += new System.EventHandler(this.Log_join_btn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 84);
            this.panel2.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel7.Controls.Add(this.Log_start_btn);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(257, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(10);
            this.panel7.Size = new System.Drawing.Size(92, 84);
            this.panel7.TabIndex = 2;
            // 
            // Log_start_btn
            // 
            this.Log_start_btn.BackColor = System.Drawing.SystemColors.Desktop;
            this.Log_start_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Log_start_btn.ForeColor = System.Drawing.Color.Yellow;
            this.Log_start_btn.Location = new System.Drawing.Point(10, 10);
            this.Log_start_btn.Name = "Log_start_btn";
            this.Log_start_btn.Size = new System.Drawing.Size(72, 64);
            this.Log_start_btn.TabIndex = 2;
            this.Log_start_btn.Text = "사용시작";
            this.Log_start_btn.UseVisualStyleBackColor = false;
            this.Log_start_btn.Click += new System.EventHandler(this.button4_Click);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter2.Location = new System.Drawing.Point(254, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 84);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(254, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel6.Controls.Add(this.Log_tbox_pw);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(79, 45);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(8);
            this.panel6.Size = new System.Drawing.Size(172, 36);
            this.panel6.TabIndex = 3;
            // 
            // Log_tbox_pw
            // 
            this.Log_tbox_pw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Log_tbox_pw.Location = new System.Drawing.Point(8, 8);
            this.Log_tbox_pw.Name = "Log_tbox_pw";
            this.Log_tbox_pw.PasswordChar = '*';
            this.Log_tbox_pw.Size = new System.Drawing.Size(156, 21);
            this.Log_tbox_pw.TabIndex = 1;
            this.Log_tbox_pw.Text = "5372";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 45);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(70, 36);
            this.panel5.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "비밀번호";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel4.Controls.Add(this.Log_tbox_id);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(79, 3);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(8);
            this.panel4.Size = new System.Drawing.Size(172, 36);
            this.panel4.TabIndex = 1;
            // 
            // Log_tbox_id
            // 
            this.Log_tbox_id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Log_tbox_id.Location = new System.Drawing.Point(8, 8);
            this.Log_tbox_id.Name = "Log_tbox_id";
            this.Log_tbox_id.Size = new System.Drawing.Size(156, 21);
            this.Log_tbox_id.TabIndex = 0;
            this.Log_tbox_id.Text = "kingsj";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(70, 36);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "아이디";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 81);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(349, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // Loginform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(349, 120);
            this.ControlBox = false;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Loginform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox Log_tbox_pw;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox Log_tbox_id;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button Log_start_btn;
        private System.Windows.Forms.Button Log_find_id;
        private System.Windows.Forms.Button Log_find_pw;
        private System.Windows.Forms.Button Log_join_btn;
    }
}

