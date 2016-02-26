using System.Windows.Forms;

namespace LoginSrv
{
    public partial class TFrmFindUserId : Form
    {
        public static TFrmFindUserId FrmFindUserId = null;

        public TFrmFindUserId()
        {
            InitializeComponent();
        }

        // Note: the original parameters are Object Sender, ref char Key
        public void EdFindIdKeyPress(System.Object Sender, System.Windows.Forms.KeyPressEventArgs _e1)
        {
            string sAccount;
            int n08;
            int nIndex;
            TAccountDBRecord DBRecord;

            //if (Key != '\r')
            //{
            //    return;
            //}
            //sAccount = EdFindId.Text.Trim();
            //IdGrid.RowCount = 1;
            //try {
            //    if (IDDB.Units.IDDB.AccountDB.Open())
            //    {
            //        n08 = IDDB.Units.IDDB.AccountDB.Index(sAccount);
            //        if (n08 >= 0)
            //        {
            //            nIndex = IDDB.Units.IDDB.AccountDB.Get(n08, ref DBRecord);
            //            if (nIndex >= 0)
            //            {
            //                RefChrGrid( -1, ref DBRecord);
            //            }
            //        }
            //    }
            //} finally {
            //    IDDB.Units.IDDB.AccountDB.Close();
            //}
        }

        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            ////@ Unsupported property or method(C): 'RowCount'
            //IdGrid.RowCount = 2;
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[0, 0] = "帐号";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[1, 0] = "密码";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[2, 0] = "用户名称";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[3, 0] = "身份证号";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[4, 0] = "生日";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[5, 0] = "问题一";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[6, 0] = "答案一";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[7, 0] = "问题二";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[8, 0] = "答案二";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[9, 0] = "电话";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[10, 0] = "移动电话";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[11, 0] = "备注一";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[12, 0] = "备注二";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[13, 0] = "创建时间";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[14, 0] = "最后登录时间";
            ////@ Unsupported property or method(A): 'Cells'
            //IdGrid.Cells[15, 0] = "电子邮箱";
        }

        public void BtnFindAllClick(System.Object Sender, System.EventArgs _e1)
        {
            //string sAccount;
            //List<string> AccountList;
            //int I;
            //int nIndex;
            //TAccountDBRecord DBRecord;
            //try {
            //    //@ Unsupported property or method(C): 'RowCount'
            //    IdGrid.RowCount = 1;
            //    sAccount = EdFindId.Text.Trim();
            //    if (sAccount == "")
            //    {
            //        return;
            //    }
            //    AccountList = new List<string>();
            //    try {
            //        if (IDDB.Units.IDDB.AccountDB.Open())
            //        {
            //            if (IDDB.Units.IDDB.AccountDB.FindByName(sAccount, ref AccountList) > 0)
            //            {
            //                for (I = 0; I < AccountList.Count; I ++ )
            //                {
            //                    //@ Unsupported property or method(A): 'Values'
            //                    nIndex = ((int)AccountList.Values[I]);
            //                    if (IDDB.Units.IDDB.AccountDB.GetBy(nIndex, ref DBRecord))
            //                    {
            //                        RefChrGrid( -1, ref DBRecord);
            //                    }
            //                }
            //            }
            //        }
            //    } finally {
            //        IDDB.Units.IDDB.AccountDB.Close();
            //    }
            //    //@ Unsupported property or method(C): 'Free'
            //    AccountList.Free;
            //}
            //catch {
            //    LSShare.Units.LSShare.MainOutMessage("TFrmFindUserId.BtnFindAllClick");
            //}
        }

        public void Button1Click(System.Object Sender, System.EventArgs _e1)
        {
            // MasSock.Units.MasSock.FrmMasSoc.LoadServerAddr();
        }

