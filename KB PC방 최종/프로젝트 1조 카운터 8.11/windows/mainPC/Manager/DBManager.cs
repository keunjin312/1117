using Lib.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Security.Cryptography;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.Collections;
using System.Xml.Linq;

namespace PC.Manager {
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

    
        //회원관련 DB함수-------------------------------------------------

        public DataTable ReadMemberByAll(string seed) {

        DataTable _dt = null;
        DbConnection _Connection = m_OracleAssist.NewConnection();
        if (_Connection != null) {
        string _strQuery = string.Format("SELECT mb_name, mb_id, mb_ph FROM member ");
        _strQuery += string.Format("WHERE mb_name LIKE '%{0}%' or mb_id LIKE '%{0}%' or mb_ph LIKE '%{0}%'", seed);
        _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
        }
        return _dt;
        }
        //검색창 회원정보 전체 불러오기
        public int Addmember(string _addmb_name, string _addmb_id, string _addmb_pw, string _addmb_ph, DateTime _addmb_birthdate, DateTime _addmb_newdate) {
        //회원 추가
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

        _fieldsQuery += "mb_join";
        _valuesQuery += string.Format("'{0}' ", _addmb_newdate.ToString("yyyy-MM-dd"));

        _strQuery = "INSERT INTO member(" + _fieldsQuery + ") VALUES (" + _valuesQuery + ")";

        _result = m_OracleAssist.ExcuteQuery(_strQuery);
        }
        return _result;
        }
        //회원추가

        public int DeleteMember(string mb_ides) {
        //회원삭제
        int _result = 0;
        DbConnection _Connection = m_OracleAssist.NewConnection();
        if (_Connection == null) {
        _result = -999;
        }

        else {
        string _strQuery = string.Format("DELETE FROM member WHERE mb_id in {0} ", mb_ides);

        _result = m_OracleAssist.ExcuteQuery(_strQuery);
        }
        return _result;
        } //회원정보 선택삭제

        public DataTable ReadMember(string seed) {
        
        DataTable _dt = null;
        DbConnection _Connection = m_OracleAssist.NewConnection();
        if (_Connection != null) {
        string _strQuery = "SELECT mb_name, mb_id, mb_ph  FROM  member";  //39
        if (seed.Length > 0) {
        _strQuery += string.Format("WHERE mb_name LIKE '%{0}%' ", seed);
        }
        _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
        }
        return _dt;
        } //회원정보불러오기

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
        } //회원정보불러오기

        public int save_member(string mb_id, string mb_name, string mb_pw, string mbr_ph, string mb_memo) {
        int _result = 0;
        DbConnection _Connection = m_OracleAssist.NewConnection();
        if (_Connection == null) {
        _result = -999;
        }
        else {
        string _strQuery = "UPDATE member SET ";
        _strQuery += string.Format("mb_name = '{0}', ", mb_name);
        _strQuery += string.Format("mb_pw = '{0}', ", mb_pw);
        _strQuery += string.Format("mb_ph = '{0}', ", mbr_ph);
        _strQuery += string.Format("mb_memo = '{0}' ", mb_memo);
        _strQuery += string.Format("WHERE mb_id = '{0}' ", mb_id);

        _result = m_OracleAssist.ExcuteQuery(_strQuery);
        }
        return _result;
        }
        //회원정보 수정사항 저장


        //상품관련 DB함수---------------------------------------------
        public DataTable ReadProductAll(string Seed) {

            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT p_name,p_price,p_category FROM product_info ";
                _strQuery += string.Format("WHERE p_name LIKE '%{0}%'", Seed);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "product_info");
            }
            return _dt;
        }

        public DataTable ReadProductbyBeverage(string seed) {

            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT p_name,p_price,p_category FROM product_info ";
                _strQuery += " where p_category = '음료' ";
                _strQuery += string.Format("AND p_name LIKE '%{0}%'", seed);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "product_info");
            }
            return _dt;
        }


        public DataTable ReadProductbySnack(string seed) {

            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT p_name,p_price,p_category FROM product_info ";
                _strQuery += "where p_category = '과자' ";
                _strQuery += string.Format("AND p_name LIKE '%{0}%'", seed);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "product_info");
            }
            return _dt;
        }

        public DataTable ReadProductbyRamen(string seed) {

            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT p_name,p_price,p_category FROM product_info ";
                _strQuery += "where p_category = '라면' ";
                _strQuery += string.Format("AND p_name LIKE '%{0}%'", seed);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "product_info");
            }
            return _dt;
        }

        public DataTable ReadProductbyEtc(string seed) {

            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT p_name,p_price,p_category FROM product_info ";
                _strQuery += "where (p_category = '기타') ";
                _strQuery += string.Format("AND p_name LIKE '%{0}%'", seed);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "product_info");
            }
            return _dt;

        }


        //멤버 데이터 수정



        //메인화면 관련 DB함수
        public DataTable Readseatinfo() {

        DataTable _dt = null;
        DbConnection _Connection = m_OracleAssist.NewConnection();
        if (_Connection != null) {
        string _strQuery = "SELECT  s_num, s_start_time, st.mb_id, substr(st.mb_id,1,3), s_end_time, mb.mb_name FROM seat st left join member mb on mb.mb_id = st.mb_id ";

        _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
        }
        return _dt;
        } //자리에 회원정보 불러오기

        internal DataTable Addtimes() {
        throw new NotImplementedException();
        } //우클릭 시간추가

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

        public int AddProduct(string p_name, string p_price, string p_memo, string p_picture, string p_category) {
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = " ";
                string _fieldsQuery = " ";
                string _valuesQuery = " ";

                _fieldsQuery += "p_name,";
                _valuesQuery += string.Format("'{0}', ", p_name);

                _fieldsQuery += "p_price,";
                _valuesQuery += string.Format("'{0}', ", p_price);

                _fieldsQuery += "p_memo,";
                _valuesQuery += string.Format("'{0}', ", p_memo);

                _fieldsQuery += "p_picture, ";
                _valuesQuery += string.Format("{0}, ", MakeToClobQuery(p_picture));

                _fieldsQuery += "p_category";
                _valuesQuery += string.Format("'{0}' ", p_category);

                _strQuery = "INSERT INTO product_info (" + _fieldsQuery + ") VALUES (" + _valuesQuery + ")";

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        public int ModifyProduct(string p_org_name, string p_name, string p_price, string p_memo, string p_picture, string p_category) {
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = "UPDATE Product_info SET ";
                _strQuery += string.Format("p_name = '{0}', ", p_name);
                _strQuery += string.Format("p_price = '{0}', ", p_price);
                _strQuery += string.Format("p_memo = '{0}', ", p_memo);
                _strQuery += string.Format("p_picture = {0}, ", MakeToClobQuery(p_picture));
                _strQuery += string.Format("p_category = '{0}' ", p_category);
                _strQuery += string.Format("WHERE p_name = '{0}' ", p_org_name);

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }


        public int Delete_Product(string p_name) {

            ArrayList _QueryArray = new ArrayList();

            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = string.Format("DELETE FROM Product_info WHERE p_name in {0} ", p_name);
                _QueryArray.Add(_strQuery);
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

        public DataTable ReadOrder() {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT odrp_num, s_num, P_name, odrp_memo, odrp_amount, odrp_time, to_char(odrp_time,'HH24:MI:SS') FROM order_product WHERE odrp_state is null ";
                _strQuery += "order by odrp_num ";
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "order_product");
            }
            return _dt;
        }
    }

}
