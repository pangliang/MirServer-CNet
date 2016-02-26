using System;
using System.Windows.Forms;
using GameFramework;

namespace M2Server
{
    public partial class TfrmGameCmd: Form
    {
        private int nRefGameUserIndex = 0;
        private int nRefGameMasterIndex = 0;
        private int nRefGameDebugIndex = 0;
        public static TfrmGameCmd frmGameCmd = null;
        public TfrmGameCmd()
        {
            InitializeComponent();
        }

//        public void FormCreate(object sender, EventArgs e)
//        {
//            PageControl.SelectedIndex = 0;
            
//            StringGridGameCmd.RowCount = 50;
            
//            StringGridGameCmd.Cells[0, 0] = "游戏命令";
            
//            StringGridGameCmd.Cells[1, 0] = "所需权限";
            
//            StringGridGameCmd.Cells[2, 0] = "命令格式";
            
//            StringGridGameCmd.Cells[3, 0] = "命令说明";
            
//            StringGridGameMasterCmd.RowCount = 105;
            
//            StringGridGameMasterCmd.Cells[0, 0] = "游戏命令";
            
//            StringGridGameMasterCmd.Cells[1, 0] = "所需权限";
            
//            StringGridGameMasterCmd.Cells[2, 0] = "命令格式";
            
//            StringGridGameMasterCmd.Cells[3, 0] = "命令说明";
            
//            StringGridGameDebugCmd.RowCount = 41;
            
//            StringGridGameDebugCmd.Cells[0, 0] = "游戏命令";
            
//            StringGridGameDebugCmd.Cells[1, 0] = "所需权限";
            
//            StringGridGameDebugCmd.Cells[2, 0] = "命令格式";
            
//            StringGridGameDebugCmd.Cells[3, 0] = "命令说明";
//        }

        public void Open()
        {
            //RefUserCommand();
            //RefGameMasterCommand();
            //RefDebugCommand();
            this.ShowDialog();
        }

