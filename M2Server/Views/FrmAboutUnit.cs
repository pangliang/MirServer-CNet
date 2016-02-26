using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmRegister : Form
    {
        public static TfrmRegister frmRegister = null;

        public TfrmRegister()
        {
            InitializeComponent();
        }

        public void Open()
        {
            RefRegInfo();
            this.ShowDialog();
        }

        private void RefRegInfo()
        {
            string RegName = M2Share.g_Config.sServerName;
            string CompanyName = AESEncrypt(M2Share.g_Config.sServerIPaddr + M2Share.g_Config.sServerName, "12345679");
            EditProductName.Text = EngineVersion.g_sTitleName;// 刺客帝国第二代游戏引擎
            EditVersion.Text = "程序版本:" + EngineVersion.g_BuildVer;// 程序版本: V5.18 Build 20100418(内部版)
            EditUpDateTime.Text = "编译时间:" + EngineVersion.g_sUpDateTime;// 编译时间: 2010/04/18
            EditWebSite.Text = "程序网站:" + EngineVersion.g_sWebSite;// 程序网站: http://www.uc845.com
            EditBbsSite.Text = "程序论坛:" + EngineVersion.g_sWebSite;// 程序论坛: http://www.uc845.com
            EditCopyright.Text = "Copyright (C) 2009-2012 DraGon Corporation";// Copyright (C) 2009-2012 DraGon Corporation
            Editkeyxxi.Text = "注册授权: 请将[硬件信息/注册标识]发送给作者'";// 注册授权: 请将[硬件信息/注册标识]发送给作者'
            try
            {
                EditRegHWInfo.Text = AESEncrypt(EngineVersion.g_sTitleName, "asdasdasd");
                EditTianShu.Text = "9999";
                EditChiShu.Text = "9999";
                EditRegCodeKey.Text = "";
                int nStatus = 6;
                switch (nStatus)
                {
                    case 0:
                        this.Text = "软件注册 [试用模式]";
                        break;
                    case 1:
                        this.Text = "软件注册 [已注册]";
                        break;
                    case 2:
                        this.Text = "软件注册 [授权文件错误]";
                        break;
                    case 3:
                        this.Text = "软件注册 [授权文件错误]";
                        break;
                    case 4:
                        this.Text = "软件注册 [硬件变换多次]";
                        break;
                    case 5:
                        this.Text = "软件注册 [授权文件过期)";
                        break;
                    case 6:
                        this.Text = "软件注册 [无限制)";
                        break;
                }
                if (nStatus == 1 || nStatus==6)
                {
                    EditRegCodeKey.Text = RegName;
                    EditRegUserIPAddr.Text = CompanyName;
                    EditRegCodeKey.BackColor = System.Drawing.SystemColors.ButtonFace;
                    EditRegCodeKey.ReadOnly = true;
                    //EditRegCodeKey.ParentCtl3D = false;
                    //EditRegCodeKey.ParentFont = false;
                    EditTianShu.Text = "无限制";
                    EditChiShu.Text = "无限制";
                    //FillChar(TrialDate, sizeof(SYSTEMTIME), '\0');
                    //WLRegExpirationDate(Addr(TrialDate));
                    //DateTimePicker1.Value = TrialDate;
                }
                else
                {
                    // EditRegUserIPAddr.Text = jiami;
                    //FillChar(TrialDate, sizeof(SYSTEMTIME), '\0');
                    //WLTrialExpirationDate(Addr(TrialDate));
                    //DateTimePicker1.Value = TrialDate;
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// AES 加密(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="EncryptString">待加密密文</param>
        /// <param name="EncryptKey">加密密钥</param>
        /// <returns></returns>
        public static string AESEncrypt(string EncryptString, string EncryptKey)
        {
            if (string.IsNullOrEmpty(EncryptString)) { throw (new Exception("密文不得为空")); }

            if (string.IsNullOrEmpty(EncryptKey)) { throw (new Exception("密钥不得为空")); }

            string m_strEncrypt = "";

            byte[] m_btIV = Convert.FromBase64String("Rkb4jvUy/ye7Cd7k89QQgQ==");

            Rijndael m_AESProvider = Rijndael.Create();

            try
            {
                byte[] m_btEncryptString = Encoding.Default.GetBytes(EncryptString);

                MemoryStream m_stream = new MemoryStream();

                CryptoStream m_csstream = new CryptoStream(m_stream, m_AESProvider.CreateEncryptor(Encoding.Default.GetBytes(EncryptKey), m_btIV), CryptoStreamMode.Write);

                m_csstream.Write(m_btEncryptString, 0, m_btEncryptString.Length);

                m_csstream.FlushFinalBlock();

                m_strEncrypt = Convert.ToBase64String(m_stream.ToArray());

                m_stream.Close(); m_stream.Dispose();

                m_csstream.Close(); m_csstream.Dispose();
            }
            catch (IOException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { m_AESProvider.Clear(); }

            return m_strEncrypt;
        }
    }
}