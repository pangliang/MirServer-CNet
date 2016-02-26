/****************************************************************
** 文件名：DataGridViewHelper.cs
** Copyright(c)2012-2020 JohnSoft
** 创建人：陶志强
** 日  期：2012-3-17
** 修改人：
** 日  期：
** 描  述：DataGridView助手
****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;

namespace GameFramework
{
    public class DataGridViewHelper
    {
        /****************************************************************
        ** 函 数 名：AddDataGridViewColumn
        ** 功能描述：添加DataGridView列
        ** 输入参数：strHeaderText 字符串 <列显示名称>
        **           strDataPropertyName 字符串 <绑定字段>
        **           nWidth 整数型 <宽度>
        **           objTag 字符串 <对象型>
        **           myDataGridView DataGridView <目标数据网格>
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2012-3-17
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        public static void AddDataGridViewColumn(string strHeaderText, string strDataPropertyName, int nWidth, object objTag, DataGridView myDataGridView)
        {
            DataGridViewTextBoxColumn myDataGridViewColumn = new DataGridViewTextBoxColumn();
            myDataGridViewColumn.Name = strDataPropertyName;
            myDataGridViewColumn.HeaderText = strHeaderText;
            //myDataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            myDataGridViewColumn.DataPropertyName = strDataPropertyName;
            myDataGridViewColumn.Tag = objTag;
            myDataGridViewColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            if (nWidth == -1)
            {
                myDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                myDataGridViewColumn.Width = nWidth;
            }
            myDataGridView.Columns.Add(myDataGridViewColumn);
        }

        /****************************************************************
        ** 函 数 名：ConvertData
        ** 功能描述：将DataGridView转换为DataSet
        ** 输入参数：dgvInstant 数据网格 <列显示名称>
        **           TableName  字符串 <数据表名>
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2012-3-17
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        public static DataSet ConvertData(DataGridView dgvInstant,string TableName)
        {
            DataSet dsReturn = default(DataSet);
            if (null != dgvInstant)
            {
                if (null != dgvInstant.DataSource && null != (dgvInstant.DataSource as DataTable))
                {
                    dsReturn = ((DataTable)dgvInstant.DataSource).DataSet;
                    if (null != dsReturn)
                        return dsReturn.Copy();
                }
                dsReturn = new DataSet();
                dsReturn.Tables.Add(new DataTable(TableName));
                foreach (DataGridViewColumn column in dgvInstant.Columns)
                {
                    dsReturn.Tables[TableName].Columns.Add(null == column.Tag
                                                                     ? string.IsNullOrEmpty(column.DataPropertyName)
                                                                           ? column.Name
                                                                           : column.DataPropertyName
                                                                     : column.Tag.ToString());
                }
                List<object> list = new List<object>(dsReturn.Tables[TableName].Columns.Count);
                foreach (DataGridViewRow row in dgvInstant.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        list.Add(cell.Value);
                    }
                    dsReturn.Tables[TableName].Rows.Add(list.ToArray());
                    list.Clear();
                }
            }
            return dsReturn;
        }

        /****************************************************************
        ** 函 数 名：Dgv2DataSet
        ** 功能描述：将DataGridView转换为DataSet
        ** 输入参数：dgvStatAnalyInf    控件型   <数据网格>
        ** 输出参数：数据集 <转换后的数据集>
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2012-3-17
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        public static DataSet Dgv2DataSet(DataGridView dgvStatAnalyInf)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add(new DataTable());
            foreach (DataGridViewColumn dgvc in dgvStatAnalyInf.Columns)
            {
                if (dgvc.Visible)
                {
                    dsData.Tables[0].Columns.Add(dgvc.HeaderText);
                }
            }
            foreach (DataGridViewRow dgvc in dgvStatAnalyInf.Rows)
            {
                ArrayList arr = new ArrayList();
                for (int i = 0; i < dgvStatAnalyInf.Columns.Count; i++)
                {
                    if (dgvStatAnalyInf.Columns[i].Visible)
                    {
                        arr.Add(dgvc.Cells[i].Value.ToString());
                    }
                }
                dsData.Tables[0].Rows.Add(arr.ToArray());
            }
            return dsData;
        }

        /****************************************************************
        ** 函 数 名：合并DataTable
        ** 功能描述：将DataGridView转换为DataSet
        ** 输入参数：dts 控件型数组 <多个数据表格>
        ** 输出参数：控件型 <合并后的表格>
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2012-3-17
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        public static DataTable MergeDataTable(params DataTable [] dts)
        {
            DataTable dtResult = new DataTable();
            foreach (DataColumn dc in dts[0].Columns)
            {

                dtResult.Columns.Add(dc.ColumnName, dc.DataType);
            }
            foreach (DataTable dt in dts)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dtResult.Rows.Add(dr.ItemArray);
                }
            }
            return dtResult;
        }

        /****************************************************************
        ** 函 数 名：RemoveBlankRow
        ** 功能描述：移除数据网络中的空白行
        ** 输入参数：myDataGridView 控件型 <显示数据的数据网格>
        **           aObjParams  对象型数组 <辅助参数>
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2012-3-17
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        public static void RemoveBlankRow(DataGridView myDataGridView, params object[] aObjParams)
        {
            for (int i = Int32.Parse(aObjParams[0].ToString()); i < Int32.Parse(aObjParams[1].ToString()); i++)
            {
                bool bRemove = true;
                for (int j = Int32.Parse(aObjParams[2].ToString()); j < Int32.Parse(aObjParams[3].ToString()); j++)
                {
                    if ((myDataGridView.Rows[i].Cells[j].Value != null) && (myDataGridView.Rows[i].Cells[j].Value.ToString() != ""))
                    {
                        bool bExists = false;
                        for (int k = 4; k < aObjParams.Length; k++)
                        {
                            if (myDataGridView.Rows[i].Cells[j].Value.ToString() == aObjParams[k].ToString())
                            {
                                bExists = true;
                                break;
                            }
                        }
                        if (bExists == false)
                        {
                            bRemove = false;
                            break;
                        }
                    }
                }
                if (bRemove == true)
                {
                    myDataGridView.Rows.RemoveAt(i);
                    i--;
                    aObjParams[1] = Int32.Parse(aObjParams[1].ToString()) - 1;
                }
            }
        }

        /****************************************************************
        ** 函 数 名：InitDataGridView
        ** 功能描述：数据网格初始化
        ** 输入参数：dgvTarget 控件型 <目标数据网格>
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2012-3-17
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        public static void InitDataGridView(bool ReadOnly, bool AllowUserToAddRows, bool RowHeadersVisible,bool ColumnHeadersVisible, bool MultiSelect,bool AllowUserToResizeRows,bool AllowUserToResizeColumns,DataGridViewSelectionMode SelectionMode, DataGridView dgvTarget)
        {
            dgvTarget.ReadOnly = ReadOnly;
            dgvTarget.AllowUserToAddRows = AllowUserToAddRows;
            dgvTarget.RowHeadersVisible = RowHeadersVisible;
            dgvTarget.ColumnHeadersVisible = ColumnHeadersVisible;
            dgvTarget.SelectionMode = SelectionMode;
            dgvTarget.MultiSelect = MultiSelect;
            dgvTarget.AllowUserToResizeRows = AllowUserToResizeRows;
            dgvTarget.AllowUserToResizeColumns = AllowUserToResizeColumns;
           // dgvTarget.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            
        }
    }
}
