//using System;
//using System.Collections.Generic;
//using System.Collections;

//namespace LoginSrv
//{
//    public struct TQuickID
//    {
//        public string sAccount;
//        public string sChrName;
//        public int nIndex;
//        public int nSelectID;
//        public bool boIsHero;
//    } // end TQuickID

//    public class TQuickList: List<string>
//    {
//        public bool boCaseSensitive
//        {
//          get {
//            return GetCaseSensitive();
//          }
//          set {
//            SetCaseSensitive(value);
//          }
//        }
//        private object CriticalSection = null;
//        // TQuickList
//        public int GetIndex(string sName)
//        {
//            int result;
//            int nLow;
//            int nHigh;
//            int nMed;
//            int nCompareVal;
//            string s;
//            result =  -1;
//            if (this.Count != 0)
//            {
//                //@ Unsupported property or method(C): 'Sorted'
//                if (this.Sorted)
//                {
//                    if (this.Count == 1)
//                    {
//                        if (sName.CompareTo(this[0]) == 0)
//                        {
//                            result = 0;
//                        }
//                    }
//                    else
//                    {
//                        nLow = 0;
//                        nHigh = this.Count - 1;
//                        nMed = (nHigh - nLow) / 2 + nLow;
//                        while (true)
//                        {
//                            if ((nHigh - nLow) == 1)
//                            {
//                                if (sName.CompareTo(this[nHigh]) == 0)
//                                {
//                                    result = nHigh;
//                                }
//                                if (sName.CompareTo(this[nLow]) == 0)
//                                {
//                                    result = nLow;
//                                }
//                                break;
//                            }
//                            else
//                            {
//                                nCompareVal = sName.CompareTo(this[nMed]);
//                                if (nCompareVal > 0)
//                                {
//                                    nLow = nMed;
//                                    nMed = (nHigh - nLow) / 2 + nLow;
//                                    continue;
//                                }
//                                if (nCompareVal < 0)
//                                {
//                                    nHigh = nMed;
//                                    nMed = (nHigh - nLow) / 2 + nLow;
//                                    continue;
//                                }
//                                result = nMed;
//                                break;
//                            }
//                        }
//                    }
//                }
//                else
//                {
//                    if (this.Count == 1)
//                    {
//                        if ((sName).ToLower().CompareTo((this[0]).ToLower()) == 0)
//                        {
//                            result = 0;
//                        }
//                    }
//                    else
//                    {
//                        nLow = 0;
//                        nHigh = this.Count - 1;
//                        nMed = (nHigh - nLow) / 2 + nLow;
//                        while (true)
//                        {
//                            if ((nHigh - nLow) == 1)
//                            {
//                                if ((sName).ToLower().CompareTo((this[nHigh]).ToLower()) == 0)
//                                {
//                                    result = nHigh;
//                                }
//                                if ((sName).ToLower().CompareTo((this[nLow]).ToLower()) == 0)
//                                {
//                                    result = nLow;
//                                }
//                                break;
//                            }
//                            else
//                            {
//                                nCompareVal = (sName).ToLower().CompareTo((this[nMed]).ToLower());
//                                if (nCompareVal > 0)
//                                {
//                                    nLow = nMed;
//                                    nMed = (nHigh - nLow) / 2 + nLow;
//                                    continue;
//                                }
//                                if (nCompareVal < 0)
//                                {
//                                    nHigh = nMed;
//                                    nMed = (nHigh - nLow) / 2 + nLow;
//                                    continue;
//                                }
//                                result = nMed;
//                                break;
//                            }
//                        }
//                    }
//                }
//            }
//            return result;
//        }

//        public void SortString(int nMIN, int nMax)
//        {
//            int ntMin;
//            int ntMax;
//            string s18;
//            if (this.Count > 0)
//            {
//                while (true)
//                {
//                    ntMin = nMIN;
//                    ntMax = nMax;
//                    s18 = this[(nMIN + nMax) >> 1];
//                    while (true)
//                    {
//                        while (((this[ntMin]).ToLower().CompareTo((s18).ToLower()) < 0))
//                        {
//                            ntMin ++;
//                        }
//                        while (((this[ntMax]).ToLower().CompareTo((s18).ToLower()) > 0))
//                        {
//                            ntMax -= 1;
//                        }
//                        if (ntMin <= ntMax)
//                        {
//                            //@ Unsupported property or method(A): 'Exchange'
//                            this.Exchange(ntMin, ntMax);
//                            ntMin ++;
//                            ntMax -= 1;
//                        }
//                        if (ntMin > ntMax)
//                        {
//                            break;
//                        }
//                    }
//                    if (nMIN < ntMax)
//                    {
//                        SortString(nMIN, ntMax);
//                    }
//                    nMIN = ntMin;
//                    if (ntMin >= nMax)
//                    {
//                        break;
//                    }
//                }
//            }
//        }

