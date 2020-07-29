using MySql.Data.MySqlClient;
using Renci.SshNet.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SqlSample.DbEngine
{
    public class DbConnection
    {
        /// <summary>
        /// DBコネクション
        /// </summary>
        private MySqlConnection con = new MySqlConnection();

        /// <summary>
        /// 接続文字列
        /// </summary>
        const string CONNECTION_STRING = "server=localhost;port=3306;Database=mysql;uid=root";

        /// <summary>
        /// コンストラクタ
        ///     DB接続の確立
        /// </summary>
        public DbConnection()
        {
            OpenDbConnection();
        }

        /// <summary>
        /// SQLの実行オブジェクトを作成
        ///     SQL文字列も渡す版
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public MySqlCommand CreateCommand(string sql)
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;

            return cmd; 
        }

        /// <summary>
        /// DB接続
        ///     Exception発生時はThrow
        /// </summary>
        public string OpenDbConnection()
        {
            string result;

            try
            {
                // DB接続を確立する。
                con = new MySqlConnection();
                
                result = string.Format("接続結果[{0}]接続文字列{1}", con.State.ToString(), CONNECTION_STRING);

            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            return result;

        }

        /// <summary>
        /// DB接続
        ///     Exception発生時はThrow
        /// </summary>
        public string CloseDbConnection()
        {
            string result = string.Empty;

            try
            {
                // DB接続を解除
                con.Close();
                result = string.Format("接続結果[{0}]", con.State.ToString());

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Dispose();
            }
            
            return result;

        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~DbConnection()
        {
            try
            {
                //接続解除
                CloseDbConnection();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }
    }
}
