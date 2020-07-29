using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using MySql.Data.MySqlClient;

namespace SqlSample.DbEngine
{
    public class SqlExecutor : DbConnection
    {

        public ResultData Select(string sql)
        {
            ResultData result = new ResultData(sql);

            MySqlCommand sqlCmd = base.CreateCommand(sql);
            MySqlDataReader reader = sqlCmd.ExecuteReader();

            return result;

        }


        

        public class ResultData
        {

            /// <summary>
            /// 実行したSQL
            /// </summary>
            private string sql;

            public ResultData(string sql)
            {
                this.sql = sql;
            }

    

            



        }



    }
}