//        public bool AddRecord(string sName, int nIndex)
//        {
//            bool result;
//            int nLow;
//            int nHigh;
//            int nMed;
//            int nCompareVal;
//            result = true;
//            if (this.Count == 0)
//            {
//                this.Add(sName, ((nIndex) as Object));
//            }
//            else
//            {
//                //@ Unsupported property or method(C): 'Sorted'
//                if (this.Sorted)
//                {
//                    if (this.Count == 1)
//                    {
//                        nMed = sName.CompareTo(this[0]);
//                        if (nMed > 0)
//                        {
//                            this.Add(sName, ((nIndex) as Object));
//                        }
//                        else
//                        {
//                            if (nMed < 0)
//                            {
//                                //@ Unsupported property or method(A): 'InsertObject'
//                                this.InsertObject(0, sName, ((nIndex) as Object));
//                            }
//                        }
//                    }
//                    else
//                    {
//                        nLow = 0;
//                        nHigh = this.Count - 1;
//                        nMed = (nHigh - nLow) / 2 + nLow;
//                        while (true)
//                        {
//                            if ((nHigh - nLow) == 1)
//                            {
//                                nMed = sName.CompareTo(this[nHigh]);
//                                if (nMed > 0)
//                                {
//                                    //@ Unsupported property or method(A): 'InsertObject'
//                                    this.InsertObject(nHigh + 1, sName, ((nIndex) as Object));
//                                    break;
//                                }
//                                else
//                                {
//                                    nMed = sName.CompareTo(this[nLow]);
//                                    if (nMed > 0)
//                                    {
//                                        //@ Unsupported property or method(A): 'InsertObject'
//                                        this.InsertObject(nLow + 1, sName, ((nIndex) as Object));
//                                        break;
//                                    }
//                                    else
//                                    {
//                                        if (nMed < 0)
//                                        {
//                                            //@ Unsupported property or method(A): 'InsertObject'
//                                            this.InsertObject(nLow, sName, ((nIndex) as Object));
//                                            break;
//                                        }
//                                        else
//                                        {
//                                            result = false;
//                                            break;
//                                        }
//                                    }
//                                }
//                            }
//                            else
//                            {
//                                nCompareVal = sName.CompareTo(this[nMed]);
//                                if (nCompareVal > 0)
//                                {
//                                    nLow = nMed;
//                                    nMed = (nHigh - nLow) / 2 + nLow;
//                                    continue;
//                                }
//                                if (nCompareVal < 0)
//                                {
//                                    nHigh = nMed;
//                                    nMed = (nHigh - nLow) / 2 + nLow;
//                                    continue;
//                                }
//                                result = false;
//                                break;
//                            }
//                        }
//                    }
//                }
//                else
//                {
//                    if (this.Count == 1)
//                    {
//                        nMed = (sName).ToLower().CompareTo((this[0]).ToLower());
//                        if (nMed > 0)
//                        {
//                            this.Add(sName, ((nIndex) as Object));
//                        }
//                        else
//                        {
//                            if (nMed < 0)
//                            {
//                                //@ Unsupported property or method(A): 'InsertObject'
//                                this.InsertObject(0, sName, ((nIndex) as Object));
//                            }
//                        }
//                    }
//                    else
//                    {
//                        nLow = 0;
//                        nHigh = this.Count - 1;
//                        nMed = (nHigh - nLow) / 2 + nLow;
//                        while (true)
//                        {
//                            if ((nHigh - nLow) == 1)
//                            {
//                                nMed = (sName).ToLower().CompareTo((this[nHigh]).ToLower());
//                                if (nMed > 0)
//                                {
//                                    this.InsertObject(nHigh + 1, sName, ((nIndex) as Object));
//                                    break;
//                                }
//                                else
//                                {
//                                    nMed = (sName).ToLower().CompareTo((this[nLow]).ToLower());
//                                    if (nMed > 0)
//                                    {
//                                        this.InsertObject(nLow + 1, sName, ((nIndex) as Object));
//                                        break;
//                                    }
//                                    else
//                                    {
//                                        if (nMed < 0)
//                                        {
//                                            this.InsertObject(nLow, sName, ((nIndex) as Object));
//                                            break;
//                                        }
//                                        else
//                                        {
//                                            result = false;
//                                            break;
//                                        }
//                                    }
//                                }
//                            }
//                            else
//                            {
//                                nCompareVal = (sName).ToLower().CompareTo((this[nMed]).ToLower());
//                                if (nCompareVal > 0)
//                                {
//                                    nLow = nMed;
//                                    nMed = (nHigh - nLow) / 2 + nLow;
//                                    continue;
//                                }
//                                if (nCompareVal < 0)
//                                {
//                                    nHigh = nMed;
//                                    nMed = (nHigh - nLow) / 2 + nLow;
//                                    continue;
//                                }
//                                result = false;
//                                break;
//                            }
//                        }
//                    }
//                }
//            }
//            return result;
//        }

