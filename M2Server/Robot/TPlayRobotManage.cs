using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;

namespace M2Server
{
    public class TPlayRobotManage
    {
        public List<TPlayRobotObject> RobotHumanList = null;
        public Object PlayObject = null;

        public TPlayRobotManage()
        {
            PlayObject = null;
            RobotHumanList = new List<TPlayRobotObject>();
            LoadRobot();
        }

        ~TPlayRobotManage()
        {
            UnLoadRobot();
        }

        private void LoadRobot()
        {
            TStringList LoadList;
            string sFileName = string.Empty;
            string sLineText = string.Empty;
            string sRobotName = string.Empty;
            string sScriptFileName = string.Empty;
            string sRobotType = string.Empty;
            TPlayRobotObject RobotHuman;
            sFileName = M2Share.g_Config.sEnvirDir + "Robot.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                if (LoadList.Count > 0)
                {
                    for (int I = 0; I < LoadList.Count; I++)
                    {
                        sLineText = LoadList[I];
                        if ((sLineText != "") && (sLineText[0] != ';'))
                        {
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sRobotName, new string[] { " ", "/", "\09" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sScriptFileName, new string[] { " ", "/", "\09" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sRobotType, new string[] { " ", "/", "\09" });
                            if ((sRobotName != "") && (sScriptFileName != "") && (sRobotType == "1"))
                            {
                                RobotHuman = new TPlayRobotObject();
                                RobotHuman.m_sCharName = sRobotName;
                                RobotHuman.m_sScriptFileName = sScriptFileName;
                                RobotHuman.LoadScript();
                                RobotHumanList.Add(RobotHuman);
                            }
                        }
                    }
                }
                Dispose(LoadList);
            }
        }

        public void RELOADROBOT()
        {
            UnLoadRobot();
            LoadRobot();
        }

        public void Run()
        {
            try
            {
                if (PlayObject != null)
                {
                    foreach (var RobotHuman in RobotHumanList)
                    {
                        RobotHuman.Run(PlayObject);
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TPlayRobotManage::Run");
            }
        }

        private void UnLoadRobot()
        {
            if (RobotHumanList.Count > 0)
            {
                for (int I = 0; I < RobotHumanList.Count; I++)
                {
                    Dispose(RobotHumanList[I]);
                }
            }
            RobotHumanList.Clear();
        }


        /// <summary>
        /// 释放指定对象资源
        /// </summary>
        /// <param name="obj"></param>
        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}
