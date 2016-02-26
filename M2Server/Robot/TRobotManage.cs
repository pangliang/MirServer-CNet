using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;

namespace M2Server
{
    public class TRobotManage
    {
        public List<TRobotObject> RobotHumanList = null;

        public TRobotManage()
        {
            RobotHumanList = new List<TRobotObject>();
            LoadRobot();
        }

        ~TRobotManage()
        {
            UnLoadRobot();
            Dispose(RobotHumanList);
        }

        private void LoadRobot()
        {
            TStringList LoadList;
            string sFileName = string.Empty;
            string sLineText = string.Empty;
            string sRobotName = string.Empty;
            string sScriptFileName = string.Empty;
            string sRobotType = string.Empty;
            TRobotObject RobotHuman;
            sFileName = M2Share.g_Config.sEnvirDir + "Robot.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    if ((sLineText != "") && (sLineText[0] != ';'))
                    {
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sRobotName, new string[] { " ", "/", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sScriptFileName, new string[] { " ", "/", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sRobotType, new string[] { " ", "/", "\09" });
                        if ((sRobotName != "") && (sScriptFileName != "") && (sRobotType != "1"))
                        {
                            RobotHuman = new TRobotObject();
                            RobotHuman.m_sCharName = sRobotName;
                            RobotHuman.m_sScriptFileName = sScriptFileName;
                            RobotHuman.LoadScript();
                            RobotHumanList.Add(RobotHuman);
                        }
                    }
                }
                Dispose(LoadList);
            }
        }

        public void ReLoadRobot()
        {
            UnLoadRobot();
            LoadRobot();
        }

        public void Run()
        {
            try
            {
                foreach (var RobotObject in RobotHumanList)
                {
                    if (RobotObject != null)
                    {
                        RobotObject.Run();
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TRobotManage::Run");
            }
        }

        private void UnLoadRobot()
        {
            try
            {
                foreach (var RobotObject in RobotHumanList)
                {
                    if (RobotObject != null)
                        Dispose(RobotObject);
                }
                RobotHumanList.Clear();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TRobotManage::UnLoadRobot");
            }
        }

        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}