//        private bool GetCaseSensitive()
//        {
//            bool result;
//            //@ Unsupported property or method(C): 'CaseSensitive'
//            result = this.CaseSensitive;
//            return result;
//        }

//        private void SetCaseSensitive(bool Value)
//        {
//            //@ Unsupported property or method(C): 'CaseSensitive'
//            this.CaseSensitive = Value;
//        }

//        public void __Lock()
//        {
//            //@ Unsupported function or procedure: 'EnterCriticalSection'
//            EnterCriticalSection(CriticalSection);
//        }

//        public void UnLock()
//        {
//            //@ Unsupported function or procedure: 'LeaveCriticalSection'
//            LeaveCriticalSection(CriticalSection);
//        }

//        //Constructor  Create()
//        public TQuickList() : base()
//        {
//            //@ Unsupported function or procedure: 'InitializeCriticalSection'
//            InitializeCriticalSection(CriticalSection);
//        }
//        //@ Destructor  Destroy()
//        ~TQuickList()
//        {
//            //@ Unsupported function or procedure: 'DeleteCriticalSection'
//            DeleteCriticalSection(CriticalSection);
//            // base.Destroy();
//        }
//    } // end TQuickList

//    public class TQuickIDList: List<string>
//    {
//        //@ Constructor auto-generated
//        public TQuickIDList(Int32 capacity)
//            :base(capacity)
//        {
//        }
//        //@ Constructor auto-generated
//        public TQuickIDList(IEnumerable collection)
//            :base(collection)
//        {
//        }
//        // TQuickIDList
//        public void AddRecord(string sAccount, string sChrName, int nIndex, int nSelIndex, bool boIsHero)
//        {
//            TQuickID QuickID;
//            ArrayList ChrList;
//            int nLow;
//            int nHigh;
//            int nMed;
//            int n1C;
//            int n20;
//            QuickID = new TQuickID();
//            QuickID.sAccount = sAccount;
//            QuickID.sChrName = sChrName;
//            QuickID.nIndex = nIndex;
//            QuickID.nSelectID = nSelIndex;
//            QuickID.boIsHero = boIsHero;
//            if (this.Count == 0)
//            {
//                ChrList = new ArrayList();
//                ChrList.Add(QuickID);
//                this.Add(sAccount, ChrList);
//            }
//            else
//            {
//                if (this.Count == 1)
//                {
//                    nMed = sAccount.CompareTo(this[0]);
//                    if (nMed > 0)
//                    {
//                        ChrList = new ArrayList();
//                        ChrList.Add(QuickID);
//                        this.Add(sAccount, ChrList);
//                    }
//                    else
//                    {
//                        if (nMed < 0)
//                        {
//                            ChrList = new ArrayList();
//                            ChrList.Add(QuickID);
//                            this.InsertObject(0, sAccount, ChrList);
//                        }
//                        else
//                        {
//                            ChrList = ((this.Values[0]) as ArrayList);
//                            ChrList.Add(QuickID);
//                        }
//                    }
//                }
//                else
//                {
//                    nLow = 0;
//                    nHigh = this.Count - 1;
//                    nMed = (nHigh - nLow) / 2 + nLow;
//                    while (true)
//                    {
//                        if ((nHigh - nLow) == 1)
//                        {
//                            n20 = sAccount.CompareTo(this[nHigh]);
//                            if (n20 > 0)
//                            {
//                                ChrList = new ArrayList();
//                                ChrList.Add(QuickID);
//                                this.InsertObject(nHigh + 1, sAccount, ChrList);
//                                break;
//                            }
//                            else
//                            {
//                                if (sAccount.CompareTo(this[nHigh]) == 0)
//                                {
//                                    ChrList = ((this.Values[nHigh]) as ArrayList);
//                                    ChrList.Add(QuickID);
//                                    break;
//                                }
//                                else
//                                {
//                                    n20 = sAccount.CompareTo(this[nLow]);
//                                    if (n20 > 0)
//                                    {
//                                        ChrList = new ArrayList();
//                                        ChrList.Add(QuickID);
//                                        this.InsertObject(nLow + 1, sAccount, ChrList);
//                                        break;
//                                    }
//                                    else
//                                    {
//                                        if (n20 < 0)
//                                        {
//                                            ChrList = new ArrayList();
//                                            ChrList.Add(QuickID);
//                                            this.InsertObject(nLow, sAccount, ChrList);
//                                            break;
//                                        }
//                                        else
//                                        {
//                                            ChrList = ((this.Values[n20]) as ArrayList);
//                                            ChrList.Add(QuickID);
//                                            break;
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                        else
//                        {
//                            n1C = sAccount.CompareTo(this[nMed]);
//                            if (n1C > 0)
//                            {
//                                nLow = nMed;
//                                nMed = (nHigh - nLow) / 2 + nLow;
//                                continue;
//                            }
//                            if (n1C < 0)
//                            {
//                                nHigh = nMed;
//                                nMed = (nHigh - nLow) / 2 + nLow;
//                                continue;
//                            }
//                            ChrList = ((this.Values[nMed]) as ArrayList);
//                            ChrList.Add(QuickID);
//                            break;
//                        }
//                    }
//                }
//            }
//        }

