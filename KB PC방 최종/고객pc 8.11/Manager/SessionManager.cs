namespace Player_PC.Manager {
    class SessionManager {
        public string SessionName { get; set; } 
        public string SessionId { get; set; }
        public int SessionGrade { get; set; }

        public bool OnLine { get; set; }
        public SessionManager() { 
            OnLine = false;
        } 
                
        public void Login(string aName, string aId, int aGrade) { 
            OnLine = true;
            SessionName = aName;
            SessionId = aId;
            SessionGrade = aGrade;
        }

        public void Logout() {  OnLine = false; }

    }
}
