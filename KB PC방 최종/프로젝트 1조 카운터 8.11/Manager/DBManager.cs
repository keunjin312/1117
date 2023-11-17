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

namespace BookPro.Manager {
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

        // 공통 DB함수 ------------------------------
        public int ReadSeq(string v) {
            int _result = -1;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = string.Format("SELECT {0}.nextval  FROM DUAL", v);
                _result = Convert.ToInt32(m_OracleAssist.ExcuteScalar(_Connection, _strQuery));
            }
            return _result;
        }

        //직원관련 DB함수------------------------------------------------------------
        //20
        public DataTable ReadStaff(string aId, string aPwd) {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strFormat = " SELECT stf_id,stf_name,stf_regdate,stf_gender, ";
                _strFormat += "case when stf_pwd = '{0}' then 1 else 0 end chk_pwd, ";
                _strFormat += "case when stf_retiredate is null then 1 when stf_retiredate > sysdate then 1 else 0 end chk_retiredate, ";
                _strFormat += "case when stf_work_state = 'ON' then 1 else 0 end chk_work_state ";
                _strFormat += "FROM staff ";
                _strFormat += "WHERE stf_id = '{1}' ";

                string _strQuery = string.Format(_strFormat, aPwd, aId);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "staff");
            }

            return _dt;
        }
        public DataTable ReadStaff(int aKind, string aSeed) {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strFormat = " SELECT stf_id, stf_name, stf_pwd, stf_regdate, stf_retiredate";
                _strFormat += ", stf_work_state, stf_gender ";
                _strFormat += "FROM staff ";

                if (aSeed.Length > 0) {
                    if (aKind == 0) {
                        _strFormat += "WHERE stf_name LIKE '%{0}%' ";
                    }
                    else {
                        _strFormat += "WHERE stf_id LIKE '%{0}%' ";
                    }
                }

                string _strQuery = string.Format(_strFormat, aSeed);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "staff");
            }

            return _dt;
        }

        public DataRow ReadStaff(string aId) {
            DataRow _dr = null;
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strFormat = "SELECT stf_id, stf_name, stf_pwd, stf_regdate, stf_retiredate, stf_work_state, stf_gender, stf_picture ";
                _strFormat += "FROM staff ";
                _strFormat += "WHERE stf_id = '{0}' ";

                string _strQuery = string.Format(_strFormat, aId);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "staff");
                if (_dt != null && _dt.Rows != null && _dt.Rows.Count > 0) {
                    _dr = _dt.Rows[0];
                }
            }

            return _dr;
        }

        public int ModifyStaff(string stf_org_id, string stf_id, string stf_name, string stf_pwd, string stf_gender, DateTime stf_regdate, DateTime stf_retiredate, bool stf_retired, string stf_work_state, string str_picture) {
            //26
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = "UPDATE staff SET ";
                _strQuery += string.Format("stf_id = '{0}', ", stf_id);
                _strQuery += string.Format("stf_name = '{0}', ", stf_name);
                _strQuery += string.Format("stf_pwd = '{0}', ", stf_pwd);
                _strQuery += string.Format("stf_regdate = '{0}', ", stf_regdate.ToString("yyyy-MM-dd"));
                if (stf_retired == true) {
                    _strQuery += string.Format("stf_retiredate = '{0}', ", stf_retiredate.ToString("yyyy-MM-dd"));
                }
                else {
                    _strQuery += "stf_retiredate = NULL, ";
                }
                _strQuery += string.Format("stf_work_state = '{0}', ", stf_work_state);
                _strQuery += string.Format("stf_gender = '{0}', ", stf_gender);
                _strQuery += string.Format("stf_picture = {0} ", MakeToClobQuery(str_picture));
                _strQuery += string.Format("WHERE stf_id = '{0}' ", stf_org_id);

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        public int AddStaff(string stf_id, string stf_name, string stf_pwd, string stf_gender, DateTime stf_regdate, DateTime stf_retiredate, bool stf_retired, string stf_work_state, string stf_picture) {
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = " ";
                string _fieldsQuery = " ";
                string _valuesQuery = " ";
                _fieldsQuery += "stf_id,";
                _valuesQuery += string.Format("'{0}', ", stf_id);

                _fieldsQuery += "stf_name,";
                _valuesQuery += string.Format("'{0}', ", stf_name);

                _fieldsQuery += "stf_pwd,";
                _valuesQuery += string.Format("'{0}', ", stf_pwd);

                _fieldsQuery += "stf_regdate,";
                _valuesQuery += string.Format("'{0}', ", stf_regdate.ToString("yyyy-MM-dd"));

                if (stf_retired == true) {
                    _fieldsQuery += "stf_retiredate,";
                    _valuesQuery += string.Format("'{0}', ", stf_retiredate.ToString("yyyy-MM-dd"));
                }

                _fieldsQuery += "stf_work_state,";
                _valuesQuery += string.Format("'{0}', ", stf_work_state);

                _fieldsQuery += "stf_gender,";
                _valuesQuery += string.Format("'{0}', ", stf_gender);

                _fieldsQuery += "stf_picture ";
                _valuesQuery += string.Format("{0} ", MakeToClobQuery(stf_picture));

                _strQuery = "INSERT INTO staff(" + _fieldsQuery + ") VALUES (" + _valuesQuery + ")";

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        //장르관련 DB함수--------------------------------------------------------------
        public DataTable ReadCategory() {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                return null;
            }
            else {
                string _strQuery = "SELECT ctg_code,ctg_name FROM category ";
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "category");
            }
            return _dt;
        }


        //도서관련 DB함수--------------------------------------------------
        //30
        public DataTable ReadBook(int aKind, string aSeed) {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT bk_code, bk_title, bk_writer, bk_pubs, bk_price, bk_pub_year, bk_regdate, bk_erasedate, ctg.ctg_code,ctg.ctg_name ";
                _strQuery += ", NVL((SELECT case when  sysdate <= rnt_limit_date then '대여중' else '연체중' end  FROM rent rnt WHERE rnt.BK_CODE = bk.bk_code and rnt_return_date is null  ), '대기중') bk_state  ";  //31
                _strQuery += "FROM book bk ";
                _strQuery += "JOIN category ctg on bk.ctg_code = ctg.ctg_code ";
                if (aSeed.Length > 0) {
                    if (aKind == 0) {
                        _strQuery += string.Format("WHERE bk_title LIKE '%{0}%' ", aSeed); //제목
                    }
                    else if (aKind == 1) {
                        _strQuery += string.Format("WHERE bk.ctg_code = '{0}' ", aSeed); //분류
                    }
                    else if (aKind == 2) {
                        _strQuery += string.Format("WHERE bk_writer LIKE '%{0}%' ", aSeed); //저자
                    }
                    else {
                        _strQuery += string.Format("WHERE bk_pubs LIKE '%{0}%' ", aSeed); //출판사
                    }
                }

                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "category");
            }
            return _dt;
        }

        //33
        public int AddBook(string bk_code, string bk_title, string bk_writer, string bk_pubs, int bk_price, int bk_pub_year, DateTime bk_regdate, string ctg_code, string bk_picture) {
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = " ";
                string _fieldsQuery = " ";
                string _valuesQuery = " ";
                _fieldsQuery += "bk_code,";
                _valuesQuery += string.Format("'{0}', ", bk_code);
                _fieldsQuery += "bk_title,";
                _valuesQuery += string.Format("'{0}', ", bk_title);
                _fieldsQuery += "bk_writer,";
                _valuesQuery += string.Format("'{0}', ", bk_writer);
                _fieldsQuery += "bk_pubs,";
                _valuesQuery += string.Format("'{0}', ", bk_pubs);
                _fieldsQuery += "bk_price,";
                _valuesQuery += string.Format("{0}, ", bk_price);
                _fieldsQuery += "bk_pub_year,";
                _valuesQuery += string.Format("{0}, ", bk_pub_year);
                _fieldsQuery += "bk_regdate,";
                _valuesQuery += string.Format("'{0}', ", bk_regdate.ToString("yyyy-MM-dd"));
                _fieldsQuery += "ctg_code,";
                _valuesQuery += string.Format("'{0}', ", ctg_code);
                _fieldsQuery += "bk_picture";
                _valuesQuery += string.Format("{0} ", MakeToClobQuery(bk_picture));

                _strQuery = "INSERT INTO book(" + _fieldsQuery + ") VALUES (" + _valuesQuery + ")";

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }
        //34
        public DataRow ReadBook(string bk_code) {
            DataRow _dr = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strFormat = "SELECT bk_code, bk_title, bk_writer, bk_pubs, bk_price ";
                _strFormat += ", bk_pub_year, bk_regdate, bk_erasedate, ctg_code, bk_picture ";
                _strFormat += "FROM book WHERE bk_code = '{0}' ";
                string _strQuery = string.Format(_strFormat, bk_code);
                DataTable _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "book");
                if (_dt != null && _dt.Rows != null && _dt.Rows.Count > 0) {
                    _dr = _dt.Rows[0];
                }
            }
            return _dr;
        }
        //35
        public int ModifyBook(string bk_code, string bk_title, string bk_writer, string bk_pubs, int bk_price, int bk_pub_year, DateTime bk_regdate, string ctg_code, string bk_picture) {
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = "UPDATE book SET ";
                _strQuery += string.Format("bk_title = '{0}', ", bk_title);
                _strQuery += string.Format("bk_writer = '{0}', ", bk_writer);
                _strQuery += string.Format("bk_pubs = '{0}', ", bk_pubs);
                _strQuery += string.Format("bk_price = {0}, ", bk_price);
                _strQuery += string.Format("bk_pub_year = {0}, ", bk_pub_year);
                _strQuery += string.Format("bk_regdate = '{0}', ", bk_regdate.ToString("yyyy-MM-dd"));
                _strQuery += string.Format("ctg_code = '{0}', ", ctg_code);
                _strQuery += string.Format("bk_picture = {0} ", MakeToClobQuery(bk_picture));
                _strQuery += string.Format("WHERE bk_code = '{0}' ", bk_code);

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        public int DeleteBook(string bk_code) {
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = string.Format("DELETE FROM book WHERE bk_code = '{0}' ", bk_code);
                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        //회원관련 DB함수-------------------------------------------------

        public DataRow ReadMemberByUcode(int mbr_ucode) {
            //41
            DataRow _dr = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT mbr_ucode,mbr_name,mbr_id,mbr_pwd,mbr_gender,mbr_phone,mbr_addr,mbr_ban_date,mbr_picture ";
                _strQuery += string.Format("FROM member WHERE mbr_ucode = {0} ", mbr_ucode);
                DataTable _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
                if(_dt != null && _dt.Rows !=null && _dt.Rows.Count > 0) {
                    _dr = _dt.Rows[0];
                }
            }
            return _dr;
        }
        public DataTable ReadMemberById(string aId) {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT  mbr_ucode ";
                _strQuery += string.Format("FROM member  WHERE mbr_id = '{0}' ", aId);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
            }
            return _dt;
        }

        public DataTable ReadMemberByName(string aSeed) {
            //38
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT  mbr_ucode,mbr_name,mbr_id,mbr_pwd,mbr_gender,mbr_phone,mbr_addr,mbr_ban_date ";  //39
                _strQuery += ",(SELECT count(rnt.rnt_ucode) FROM rent rnt where rnt.mbr_ucode = mbr.mbr_ucode and rnt.rnt_return_date is null ) mbr_cnt_rent  ";
                _strQuery += ",(SELECT count(rnt.rnt_ucode) FROM rent rnt where rnt.mbr_ucode = mbr.mbr_ucode and rnt.rnt_return_date is null and  sysdate - rnt_limit_date>0 ) mbr_cnt_overdue ";
                _strQuery += "FROM member mbr ";
                if (aSeed.Length > 0) {
                    _strQuery += string.Format("WHERE mbr_name LIKE '%{0}%' ", aSeed); //출판사                
                }
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
            }
            return _dt;
            /*
    mbr_ucode,mbr_name,
    mbr_id,mbr_pwd,
    mbr_gender,mbr_phone,
    mbr_addr,mbr_ban_date,
    mbr_cnt_rent ,mbr_cnt_overdue 
////////////////////

    select M.Mbr_ucode, Mbr_name ,mbr_id,mbr_pwd,mbr_gender,mbr_phone,mbr_addr,mbr_ban_date, 
        count(Rnt_ucode) - count(Rnt_return_date) 현재대출도서수, 
        count(case when ((Rnt_return_date is null) and (Rnt_limit_date < sysdate)) then 1 end) 현재연체도서수 
    From member M
    Left Join rent R on M.Mbr_ucode = R.Mbr_ucode
    WHERE mbr_name LIKE '%이%'
    Group by M.Mbr_ucode, Mbr_name,mbr_id,mbr_pwd,mbr_gender,mbr_phone,mbr_addr,mbr_ban_date

    SELECT  mbr_ucode,mbr_name,mbr_id,mbr_pwd,mbr_gender,mbr_phone,mbr_addr,mbr_ban_date 
    ,(SELECT count(rnt.rnt_ucode) FROM rent rnt where rnt.mbr_ucode = mbr.mbr_ucode and rnt.rnt_return_date is null ) mbr_cnt_rent 
    ,(SELECT count(rnt.rnt_ucode) FROM rent rnt where rnt.mbr_ucode = mbr.mbr_ucode and rnt.rnt_return_date is null and  sysdate - rnt_limit_date>0 ) mbr_cnt_overdue
    FROM member mbr
    WHERE mbr_name LIKE '%이%'          
             */
        }
        public DataTable ReadMemberByState(string aSeed) {
            //38
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT  mbr_ucode,mbr_name,mbr_id,mbr_pwd,mbr_gender,mbr_phone,mbr_addr,mbr_ban_date ";  //39
                _strQuery += ",(SELECT count(rnt.rnt_ucode) FROM rent rnt where rnt.mbr_ucode = mbr.mbr_ucode and rnt.rnt_return_date is null ) mbr_cnt_rent  ";
                _strQuery += ",(SELECT count(rnt.rnt_ucode) FROM rent rnt where rnt.mbr_ucode = mbr.mbr_ucode and rnt.rnt_return_date is null and  sysdate - rnt_limit_date>0 ) mbr_cnt_overdue ";
                _strQuery += "FROM member mbr ";
                if (aSeed == "대여중") {
                    _strQuery += "WHERE (SELECT count(rnt.rnt_ucode) FROM rent rnt where rnt.mbr_ucode = mbr.mbr_ucode and rnt.rnt_return_date is null ) > 0 ";
                }
                else {
                    _strQuery += "WHERE (SELECT count(rnt.rnt_ucode) FROM rent rnt where rnt.mbr_ucode = mbr.mbr_ucode and rnt.rnt_return_date is null and  sysdate - rnt_limit_date>0 ) > 0 ";
                }
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
            }
            return _dt;
        }

        public DataTable ReadMemberByPhone(string aSeed) {
            //38
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT  mbr_ucode,mbr_name,mbr_id,mbr_pwd,mbr_gender,mbr_phone,mbr_addr,mbr_ban_date ";  //39
                _strQuery += ",(SELECT count(rnt.rnt_ucode) FROM rent rnt where rnt.mbr_ucode = mbr.mbr_ucode and rnt.rnt_return_date is null ) mbr_cnt_rent  ";
                _strQuery += ",(SELECT count(rnt.rnt_ucode) FROM rent rnt where rnt.mbr_ucode = mbr.mbr_ucode and rnt.rnt_return_date is null and  sysdate - rnt_limit_date>0 ) mbr_cnt_overdue ";
                _strQuery += "FROM member mbr ";
                if (aSeed.Length > 0) {
                    _strQuery += string.Format("WHERE mbr_phone LIKE '%{0}%' ", aSeed); //연락처             
                }
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
            }
            return _dt;
        }

        public int AddMember(string mbr_name, string mbr_id, string mbr_pwd, string mbr_gender, string mbr_phone, string mbr_addr, string mbr_picture) {
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = " ";
                string _fieldsQuery = " ";
                string _valuesQuery = " ";
                _fieldsQuery += "mbr_ucode,";
                _valuesQuery += "SEQ_MEMBER.nextval, ";
                _fieldsQuery += "mbr_name,";
                _valuesQuery += string.Format("'{0}', ", mbr_name);
                _fieldsQuery += "mbr_id,";
                _valuesQuery += string.Format("'{0}', ", mbr_id);
                _fieldsQuery += "mbr_pwd,";
                _valuesQuery += string.Format("'{0}', ", mbr_pwd);
                _fieldsQuery += "mbr_gender,";
                _valuesQuery += string.Format("'{0}', ", mbr_gender);
                _fieldsQuery += "mbr_phone,";
                _valuesQuery += string.Format("'{0}', ", mbr_phone);
                _fieldsQuery += "mbr_addr,";
                _valuesQuery += string.Format("'{0}', ", mbr_addr);
                _fieldsQuery += "mbr_picture";
                _valuesQuery += string.Format("{0} ", MakeToClobQuery(mbr_picture));

                _strQuery = "INSERT INTO member(" + _fieldsQuery + ") VALUES (" + _valuesQuery + ")";

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        public int ModifyMember(int mbr_ucode, string mbr_name, string mbr_id, string mbr_pwd, string mbr_gender, string mbr_phone, string mbr_addr, string mbr_picture) {
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = "UPDATE member SET ";
                    _strQuery += string.Format("mbr_name = '{0}', ", mbr_name);
                    _strQuery += string.Format("mbr_id = '{0}', ", mbr_id);
                    _strQuery += string.Format("mbr_pwd = '{0}', ", mbr_pwd);
                    _strQuery += string.Format("mbr_gender = '{0}', ", mbr_gender);
                    _strQuery += string.Format("mbr_phone = '{0}', ", mbr_phone);
                    _strQuery += string.Format("mbr_addr = '{0}', ", mbr_addr);
                    _strQuery += string.Format("mbr_picture = {0} ", MakeToClobQuery(mbr_picture));
                    _strQuery += string.Format("WHERE mbr_ucode = {0} ", mbr_ucode);

                _result = m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        //대여관련 DB함수 ----------------------------------

        //42
        public DataTable ReadRent(int kind, int rnt_seed, string seed, DateTime begin_date, DateTime end_date) {
            /*

             */
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT rnt_ucode, rnt_rent_date, rnt_return_date, rnt_limit_date, ";  //43
                _strQuery += "stf_reg_id, stf_return_id, rnt.bk_code,bk.bk_title, ";
                _strQuery += "ctg.ctg_name, rnt.mbr_ucode,mbr.mbr_name,mbr.mbr_phone ";
                _strQuery += "FROM rent rnt ";
                _strQuery += "JOIN book bk on rnt.bk_code = bk.bk_code ";
                _strQuery += "JOIN category ctg on bk.ctg_code = ctg.ctg_code ";
                _strQuery += "JOIN member mbr on rnt.mbr_ucode = mbr.mbr_ucode ";
                if (kind == 0) {
                    //대여일0
                    _strQuery += string.Format("WHERE rnt_rent_date BETWEEN '{0}' AND '{1}' "
                        ,begin_date.ToString("yyyy-MM-dd"), end_date.ToString("yyyy-MM-dd") );
                }
                else if (kind == 1) {
                    //반납예정일1
                    _strQuery += string.Format("WHERE rnt_limit_date BETWEEN '{0}' AND '{1}' "
                        , begin_date.ToString("yyyy-MM-dd"), end_date.ToString("yyyy-MM-dd"));
                }
                else if (kind == 2) {
                    //반납일2
                    _strQuery += string.Format("WHERE rnt_return_date BETWEEN '{0}' AND '{1}' "
                        , begin_date.ToString("yyyy-MM-dd"), end_date.ToString("yyyy-MM-dd"));
                }
                else if (kind == 3) {
                    //대여상태3
                    if(rnt_seed == 0) {
                        //거래완료
                        _strQuery += "WHERE rnt_return_date is not null ";
                    }
                    else if (rnt_seed == 1) {
                        //대여중
                        _strQuery += "WHERE rnt_return_date is null ";
                    }
                    else if (rnt_seed == 2) {
                        //연체중
                        _strQuery += "WHERE rnt_return_date is null AND rnt_limit_date < sysdate ";
                    }

                }
                else if (kind == 4) {
                    //회원이름4
                    if (seed.Length > 0) {
                        _strQuery += string.Format("WHERE mbr.mbr_name LIKE '%{0}%' ", seed);
                    }
                }
                else if (kind == 5) {
                    //회원연락처5
                    if (seed.Length > 0) {
                        _strQuery += string.Format("WHERE mbr.mbr_phone LIKE '%{0}%' ", seed);
                    }
                }

                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
            }
            return _dt;
        }

        public DataTable ReadRentByMemberUcode(int mbr_ucode) {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection != null) {
                string _strQuery = "SELECT rnt_ucode, rnt_rent_date, rnt_limit_date, rnt.bk_code,bk.bk_title, stf_reg_id ";
                _strQuery += "FROM rent rnt ";
                _strQuery += "JOIN book bk on rnt.bk_code = bk.bk_code ";
                _strQuery += string.Format("WHERE mbr_ucode = {0} and rnt_return_date is null ", mbr_ucode);
                _dt = m_OracleAssist.SelectQuery(_Connection, _strQuery, "member");
            }
            return _dt;            
        }

        public int ReturnRent(string rnt_ucodes, string sessionId, DateTime ban_date) {

            ArrayList _QueryArray = new ArrayList();
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strQuery = "UPDATE rent SET ";
                _strQuery += string.Format("stf_return_id = '{0}', ", sessionId);
                _strQuery += string.Format("rnt_return_date = sysdate ");
                _strQuery += string.Format("WHERE rnt_ucode in ({0}) ", rnt_ucodes);
                _QueryArray.Add( _strQuery );
                if (ban_date != null) {
                    _strQuery = String.Format("Update member Set mbr_ban_date = '{0}'", ban_date.ToString("yyyy-MM-dd"));
                    _QueryArray.Add(_strQuery);
                }
                _result = m_OracleAssist.ExcuteArrayQuery(_QueryArray);
            }
            return _result;
        }

        public int RentBooks(ArrayList bk_codes, int mbr_ucode, string sessionId) {
            ArrayList _QueryArray = new ArrayList();
            int _result = 0;
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null) {
                _result = -999;
            }
            else {
                string _strFormat = "INSERT INTO rent(rnt_ucode,rnt_rent_date,rnt_limit_date,bk_code,stf_reg_id,mbr_ucode) ";
                    _strFormat += "VALUES( SEQ_RENT.nextval, sysdate, sysdate+7, '{0}', '{1}',{2})";
                foreach (string bk_code in bk_codes) {
                    string _strQuery = string.Format(_strFormat, bk_code, sessionId, mbr_ucode);
                    _QueryArray.Add(_strQuery);
                }
                _result = m_OracleAssist.ExcuteArrayQuery(_QueryArray);
            }
            return _result;
        }
    }

}