//        public void DelRecord(int nIndex, string sChrName)
//        {
//            TQuickID QuickID;
//            ArrayList ChrList;
//            int I;
//            if ((this.Count - 1) < nIndex)
//            {
//                return;
//            }
//            //@ Unsupported property or method(A): 'Values'
//            ChrList = ((this.Values[nIndex]) as ArrayList);
//            for (I = 0; I < ChrList.Count; I ++ )
//            {
//                QuickID = ChrList[I];
//                if (QuickID.sChrName == sChrName)
//                {
//                    //@ Unsupported function or procedure: 'Dispose'
//                    Dispose(QuickID);
//                    ChrList.RemoveAt(I);
//                    break;
//                }
//            }
//            if (ChrList.Count <= 0)
//            {
//                //@ Unsupported property or method(C): 'Free'
//                //ChrList.Free;
//                this.Remove(nIndex);
//            }
//        }

//        public int GetChrList(string sAccount, ref ArrayList ChrNameList)
//        {
//            int result;
//            int nHigh;
//            int nLow;
//            int nMed;
//            int n20;
//            int n24;
//            result =  -1;
//            if (this.Count == 0)
//            {
//                return result;
//            }
//            if (this.Count == 1)
//            {
//                if (sAccount.CompareTo(this[0]) == 0)
//                {
//                    //@ Unsupported property or method(A): 'Values'
//                    ChrNameList = ((this.Values[0]) as ArrayList);
//                    result = 0;
//                }
//            }
//            else
//            {
//                nLow = 0;
//                nHigh = this.Count - 1;
//                nMed = (nHigh - nLow) / 2 + nLow;
//                n24 =  -1;
//                while (true)
//                {
//                    if ((nHigh - nLow) == 1)
//                    {
//                        if (sAccount.CompareTo(this[nHigh]) == 0)
//                        {
//                            n24 = nHigh;
//                        }
//                        if (sAccount.CompareTo(this[nLow]) == 0)
//                        {
//                            n24 = nLow;
//                        }
//                        break;
//                    }
//                    else
//                    {
//                        n20 = sAccount.CompareTo(this[nMed]);
//                        if (n20 > 0)
//                        {
//                            nLow = nMed;
//                            nMed = (nHigh - nLow) / 2 + nLow;
//                            continue;
//                        }
//                        if (n20 < 0)
//                        {
//                            nHigh = nMed;
//                            nMed = (nHigh - nLow) / 2 + nLow;
//                            continue;
//                        }
//                        n24 = nMed;
//                        break;
//                    }
//                }
//                if (n24 !=  -1)
//                {
//                    //@ Unsupported property or method(A): 'Values'
//                    ChrNameList = ((this.Values[n24]) as ArrayList);
//                }
//                result = n24;
//            }
//            return result;
//        }

//    } // end TQuickIDList

//}