using System;
using System.Windows.Forms;
using System.Collections;
using GameFramework;
using System.Collections.Generic;

namespace M2Server
{
    public partial class TfrmConfigMonGen: Form
    {
        public class ConfigMonGen
        {
            public static TfrmConfigMonGen frmConfigMonGen = null;
            public static TEnvirnoment SelEnvirnoment = null;
        } 
        public TfrmConfigMonGen()
        {
            InitializeComponent();
        }

        private  void RefListViewSession()
        {
            int I;
            TBaseObject Monster;
            ListViewItem ListItem;
            List<TBaseObject> MonList;
            this.Text = "正在取得数据...";
            PanelStatus.Text = "正在取得数据...";
            ListView.Visible = false;
            ListView.Items.Clear();
            if (ConfigMonGen.SelEnvirnoment != null)
            {
                MonList = new List<TBaseObject>();
                M2Share.UserEngine.GetMapMonster(ConfigMonGen.SelEnvirnoment, MonList);
                for (I = 0; I < MonList.Count; I++)
                {
                    Monster = ((TBaseObject)(MonList[I]));
                    ListItem = new ListViewItem();
                    ListItem.Text = (I + 1).ToString();
                    ListItem.SubItems.Add(Monster.m_sCharName);
                    ListItem.SubItems.Add((Monster.m_nCurrX).ToString() + ':' + (Monster.m_nCurrY).ToString());
                    ListItem.SubItems.Add((Monster.m_Abil.Level).ToString());
                    ListItem.SubItems.Add((Monster.m_Abil.HP).ToString() + '/' + (Monster.m_Abil.MaxHP).ToString());
                    ListItem.SubItems.Add((Monster.m_Abil.MP).ToString() + '/' + (Monster.m_Abil.MaxMP).ToString());
                    ListItem.SubItems.Add(HUtil32.BooleanToStr(Monster.m_boDeath));
                    ListView.Items.Add(ListItem);
                }
                this.Text = ConfigMonGen.SelEnvirnoment.sMapDesc + ' ' + "怪物数:" + (ListView.Items.Count).ToString();
            }
            ListView.Visible = true;
        }

        public void Open(TEnvirnoment Envir)
        {
            ConfigMonGen.SelEnvirnoment = Envir;
            RefListViewSession();
            PopupMenu_AutoRef.Checked = false;
            Timer.Enabled = PopupMenu_AutoRef.Checked;
            PopupMenu_AutoRef.Enabled = false;
            this.ShowDialog();
        }