        private void RefGameUserCmd(TGameCmd GameCmd, string sCmdParam, string sDesc)
        {
            nRefGameUserIndex++;

            //if (StringGridGameCmd.RowCount - 1 < nRefGameUserIndex)
            //{
            //    StringGridGameCmd.RowCount = nRefGameUserIndex + 1;
            //}

            //StringGridGameCmd.Cells[0, nRefGameUserIndex] = GameCmd.sCmd;

            //StringGridGameCmd.Cells[1, nRefGameUserIndex] = (GameCmd.nPermissionMin).ToString() + "/" + (GameCmd.nPermissionMax).ToString();

            //StringGridGameCmd.Cells[2, nRefGameUserIndex] = sCmdParam;

            //StringGridGameCmd.Cells[3, nRefGameUserIndex] = sDesc;

            //StringGridGameCmd.Objects[0, nRefGameUserIndex] = ((GameCmd) as Object);
        }

//        // StringGridGameCmd.Cells[3,12]:='未使用';
//        // StringGridGameCmd.Cells[3,13]:='移动地图指定座标(需要戴传送装备)';
//        // StringGridGameCmd.Cells[3,14]:='探测人物所在位置(需要戴传送装备)';
//        // StringGridGameCmd.Cells[3,15]:='允许记忆传送';
//        // StringGridGameCmd.Cells[3,16]:='将组队人员传送到身边(需要戴记忆全套装备)';
//        // StringGridGameCmd.Cells[3,17]:='允许行会传送';
//        // StringGridGameCmd.Cells[3,18]:='将行会成员传送身边(需要戴行会传送装备)';
//        // StringGridGameCmd.Cells[3,19]:='开启仓库密码锁';
//        // StringGridGameCmd.Cells[3,20]:='开启登录密码锁';
//        // StringGridGameCmd.Cells[3,21]:='将仓库密码锁上';
//        // StringGridGameCmd.Cells[3,22]:='设置仓库密码';
//        // StringGridGameCmd.Cells[3,23]:='修改仓库密码';
//        // StringGridGameCmd.Cells[3,24]:='清除密码(先开锁再清除密码)';
//        // StringGridGameCmd.Cells[3,25]:='未使用';
//        // StringGridGameCmd.Cells[3,26]:='查询夫妻位置';
//        // StringGridGameCmd.Cells[3,27]:='允许夫妻传送';
//        // StringGridGameCmd.Cells[3,28]:='夫妻将对方传送到身边';
//        // StringGridGameCmd.Cells[3,29]:='查询师徒位置';
//        // StringGridGameCmd.Cells[3,30]:='允许师徒传送';
//        // StringGridGameCmd.Cells[3,31]:='师父将徒弟召唤到身边';
//        // StringGridGameCmd.Cells[3,32]:='更换攻击模式(此命令不要修改)';
//        // StringGridGameCmd.Cells[3,33]:='宝宝攻击状态(此命令不要修改)';
//        // StringGridGameCmd.Cells[3,34]:='带马牌后骑上马';
//        // StringGridGameCmd.Cells[3,35]:='从马上下来';
//        // StringGridGameCmd.Cells[3,36]:='';
//        // StringGridGameCmd.Cells[3,37]:='开启/关闭登录锁';

//        private void RefUserCommand()
//        {
//            EditUserCmdOK.Enabled = false;
//            nRefGameUserIndex = 0;
//            RefGameUserCmd(M2Share.g_GameCommand.Data, "@" + M2Share.g_GameCommand.Data.sCmd, "查看当前服务器日期时间");
//            RefGameUserCmd(M2Share.g_GameCommand.PRVMSG, "@" + M2Share.g_GameCommand.PRVMSG.sCmd, "禁止指定人物发的私聊信息");
//            RefGameUserCmd(M2Share.g_GameCommand.ALLOWMSG, "@" + M2Share.g_GameCommand.ALLOWMSG.sCmd, "禁止别人向自己发私聊信息");
//            RefGameUserCmd(M2Share.g_GameCommand.LETSHOUT, "@" + M2Share.g_GameCommand.LETSHOUT.sCmd, "禁止接收组队聊天信息");
//            // RefGameUserCmd(@g_GameCommand.BANGMMSG, //拒绝所有喊话信息 20080211
//            // '@' + g_GameCommand.BANGMMSG.sCmd,
//            // '禁止接收所有喊话信息');
//            RefGameUserCmd(M2Share.g_GameCommand.LETTRADE, "@" + M2Share.g_GameCommand.LETTRADE.sCmd, "禁止交易交易物品");
//            RefGameUserCmd(M2Share.g_GameCommand.LETGUILD, "@" + M2Share.g_GameCommand.LETGUILD.sCmd, "允许加入行会");
//            RefGameUserCmd(M2Share.g_GameCommand.ENDGUILD, "@" + M2Share.g_GameCommand.ENDGUILD.sCmd, "退出当前所加入的行会");
//            RefGameUserCmd(M2Share.g_GameCommand.BANGUILDCHAT, "@" + M2Share.g_GameCommand.BANGUILDCHAT.sCmd, "禁止接收行会聊天信息");
//            RefGameUserCmd(M2Share.g_GameCommand.AUTHALLY, "@" + M2Share.g_GameCommand.AUTHALLY.sCmd, "许行会进入联盟");
//            RefGameUserCmd(M2Share.g_GameCommand.AUTH, "@" + M2Share.g_GameCommand.AUTH.sCmd, "开始进行行会联盟(命令格式需为@Alliance,否则游戏里则无法联盟)");
//            RefGameUserCmd(M2Share.g_GameCommand.AUTHCANCEL, "@" + M2Share.g_GameCommand.AUTHCANCEL.sCmd, "取消行会联盟关系(命令格式需为@CancelAlliance,否则游戏里则无法取消联盟)");
//            // Exit;//20080823
//            RefGameUserCmd(M2Share.g_GameCommand.USERMOVE, "@" + M2Share.g_GameCommand.USERMOVE.sCmd + "  座标X  座标Y", "传送到指定坐标");
//            RefGameUserCmd(M2Share.g_GameCommand.SEARCHING, "@" + M2Share.g_GameCommand.SEARCHING.sCmd + " 人物名称", "探测指定人物在何处");
//            RefGameUserCmd(M2Share.g_GameCommand.ALLOWGROUPCALL, "@" + M2Share.g_GameCommand.ALLOWGROUPCALL.sCmd, "允许天地合一(此命令用于允许或禁止编组传送功能)");
//            RefGameUserCmd(M2Share.g_GameCommand.GROUPRECALLL, "@" + M2Share.g_GameCommand.GROUPRECALLL.sCmd, "天地合一");
//            RefGameUserCmd(M2Share.g_GameCommand.ALLOWGUILDRECALL, "@" + M2Share.g_GameCommand.ALLOWGUILDRECALL.sCmd, "允许行会合一(行会传送，行会掌门人可以将整个行会成员全部集中)");
//            RefGameUserCmd(M2Share.g_GameCommand.GUILDRECALLL, "@" + M2Share.g_GameCommand.GUILDRECALLL.sCmd, "行会合一");
//            RefGameUserCmd(M2Share.g_GameCommand.UNLOCKSTORAGE, "@" + M2Share.g_GameCommand.UNLOCKSTORAGE.sCmd, "仓库开锁");
//            RefGameUserCmd(M2Share.g_GameCommand.UnLock, "@" + M2Share.g_GameCommand.UnLock.sCmd, "开锁");
//            RefGameUserCmd(M2Share.g_GameCommand.__Lock, "@" + M2Share.g_GameCommand.__Lock.sCmd, "锁定仓库");
//            RefGameUserCmd(M2Share.g_GameCommand.SETPASSWORD, "@" + M2Share.g_GameCommand.SETPASSWORD.sCmd, "设置密码");
//            RefGameUserCmd(M2Share.g_GameCommand.CHGPASSWORD, "@" + M2Share.g_GameCommand.CHGPASSWORD.sCmd, "修改密码");
//            RefGameUserCmd(M2Share.g_GameCommand.UNPASSWORD, "@" + M2Share.g_GameCommand.UNPASSWORD.sCmd, "清除密码");
//            RefGameUserCmd(M2Share.g_GameCommand.MEMBERFUNCTION, "@" + M2Share.g_GameCommand.MEMBERFUNCTION.sCmd, "打开会员功能窗口(QManage-[@Member])");
//            RefGameUserCmd(M2Share.g_GameCommand.DEAR, "@" + M2Share.g_GameCommand.DEAR.sCmd + " 人物名称", "此命令用于查询配偶当前所在位置");
//            RefGameUserCmd(M2Share.g_GameCommand.ALLOWDEARRCALL, "@" + M2Share.g_GameCommand.ALLOWDEARRCALL.sCmd, "允许夫妻传送");
//            RefGameUserCmd(M2Share.g_GameCommand.DEARRECALL, "@" + M2Share.g_GameCommand.DEARRECALL.sCmd, "夫妻传送，将对方传送到自己身边，对方必须允许传送");
//            RefGameUserCmd(M2Share.g_GameCommand.MASTER, "@" + M2Share.g_GameCommand.MASTER.sCmd + " 人物名称", "此命令用于查询师徒当前所在位置");
//            RefGameUserCmd(M2Share.g_GameCommand.ALLOWMASTERRECALL, "@" + M2Share.g_GameCommand.ALLOWMASTERRECALL.sCmd, "允许师徒传送");
//            RefGameUserCmd(M2Share.g_GameCommand.MASTERECALL, "@" + M2Share.g_GameCommand.MASTERECALL.sCmd + " 人物名称", "师徒传送");
//            RefGameUserCmd(M2Share.g_GameCommand.ATTACKMODE, "@" + M2Share.g_GameCommand.ATTACKMODE.sCmd, "改变攻击模式");
//            RefGameUserCmd(M2Share.g_GameCommand.REST, "@" + M2Share.g_GameCommand.REST.sCmd, "改变下属状态");
//            RefGameUserCmd(M2Share.g_GameCommand.MEMBERFUNCTIONEX, "@" + M2Share.g_GameCommand.MEMBERFUNCTIONEX.sCmd, "打开会员功能(QFunction-[@Member])");
//            RefGameUserCmd(M2Share.g_GameCommand.LOCKLOGON, "@" + M2Share.g_GameCommand.LOCKLOGON.sCmd, "启用登录锁功能");
//            // RefGameUserCmd(@g_GameCommand.REMTEMSG,
//            // '@' +  g_GameCommand.REMTEMSG.sCmd ,
//            // '允许接受消息(点歌)');
//            // //未使用 20080823
//            // StringGridGameCmd.Cells[0, 12] := g_GameCommand.DIARY.sCmd;
//            // StringGridGameCmd.Cells[1, 12] := IntToStr(g_GameCommand.DIARY.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 12] := '@' + g_GameCommand.DIARY.sCmd;
//            // StringGridGameCmd.Objects[0, 12] := TObject(@g_GameCommand.DIARY);
//            // StringGridGameCmd.Cells[0, 13] := g_GameCommand.USERMOVE.sCmd;
//            // StringGridGameCmd.Cells[1, 13] := IntToStr(g_GameCommand.USERMOVE.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 13] := '@' + g_GameCommand.USERMOVE.sCmd;
//            // StringGridGameCmd.Objects[0, 13] := TObject(@g_GameCommand.USERMOVE);
//            // 
//            // StringGridGameCmd.Cells[0, 14] := g_GameCommand.SEARCHING.sCmd;
//            // StringGridGameCmd.Cells[1, 14] := IntToStr(g_GameCommand.SEARCHING.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 14] := '@' + g_GameCommand.SEARCHING.sCmd;
//            // StringGridGameCmd.Objects[0, 14] := TObject(@g_GameCommand.SEARCHING);
//            // 
//            // StringGridGameCmd.Cells[0, 15] := g_GameCommand.ALLOWGROUPCALL.sCmd;//允许天地合一
//            // StringGridGameCmd.Cells[1, 15] := IntToStr(g_GameCommand.ALLOWGROUPCALL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 15] := '@' + g_GameCommand.ALLOWGROUPCALL.sCmd;
//            // StringGridGameCmd.Objects[0, 15] := TObject(@g_GameCommand.ALLOWGROUPCALL);
//            // 
//            // StringGridGameCmd.Cells[0, 16] := g_GameCommand.GROUPRECALLL.sCmd;//天地合一
//            // StringGridGameCmd.Cells[1, 16] := IntToStr(g_GameCommand.GROUPRECALLL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 16] := '@' + g_GameCommand.GROUPRECALLL.sCmd;
//            // StringGridGameCmd.Objects[0, 16] := TObject(@g_GameCommand.GROUPRECALLL);
//            // 
//            // StringGridGameCmd.Cells[0, 17] := g_GameCommand.ALLOWGUILDRECALL.sCmd;//允许行会合一
//            // StringGridGameCmd.Cells[1, 17] := IntToStr(g_GameCommand.ALLOWGUILDRECALL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 17] := '@' + g_GameCommand.ALLOWGUILDRECALL.sCmd;
//            // StringGridGameCmd.Objects[0, 17] := TObject(@g_GameCommand.ALLOWGUILDRECALL);
//            // 
//            // StringGridGameCmd.Cells[0, 18] := g_GameCommand.GUILDRECALLL.sCmd;//行会合一
//            // StringGridGameCmd.Cells[1, 18] := IntToStr(g_GameCommand.GUILDRECALLL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 18] := '@' + g_GameCommand.GUILDRECALLL.sCmd;
//            // StringGridGameCmd.Objects[0, 18] := TObject(@g_GameCommand.GUILDRECALLL);
//            // 
//            // StringGridGameCmd.Cells[0, 19] := g_GameCommand.UNLOCKSTORAGE.sCmd;//仓库开锁
//            // StringGridGameCmd.Cells[1, 19] := IntToStr(g_GameCommand.UNLOCKSTORAGE.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 19] := '@' + g_GameCommand.UNLOCKSTORAGE.sCmd;
//            // StringGridGameCmd.Objects[0, 19] := TObject(@g_GameCommand.UNLOCKSTORAGE);
//            // 
//            // StringGridGameCmd.Cells[0, 20] := g_GameCommand.UnLock.sCmd;//开锁
//            // StringGridGameCmd.Cells[1, 20] := IntToStr(g_GameCommand.UnLock.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 20] := '@' + g_GameCommand.UnLock.sCmd;
//            // StringGridGameCmd.Objects[0, 20] := TObject(@g_GameCommand.UnLock);
//            // 
//            // StringGridGameCmd.Cells[0, 21] := g_GameCommand.Lock.sCmd;//锁定仓库
//            // StringGridGameCmd.Cells[1, 21] := IntToStr(g_GameCommand.Lock.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 21] := '@' + g_GameCommand.Lock.sCmd;
//            // StringGridGameCmd.Objects[0, 21] := TObject(@g_GameCommand.Lock);
//            // 
//            // StringGridGameCmd.Cells[0, 22] := g_GameCommand.SETPASSWORD.sCmd;//设置密码
//            // StringGridGameCmd.Cells[1, 22] := IntToStr(g_GameCommand.SETPASSWORD.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 22] := '@' + g_GameCommand.SETPASSWORD.sCmd;
//            // StringGridGameCmd.Objects[0, 22] := TObject(@g_GameCommand.SETPASSWORD);
//            // 
//            // StringGridGameCmd.Cells[0, 23] := g_GameCommand.CHGPASSWORD.sCmd;//修改密码
//            // StringGridGameCmd.Cells[1, 23] := IntToStr(g_GameCommand.CHGPASSWORD.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 23] := '@' + g_GameCommand.CHGPASSWORD.sCmd;
//            // StringGridGameCmd.Objects[0, 23] := TObject(@g_GameCommand.CHGPASSWORD);
//            // 
//            // StringGridGameCmd.Cells[0, 24] := g_GameCommand.UNPASSWORD.sCmd;//清除密码
//            // StringGridGameCmd.Cells[1, 24] := IntToStr(g_GameCommand.UNPASSWORD.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 24] := '@' + g_GameCommand.UNPASSWORD.sCmd;
//            // StringGridGameCmd.Objects[0, 24] := TObject(@g_GameCommand.UNPASSWORD);
//            // 
//            // StringGridGameCmd.Cells[0, 25] := g_GameCommand.MEMBERFUNCTION.sCmd;//后台管理
//            // StringGridGameCmd.Cells[1, 25] := IntToStr(g_GameCommand.MEMBERFUNCTION.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 25] := '@' + g_GameCommand.MEMBERFUNCTION.sCmd;
//            // StringGridGameCmd.Objects[0, 25] := TObject(@g_GameCommand.MEMBERFUNCTION);
//            // 
//            // StringGridGameCmd.Cells[0, 26] := g_GameCommand.DEAR.sCmd;//此命令用于查询配偶当前所在位置
//            // StringGridGameCmd.Cells[1, 26] := IntToStr(g_GameCommand.DEAR.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 26] := '@' + g_GameCommand.DEAR.sCmd;
//            // StringGridGameCmd.Objects[0, 26] := TObject(@g_GameCommand.DEAR);
//            // 
//            // StringGridGameCmd.Cells[0, 27] := g_GameCommand.ALLOWDEARRCALL.sCmd;//允许夫妻传送
//            // StringGridGameCmd.Cells[1, 27] := IntToStr(g_GameCommand.ALLOWDEARRCALL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 27] := '@' + g_GameCommand.ALLOWDEARRCALL.sCmd;
//            // StringGridGameCmd.Objects[0, 27] := TObject(@g_GameCommand.ALLOWDEARRCALL);
//            // 
//            // StringGridGameCmd.Cells[0, 28] := g_GameCommand.DEARRECALL.sCmd;//夫妻传送
//            // StringGridGameCmd.Cells[1, 28] := IntToStr(g_GameCommand.DEARRECALL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 28] := '@' + g_GameCommand.DEARRECALL.sCmd;
//            // StringGridGameCmd.Objects[0, 28] := TObject(@g_GameCommand.DEARRECALL);
//            // 
//            // StringGridGameCmd.Cells[0, 29] := g_GameCommand.MASTER.sCmd;//此命令用于查询师徒当前所在位置
//            // StringGridGameCmd.Cells[1, 29] := IntToStr(g_GameCommand.MASTER.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 29] := '@' + g_GameCommand.MASTER.sCmd;
//            // StringGridGameCmd.Objects[0, 29] := TObject(@g_GameCommand.MASTER);
//            // 
//            // StringGridGameCmd.Cells[0, 30] := g_GameCommand.ALLOWMASTERRECALL.sCmd;//允许师徒传送
//            // StringGridGameCmd.Cells[1, 30] := IntToStr(g_GameCommand.ALLOWMASTERRECALL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 30] := '@' + g_GameCommand.ALLOWMASTERRECALL.sCmd;
//            // StringGridGameCmd.Objects[0, 30] := TObject(@g_GameCommand.ALLOWMASTERRECALL);
//            // 
//            // StringGridGameCmd.Cells[0, 31] := g_GameCommand.MASTERECALL.sCmd;//师徒传送
//            // StringGridGameCmd.Cells[1, 31] := IntToStr(g_GameCommand.MASTERECALL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 31] := '@' + g_GameCommand.MASTERECALL.sCmd;
//            // StringGridGameCmd.Objects[0, 31] := TObject(@g_GameCommand.MASTERECALL);
//            // 
//            // StringGridGameCmd.Cells[0, 32] := g_GameCommand.ATTACKMODE.sCmd;//改变攻击模式
//            // StringGridGameCmd.Cells[1, 32] := IntToStr(g_GameCommand.ATTACKMODE.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 32] := '@' + g_GameCommand.ATTACKMODE.sCmd;
//            // StringGridGameCmd.Objects[0, 32] := TObject(@g_GameCommand.ATTACKMODE);
//            // 
//            // StringGridGameCmd.Cells[0, 33] := g_GameCommand.REST.sCmd;//改变下属状态
//            // StringGridGameCmd.Cells[1, 33] := IntToStr(g_GameCommand.REST.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 33] := '@' + g_GameCommand.REST.sCmd;
//            // StringGridGameCmd.Objects[0, 33] := TObject(@g_GameCommand.REST);
//            // StringGridGameCmd.Cells[0, 34] := g_GameCommand.TAKEONHORSE.sCmd;//骑马
//            // StringGridGameCmd.Cells[1, 34] := IntToStr(g_GameCommand.TAKEONHORSE.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 34] := '@' + g_GameCommand.TAKEONHORSE.sCmd;
//            // StringGridGameCmd.Objects[0, 34] := TObject(@g_GameCommand.TAKEONHORSE);
//            // 
//            // StringGridGameCmd.Cells[0, 35] := g_GameCommand.TAKEOFHORSE.sCmd;//下马
//            // StringGridGameCmd.Cells[1, 35] := IntToStr(g_GameCommand.TAKEOFHORSE.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 35] := '@' + g_GameCommand.TAKEOFHORSE.sCmd;
//            // StringGridGameCmd.Objects[0, 35] := TObject(@g_GameCommand.TAKEOFHORSE);
//            // StringGridGameCmd.Cells[0, 36] := g_GameCommand.MEMBERFUNCTIONEX.sCmd;//打开会员功能
//            // StringGridGameCmd.Cells[1, 36] := IntToStr(g_GameCommand.MEMBERFUNCTIONEX.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 36] := '@' + g_GameCommand.MEMBERFUNCTIONEX.sCmd;
//            // StringGridGameCmd.Objects[0, 36] := TObject(@g_GameCommand.MEMBERFUNCTIONEX);
//            // 
//            // StringGridGameCmd.Cells[0, 37] := g_GameCommand.LOCKLOGON.sCmd;//启用登录锁功能
//            // StringGridGameCmd.Cells[1, 37] := IntToStr(g_GameCommand.LOCKLOGON.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 37] := '@' + g_GameCommand.LOCKLOGON.sCmd;
//            // StringGridGameCmd.Objects[0, 37] := TObject(@g_GameCommand.LOCKLOGON);

//        }

//        public void StringGridGameCmdClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TGameCmd GameCmd;
//            nIndex = StringGridGameCmd.CurrentRowIndex;
            
//            GameCmd = ((TGameCmd)(StringGridGameCmd.Objects[0, nIndex]));
//            if (GameCmd != null)
//            {
//                EditUserCmdName.Text = GameCmd.sCmd;
//                EditUserCmdPerMission.Value = GameCmd.nPermissionMin;
                
//                LabelUserCmdParam.Text = StringGridGameCmd.Cells[2, nIndex];
                
//                LabelUserCmdFunc.Text = StringGridGameCmd.Cells[3, nIndex];
//            }
//            EditUserCmdOK.Enabled = false;
//        }

//        public void EditUserCmdNameChange(object sender, EventArgs e)
//        {
//            EditUserCmdOK.Enabled = true;
//            EditUserCmdSave.Enabled = true;
//        }

//        public void EditUserCmdPerMissionChange(Object Sender)
//        {
//            EditUserCmdOK.Enabled = true;
//            EditUserCmdSave.Enabled = true;
//        }

//        public void EditUserCmdOKClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TGameCmd GameCmd;
//            string sCmd;
//            int nPermission;
//            sCmd = EditUserCmdName.Text.Trim();
//            nPermission = EditUserCmdPerMission.Value;
//            if (sCmd == "")
//            {
//                System.Windows.Forms.MessageBox.Show("命令名称不能为空！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                EditUserCmdName.Focus();
//                return;
//            }
//            nIndex = StringGridGameCmd.CurrentRowIndex;
            
//            GameCmd = ((TGameCmd)(StringGridGameCmd.Objects[0, nIndex]));
//            if (GameCmd != null)
//            {
//                GameCmd.sCmd = sCmd;
//                GameCmd.nPermissionMin = nPermission;
//            }
//            RefUserCommand();
//        }

//        public void EditUserCmdSaveClick(object sender, EventArgs e)
//        {
//            EditUserCmdSave.Enabled = false;
//#if SoftVersion <> VERDEMO
            
//            M2Share.CommandConf.WriteString("Command", "Date", M2Share.g_GameCommand.Data.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "PrvMsg", M2Share.g_GameCommand.PRVMSG.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AllowMsg", M2Share.g_GameCommand.ALLOWMSG.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "LetShout", M2Share.g_GameCommand.LETSHOUT.sCmd);
//            // CommandConf.WriteString('Command', 'BanGmMsg', g_GameCommand.BANGMMSG.sCmd);//拒绝所有喊话信息 20080211
            
//            M2Share.CommandConf.WriteString("Command", "LetTrade", M2Share.g_GameCommand.LETTRADE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "LetGuild", M2Share.g_GameCommand.LETGUILD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "EndGuild", M2Share.g_GameCommand.ENDGUILD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "BanGuildChat", M2Share.g_GameCommand.BANGUILDCHAT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AuthAlly", M2Share.g_GameCommand.AUTHALLY.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Auth", M2Share.g_GameCommand.AUTH.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AuthCancel", M2Share.g_GameCommand.AUTHCANCEL.sCmd);
//            // CommandConf.WriteString('Command', 'ViewDiary', g_GameCommand.DIARY.sCmd);//未使用 20080823
            
//            M2Share.CommandConf.WriteString("Command", "UserMove", M2Share.g_GameCommand.USERMOVE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Searching", M2Share.g_GameCommand.SEARCHING.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AllowGroupCall", M2Share.g_GameCommand.ALLOWGROUPCALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "GroupCall", M2Share.g_GameCommand.GROUPRECALLL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AllowGuildReCall", M2Share.g_GameCommand.ALLOWGUILDRECALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "GuildReCall", M2Share.g_GameCommand.GUILDRECALLL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "StorageUnLock", M2Share.g_GameCommand.UNLOCKSTORAGE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "PasswordUnLock", M2Share.g_GameCommand.UnLock.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "StorageLock", M2Share.g_GameCommand.__Lock.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "StorageSetPassword", M2Share.g_GameCommand.SETPASSWORD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "StorageChgPassword", M2Share.g_GameCommand.CHGPASSWORD.sCmd);
//            // CommandConf.WriteString('Command','StorageClearPassword',g_GameCommand.CLRPASSWORD.sCmd)
//            // CommandConf.WriteInteger('Permission','StorageClearPassword', g_GameCommand.CLRPASSWORD.nPermissionMin)
            
//            M2Share.CommandConf.WriteString("Command", "StorageUserClearPassword", M2Share.g_GameCommand.UNPASSWORD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MemberFunc", M2Share.g_GameCommand.MEMBERFUNCTION.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Dear", M2Share.g_GameCommand.DEAR.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Master", M2Share.g_GameCommand.MASTER.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "DearRecall", M2Share.g_GameCommand.DEARRECALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MasterRecall", M2Share.g_GameCommand.MASTERECALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AllowDearRecall", M2Share.g_GameCommand.ALLOWDEARRCALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AllowMasterRecall", M2Share.g_GameCommand.ALLOWMASTERRECALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AttackMode", M2Share.g_GameCommand.ATTACKMODE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Rest", M2Share.g_GameCommand.REST.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "TakeOnHorse", M2Share.g_GameCommand.TAKEONHORSE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "TakeOffHorse", M2Share.g_GameCommand.TAKEOFHORSE.sCmd);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Date", M2Share.g_GameCommand.Data.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "PrvMsg", M2Share.g_GameCommand.PRVMSG.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "AllowMsg", M2Share.g_GameCommand.ALLOWMSG.nPermissionMin);
//#endif

//        }

//        private void RefGameMasterCmd(TGameCmd GameCmd, string sCmdParam, string sDesc)
//        {
//            byte nCode;
//            // 20080829
//            nCode = 0;
//            try {
//                nRefGameMasterIndex ++;
//                nCode = 1;
                
//                if (StringGridGameMasterCmd.RowCount - 1 < nRefGameMasterIndex)
//                {
//                    nCode = 2;
                    
//                    StringGridGameMasterCmd.RowCount = nRefGameMasterIndex + 1;
//                }
//                nCode = 3;
                
//                StringGridGameMasterCmd.Cells[0, nRefGameMasterIndex] = GameCmd.sCmd;
//                nCode = 4;
                
//                StringGridGameMasterCmd.Cells[1, nRefGameMasterIndex] = (GameCmd.nPermissionMin).ToString() + "/" + (GameCmd.nPermissionMax).ToString();
//                nCode = 5;
                
//                StringGridGameMasterCmd.Cells[2, nRefGameMasterIndex] = sCmdParam;
//                nCode = 6;
                
//                StringGridGameMasterCmd.Cells[3, nRefGameMasterIndex] = sDesc;
//                nCode = 7;
                
//                StringGridGameMasterCmd.Objects[0, nRefGameMasterIndex] = ((GameCmd) as Object);
//            }
//            catch {
//                M2Share.MainOutMessage("{异常} TfrmGameCmd.RefGameMasterCmd Code:" + (nCode).ToString());
//            }
//        }

//        // 游戏命令说明
//        private void RefGameMasterCommand()
//        {
//            EditGameMasterCmdOK.Enabled = false;
//            nRefGameMasterIndex = 0;
//            RefGameMasterCmd(M2Share.g_GameCommand.CLRPASSWORD, "@" + M2Share.g_GameCommand.CLRPASSWORD.sCmd + " 人物名称", "清除人物仓库/登录密码(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.WHO, "/" + M2Share.g_GameCommand.WHO.sCmd, "查看当前服务器在线人数(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.TOTAL, "/" + M2Share.g_GameCommand.TOTAL.sCmd, "查看所有服务器在线人数(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.GAMEMASTER, "@" + M2Share.g_GameCommand.GAMEMASTER.sCmd, "进入/退出管理员模式(进入模式后不会受到任何角色攻击)(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.OBSERVER, "@" + M2Share.g_GameCommand.OBSERVER.sCmd, "进入/退出隐身模式(进入模式后别人看不到自己)(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SUEPRMAN, "@" + M2Share.g_GameCommand.SUEPRMAN.sCmd, "进入/退出无敌模式(进入模式后人物不会死亡)(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.MAKE, "@" + M2Share.g_GameCommand.MAKE.sCmd + " 物品名称 数量", "制造指定物品(支持权限分配，小于最大权限受允许、禁止制造列表限制)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SMAKE, "@" + M2Share.g_GameCommand.SMAKE.sCmd + " 参数详见使用说明", "调整自己身上的物品属性(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.Move, "@" + M2Share.g_GameCommand.Move.sCmd + " 地图号", "移动到指定地图(支持权限分配，小于最大权限受受禁止传送地图列表限制)");
//            RefGameMasterCmd(M2Share.g_GameCommand.POSITIONMOVE, "@" + M2Share.g_GameCommand.POSITIONMOVE.sCmd + " 地图号 X Y", "移动到指定地图(支持权限分配，小于最大权限受受禁止传送地图列表限制)");
//            RefGameMasterCmd(M2Share.g_GameCommand.RECALL, "@" + M2Share.g_GameCommand.RECALL.sCmd + " 人物名称", "将指定人物召唤到身边(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.REGOTO, "@" + M2Share.g_GameCommand.REGOTO.sCmd + " 人物名称", "跟踪指定人物(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.TING, "@" + M2Share.g_GameCommand.TING.sCmd + " 人物名称", "将指定人物随机传送(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SUPERTING, "@" + M2Share.g_GameCommand.SUPERTING.sCmd + " 人物名称 范围大小", "将指定人物身边指定范围内的人物随机传送(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.MAPMOVE, "@" + M2Share.g_GameCommand.MAPMOVE.sCmd + " 源地图号 目标地图号", "将整个地图中的人物移动到其它地图中(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.INFO, "@" + M2Share.g_GameCommand.INFO.sCmd + " 人物名称", "看人物信息(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.HUMANLOCAL, "@" + M2Share.g_GameCommand.HUMANLOCAL.sCmd + " 地图号", "查询人物IP所在地区(需加载IP地区查询插件)(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.VIEWWHISPER, "@" + M2Share.g_GameCommand.VIEWWHISPER.sCmd + " 人物名称", "查看指定人物的私聊信息(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.MOBLEVEL, "@" + M2Share.g_GameCommand.MOBLEVEL.sCmd, "查看身边角色信息(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.MOBCOUNT, "@" + M2Share.g_GameCommand.MOBCOUNT.sCmd + " 地图号", "查看地图中怪物数量(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.HUMANCOUNT, "@" + M2Share.g_GameCommand.HUMANCOUNT.sCmd, "查看身边人数(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.Map, "@" + M2Share.g_GameCommand.Map.sCmd, "显示当前所在地图相关信息(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.Level, "@" + M2Share.g_GameCommand.Level.sCmd, "调整自己的等级(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.KICK, "@" + M2Share.g_GameCommand.KICK.sCmd + " 人物名称", "将指定人物踢下线(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ReAlive, "@" + M2Share.g_GameCommand.ReAlive.sCmd + " 人物名称", "将指定人物复活(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.KILL, "@" + M2Share.g_GameCommand.KILL.sCmd + "人物名称", "将指定人物或怪物杀死(杀怪物时需面对怪物)(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CHANGEJOB, "@" + M2Share.g_GameCommand.CHANGEJOB.sCmd + " 人物名称 职业类型(Warr Wizard Taos)", "调整人物的职业(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.FREEPENALTY, "@" + M2Share.g_GameCommand.FREEPENALTY.sCmd + " 人物名称", "清除指定人物的PK值(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.PKPOINT, "@" + M2Share.g_GameCommand.PKPOINT.sCmd + " 人物名称", "查看指定人物的PK值(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.IncPkPoint, "@" + M2Share.g_GameCommand.IncPkPoint.sCmd + " 人物名称 点数", "增加指定人物的PK值(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CHANGEGENDER, "@" + M2Share.g_GameCommand.CHANGEGENDER.sCmd + " 人物名称 性别(男、女)", "调整人物的性别(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.HAIR, "@" + M2Share.g_GameCommand.HAIR.sCmd + " 类型值", "更改指定人物的头发类型(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.BonusPoint, "@" + M2Share.g_GameCommand.BonusPoint.sCmd + " 人物名称 属性点数", "调整人物的属性点数(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELBONUSPOINT, "@" + M2Share.g_GameCommand.DELBONUSPOINT.sCmd + " 人物名称", "删除人物的属性点数(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.RESTBONUSPOINT, "@" + M2Share.g_GameCommand.RESTBONUSPOINT.sCmd + " 人物名称", "将人物的属性点数重新分配(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SETPERMISSION, "@" + M2Share.g_GameCommand.SETPERMISSION.sCmd + " 人物名称 权限等级(0 - 10)", "调整人物的权限等级，可以将普通人物升为GM权限(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.RENEWLEVEL, "@" + M2Share.g_GameCommand.RENEWLEVEL.sCmd + " 人物名称 点数(为空则查看)", "调整查看人物的转生等级(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELGOLD, "@" + M2Share.g_GameCommand.DELGOLD.sCmd + " 人物名称 数量", "删除人物指定数量的金币(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ADDGOLD, "@" + M2Share.g_GameCommand.ADDGOLD.sCmd + " 人物名称 数量", "增加人物指定数量的金币(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.GAMEGOLD, "@" + M2Share.g_GameCommand.GAMEGOLD.sCmd + " 人物名称 控制符(+ - =) 数量", "调整人物的游戏币数量(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.GAMEGIRD, "@" + M2Share.g_GameCommand.GAMEGIRD.sCmd + " 人物名称 控制符(+ - =) 数量", "调整人物的灵符数量(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.GAMEDIAMOND, "@" + M2Share.g_GameCommand.GAMEDIAMOND.sCmd + " 人物名称 控制符(+ - =) 数量", "调整人物的金刚石数量(支持权限分配)");
//            // ------------------------------------------------------------------------------
//            // 调整英雄的忠诚度 20080109
//            // g_GameCommand.HEROLOYAL.sCmd
//            RefGameMasterCmd(M2Share.g_GameCommand.HEROLOYAL, "@" + "改变忠诚" + " 英雄名称  忠诚度(0-10000)", "调整英雄的忠诚度(支持权限分配)");
//            // ------------------------------------------------------------------------------
//            RefGameMasterCmd(M2Share.g_GameCommand.GAMEPOINT, "@" + M2Share.g_GameCommand.GAMEPOINT.sCmd + " 人物名称 控制符(+ - =) 数量", "调整人物的游戏点数量(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CREDITPOINT, "@" + M2Share.g_GameCommand.CREDITPOINT.sCmd + " 人物名称 控制符(+ - =) 点数", "调整人物的声望点数(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.REFINEWEAPON, "@" + M2Share.g_GameCommand.REFINEWEAPON.sCmd + " 攻击力 魔法力 道术 准确度", "调整身上武器属性(支持权限分配)");
//            // 千里传音 20071228
//            RefGameMasterCmd(M2Share.g_GameCommand.SysMsg, "@" + M2Share.g_GameCommand.SysMsg.sCmd + " 发布信息", "千里传音功能");
//            // 调整英雄等级 20071227
//            RefGameMasterCmd(M2Share.g_GameCommand.HEROLEVEL, "@" + M2Share.g_GameCommand.HEROLEVEL.sCmd + " 英雄名称 等级", "调整指定英雄的等级(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ADJUESTLEVEL, "@" + M2Share.g_GameCommand.ADJUESTLEVEL.sCmd + " 人物名称 等级", "调整指定人物的等级(支持权限分配)");
//            // 调整人物内功等级 20081221
//            RefGameMasterCmd(M2Share.g_GameCommand.NGLEVEL, "@" + M2Share.g_GameCommand.NGLEVEL.sCmd + " 人物名称 内功等级(1-255)", "调整指定人物或英雄内功等级(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ADJUESTEXP, "@" + M2Share.g_GameCommand.ADJUESTEXP.sCmd + " 人物名称 经验值", "调整指定人物的经验值(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CHANGEDEARNAME, "@" + M2Share.g_GameCommand.CHANGEDEARNAME.sCmd + " 人物名称 配偶名称(如果为 无 则清除)", "更改指定人物的配偶名称(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CHANGEMASTERNAME, "@" + M2Share.g_GameCommand.CHANGEMASTERNAME.sCmd + " 人物名称 师徒名称(如果为 无 则清除)", "更改指定人物的师徒名称(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.RECALLMOB, "@" + M2Share.g_GameCommand.RECALLMOB.sCmd + " 怪物名称 数量 召唤等级", "召唤指定怪物为宝宝(支持权限分配)");
//            // 20080122 召唤宝宝
//            RefGameMasterCmd(M2Share.g_GameCommand.RECALLMOBEX, "@" + M2Share.g_GameCommand.RECALLMOBEX.sCmd + " 怪物名称 名称颜色 坐标X 坐标Y", "召唤指定怪物为宝宝(支持权限分配)-魔王岭");
//            // 20080403 给指定纯度的矿石
//            RefGameMasterCmd(M2Share.g_GameCommand.GIVEMINE, "@" + M2Share.g_GameCommand.GIVEMINE.sCmd + " 矿石名称 数量 纯度", "给指定纯度的矿石(支持权限分配)");
//            // 20080123 将指定坐标的怪物移动到新坐标
//            RefGameMasterCmd(M2Share.g_GameCommand.MOVEMOBTO, "@" + M2Share.g_GameCommand.MOVEMOBTO.sCmd + " 怪物名称 原地图 原X 原Y 新地图 新X 新Y", "将指定坐标的怪物移动到新坐标(支持权限分配)");
//            // 20080124 清除地图物品
//            RefGameMasterCmd(M2Share.g_GameCommand.CLEARITEMMAP, "@" + M2Share.g_GameCommand.CLEARITEMMAP.sCmd + " 地图 X Y 范围 物品名称", "清除地图物品，物品名称为ALL则清除所有(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.TRAINING, "@" + M2Share.g_GameCommand.TRAINING.sCmd + " 人物名称  技能名称 修炼等级(0-3)", "调整人物的技能修炼等级(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.TRAININGSKILL, "@" + M2Share.g_GameCommand.TRAININGSKILL.sCmd + " 人物名称  技能名称 修炼等级(0-3)", "给指定人物增加技能(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELETESKILL, "@" + M2Share.g_GameCommand.DELETESKILL.sCmd + " 人物名称 技能名称(All)", "删除人物的技能，All代表删除全部技能(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELETEITEM, "@" + M2Share.g_GameCommand.DELETEITEM.sCmd + " 人物名称 物品名称 数量", "删除人物身上指定的物品(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CLEARMISSION, "@" + M2Share.g_GameCommand.CLEARMISSION.sCmd + " 人物名称", "清除人物的任务标志(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.AddGuild, "@" + M2Share.g_GameCommand.AddGuild.sCmd + " 行会名称 掌门人", "新建一个行会(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELGUILD, "@" + M2Share.g_GameCommand.DELGUILD.sCmd + " 行会名称", "删除一个行会(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CHANGESABUKLORD, "@" + M2Share.g_GameCommand.CHANGESABUKLORD.sCmd + " 行会名称", "更改城堡所属行会(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.FORCEDWALLCONQUESTWAR, "@" + M2Share.g_GameCommand.FORCEDWALLCONQUESTWAR.sCmd, "强行开始/停止攻城战(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CONTESTPOINT, "@" + M2Share.g_GameCommand.CONTESTPOINT.sCmd + " 行会名称", "查看行会争霸赛得分情况(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.STARTCONTEST, "@" + M2Share.g_GameCommand.STARTCONTEST.sCmd, "开始行会争霸赛(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ENDCONTEST, "@" + M2Share.g_GameCommand.ENDCONTEST.sCmd, "结束行会争霸赛(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ANNOUNCEMENT, "@" + M2Share.g_GameCommand.ANNOUNCEMENT.sCmd + " 行会名称", "查看行会争霸赛结果(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.MOB, "@" + M2Share.g_GameCommand.MOB.sCmd + " 怪物名称 数量 内功怪(0,1)", "在身边放置指定类型数量的怪物(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.Mission, "@" + M2Share.g_GameCommand.Mission.sCmd + " X  Y", "设置怪物的集中点(举行怪物攻城用)(支持权限分配");
//            RefGameMasterCmd(M2Share.g_GameCommand.MobPlace, "@" + M2Share.g_GameCommand.MobPlace.sCmd + " X  Y 怪物名称 怪物数量 内功怪(0,1)", "在当前地图指定XY放置怪物(支持权限分配(先必须设置怪物的集中点)，放置的怪物大刀守卫不会攻击这些怪物");
//            RefGameMasterCmd(M2Share.g_GameCommand.CLEARMON, "@" + M2Share.g_GameCommand.CLEARMON.sCmd + " 地图号(* 为所有) 怪物名称(* 为所有) 掉物品(0,1)", "清除地图中的怪物(支持权限分配\')");
//            RefGameMasterCmd(M2Share.g_GameCommand.DISABLESENDMSG, "@" + M2Share.g_GameCommand.DISABLESENDMSG.sCmd + " 人物名称", "将指定人物加入发言过滤列表，加入列表后自己发的文字自己可以看到，其他人看不到(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ENABLESENDMSG, "@" + M2Share.g_GameCommand.ENABLESENDMSG.sCmd, "将指定人物从发言过滤列表中删除(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DISABLESENDMSGLIST, "@" + M2Share.g_GameCommand.DISABLESENDMSGLIST.sCmd, "查看发言过滤列表中的内容(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SHUTUP, "@" + M2Share.g_GameCommand.SHUTUP.sCmd + " 人物名称", "将指定人物禁言(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.RELEASESHUTUP, "@" + M2Share.g_GameCommand.RELEASESHUTUP.sCmd + " 人物名称", "将指定人物从禁言列表中删除(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SHUTUPLIST, "@" + M2Share.g_GameCommand.SHUTUPLIST.sCmd, "查看禁言列表中的内容(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SABUKWALLGOLD, "@" + M2Share.g_GameCommand.SABUKWALLGOLD.sCmd, "查看城堡金币数(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.STARTQUEST, "@" + M2Share.g_GameCommand.STARTQUEST.sCmd, "开始提问功能，游戏中所有人同时跳出问题窗口(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DENYIPLOGON, "@" + M2Share.g_GameCommand.DENYIPLOGON.sCmd + " IP地址 是否永久封(0,1)", "将指定IP地址加入禁止登录列表，以这些IP登录的用户将无法进入游戏(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DENYACCOUNTLOGON, "@" + M2Share.g_GameCommand.DENYACCOUNTLOGON.sCmd + " 登录帐号 是否永久封(0,1)", "将指定登录帐号加入禁止登录列表，以此帐号登录的用户将无法进入游戏(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DENYCHARNAMELOGON, "@" + M2Share.g_GameCommand.DENYCHARNAMELOGON.sCmd + " 人物名称 是否永久封(0,1)", "将指定人物名称加入禁止登录列表，此人物将无法进入游戏(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELDENYIPLOGON, "@" + M2Share.g_GameCommand.DELDENYIPLOGON.sCmd + " IP地址", "恢复禁止登陆IP(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELDENYACCOUNTLOGON, "@" + M2Share.g_GameCommand.DELDENYACCOUNTLOGON.sCmd + " 登录帐号", "恢复禁止登陆帐号(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELDENYCHARNAMELOGON, "@" + M2Share.g_GameCommand.DELDENYCHARNAMELOGON.sCmd + " 人物名称", "恢复禁止登陆人物(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SHOWDENYIPLOGON, "@" + M2Share.g_GameCommand.SHOWDENYIPLOGON.sCmd, "查看禁止登陆IP(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SHOWDENYACCOUNTLOGON, "@" + M2Share.g_GameCommand.SHOWDENYACCOUNTLOGON.sCmd, "查看禁止登陆帐号(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SHOWDENYCHARNAMELOGON, "@" + M2Share.g_GameCommand.SHOWDENYCHARNAMELOGON.sCmd, "查看禁止登录角色列表(支持权限分配)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SetMapMode, "@" + M2Share.g_GameCommand.SetMapMode.sCmd, "设置地图模式");
//            RefGameMasterCmd(M2Share.g_GameCommand.SHOWMAPMODE, "@" + M2Share.g_GameCommand.SHOWMAPMODE.sCmd, "显示地图模式");
//            // RefGameMasterCmd(@g_GameCommand.Attack,//20080812 注释
//            // '@' + g_GameCommand.Attack.sCmd,
//            // '');
//            RefGameMasterCmd(M2Share.g_GameCommand.LUCKYPOINT, "@" + M2Share.g_GameCommand.LUCKYPOINT.sCmd + " 人物名称 操作符(+,-,=) 点数", "调整指定人物的幸运值(支持权限分配)");
//            // RefGameMasterCmd(@g_GameCommand.CHANGELUCK,//20080812 注释
//            // '@' + g_GameCommand.CHANGELUCK.sCmd,
//            // '');
//            RefGameMasterCmd(M2Share.g_GameCommand.HUNGER, "@" + M2Share.g_GameCommand.HUNGER.sCmd + " 人物名称 能量值", "调整指定人物的能量值(权限6以上)");
//            // RefGameMasterCmd(@g_GameCommand.NAMECOLOR,//20080812 注释
//            // '@' + g_GameCommand.NAMECOLOR.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.TRANSPARECY,
//            // '@' + g_GameCommand.TRANSPARECY.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.LEVEL0,
//            // '@' + g_GameCommand.LEVEL0.sCmd,
//            // '');
//            RefGameMasterCmd(M2Share.g_GameCommand.CHANGEITEMNAME, "@" + M2Share.g_GameCommand.CHANGEITEMNAME.sCmd + " 物品编号 物品ID号 物品名称", "改变物品名称(权限6以上)");
//            // RefGameMasterCmd(@g_GameCommand.ADDTOITEMEVENT,//20080812 注释
//            // '@' + g_GameCommand.ADDTOITEMEVENT.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.ADDTOITEMEVENTASPIECES,
//            // '@' + g_GameCommand.ADDTOITEMEVENTASPIECES.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.ItemEventList,
//            // '@' + g_GameCommand.ItemEventList.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.STARTINGGIFTNO,
//            // '@' + g_GameCommand.STARTINGGIFTNO.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.DELETEALLITEMEVENT,
//            // '@' + g_GameCommand.DELETEALLITEMEVENT.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.STARTITEMEVENT,
//            // '@' + g_GameCommand.STARTITEMEVENT.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.ITEMEVENTTERM,
//            // '@' + g_GameCommand.ITEMEVENTTERM.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.OPDELETESKILL,
//            // '@' + g_GameCommand.OPDELETESKILL.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.CHANGEWEAPONDURA,
//            // '@' + g_GameCommand.CHANGEWEAPONDURA.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.SBKDOOR,
//            // '@' + g_GameCommand.SBKDOOR.sCmd,
//            // '');
//            RefGameMasterCmd(M2Share.g_GameCommand.SPIRIT, "@" + M2Share.g_GameCommand.SPIRIT.sCmd + "  时间(秒)", "用于开始祈祷生效宝宝叛变(权限6以上)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SPIRITSTOP, "@" + M2Share.g_GameCommand.SPIRITSTOP.sCmd, "用于停止祈祷生效导致宝宝叛变(权限6以上)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CLEARCOPYITEM, "@" + M2Share.g_GameCommand.CLEARCOPYITEM.sCmd + " 人物名称", "清除人物包裹仓库复制品(支持权限分配)");
//        }

//        private void RefGameDebugCmd(TGameCmd GameCmd, string sCmdParam, string sDesc)
//        {
//            nRefGameDebugIndex ++;
            
//            if (StringGridGameMasterCmd.RowCount - 1 < nRefGameDebugIndex)
//            {
                
//                StringGridGameDebugCmd.RowCount = nRefGameDebugIndex + 1;
//            }
            
//            StringGridGameDebugCmd.Cells[0, nRefGameDebugIndex] = GameCmd.sCmd;
            
//            StringGridGameDebugCmd.Cells[1, nRefGameDebugIndex] = (GameCmd.nPermissionMin).ToString() + "/" + (GameCmd.nPermissionMax).ToString();
            
//            StringGridGameDebugCmd.Cells[2, nRefGameDebugIndex] = sCmdParam;
            
//            StringGridGameDebugCmd.Cells[3, nRefGameDebugIndex] = sDesc;
            
//            StringGridGameDebugCmd.Objects[0, nRefGameDebugIndex] = ((GameCmd) as Object);
//        }

//        // 调试命令
//        private void RefDebugCommand()
//        {
//            TGameCmd GameCmd;
//            EditGameDebugCmdOK.Enabled = false;
//            // StringGridGameDebugCmd.RowCount:=41;
//            GameCmd = M2Share.g_GameCommand.SHOWFLAG;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "");
//            GameCmd = M2Share.g_GameCommand.SETFLAG;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " 人物名称 标志号 数字(0 - 1)", "");
//            // GameCmd := @g_GameCommand.SHOWOPEN;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '');
//            // 
//            // GameCmd := @g_GameCommand.SETOPEN;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '');
//            // 
//            // GameCmd := @g_GameCommand.SHOWUNIT;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '');
//            // 
//            // GameCmd := @g_GameCommand.SETUNIT;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '');
//            GameCmd = M2Share.g_GameCommand.MOBNPC;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " NPC名称 脚本文件名 外形(数字) 属沙城(0,1)", "增加NPC");
//            GameCmd = M2Share.g_GameCommand.DELNPC;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "删除NPC(需与NPC面对面)");
//            GameCmd = M2Share.g_GameCommand.LOTTERYTICKET;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "查看彩票中奖数据");
//            GameCmd = M2Share.g_GameCommand.RELOADADMIN;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "重新加载管理员列表");
//            GameCmd = M2Share.g_GameCommand.ReLoadNpc;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "重新加载NPC脚本");
//            GameCmd = M2Share.g_GameCommand.RELOADMANAGE;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "重新加载登录脚本");
//            GameCmd = M2Share.g_GameCommand.RELOADROBOTMANAGE;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "重新加载机器人配置");
//            GameCmd = M2Share.g_GameCommand.RELOADROBOT;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "重新加载机器人脚本");
//            GameCmd = M2Share.g_GameCommand.RELOADMONITEMS;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "重新加载怪物爆率配置");
//            // GameCmd := @g_GameCommand.RELOADDIARY; //20080812 注释
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '未使用');
//            GameCmd = M2Share.g_GameCommand.RELOADITEMDB;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "重新加载物品数据库");
//            GameCmd = M2Share.g_GameCommand.RELOADMAGICDB;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "重新加载魔法数据库");
//            GameCmd = M2Share.g_GameCommand.RELOADMONSTERDB;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "重新加载怪物数据库");
//            GameCmd = M2Share.g_GameCommand.RELOADMINMAP;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "重新加载小地图配置");
//            GameCmd = M2Share.g_GameCommand.RELOADGUILD;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " 行会名称", "重新加载指定的行会");
//            // GameCmd := @g_GameCommand.RELOADGUILDALL;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '未使用');
//            GameCmd = M2Share.g_GameCommand.RELOADLINENOTICE;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "重新加载游戏公告信息");
//            GameCmd = M2Share.g_GameCommand.RELOADABUSE;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "重新加载脏话过滤配置");
//            GameCmd = M2Share.g_GameCommand.BACKSTEP;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " 方向(0-8) 人数", "推开人物");
//            GameCmd = M2Share.g_GameCommand.RECONNECTION;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "将指定人物重新切换网络连接");
//            GameCmd = M2Share.g_GameCommand.DISABLEFILTER;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "禁用脏话过滤功能");
//            GameCmd = M2Share.g_GameCommand.CHGUSERFULL;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " 人数", "设置服务器最高上线人数");
//            GameCmd = M2Share.g_GameCommand.CHGZENFASTSTEP;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " 速度", "设置怪物行动速度");
//            // GameCmd := @g_GameCommand.OXQUIZROOM;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '未使用');
//            // 
//            // GameCmd := @g_GameCommand.BALL;//20080812 注释
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '未使用');
//            GameCmd = M2Share.g_GameCommand.FIREBURN;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " 类型(1-6) 时间(秒) 点数", "增加场景");
//            GameCmd = M2Share.g_GameCommand.TESTFIRE;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " 范围 类型(1-6) 时间(秒) 点数", "在一定范围增加场景");
//            GameCmd = M2Share.g_GameCommand.TESTSTATUS;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " 类型(0..11) 时长", "改变人物的临时属性");
//            // GameCmd := @g_GameCommand.TESTGOLDCHANGE; //20080812 注释
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '未使用');
//            // 
//            // GameCmd := @g_GameCommand.GSA;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '未使用');
//            // GameCmd := @g_GameCommand.TESTGA;//20081014 注释
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '输入TESTGA命令');
//            GameCmd = M2Share.g_GameCommand.MAPINFO;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " 地图号 X Y", "显示地图信息");
//            GameCmd = M2Share.g_GameCommand.CLEARBAG;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " 人物名称", "清除背包全部物品");
//        }

//        public void StringGridGameMasterCmdClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TGameCmd GameCmd;
//            nIndex = StringGridGameMasterCmd.CurrentRowIndex;
            
//            GameCmd = ((TGameCmd)(StringGridGameMasterCmd.Objects[0, nIndex]));
//            if (GameCmd != null)
//            {
//                EditGameMasterCmdName.Text = GameCmd.sCmd;
//                EditGameMasterCmdPerMission.Value = GameCmd.nPermissionMin;
                
//                LabelGameMasterCmdParam.Text = StringGridGameMasterCmd.Cells[2, nIndex];
                
//                LabelGameMasterCmdFunc.Text = StringGridGameMasterCmd.Cells[3, nIndex];
//            }
//            EditGameMasterCmdOK.Enabled = false;
//        }

//        public void EditGameMasterCmdNameChange(object sender, EventArgs e)
//        {
//            EditGameMasterCmdOK.Enabled = true;
//            EditGameMasterCmdSave.Enabled = true;
//        }

//        public void EditGameMasterCmdPerMissionChange(Object Sender)
//        {
//            EditGameMasterCmdOK.Enabled = true;
//            EditGameMasterCmdSave.Enabled = true;
//        }

//        public void EditGameMasterCmdOKClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TGameCmd GameCmd;
//            string sCmd;
//            int nPermission;
//            sCmd = EditGameMasterCmdName.Text.Trim();
//            nPermission = EditGameMasterCmdPerMission.Value;
//            if (sCmd == "")
//            {
//                System.Windows.Forms.MessageBox.Show("命令名称不能为空！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK);
//                EditGameMasterCmdName.Focus();
//                return;
//            }
//            nIndex = StringGridGameMasterCmd.CurrentRowIndex;
            
