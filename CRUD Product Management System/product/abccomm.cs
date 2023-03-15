using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace product
{
    class abccomm
    {
        DataTable dtable;
        SqlConnection sqlcon;
        SqlDataAdapter sqlda;
        SqlCommand sqlcom;
        string constring;

        string datasource = "PC-PC\\SQLEXPRESS";
        string dabase = "abccom";
        public abccomm()
        {
            constring = string.Format("data source = {0}; initial catalog = {1}; integrated security = true;", datasource, dabase);
            sqlcon = new SqlConnection(constring);
            sqlcon.Open();


        }
        public int CUDCmd(string sql)
        {
            sqlcom = new SqlCommand(sql, sqlcon);
            return sqlcom.ExecuteNonQuery();
        }

        public DataTable SelectCmd(string sql)
        {
            dtable = new DataTable();
            sqlda = new SqlDataAdapter(sql, constring);
            sqlda.Fill(dtable);
            sqlda.Dispose();
            return dtable;
        }

        public void Dispose()
        {
            sqlcon.Close();
            sqlcon.Dispose();
            sqlda.Dispose();
            sqlcom.Dispose();
            dtable.Dispose();
        }

    }
}
