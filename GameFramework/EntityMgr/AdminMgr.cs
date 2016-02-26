using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.EntityMgr {
    public class AdminMgr : BaseMgr<Entity.TAdminInfo> {
        public AdminMgr(string filePath)
            : base(filePath) {

        }

        public override Entity.TAdminInfo ConvertFromString(string s) {
            string[] arr = s.Split('\t');
            if (arr.Length < 2) {
                return null;
            }

            int nLv = -1;
            if (arr[0] == "*") {
                nLv = 10;
            } else {
                int.TryParse(arr[1], out nLv);
            }

            Entity.TAdminInfo admin = null;
            if (nLv > 0 && nLv <= 10) {
                admin = new Entity.TAdminInfo();
                admin.nLv = nLv;
                admin.sChrName = arr[1];

                if (arr.Length >= 3) {
                    admin.sIPaddr = arr[2];
                }
            }

            return admin;
        }

        public override string ConviertToString(Entity.TAdminInfo t) {
            return string.Format("{0}\t{1}\t{2}",
                t.nLv == 10 ? "*" : t.nLv.ToString(), t.sChrName, t.sIPaddr);
        }
    }
}