//            GameCmd = ((TGameCmd)(StringGridGameMasterCmd.Objects[0, nIndex]));
//            if (GameCmd != null)
//            {
//                GameCmd.sCmd = sCmd;
//                GameCmd.nPermissionMin = nPermission;
//            }
//            RefGameMasterCommand();
//        }

//        public void EditGameMasterCmdSaveClick(object sender, EventArgs e)
//        {
//            EditGameMasterCmdSave.Enabled = false;
            
//            M2Share.CommandConf.WriteString("Command", "ObServer", M2Share.g_GameCommand.OBSERVER.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "GameMaster", M2Share.g_GameCommand.GAMEMASTER.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "SuperMan", M2Share.g_GameCommand.SUEPRMAN.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "StorageClearPassword", M2Share.g_GameCommand.CLRPASSWORD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ClearCopyItem", M2Share.g_GameCommand.CLEARCOPYITEM.sCmd);
//            // 20080816 清理玩家复制品
            
//            M2Share.CommandConf.WriteString("Command", "Who", M2Share.g_GameCommand.WHO.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Total", M2Share.g_GameCommand.TOTAL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Make", M2Share.g_GameCommand.MAKE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "PositionMove", M2Share.g_GameCommand.POSITIONMOVE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Move", M2Share.g_GameCommand.Move.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Recall", M2Share.g_GameCommand.RECALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ReGoto", M2Share.g_GameCommand.REGOTO.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Ting", M2Share.g_GameCommand.TING.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "SuperTing", M2Share.g_GameCommand.SUPERTING.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MapMove", M2Share.g_GameCommand.MAPMOVE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Info", M2Share.g_GameCommand.INFO.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "HumanLocal", M2Share.g_GameCommand.HUMANLOCAL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ViewWhisper", M2Share.g_GameCommand.VIEWWHISPER.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MobLevel", M2Share.g_GameCommand.MOBLEVEL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MobCount", M2Share.g_GameCommand.MOBCOUNT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "HumanCount", M2Share.g_GameCommand.HUMANCOUNT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Map", M2Share.g_GameCommand.Map.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Level", M2Share.g_GameCommand.Level.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Kick", M2Share.g_GameCommand.KICK.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ReAlive", M2Share.g_GameCommand.ReAlive.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Kill", M2Share.g_GameCommand.KILL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ChangeJob", M2Share.g_GameCommand.CHANGEJOB.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "FreePenalty", M2Share.g_GameCommand.FREEPENALTY.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "PkPoint", M2Share.g_GameCommand.PKPOINT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "IncPkPoint", M2Share.g_GameCommand.IncPkPoint.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ChangeGender", M2Share.g_GameCommand.CHANGEGENDER.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Hair", M2Share.g_GameCommand.HAIR.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "BonusPoint", M2Share.g_GameCommand.BonusPoint.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "DelBonuPoint", M2Share.g_GameCommand.DELBONUSPOINT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "RestBonuPoint", M2Share.g_GameCommand.RESTBONUSPOINT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "SetPermission", M2Share.g_GameCommand.SETPERMISSION.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ReNewLevel", M2Share.g_GameCommand.RENEWLEVEL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "DelGold", M2Share.g_GameCommand.DELGOLD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AddGold", M2Share.g_GameCommand.ADDGOLD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "GameGold", M2Share.g_GameCommand.GAMEGOLD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "GameDiaMond", M2Share.g_GameCommand.GAMEDIAMOND.sCmd);
//            // 20071226 金刚石
            
