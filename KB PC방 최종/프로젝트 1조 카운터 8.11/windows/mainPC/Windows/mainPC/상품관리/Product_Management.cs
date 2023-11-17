﻿using Lib.Util;
using mainPC.Windows.mainPC.상품관리;
using PC.Manager;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace PC.Windows.mainPC.상품관리 {
    public partial class Product_Management : Form {
        private DataRow m_prod_row = null;
        private DataTable dt;
        private DataRow dr;

        public Product_Management() {
            InitializeComponent();
            Initialize();
        }

        private void Initialize() {
            cbox_category.SelectedIndex = 0;
        }

        private void btn_search_Click(object sender, EventArgs e) {            
            ReadProduct();
        }

        private void ReadProduct() {
            string _key = cbox_category.SelectedItem.ToString();
            switch (_key) { 
                case "전체":
                    SearchAll();
                    break;
                case "음료":
                    SearchByBeverage();
                    break;
                case "과자":
                    SearchBySnack();
                    break;
                case "라면":
                    SearchByRamen();
                    break;
                case "기타":
                    SearchByEtc();
                    break;
                default:
                    MessageBox.Show("검색조건을 선택하세요");
                    break;
            }
        }

        private void SearchAll() {
            string _seed = tbox_seed.Text;
            string _key = cbox_category.SelectedItem.ToString();
            if (_key == "전체") ;
            DataTable _dt = App.Self().DBManager.ReadProductAll(_seed);
            if (_dt != null) {
                DataTable _dp_product = DisplaySet.Tables["product_info"];
                _dp_product.Rows.Clear();
                foreach (DataRow row in _dt.Rows) {
                    DataRow _dp_row = _dp_product.NewRow();
                    _dp_row["p_name"] = row["p_name"];
                    _dp_row["p_price"] = row["p_price"];
                    _dp_row["p_category"] = row["p_category"];
                    _dp_product.Rows.Add(_dp_row);
                }
            }
        }
    
        private void SearchByBeverage() {
            string _seed = tbox_seed.Text;
            DataTable _dt = App.Self().DBManager.ReadProductbyBeverage(_seed);
            if (_dt != null) {
                DataTable _dp_product = DisplaySet.Tables["product_info"];
                _dp_product.Rows.Clear();
                foreach (DataRow row in _dt.Rows) {
                    DataRow _dp_row = _dp_product.NewRow();
                    _dp_row["p_name"] = row["p_name"];
                    _dp_row["p_price"] = row["p_price"];
                    _dp_row["p_category"] = row["p_category"];
                    _dp_product.Rows.Add(_dp_row);
                }
            }
        }

        private void SearchBySnack() {
            string _seed = tbox_seed.Text;
            DataTable _dt = App.Self().DBManager.ReadProductbySnack(_seed);
            if (_dt != null) {
                DataTable _dp_product = DisplaySet.Tables["product_info"];
                _dp_product.Rows.Clear();
                foreach (DataRow row in _dt.Rows) {
                    DataRow _dp_row = _dp_product.NewRow();
                    _dp_row["p_name"] = row["p_name"];
                    _dp_row["p_price"] = row["p_price"];
                    _dp_row["p_category"] = row["p_category"];
                    _dp_product.Rows.Add(_dp_row);
                }
            }
        }

        private void SearchByRamen() {
            string _seed = tbox_seed.Text;
            DataTable _dt = App.Self().DBManager.ReadProductbyRamen(_seed);
            if (_dt != null) {
                DataTable _dp_product = DisplaySet.Tables["product_info"];
                _dp_product.Rows.Clear();
                foreach (DataRow row in _dt.Rows) {
                    DataRow _dp_row = _dp_product.NewRow();
                    _dp_row["p_name"] = row["p_name"];
                    _dp_row["p_price"] = row["p_price"];
                    _dp_row["p_category"] = row["p_category"];
                    _dp_product.Rows.Add(_dp_row);
                }
            }
        }
    
        private void SearchByEtc() {
            string _seed = tbox_seed.Text;
            DataTable _dt = App.Self().DBManager.ReadProductbyEtc(_seed);
            if (_dt != null) {
                DataTable _dp_product = DisplaySet.Tables["product_info"];
                _dp_product.Rows.Clear();
                foreach (DataRow row in _dt.Rows) {
                    DataRow _dp_row = _dp_product.NewRow();
                    _dp_row["p_name"] = row["p_name"];
                    _dp_row["p_price"] = row["p_price"];
                    _dp_row["p_category"] = row["p_category"];
                    _dp_product.Rows.Add(_dp_row);
                }
            }
        }

        private void grid_main_SelectionChanged(object sender, EventArgs e) {
             if (grid_main.CurrentRow != null) {
                    DataRow _SelectedRow = GridAssist.SelectedRow(grid_main);
                    String p_name = _SelectedRow["p_name"].ToString();
                    DataRow _prod_row = App.Self().DBManager.ReadProduct(p_name);
                    if (_prod_row != null) {
                        m_prod_row = _prod_row;
                        DisplayProduct();
                    }
                btn_modifysave.Enabled = false;
                btn_modify.Enabled = true;
            }
        }

        private void DisplayProduct() {
            if (m_prod_row == null) {
                tbox_name.Text = "";
                tbox_price.Text = "";
                tbox_memo.Text = "";
                string _p_picture = "89504E470D0A1A0A0000000D49484452000000C2000000A70802000000CCBA148F000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000EC300000EC301C76FA86400000AA149444154785EED9D69575ACD1246EFFFFF21EF7B33272BF39C98C948C4017188821A9C704014937CBD7B519D733B07448D15E9C37AF6071674F7E95359BDA9AE4625FFF929C4A59146C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C28191D2A8D3E96C6E6E2E2F2F7F4D1B22244EA20D71179FD1D1885561854AA5D2E722409C4B4B4B2363D2E86854AFD7599E8FC581686BB55A88BEE08C8E46535353617D8A43B95C0ED1179CD1D1686262222C4E175608B15283A8427C5D484821FA82333A1AC53BDAECEC6CBBDD3E4A0FA2AA542A214A699420B1469C83426B7A105B88521A2548ACD1CECE4E684D0F620B514AA304914643441AF9D0E974B8E9F2F272B55A5D5858585D5D3D3C3CFCF1E347E88E90464933448D9ACD268533018C8F8F7FEAC29352A954ABD54E4E4EC2A05F48A3A4199646BBBBBBD3D3D3A813EE1D41E3CACA4ACE2469943443D188337C7C80EF0593389AC5BB9B344A9AA168D46834D8BCC25D4F815C15272469943457AF116535D574DFED2C86C05AAD56B8461A25CE50349A9B9B0BB71C083578B6AF49A3A4495923CA7069540CAE5E2338CF6FA730409B5A61188A46DBDBDB939393E1AEA740C652895D182EAF11FBCEF72E7D3F7DEE0BFBDAE2E2E2F8F878B8710F74C53B1A48A3A4B9A446C7C7C71B1B1BD56A152DB81C9942C7591C1C1C70557C7783131C8DEBEBEBB9A9A451D25C46231C5A5B5BCB92CA972F5F1A8DC6F94D3A3A3A5A5959E12A62C8989D9D65CBEB9D441A250D4B1216E7821A51B8204D6E63BAA849D06EB7C967A41F1890CFA451D2FC9946542D0C469A706544B95CDEDADABA9049E7411A25CD1F688443D4BF53A7FF2D005D7D37A6CB208D92E6A21AE110D5F1999F1FCECCCC30DBE0B3DBE0DE1CD228692EAA11A50C87B270C1402A95CADEDE5E5F57A8AB98875E1ECF2993344A9A0B69943B9A0D86611CE97B4DC2216A6A363E6E4D563B4DB51CD22869CEAF11B50ECB7F4E870C0693BA5AAD9689C2232272228B6BF301492B461A25CD393562999BCD66DFA3D960CC2444393A3ADADFDF5F5E5E8EEF689093E81A6C92344A9AF368C402B3CC54CD61DC05C124AE45261E7B1D32E6E7E7A9DC0798248D92E64C8D58DAC3C3C373FE6AC765C0A46CFBEB451A25CD991AB119B11385117F99AF5FBFEA0F8C0AC9608D3A9DCEEAEAEA85CAEACBC08D501671C3ED23A451D20CD088AC70D1A3D9E5E176F57A9D035D08E217D228694ED30887FEEC687679CC24126108A58B344A9AD334E268363D3D1D3AAE1C4C6A341AFAEDC7C2D057A376BB7D0547B3C1944A25B6D4ACDC964649D3AB11BBC9951DCD06C3964A486692344A9A9C46EC23EBEBEB575C560FA05C2E9BDCD22869721A6D6D6D9DF967D1570C26EDEDED49A3A48935AAD56AB92FEB4C844AA5C2D92DBC904609126B945A1E8A89639346C9116B5414A4517248A321228D8689344A0E693444A4D1309146C9218D86C8E86894F221FF3426262642F405677434AA542A677E0D6352102D3187E80BCEE868B4B3B373E637562505D1DA4FD94680D1D1E8FBF7EF5B5B5BD56A95E5F9923CC4F937BE6762588C8E46C0AAB45AAD66B3C9BB3C6588903847C62118298DC4B09046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C289846F57ABD5AADE6BEC8ECF0F070717191F6F867E6C7C7C74B4B4BA552E9DDBB779393932B2B2BBDDF5865D8FF64C5CCCC79727262BF6D02DFBE7D8BBF5006B6B7B7171616E85A5D5D6DB7DBA1B50BD7720BBA082634FD0EED844D30867DAB9F75753A9DEE0DF33061DFEF6B4B908269F4EAD5ABEBD7AFDFB871A356AB656BCCEADEBD7B97F64C94F5F5F5FBF7EF338CC66BD7AEF178F3E6CD67CF9EEDEDEDD980187461C0CB972F77777791A35C2EF312DEBC79B313FD5A19937FFEFCD9BAF0A0D96C868E2EDCF1D1A347744D4F4FF7AE3D42DCBB778F7808E6BF5D784ECC48492F3ED9B4399E3E7D9ABB4BB2144CA3E7CF9FFFD30527F6F7F7AD91FC812534DAFAB55A2DD6ECDF7FFFBD73E78EFD8E982D3F8BC755BDD90203B8D6D60C8D4860B68AB76FDF26258441DD618F1F3FEEDEFC9F9C61F0F1E3472EA1EBC9932739591B8D0691D0C5844C4E3C3C6239F19846044C2F97BF7FFFDE0236E6E6E64ECB6DA951488D9086B7357B9625A49C4613131338C4DB9DE56400B06B6C6E6EB24E34922DBA33FD9F5E8D6EDDBA8531ACFA870F1FB2859C9D9DB5F406398DD816B99C1830835BAFADADC5DB2BEED2C884E842241612A1B233F28401A611B7DBD8D8B0DE8CBEDF659B2085D4880DC836057BDFE734B2B7FEF8F878F78A005DEC442CF38B172F42D32FFA6A8440AF5FBF66ED718231DC686C6C8C3B328CDE9C46F3F3F3DC94F14C8E6424128B04B0103F989FEA2DE744F632D3887F88B5148E426A44A9F1E0C1039E4C4D4D51B2E4342251F19CE2C92E317867CFCCCCD0CE6E129A7ED157232A240A73A6B2EC45E678F8F0E1DBB76F3F7DFAC47AE7343241D901299C510DA528B3AC2B8BAD6F596648A3ABC6346287C20996879CC472F232D68815E53915895D62B0CB7050A2FD9C1A552A1564C5098A7AE6A7913443B102398DB8118611005B124E5368331BD7222EBD39C581544AD232988716D308881C7133186997A44F513562C12866A939A884F0E06F6844FEA0E625B5B03FB2A2DC8E335DAF46242D6C6647B37CC3602B9EACA8EAD58898796970212DA61161A32385544681FEA6B6A81AF11C2D586F5E52FCB2723C8935AAD7EBDD2B02E40686D17E7E8DE8A2E861668376DCCD69C478920A97E760BCED6B9946D9B9D2B09BC61A6953BB3A628D8025441A16C0DEE2A611A77D9EE7DECA1840D5CC60DB47620668C4BA9A25EC6ED43DB4E434A200B72A8D006268B1BA8D394D232E8F4B6C69344C721A6D6F6FDBB9CC308D1088E7AC10DB0A2B07EC68ACBA25156A67BB366380469CCF3976211FC5B57993D3882D953911344E36B6AF5124E1072F6DF3250B3286482C24FCB320199069C4BFCB7A33BAF31580626B042C21D5288D601AB12A2C092F49032845ED629F0DB2961CE07B3FD01BA011D04292383838B097B14668413C4C9B7D826570AC33B9A9A55081474B485C8861780CB8454BAC111112A7F51AC460B2A64FC134A2D4459A38F95382B0E3744F36D7D844AC91F73A0B490B898465E69145C2A1EC1C1E83468C4408FB6108DA3121BA84EEDFE1544FAF2527F6297634D24CAC3590C3988D3BA202CF6961246AC6F1F09C01636363F4A2112F7B61664E7CDD2953A7601AD56A35DEA3B98C4235CDAAD31E7F764C6662F1D892C81C2C27176692E520D3702D0BC6252415CEED54D66C97A1FB7768A7973B221C8741AC22F758168CC163422200D3087085A485A39CE978A497E4675D8C21805E161717B3318953308D449A4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E482371697EFEFC1F0B782AEBD39038FC0000000049454E44AE426082";
                byte[] _byte = HexStringToByteArray(_p_picture);
                pbox_picture.Image = new Bitmap(new MemoryStream(_byte));
                pbox_picture.Tag = null;                    
                cbox_datailcategory.Text = "";
            }
            else {
                tbox_name.Text = Convert.ToString(m_prod_row["p_name"]);
                tbox_price.Text = Convert.ToString(m_prod_row["p_price"]);
                tbox_memo.Text = Convert.ToString(m_prod_row["p_memo"]);                     
    
                string _p_picture = "";
                if (m_prod_row["p_picture"] != DBNull.Value) {
                _p_picture = Convert.ToString(m_prod_row["p_picture"]);
                }
                if (_p_picture.Length == 0) {
                _p_picture = "89504E470D0A1A0A0000000D49484452000000C2000000A70802000000CCBA148F000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000EC300000EC301C76FA86400000AA149444154785EED9D69575ACD1246EFFFFF21EF7B33272BF39C98C948C4017188821A9C704014937CBD7B519D733B07448D15E9C37AF6071674F7E95359BDA9AE4625FFF929C4A59146C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C28191D2A8D3E96C6E6E2E2F2F7F4D1B22244EA20D71179FD1D1885561854AA5D2E722409C4B4B4B2363D2E86854AFD7599E8FC581686BB55A88BEE08C8E46535353617D8A43B95C0ED1179CD1D1686262222C4E175608B15283A8427C5D484821FA82333A1AC53BDAECEC6CBBDD3E4A0FA2AA542A214A699420B1469C83426B7A105B88521A2548ACD1CECE4E684D0F620B514AA304914643441AF9D0E974B8E9F2F272B55A5D5858585D5D3D3C3CFCF1E347E88E90464933448D9ACD268533018C8F8F7FEAC29352A954ABD54E4E4EC2A05F48A3A4199646BBBBBBD3D3D3A813EE1D41E3CACA4ACE2469943443D188337C7C80EF0593389AC5BB9B344A9AA168D46834D8BCC25D4F815C15272469943457AF116535D574DFED2C86C05AAD56B8461A25CE50349A9B9B0BB71C083578B6AF49A3A4495923CA7069540CAE5E2338CF6FA730409B5A61188A46DBDBDB939393E1AEA740C652895D182EAF11FBCEF72E7D3F7DEE0BFBDAE2E2E2F8F878B8710F74C53B1A48A3A4B9A446C7C7C71B1B1BD56A152DB81C9942C7591C1C1C70557C7783131C8DEBEBEBB9A9A451D25C46231C5A5B5BCB92CA972F5F1A8DC6F94D3A3A3A5A5959E12A62C8989D9D65CBEB9D441A250D4B1216E7821A51B8204D6E63BAA849D06EB7C967A41F1890CFA451D2FC9946542D0C469A706544B95CDEDADABA9049E7411A25CD1F688443D4BF53A7FF2D005D7D37A6CB208D92E6A21AE110D5F1999F1FCECCCC30DBE0B3DBE0DE1CD228692EAA11A50C87B270C1402A95CADEDE5E5F57A8AB98875E1ECF2993344A9A0B69943B9A0D86611CE97B4DC2216A6A363E6E4D563B4DB51CD22869CEAF11B50ECB7F4E870C0693BA5AAD9689C2232272228B6BF301492B461A25CD393562999BCD66DFA3D960CC2444393A3ADADFDF5F5E5E8EEF689093E81A6C92344A9AF368C402B3CC54CD61DC05C124AE45261E7B1D32E6E7E7A9DC0798248D92E64C8D58DAC3C3C373FE6AC765C0A46CFBEB451A25CD991AB119B11385117F99AF5FBFEA0F8C0AC9608D3A9DCEEAEAEA85CAEACBC08D501671C3ED23A451D20CD088AC70D1A3D9E5E176F57A9D035D08E217D228694ED30887FEEC687679CC24126108A58B344A9AD334E268363D3D1D3AAE1C4C6A341AFAEDC7C2D057A376BB7D0547B3C1944A25B6D4ACDC964649D3AB11BBC9951DCD06C3964A486692344A9A9C46EC23EBEBEB575C560FA05C2E9BDCD22869721A6D6D6D9DF967D1570C26EDEDED49A3A48935AAD56AB92FEB4C844AA5C2D92DBC904609126B945A1E8A89639346C9116B5414A4517248A321228D8689344A0E693444A4D1309146C9218D86C8E86894F221FF3426262642F405677434AA542A677E0D6352102D3187E80BCEE868B4B3B373E637562505D1DA4FD94680D1D1E8FBF7EF5B5B5BD56A95E5F9923CC4F937BE6762588C8E46C0AAB45AAD66B3C9BB3C6588903847C62118298DC4B09046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C9046C20169241C289846F57ABD5AADE6BEC8ECF0F070717191F6F867E6C7C7C74B4B4BA552E9DDBB779393932B2B2BBDDF5865D8FF64C5CCCC79727262BF6D02DFBE7D8BBF5006B6B7B7171616E85A5D5D6DB7DBA1B50BD7720BBA082634FD0EED844D30867DAB9F75753A9DEE0DF33061DFEF6B4B908269F4EAD5ABEBD7AFDFB871A356AB656BCCEADEBD7B97F64C94F5F5F5FBF7EF338CC66BD7AEF178F3E6CD67CF9EEDEDEDD980187461C0CB972F77777791A35C2EF312DEBC79B313FD5A19937FFEFCD9BAF0A0D96C868E2EDCF1D1A347744D4F4FF7AE3D42DCBB778F7808E6BF5D784ECC48492F3ED9B4399E3E7D9ABB4BB2144CA3E7CF9FFFD30527F6F7F7AD91FC812534DAFAB55A2DD6ECDF7FFFBD73E78EFD8E982D3F8BC755BDD90203B8D6D60C8D4860B68AB76FDF26258441DD618F1F3FEEDEFC9F9C61F0F1E3472EA1EBC9932739591B8D0691D0C5844C4E3C3C6239F19846044C2F97BF7FFFDE0236E6E6E64ECB6DA951488D9086B7357B9625A49C4613131338C4DB9DE56400B06B6C6E6EB24E34922DBA33FD9F5E8D6EDDBA8531ACFA870F1FB2859C9D9DB5F406398DD816B99C1830835BAFADADC5DB2BEED2C884E842241612A1B233F28401A611B7DBD8D8B0DE8CBEDF659B2085D4880DC836057BDFE734B2B7FEF8F878F78A005DEC442CF38B172F42D32FFA6A8440AF5FBF66ED718231DC686C6C8C3B328CDE9C46F3F3F3DC94F14C8E6424128B04B0103F989FEA2DE744F632D3887F88B5148E426A44A9F1E0C1039E4C4D4D51B2E4342251F19CE2C92E317867CFCCCCD0CE6E129A7ED157232A240A73A6B2EC45E678F8F0E1DBB76F3F7DFAC47AE7343241D901299C510DA528B3AC2B8BAD6F596648A3ABC6346287C20996879CC472F232D68815E53915895D62B0CB7050A2FD9C1A552A1564C5098A7AE6A7913443B102398DB8118611005B124E5368331BD7222EBD39C581544AD232988716D308881C7133186997A44F513562C12866A939A884F0E06F6844FEA0E625B5B03FB2A2DC8E335DAF46242D6C6647B37CC3602B9EACA8EAD58898796970212DA61161A32385544681FEA6B6A81AF11C2D586F5E52FCB2723C8935AAD7EBDD2B02E40686D17E7E8DE8A2E861668376DCCD69C478920A97E760BCED6B9946D9B9D2B09BC61A6953BB3A628D8025441A16C0DEE2A611A77D9EE7DECA1840D5CC60DB47620668C4BA9A25EC6ED43DB4E434A200B72A8D006268B1BA8D394D232E8F4B6C69344C721A6D6F6FDBB9CC308D1088E7AC10DB0A2B07EC68ACBA25156A67BB366380469CCF3976211FC5B57993D3882D953911344E36B6AF5124E1072F6DF3250B3286482C24FCB320199069C4BFCB7A33BAF31580626B042C21D5288D601AB12A2C092F49032845ED629F0DB2961CE07B3FD01BA011D04292383838B097B14668413C4C9B7D826570AC33B9A9A55081474B485C8861780CB8454BAC111112A7F51AC460B2A64FC134A2D4459A38F95382B0E3744F36D7D844AC91F73A0B490B898465E69145C2A1EC1C1E83468C4408FB6108DA3121BA84EEDFE1544FAF2527F6297634D24CAC3590C3988D3BA202CF6961246AC6F1F09C01636363F4A2112F7B61664E7CDD2953A7601AD56A35DEA3B98C4235CDAAD31E7F764C6662F1D892C81C2C27176692E520D3702D0BC6252415CEED54D66C97A1FB7768A7973B221C8741AC22F758168CC163422200D3087085A485A39CE978A497E4675D8C21805E161717B3318953308D449A4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E4823E18034120E482371697EFEFC1F0B782AEBD39038FC0000000049454E44AE426082";
                }    
                byte[] _byte = HexStringToByteArray(_p_picture);
                pbox_picture.Image = new Bitmap(new MemoryStream(_byte));
                if (m_prod_row["p_picture"] != DBNull.Value) {
                    pbox_picture.Tag = _p_picture;
                }
                else {
                    pbox_picture.Tag = null;
                }
                cbox_datailcategory.Text = Convert.ToString(m_prod_row["p_category"]);
            }                
        }

        private byte[] HexStringToByteArray(string hex) {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            if (NumberChars % 2 == 0) {
                for (int i = 0; i < NumberChars; i += 2) {
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                }
            }
            return bytes;
        }
 
        private void btn_add_Click(object sender, EventArgs e) {
            Product_add_Pop _pop = new Product_add_Pop();
            _pop.ShowDialog(this);
        }
        private bool ValidateTest() {
            return true;
        }
        private void btn_modifysave_Click(object sender, EventArgs e) {            
            if (ValidateTest()) {
                string _p_org_name = Convert.ToString(m_prod_row["p_name"]);                
                string _p_name = tbox_name.Text;
                string _p_price = tbox_price.Text;
                string _p_memo = tbox_memo.Text;
                string _p_picture = "";
                if (pbox_picture.Tag != null) {
                    _p_picture = pbox_picture.Tag.ToString();
                }

                string _p_category = cbox_datailcategory.Text;
                int _result = App.Self().DBManager.ModifyProduct(_p_org_name,
                    _p_name, _p_price, _p_memo, _p_picture, _p_category);
                if (_result > 0) {
                    MessageBox.Show("수정성공");
                }
                else {
                    MessageBox.Show("수정실패");                    
                }

                btn_picture.Enabled = false;
                cbox_datailcategory.Enabled = false;
                tbox_name.ReadOnly = true;
                tbox_price.ReadOnly = true;
                tbox_memo.ReadOnly = true;

                btn_modifysave.Enabled = false;
                btn_modify.Enabled = true;
            }
        }

        private void Product_Management_Load(object sender, EventArgs e) {        
        ReadProduct();
        }

        private void btn_close_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_delete_Click(object sender, EventArgs e) {
            DataTable _dp_product_info = DisplaySet.Tables["product_info"];
            DataRow[] _rows = _dp_product_info.Select("grid_select = true");      
            string _prod_names = "(";
            foreach (DataRow _row in _rows) {
                if (_prod_names.Length > 1) {
                    _prod_names += ","; 
                }
                _prod_names += "'"+_row["p_name"].ToString()+ "'";                
            }
            _prod_names += ")";
            if (_prod_names.Length > 4) {
                DataRow _dp_row = GridAssist.SelectedRow(grid_main);
                if (_dp_row != null) {
                    string _msg = string.Format("정말로 삭제하시겠습니까?");
                    if (MessageBox.Show(_msg, "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        
                        int _result = App.Self().DBManager.Delete_Product(_prod_names);
                        if (_result > 0) {
                            MessageBox.Show("삭제되었습니다.");
                        }
                        else {
                            MessageBox.Show("삭제중 오류가 발생했습니다.");
                        }
                    }
                }
            }
            else {
                MessageBox.Show("선택된 항목이 없습니다.");
            }
        }
                
        private void btn_modify_Click(object sender, EventArgs e) {
            btn_picture.Enabled = true;
            cbox_datailcategory.Enabled = true;
            tbox_name.ReadOnly = false;
            tbox_price.ReadOnly = false;
            tbox_memo.ReadOnly = false;

            btn_modifysave.Enabled = true;
            btn_modify.Enabled = false;
        }

        private void btn_modifyclose_Click(object sender, EventArgs e) {            
            btn_picture.Enabled = false;
            cbox_datailcategory.Enabled = false;
            tbox_name.ReadOnly = true;
            tbox_price.ReadOnly = true;
            tbox_memo.ReadOnly = true;
            DisplayProduct();

            btn_modifysave.Enabled = false;
            btn_modify.Enabled = true;
        }    
 

        private void btn_picture_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            string _image_file = string.Empty;
            ofd.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp|all files|*.*";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK) {
                _image_file = ofd.FileName;
                pbox_picture.Image = Bitmap.FromFile(_image_file);

                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read); ;
                byte[] bImage = new byte[fs.Length];
                fs.Read(bImage, 0, (int)fs.Length);

                StringBuilder hex = new StringBuilder(bImage.Length * 2);
                foreach (byte b in bImage) {
                    hex.AppendFormat("{0:X2}", b);
                }
                string _hex_image = hex.ToString();
                pbox_picture.Tag = _hex_image;
            }
        }
    }
}
