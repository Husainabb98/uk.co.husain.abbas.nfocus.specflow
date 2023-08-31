using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TechTalk.SpecFlow;

namespace uk.co.husain.abbas.nfocus.specflow.Support
{
    public class TableExtensions
    {
        public static DataTable DT(Table t)
        {
            var dT = new DataTable();
            foreach (var h in t.Header)
            {
                dT.Columns.Add(h, typeof(string));
            }
            // iterating rows
            foreach (var row in t.Rows)
            {
                var n = dT.NewRow();
                foreach (var h in t.Header)
                {
                    n.SetField(h, row[h]);
                }
                dT.Rows.Add(n);
            }
            return dT;
        }
    }
}