//            M2Share.CommandConf.WriteString("Command", "GameGird", M2Share.g_GameCommand.GAMEGIRD.sCmd);
//            // 20071226 灵符
            
//            M2Share.CommandConf.WriteString("Command", "HEROLOYAL", M2Share.g_GameCommand.HEROLOYAL.sCmd);
//            // 20080109 英雄的忠诚度
            
//            M2Share.CommandConf.WriteString("Command", "GamePoint", M2Share.g_GameCommand.GAMEPOINT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "CreditPoint", M2Share.g_GameCommand.CREDITPOINT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "RefineWeapon", M2Share.g_GameCommand.REFINEWEAPON.sCmd);
//            // g_GameCommand.SysMsg.sCmd
            
//            M2Share.CommandConf.WriteString("Command", "SysMsg", "传");
//            // 千里传音 20071228
            
//            M2Share.CommandConf.WriteString("Command", "HEROLEVEL", M2Share.g_GameCommand.HEROLEVEL.sCmd);
//            // 调整英雄等级 20071227
            
//            M2Share.CommandConf.WriteString("Command", "AdjuestTLevel", M2Share.g_GameCommand.ADJUESTLEVEL.sCmd);
//            // 调整人物等级
            
//            M2Share.CommandConf.WriteString("Command", "NGLevel", M2Share.g_GameCommand.NGLEVEL.sCmd);
//            // 调整人物内功等级 20081221
            
