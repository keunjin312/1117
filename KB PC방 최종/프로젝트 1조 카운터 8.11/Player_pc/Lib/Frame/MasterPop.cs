using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lib.Frame {
    public enum ePopMode { None = 0, Add = 1, Modify = 2, Delete=3,}
    public partial class MasterPop : Form {
        protected ePopMode m_PopMode;
        public MasterPop() {
            InitializeComponent();
            m_PopMode = ePopMode.None; //32
        }

        //32
        public virtual DialogResult ShowPop(ePopMode aPopMode) {
            Initialize(aPopMode, null);
            return this.ShowDialog();
        }


        //32
        public virtual DialogResult ShowPop(ePopMode popMode, object aParam) {
            Initialize(popMode, aParam);
            return this.ShowDialog();
        }
        //32
        public virtual void Initialize(ePopMode popMode, object aParam) { 
            m_PopMode = popMode;
        }

        private void MasterPop_Load(object sender, EventArgs e) {

        }
    }
}
