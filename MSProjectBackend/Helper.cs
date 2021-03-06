using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Backend
{
    public class Helper
    {
        public static bool Compare<T>(T e1, T e2, out List<PropertyInfo> propertyInfos)
        {
            bool flag = true;
            //bool match = false;
            propertyInfos = new List<PropertyInfo>();
            //int countFirst, countSecond;
            foreach (PropertyInfo propObj1 in e1.GetType().GetProperties())
            {
                var propObj2 = e2.GetType().GetProperty(propObj1.Name);
                if (!(propObj1.GetValue(e1, null).Equals(propObj2.GetValue(e2, null))))
                {
                    flag = false;
                    propertyInfos.Add(propObj1);
                }

                #region List compare
                //if (propObj1.PropertyType.Name.Equals("List`1"))
                //{
                //    dynamic objList1 = propObj1.GetValue(e1, null);
                //    dynamic objList2 = propObj2.GetValue(e2, null);
                //    countFirst = objList1.Count;
                //    countSecond = objList2.Count;
                //    if (countFirst == countSecond)
                //    {
                //        countFirst = objList1.Count - 1;
                //        while (countFirst > -1)
                //        {
                //            match = false;
                //            countSecond = objList2.Count - 1;
                //            while (countSecond > -1)
                //            {
                //                match = Compare(objList1[countFirst], objList2[countSecond], out propertyInfos);
                //                if (match)
                //                {
                //                    objList2.Remove(objList2[countSecond]);
                //                    countSecond = -1;
                //                    match = true;
                //                }
                //                if (match == false && countSecond == 0)
                //                {
                //                    return false;
                //                }
                //                countSecond--;
                //            }
                //            countFirst--;
                //        }
                //    }
                //    else
                //    {
                //        return false;
                //    }
                //}
                //else if (!(propObj1.GetValue(e1, null).Equals(propObj2.GetValue(e2, null))))
                //{
                //    flag = false;
                //    propertyInfos.Add(propObj1);
                //}
                #endregion
            }
            return flag;
        }
    }
}