//            M2Share.CommandConf.WriteString("Command", "AdjuestExp", M2Share.g_GameCommand.ADJUESTEXP.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ChangeDearName", M2Share.g_GameCommand.CHANGEDEARNAME.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ChangeMasterrName", M2Share.g_GameCommand.CHANGEMASTERNAME.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "RecallMob", M2Share.g_GameCommand.RECALLMOB.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "RECALLMOBEX", M2Share.g_GameCommand.RECALLMOBEX.sCmd);
//            // 20080122 召唤宝宝
            
//            M2Share.CommandConf.WriteString("Command", "GIVEMINE", M2Share.g_GameCommand.GIVEMINE.sCmd);
//            // 20080403 给指定纯度的矿石
            
//            M2Share.CommandConf.WriteString("Command", "MOVEMOBTO", M2Share.g_GameCommand.MOVEMOBTO.sCmd);
//            // 20080123 将指定坐标的怪物移动到新坐标
            
//            M2Share.CommandConf.WriteString("Command", "CLEARITEMMAP", M2Share.g_GameCommand.CLEARITEMMAP.sCmd);
//            // 20080124 清除地图物品
            
//            M2Share.CommandConf.WriteString("Command", "Training", M2Share.g_GameCommand.TRAINING.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "OpTraining", M2Share.g_GameCommand.TRAININGSKILL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "DeleteSkill", M2Share.g_GameCommand.DELETESKILL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "DeleteItem", M2Share.g_GameCommand.DELETEITEM.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ClearMission", M2Share.g_GameCommand.CLEARMISSION.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AddGuild", M2Share.g_GameCommand.AddGuild.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "DelGuild", M2Share.g_GameCommand.DELGUILD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ChangeSabukLord", M2Share.g_GameCommand.CHANGESABUKLORD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ForcedWallConQuestWar", M2Share.g_GameCommand.FORCEDWALLCONQUESTWAR.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ContestPoint", M2Share.g_GameCommand.CONTESTPOINT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "StartContest", M2Share.g_GameCommand.STARTCONTEST.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "EndContest", M2Share.g_GameCommand.ENDCONTEST.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Announcement", M2Share.g_GameCommand.ANNOUNCEMENT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MobLevel", M2Share.g_GameCommand.MOBLEVEL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Mission", M2Share.g_GameCommand.Mission.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MobPlace", M2Share.g_GameCommand.MobPlace.sCmd);
            