        //public bool TimerTimer_FindListView(Object Monster)
        //{
        //    bool result;
        //    int I;
        //    ListViewItem ListItem;
        //    result = false;
        //    for (I = 0; I < ListView.Items.Count; I ++ )
        //    {
        //        ListItem = ListView.Items[I];
        //        
        //        if (ListItem.SubItems[0] == Monster)
        //        {
        //            result = true;
        //            break;
        //        }
        //    }
        //    return result;
        //}
        //public void TimerTimer(System.Object Sender, System.EventArgs _e1)
        //{
        //    int I;
        //    int II;
        //    int n01;
        //    TMonGenInfo MonGen;
        //    TActorObject Monster;
        //    ListViewItem ListItem;
        //    ArrayList MonList;
        //    bool boFind;
        //    string sMsg;
        //    n01 = 0;
        //    if (Units.ConfigMonGen.SelEnvirnoment != null)
        //    {
        //        MonList = new ArrayList();
        //        UserEngine.GetMapMonster(Units.ConfigMonGen.SelEnvirnoment, MonList);
        //        for (I = 0; I < MonList.Count; I ++ )
        //        {
        //            Monster = ((TActorObject)(MonList[I]));
        //            if (!TimerTimer_FindListView(Monster))
        //            {
        //                //ListItem = ListView.Items.Add();
        //                //ListItem.Text = (I + 1).ToString();
        //                //ListItem.SubItems.AddObject(Monster.m_sCharName, Monster);
        //                //ListItem.SubItems.Add((Monster.m_nCurrX).ToString() + ':' + (Monster.m_nCurrY).ToString());
        //                //ListItem.SubItems.Add((Monster.m_Abil.Level).ToString());
        //                //ListItem.SubItems.Add((Monster.m_Abil.HP).ToString() + '/' + (Monster.m_Abil.MaxHP).ToString());
        //                //ListItem.SubItems.Add((Monster.m_Abil.MP).ToString() + '/' + (Monster.m_Abil.MaxMP).ToString());
        //                //ListItem.SubItems.Add(HUtil32.BooleanToStr(Monster.m_boDeath));
        //            }
        //        }
        //        for (I = ListView.Items.Count - 1; I >= 0; I-- )
        //        {
        //            ListItem = ListView.Items[I];
        //            boFind = false;
        //            for (II = 0; II < MonList.Count; II ++ )
        //            {
        //                
        //                if (((TActorObject)(ListItem.SubItems[0])) == ((TActorObject)(MonList[II])))
        //                {
        //                    boFind = true;
        //                    break;
        //                }
        //            }
        //            if (!boFind)
        //            {
        //                
        //                ListView.Items.Delete(I);
        //            }
        //        }
        //        
        //        //MonList.Free;
        //    }
        //    n01 = 0;
        //    for (I = 0; I < ListView.Items.Count; I ++ )
        //    {
        //        ListItem = ListView.Items[I];
        //        n01 ++;
        //        if ((n01).ToString() != ListItem.Text)
        //        {
        //            ListItem.Text = (n01).ToString();
        //        }
        //        sMsg = (Monster.m_nCurrX).ToString() + ':' + (Monster.m_nCurrY).ToString();
        //        
        //        if (sMsg != ListItem.SubItems.Strings[1])
        //        {
        //            
        //            ListItem.SubItems.Strings[1] = sMsg;
        //        }
        //        sMsg = (Monster.m_Abil.Level).ToString();
        //        
        //        if (sMsg != ListItem.SubItems.Strings[2])
        //        {
        //            
        //            ListItem.SubItems.Strings[2] = sMsg;
        //        }
        //        sMsg = (Monster.m_Abil.HP).ToString() + '/' + (Monster.m_Abil.MaxHP).ToString();
        //        
        //        if (sMsg != ListItem.SubItems.Strings[3])
        //        {
        //            
        //            ListItem.SubItems.Strings[3] = sMsg;
        //        }
        //        sMsg = (Monster.m_Abil.MP).ToString() + '/' + (Monster.m_Abil.MaxMP).ToString();
        //        
        //        if (sMsg != ListItem.SubItems.Strings[4])
        //        {
        //            
        //            ListItem.SubItems.Strings[4] = sMsg;
        //        }
        //        sMsg = HUtil32.BooleanToStr(Monster.m_boDeath);
        //        
        //        if (sMsg != ListItem.SubItems.Strings[5])
        //        {
        //            
        //            ListItem.SubItems.Strings[5] = sMsg;
        //        }
        //    }
        //    this.Text = Units.ConfigMonGen.SelEnvirnoment.sMapDesc + ' ' + "怪物数:" + (ListView.Items.Count).ToString();
        //}
        //public void PopupMenu_AutoRefClick(System.Object Sender, System.EventArgs _e1)
        //{
        //    PopupMenu_AutoRef.Checked = !PopupMenu_AutoRef.Checked;
        //    Timer.Enabled = PopupMenu_AutoRef.Checked;
        //}
        //public bool PopupMenu_ClearClick_GetActorObject(TActorObject ActorObject)
        //{
        //    bool result;
        //    int I;
        //    ListViewItem ListItem;
        //    result = false;
        //    for (I = 0; I < ListView.Items.Count; I ++ )
        //    {
        //        ListItem = ListView.Items[I];
        //        
        //        if (ListItem.Selected && (ListItem.SubItems.Objects[0] == ActorObject))
        //        {
        //            result = true;
        //            break;
        //        }
        //    }
        //    return result;
        //}
        //public void PopupMenu_ClearClick(System.Object Sender, System.EventArgs _e1)
        //{
        //    int I;
        //    TActorObject ActorObject;
        //    ArrayList MonList;
        //    MonList = new ArrayList();
        //    UserEngine.GetMapMonster(Units.ConfigMonGen.SelEnvirnoment, MonList);
        //    for (I = 0; I < MonList.Count; I ++ )
        //    {
        //        ActorObject = ((TActorObject)(MonList[I]));
        //        if (ActorObject.m_Master != null)
        //        {
        //            continue;
        //        }
        //        if (!PopupMenu_ClearClick_GetActorObject(ActorObject))
        //        {
        //            continue;
        //        }
        //        if (M2Share.GetNoClearMonList(ActorObject.m_sCharName))
        //        {
        //            continue;
        //        }
        //        ActorObject.m_boNoItem = true;
        //        ActorObject.MakeGhost();
        //    }
        //    
        //    MonList.Free;
        //    RefListViewSession();
        //}
        //public void PopupMenu_ClearAllClick(System.Object Sender, System.EventArgs _e1)
        //{
        //    int I;
        //    TActorObject ActorObject;
        //    ArrayList MonList;
        //    MonList = new ArrayList();
        //    UserEngine.GetMapMonster(Units.ConfigMonGen.SelEnvirnoment, MonList);
        //    for (I = 0; I < MonList.Count; I ++ )
        //    {
        //        ActorObject = ((TActorObject)(MonList[I]));
        //        if (ActorObject.m_Master != null)
        //        {
        //            continue;
        //        }
        //        if (M2Share.GetNoClearMonList(ActorObject.m_sCharName))
        //        {
        //            continue;
        //        }
        //        ActorObject.m_boNoItem = true;
        //        ActorObject.MakeGhost();
        //    }
        //    
        //    //MonList.Free;
        //    RefListViewSession();
        //}
        //public void PopupMenu_RefClick(System.Object Sender, System.EventArgs _e1)
        //{
        //    RefListViewSession();
        //}
    } 
}
