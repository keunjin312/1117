using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookPro.Manager {

    class App {
        private static App _instance;

        protected App() { }

        public static App Instance() {
            //다중쓰레드에서는 정상적으로 동작안하는 코드입니다. 
            //다중 쓰레드 경우에는 동기화가 필요합니다. 
            if (_instance == null) {
                _instance = new App();
            } 
            return _instance;
        }

        public static App Self() {
            //다중쓰레드에서는 정상적으로 동작안하는 코드입니다. 
            //다중 쓰레드 경우에는 동기화가 필요합니다. 
            if (_instance == null) {
                _instance = new App();
            } 
            return _instance;
        }
        // public int m_buffer = 1;
        //19
        private DBManager m_DBManager;
        public DBManager DBManager {
            get { return m_DBManager; }
            set { m_DBManager = value; }
        }

        //28
        public SessionManager SessionManager {
            get;
            set;
        }

        
        private MainForm m_MainForm;
        public MainForm MainForm {
            get { return m_MainForm; }
            set { m_MainForm = value; }
        }
        //public bool ShowMessage(string message) {
        //    bool _bresult = true;
        //    if (m_MessageVisible) {
        //        MessagePop _pop = new MessagePop();
        //        _pop.Initialize(VSL.Windows.Frame.ePopMode.None, message);
        //        if (_pop.ShowDialog() != System.Windows.Forms.DialogResult.OK) { _bresult = false; } else { }
        //    }
        //    else { }
        //    return _bresult;
        //}
        private bool m_MessageVisible = false;
        public bool MessageVisible { get { return m_MessageVisible; } set { m_MessageVisible = value; } }

        //17
        public string db_addr;
        public string db_id;
        public int db_port;
        public string db_pwd;
        public string db_database;

    }
}