//            M2Share.CommandConf.WriteInteger("Permission", "GameMaster", M2Share.g_GameCommand.GAMEMASTER.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ObServer", M2Share.g_GameCommand.OBSERVER.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "SuperMan", M2Share.g_GameCommand.SUEPRMAN.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "StorageClearPassword", M2Share.g_GameCommand.CLRPASSWORD.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ClearCopyItem", M2Share.g_GameCommand.CLEARCOPYITEM.nPermissionMin);
//            // 20080816 清理玩家复制品
            
//            M2Share.CommandConf.WriteInteger("Permission", "Who", M2Share.g_GameCommand.WHO.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Total", M2Share.g_GameCommand.TOTAL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MakeMin", M2Share.g_GameCommand.MAKE.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MakeMax", M2Share.g_GameCommand.MAKE.nPermissionMax);
            
//            M2Share.CommandConf.WriteInteger("Permission", "PositionMoveMin", M2Share.g_GameCommand.POSITIONMOVE.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "PositionMoveMax", M2Share.g_GameCommand.POSITIONMOVE.nPermissionMax);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MoveMin", M2Share.g_GameCommand.Move.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MoveMax", M2Share.g_GameCommand.Move.nPermissionMax);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Recall", M2Share.g_GameCommand.RECALL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ReGoto", M2Share.g_GameCommand.REGOTO.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Ting", M2Share.g_GameCommand.TING.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "SuperTing", M2Share.g_GameCommand.SUPERTING.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MapMove", M2Share.g_GameCommand.MAPMOVE.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Info", M2Share.g_GameCommand.INFO.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "HumanLocal", M2Share.g_GameCommand.HUMANLOCAL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ViewWhisper", M2Share.g_GameCommand.VIEWWHISPER.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MobLevel", M2Share.g_GameCommand.MOBLEVEL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MobCount", M2Share.g_GameCommand.MOBCOUNT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "HumanCount", M2Share.g_GameCommand.HUMANCOUNT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Map", M2Share.g_GameCommand.Map.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Level", M2Share.g_GameCommand.Level.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Kick", M2Share.g_GameCommand.KICK.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ReAlive", M2Share.g_GameCommand.ReAlive.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Kill", M2Share.g_GameCommand.KILL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ChangeJob", M2Share.g_GameCommand.CHANGEJOB.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "FreePenalty", M2Share.g_GameCommand.FREEPENALTY.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "PkPoint", M2Share.g_GameCommand.PKPOINT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "IncPkPoint", M2Share.g_GameCommand.IncPkPoint.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ChangeGender", M2Share.g_GameCommand.CHANGEGENDER.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Hair", M2Share.g_GameCommand.HAIR.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "BonusPoint", M2Share.g_GameCommand.BonusPoint.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "DelBonuPoint", M2Share.g_GameCommand.DELBONUSPOINT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "RestBonuPoint", M2Share.g_GameCommand.RESTBONUSPOINT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "SetPermission", M2Share.g_GameCommand.SETPERMISSION.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ReNewLevel", M2Share.g_GameCommand.RENEWLEVEL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "DelGold", M2Share.g_GameCommand.DELGOLD.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "AddGold", M2Share.g_GameCommand.ADDGOLD.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "GameGold", M2Share.g_GameCommand.GAMEGOLD.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "GameDiaMond", M2Share.g_GameCommand.GAMEDIAMOND.nPermissionMin);
//            // 20071226 金刚石
            