        // 0x00467D84
        public void BtnEditClick(System.Object Sender, System.EventArgs _e1)
        {
            //int nRow;
            //int nIndex;
            //string sAccount;
            //TAccountDBRecord DBRecord;
            //bool bo11;
            //bool bo12;
            //TConfig Config;
            //const string sEditAccount = "ch2";
            //Config = LSShare.g_Config;
            //nRow = IdGrid.CurrentRowIndex;
            //if (nRow <= 0)
            //{
            //    return;
            //}
            //sAccount = IdGrid.Cells[0, nRow];
            //if (sAccount == "")
            //{
            //    return;
            //}
            //bo11 = false;
            //try {
            //    if (IDDB.Units.IDDB.AccountDB.OpenEx())
            //    {
            //        nIndex = IDDB.Units.IDDB.AccountDB.Index(sAccount);
            //        if (nIndex >= 0)
            //        {
            //            if (IDDB.Units.IDDB.AccountDB.Get(nIndex, ref DBRecord) >= 0)
            //            {
            //                bo11 = true;
            //            }
            //        }
            //    }
            //} finally {
            //    IDDB.Units.IDDB.AccountDB.Close();
            //}
            //if (EditUserInfo.Units.EditUserInfo.FrmUserInfoEdit.sub_466AEC(ref DBRecord))
            //{
            //    try {
            //        if (IDDB.Units.IDDB.AccountDB.Open())
            //        {
            //            nIndex = IDDB.Units.IDDB.AccountDB.Index(sAccount);
            //            if (nIndex >= 0)
            //            {
            //                if (IDDB.Units.IDDB.AccountDB.Update(nIndex, ref DBRecord))
            //                {
            //                    RefChrGrid(nRow, ref DBRecord);
            //                    bo12 = true;
            //                }
            //            }
            //        }
            //    } finally {
            //        IDDB.Units.IDDB.AccountDB.Close();
            //    }
            //}
            //if (bo12)
            //{
            //    // 00467F34
            //    LMain.Units.LMain.WriteLogMsg(Config, sEditAccount, ref DBRecord.UserEntry, ref DBRecord.UserEntryAdd);
            //}
        }

        // 00467F94
        public void Button2Click(System.Object Sender, System.EventArgs _e1)
        {
            //TAccountDBRecord DBRecord;
            //string sAccount;
            //int nIndex;
            //bool boMakeSuccess;
            //TConfig Config;
            //const string sAddAccount = "ch2";
            //const string sMakingIDSuccess = "创建帐号成功: %s";
            //Config = LSShare.g_Config;
            //FillChar(DBRecord, sizeof(TAccountDBRecord), '\0');
            //boMakeSuccess = false;
            //if (EditUserInfo.Units.EditUserInfo.FrmUserInfoEdit.sub_466B10(true, ref DBRecord) && (DBRecord.UserEntry.sAccount != ""))
            //{
            //    sAccount = DBRecord.UserEntry.sAccount;
            //    DBRecord.Header.sAccount = sAccount;
            //    try
            //    {
            //        if (IDDB.Units.IDDB.AccountDB.Open())
            //        {
            //            nIndex = IDDB.Units.IDDB.AccountDB.Index(sAccount);
            //            if (nIndex < 0)
            //            {
            //                if (IDDB.Units.IDDB.AccountDB.Add(ref DBRecord))
            //                {
            //                    boMakeSuccess = true;
            //                }
            //            }
            //        }
            //    }
            //    finally
            //    {
            //        IDDB.Units.IDDB.AccountDB.Close();
            //    }
            //}
            //if (boMakeSuccess)
            //{
            //    LSShare.MainOutMessage(Format(sMakingIDSuccess, new string[] { sAccount }));
            //    LMain.WriteLogMsg(Config, sAddAccount, ref DBRecord.UserEntry, ref DBRecord.UserEntryAdd);
            //}
        }

        private void RefChrGrid(int nIndex, ref TAccountDBRecord DBRecord)
        {
            int nRow;
            try
            {
                if (nIndex <= 0)
                {
                    //IdGrid.RowCount = IdGrid.RowCount + 1;
                    //IdGrid.FixedRows = 1;
                    //nRow = IdGrid.RowCount - 1;
                }
                else
                {
                    nRow = nIndex;
                }
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[0, nRow] = DBRecord.UserEntry.sAccount;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[1, nRow] = DBRecord.UserEntry.sPassword;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[2, nRow] = DBRecord.UserEntry.sUserName;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[3, nRow] = DBRecord.UserEntry.sSSNo;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[4, nRow] = DBRecord.UserEntryAdd.sBirthDay;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[5, nRow] = DBRecord.UserEntry.sQuiz;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[6, nRow] = DBRecord.UserEntry.sAnswer;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[7, nRow] = DBRecord.UserEntryAdd.sQuiz2;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[8, nRow] = DBRecord.UserEntryAdd.sAnswer2;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[9, nRow] = DBRecord.UserEntry.sPhone;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[10, nRow] = DBRecord.UserEntryAdd.sMobilePhone;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[11, nRow] = DBRecord.UserEntryAdd.sMemo;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[12, nRow] = DBRecord.UserEntryAdd.sMemo2;
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[13, nRow] = (DBRecord.Header.CreateDate).ToString();
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[14, nRow] = (DBRecord.Header.UpdateDate).ToString();
                ////@ Unsupported property or method(A): 'Cells'
                //IdGrid.Cells[15, nRow] = DBRecord.UserEntry.sEMail;
            }
            catch
            {
            }
        }
    }
}