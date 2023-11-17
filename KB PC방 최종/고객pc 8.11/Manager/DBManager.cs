using Lib.DB;
using Player_pc.Manager;
using Player_pc.Windows.Pop;
using System;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;

namespace Player_pc.Manager {
    class DBManager {
        private OracleAssist m_OracleAssist;
        public void SetConnectInfo(string aAddr, int aPort, string aId, string aPwd, string aDataBase) {
            m_OracleAssist = new OracleAssist(aAddr, aPort, aId, aPwd, aDataBase);
        }
        //4000자 이상 문자열 ToClob으로 처리하기
        public string MakeToClobQuery(string aSrc) {
            return MakeToClobQuery(aSrc, 4000);
        }
        public string MakeToClobQuery(string aSrc, int aBlock) {
            string _result = "";
            if (aSrc == null || aSrc.Length == 0) {
                _result = "''";
            }
            else {
                int _len = aSrc.Length;
                int _count = (_len + aBlock - 1) / aBlock;
                for (int _idx = 0; _idx < _count; _idx++) {
                    if (_result.Length > 0) { _result += "||"; }
                    int _start = _idx * aBlock;
                    int _size = _len - _start;
                    if (_size > aBlock) { _size = aBlock; }
                    _result += string.Format(" TO_CLOB('{0}') "
                        , aSrc.Substring(_start, _size));

                }
            }
            return _result;
        }

        public DataTable ReadMember(string aId, string aPw) {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strFormat = " SELECT mb_id,mb_name, ";
                _strFormat += "case when mb_pw = '{0}' then 1 else 0 end chk_pwd, mb_remain_minute ";
                _strFormat += "FROM member ";
                _strFormat += "WHERE mb_id = '{1}' ";

                string _strQuery = string.Format(_strFormat, aPw, aId);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
            }

            return _dt;
        }