//            M2Share.CommandConf.WriteInteger("Permission", "GameGird", M2Share.g_GameCommand.GAMEGIRD.nPermissionMin);
//            // 20071226 灵符
            
//            M2Share.CommandConf.WriteInteger("Permission", "HEROLOYAL", M2Share.g_GameCommand.HEROLOYAL.nPermissionMin);
//            // 20080109 英雄的忠诚度
            
//            M2Share.CommandConf.WriteInteger("Permission", "GamePoint", M2Share.g_GameCommand.GAMEPOINT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "CreditPoint", M2Share.g_GameCommand.CREDITPOINT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "RefineWeapon", M2Share.g_GameCommand.REFINEWEAPON.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "SysMsg", M2Share.g_GameCommand.SysMsg.nPermissionMin);
//            // 千里传音 20071228
            
//            M2Share.CommandConf.WriteInteger("Permission", "HEROLEVEL", M2Share.g_GameCommand.HEROLEVEL.nPermissionMin);
//            // 调整英雄等级 20071227
            
//            M2Share.CommandConf.WriteInteger("Permission", "AdjuestTLevel", M2Share.g_GameCommand.ADJUESTLEVEL.nPermissionMin);
//            // 调整人物等级
            
//            M2Share.CommandConf.WriteInteger("Permission", "NGLevel", M2Share.g_GameCommand.NGLEVEL.nPermissionMin);
//            // 调整人物内功等级 20081221
            
//            M2Share.CommandConf.WriteInteger("Permission", "AdjuestExp", M2Share.g_GameCommand.ADJUESTEXP.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ChangeDearName", M2Share.g_GameCommand.CHANGEDEARNAME.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ChangeMasterName", M2Share.g_GameCommand.CHANGEMASTERNAME.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "RecallMob", M2Share.g_GameCommand.RECALLMOB.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "RECALLMOBEX", M2Share.g_GameCommand.RECALLMOBEX.nPermissionMin);
//            // 20080122 召唤宝宝
            
//            M2Share.CommandConf.WriteInteger("Permission", "GIVEMINE", M2Share.g_GameCommand.GIVEMINE.nPermissionMin);
//            // 20080403 给指定纯度的矿石
            
//            M2Share.CommandConf.WriteInteger("Permission", "MOVEMOBTO", M2Share.g_GameCommand.MOVEMOBTO.nPermissionMin);
//            // 20080123 将指定坐标的怪物移动到新坐标
            
//            M2Share.CommandConf.WriteInteger("Permission", "CLEARITEMMAP", M2Share.g_GameCommand.CLEARITEMMAP.nPermissionMin);
//            // 20080124 清除地图物品
            
//            M2Share.CommandConf.WriteInteger("Permission", "Training", M2Share.g_GameCommand.TRAINING.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "OpTraining", M2Share.g_GameCommand.TRAININGSKILL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "DeleteSkill", M2Share.g_GameCommand.DELETESKILL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "DeleteItem", M2Share.g_GameCommand.DELETEITEM.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ClearMission", M2Share.g_GameCommand.CLEARMISSION.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "AddGuild", M2Share.g_GameCommand.AddGuild.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "DelGuild", M2Share.g_GameCommand.DELGUILD.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ChangeSabukLord", M2Share.g_GameCommand.CHANGESABUKLORD.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ForcedWallConQuestWar", M2Share.g_GameCommand.FORCEDWALLCONQUESTWAR.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ContestPoint", M2Share.g_GameCommand.CONTESTPOINT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "StartContest", M2Share.g_GameCommand.STARTCONTEST.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "EndContest", M2Share.g_GameCommand.ENDCONTEST.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Announcement", M2Share.g_GameCommand.ANNOUNCEMENT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MobLevel", M2Share.g_GameCommand.MOBLEVEL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Mission", M2Share.g_GameCommand.Mission.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MobPlace", M2Share.g_GameCommand.MobPlace.nPermissionMin);
//        }

//        public void StringGridGameDebugCmdClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TGameCmd GameCmd;
//            nIndex = StringGridGameDebugCmd.CurrentRowIndex;
            
//            GameCmd = ((TGameCmd)(StringGridGameDebugCmd.Objects[0, nIndex]));
//            if (GameCmd != null)
//            {
//                EditGameDebugCmdName.Text = GameCmd.sCmd;
//                EditGameDebugCmdPerMission.Value = GameCmd.nPermissionMin;
                
//                LabelGameDebugCmdParam.Text = StringGridGameDebugCmd.Cells[2, nIndex];
                
//                LabelGameDebugCmdFunc.Text = StringGridGameDebugCmd.Cells[3, nIndex];
//            }
//            EditGameDebugCmdOK.Enabled = false;
//        }

//        public void EditGameDebugCmdNameChange(object sender, EventArgs e)
//        {
//            EditGameDebugCmdOK.Enabled = true;
//            EditGameDebugCmdSave.Enabled = true;
//        }

//        public void EditGameDebugCmdPerMissionChange(Object Sender)
//        {
//            EditGameDebugCmdOK.Enabled = true;
//            EditGameDebugCmdSave.Enabled = true;
//        }

//        public void EditGameDebugCmdOKClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TGameCmd GameCmd;
//            string sCmd;
//            int nPermission;
//            sCmd = EditGameDebugCmdName.Text.Trim();
//            nPermission = EditGameDebugCmdPerMission.Value;
//            if (sCmd == "")
//            {
//                System.Windows.Forms.MessageBox.Show("命令名称不能为空！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                EditGameDebugCmdName.Focus();
//                return;
//            }
//            nIndex = StringGridGameDebugCmd.CurrentRowIndex;
            
//            GameCmd = ((TGameCmd)(StringGridGameDebugCmd.Objects[0, nIndex]));
//            if (GameCmd != null)
//            {
//                GameCmd.sCmd = sCmd;
//                GameCmd.nPermissionMin = nPermission;
//            }
//            RefDebugCommand();
//        }

//        public void EditGameDebugCmdSaveClick(object sender, EventArgs e)
//        {
//            EditGameDebugCmdSave.Enabled = false;
//        }

//        public void FormDestroy(Object Sender)
//        {
//            Units.GameCommand.frmGameCmd = null;
//        }

//        public void FormClose(object sender, EventArgs e)
//        {
            
//            Action = caFree;
//        }

    } 
}

