using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib.Frame {
    public partial class MasterView : Form {
        public event Action<object> eCloseAction = null;
        //생성 초기화 ---------------------------------------------------
        public MasterView() {
            Initialize();
            InitializeComponent();
        }

        private void Initialize() {
            this.Visible = false;
            this.TopLevel = false;
            this.Left = 0;
            this.Top = 0;
            //this.Dock = DockStyle.Fill;
        }

        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e); 
            if(eCloseAction != null ) {
                eCloseAction(this);
            }        
        }

        public virtual object DoCommand(object aCommand) { return null; }

        public virtual void SetTitle(string aTitle) { 
            
        }

        public virtual void InitializeView(string aKey , object aObject) {


        }
              
        private void MasterView_Load(object sender, EventArgs e) {

        }
    }
}