        public DataRow ReadMember_byid(string aId) {
            DataRow _dr = null;
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strFormat = "SELECT mb_num, mb_id, mb_name, mb_pw, mb_ph, mb_birth, mb_join, mb_memo ";
                _strFormat += "FROM Member ";
                _strFormat += "WHERE mb_id = '{0}' ";

                string _strQuery = string.Format(_strFormat, aId);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "Member");
                if (_dt != null && _dt.Rows != null && _dt.Rows.Count > 0) {
                    _dr = _dt.Rows[0];
                }
            }
            return _dr;
        }

        public DataRow ReadMember_byid1(string aName, string aPh) {
            DataRow _dr = null;
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strFormat = "SELECT mb_id ";
                _strFormat += "FROM Member ";
                _strFormat += "WHERE mb_name = '{0}' and mb_ph ='{1}' ";
                // {0} = 정영훈 , {1} = 010-5045-1205

                string _strQuery = string.Format(_strFormat, aName, aPh);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "Member");
                if (_dt != null && _dt.Rows != null && _dt.Rows.Count > 0) {
                    _dr = _dt.Rows[0];
                }
            }
            return _dr;
        }

        public DataRow ReadMember_byid2(string addmb_name, string addmb_ph, DateTime addmb_birthdate) {
            DataRow _dr = null;
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strFormat = "SELECT mb_num, mb_id ";
                _strFormat += "FROM Member ";
                _strFormat += "WHERE mb_name = '{0}' and mb_ph ='{1}' and mb_birth ='{2}' ";

                string _strQuery = string.Format(_strFormat, addmb_name, addmb_ph, addmb_birthdate.ToString("yy-MM-dd"));
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "Member");
                if (_dt != null && _dt.Rows != null && _dt.Rows.Count > 0) {
                    _dr = _dt.Rows[0];
                }
            }
            return _dr;
            //ReadMember_byid2 내용
        }

        public int Addmember(string _addmb_name, string _addmb_id, string _addmb_pw, string _addmb_ph, DateTime _addmb_birthdate) {
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = " ";
                string _fieldsQuery = " ";
                string _valuesQuery = " ";

                _fieldsQuery += "mb_num,";
                _valuesQuery += "member_seq1.nextval, ";

                _fieldsQuery += "mb_name,";
                _valuesQuery += string.Format("'{0}', ", _addmb_name);

                _fieldsQuery += "mb_id,";
                _valuesQuery += string.Format("'{0}', ", _addmb_id);

                _fieldsQuery += "mb_pw,";
                _valuesQuery += string.Format("'{0}', ", _addmb_pw);

                _fieldsQuery += "mb_ph,";
                _valuesQuery += string.Format("'{0}', ", _addmb_ph);

                _fieldsQuery += "mb_birth,";
                _valuesQuery += string.Format("'{0}', ", _addmb_birthdate.ToString("yyyy-MM-dd"));

                _fieldsQuery += "mb_join ";
                _valuesQuery += "(select sysdate from dual ) ";


                _strQuery = "INSERT INTO member(" + _fieldsQuery + ") VALUES (" + _valuesQuery + ")";

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        public DataTable ReadProductAll() {

            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT p_name,p_price,p_memo,p_picture,p_category FROM product_info ";
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "product_info");
            }
            return _dt;

        }

        public DataTable ReadProductbev() {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT p_name,p_price,p_memo,p_picture,p_category FROM product_info ";
                _strQuery += "WHERE p_category = '음료' ";
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "product_info");
            }
            return _dt;

        }

        public DataTable ReadProductSnack() {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT p_name,p_price,p_memo,p_picture,p_category FROM product_info ";
                _strQuery += "WHERE p_category = '과자' ";
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "product_info");
            }
            return _dt;
        }

        public DataTable ReadProductramen() {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT p_name,p_price,p_memo,p_picture,p_category FROM product_info ";
                _strQuery += "WHERE p_category = '라면' ";
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "product_info");
            }
            return _dt;
        }

        public DataTable ReadProductetc() {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT p_name,p_price,p_memo,p_picture,p_category FROM product_info ";
                _strQuery += "WHERE p_category = '기타' ";
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "product_info");
            }
            return _dt;
        }

        public int LastOrder(string p_name, int odrp_amount, int p_price, string memo) {
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = " ";
                string _fieldsQuery = " ";
                string _valuesQuery = " ";

                _fieldsQuery += "odrp_num,";
                _valuesQuery += "ORDER_PRODUCT_SEQ1.nextval+5, ";

                _fieldsQuery += "mb_id, ";
                _valuesQuery += string.Format("'{0}', ", App.Self().mb_ID);

                _fieldsQuery += "p_name,";
                _valuesQuery += string.Format("'{0}', ", p_name);

                _fieldsQuery += "odrp_amount, ";
                _valuesQuery += string.Format("'{0}', ", odrp_amount);

                _fieldsQuery += "s_num,";
                _valuesQuery += string.Format("'{0}', ", App.Self().s_num);

                _fieldsQuery += "p_price,";
                _valuesQuery += string.Format("'{0}', ", p_price);

                _fieldsQuery += "odrp_memo ";
                _valuesQuery += string.Format("'{0}' ", memo);

                _strQuery = "INSERT INTO order_product (" + _fieldsQuery + ") VALUES (" + _valuesQuery + ")";

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        public DataRow ReadProduct(string aName) {
            DataRow _dr = null;
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strFormat = "SELECT p_name,p_price,p_memo,p_picture,p_category ";
                _strFormat += "FROM product_info ";
                _strFormat += "WHERE p_name = '{0}' ";

                string _strQuery = string.Format(_strFormat, aName);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "product_info");
                if (_dt != null && _dt.Rows != null && _dt.Rows.Count > 0) {
                    _dr = _dt.Rows[0];
                }
            }
            return _dr;
        }

        public int orderend(int odrp_num) {

            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = "UPDATE order_product ";
                _strQuery += "SET odrp_state = 'end' ";
                _strQuery += string.Format("WHERE odrp_num = '{0}' ", odrp_num);

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        public DataRow ReadMemo(int odrp_num) {
            DataRow _dr = null;
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strFormat = "SELECT odrp_memo ";
                _strFormat += "FROM order_product ";
                _strFormat += "WHERE odrp_num = '{0}' ";

                string _strQuery = string.Format(_strFormat, odrp_num);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "order_product");
                if (_dt != null && _dt.Rows != null && _dt.Rows.Count > 0) {
                    _dr = _dt.Rows[0];
                }
            }
            return _dr;
        }

        public int ModifySeatLogin(int _seat_num, string _mbr_id, int _mbr_remain_minute) {

            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = "UPDATE seat SET ";
                _strQuery += string.Format("mb_id = '{0}', ", _mbr_id);
                _strQuery += string.Format("s_start_time = SYSDATE, ");
                _strQuery += string.Format("s_end_time = CURRENT_TIMESTAMP + INTERVAL '{0}' MINUTE ", _mbr_remain_minute);
                _strQuery += string.Format("WHERE s_num = {0} ", _seat_num);

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        public int ModifySeatLogout(int s_num) {

            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = "UPDATE seat SET ";
                _strQuery += "s_start_time = '', mb_id = '', ";
                _strQuery += "s_end_time = '' ";
                _strQuery += string.Format("WHERE s_num = {0} ", s_num);
                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        public int ModifyEndTime(int _seat_num, int _seat_add_minute) {
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = "UPDATE seat SET ";
                _strQuery += string.Format("s_end_time = s_end_time + INTERVAL '{0}' MINUTE ", _seat_add_minute);
                _strQuery += string.Format("WHERE s_num = {0} ", _seat_num);

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        public int ModifyEndTime2(string mb_ID, double mb_remain_minute) {
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = "UPDATE member SET ";
                _strQuery += string.Format("mb_remain_minute = {0} ", mb_remain_minute);
                _strQuery += string.Format("WHERE mb_ID = '{0}' ", mb_ID);

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        public string ReadRemainTime(int seat_num) {
            string _result = "00:00";
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT TO_CHAR(s_end_time - SYSTIMESTAMP, 'HH24:MI') AS remain_time ";
                _strQuery += "FROM seat ";
                _strQuery += string.Format("WHERE s_num = {0}  ", seat_num);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
            }

            if (_dt != null && _dt.Rows.Count > 0) {
                DataRow _row = _dt.Rows[0];
                _result = Convert.ToString(_row["remain_time"]).Substring(11, 5);
            }
            return _result;
        }

        public DataRow ReadCheckMember(string login_id) {
            DataRow _dr = null;
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strFormat = " SELECT mb_id ";
                _strFormat += "FROM seat ";
                _strFormat += "WHERE mb_id = '{0}' ";

                string _strQuery = string.Format(_strFormat, login_id);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "seat");
                if (_dt != null && _dt.Rows.Count > 0)
                    _dr = _dt.Rows[0];
            }
            return _dr;
        }

        /*public DataTable ReadMember(string aId, string aPw) {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strFormat = " SELECT mb_id,mb_name, ";
                _strFormat += "case when mb_pw = '{0}' then 1 else 0 end chk_pwd, mb_remain_minute ";
                _strFormat += "FROM member ";
                _strFormat += "WHERE mb_id = '{1}' ";

                string _strQuery = string.Format(_strFormat, aPw, aId);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
            }

            return _dt;
        }*/

        public DataTable SearchEmptySeat() {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strFormat = " SELECT mb_id FROM seat ";
                _strFormat += "order by s_num ";

                string _strQuery = string.Format(_strFormat);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
            }
            return _dt;
        }
    }
}