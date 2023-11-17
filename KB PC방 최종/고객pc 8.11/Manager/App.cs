using Lib.Util;
using Player_PC.Manager;

namespace Player_pc.Manager {

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

        private DBManager m_DBManager;
        public DBManager DBManager {
            get { return m_DBManager; }
            set { m_DBManager = value; }
        }

        public SessionManager SessionManager {
            get;
            set;
        }

        
        private Loginform m_MainForm;
        public Loginform MainForm {
            get { return m_MainForm; }
            set { m_MainForm = value; }
        }
        private bool m_MessageVisible = false;
        public bool MessageVisible { get { return m_MessageVisible; } set { m_MessageVisible = value; } }

        public string db_addr;
        public string db_id;
        public int db_port;
        public string db_pwd;
        public string db_database;
        public string mb_ID;
        public int s_num; // 좌석번호

    }


}
