﻿namespace mainPC.Windows.mainPC.상품관리 {
    partial class MemoPop {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_orderend = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtbox_memo = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btn_orderend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 32);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(238, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "닫기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_orderend
            // 
            this.btn_orderend.Location = new System.Drawing.Point(3, 6);
            this.btn_orderend.Name = "btn_orderend";
            this.btn_orderend.Size = new System.Drawing.Size(75, 23);
            this.btn_orderend.TabIndex = 0;
            this.btn_orderend.Text = "전달완료";
            this.btn_orderend.UseVisualStyleBackColor = true;
            this.btn_orderend.Click += new System.EventHandler(this.btn_orderend_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbox_memo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 229);
            this.panel2.TabIndex = 1;
            // 
            // rtbox_memo
            // 
            this.rtbox_memo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbox_memo.Location = new System.Drawing.Point(0, 0);
            this.rtbox_memo.MaxLength = 100;
            this.rtbox_memo.Name = "rtbox_memo";
            this.rtbox_memo.Size = new System.Drawing.Size(316, 229);
            this.rtbox_memo.TabIndex = 0;
            this.rtbox_memo.Text = "";
            // 
            // MemoPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 261);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MemoPop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "메모";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_orderend;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtbox_memo;
    }
}