using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using Tutorial.SqlConn; 
using System.Data.Common;
// using oracle;
// using Oracle.DataAccess.Client;

public class DBOracleUtils {
    // string host, int port, string sid, string user, string password
    public static OracleConnection GetDBConnection() {
        string connString = "Data Source =                                (DESCRIPTION =                                  (ADDRESS_LIST =                                    (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1555))                                  )                                    (CONNECT_DATA =                                    (SERVICE_NAME = espc2test)                                    )                                ); Password=1111111; User ID=asutpweb";

        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connString;

        return conn;
    }
}

public class DBUtils {
    public static OracleConnection GetDBConnection() {
        return DBOracleUtils.GetDBConnection();
    }
}

public class QueryDataExample {
    static void Main(string[] args) {
        OracleConnection conn = DBUtils.GetDBConnection();
        conn.Open();
        try
        {
            Query(conn);
        }
        catch (System.Exception)
        { }
        finally {
            conn.Close();
            conn.Dispose();
        }
    }

    private static void Query(OracleConnection conn) {
        string sql = "select * form phones;";

        OracleCommand cmd = new OracleCommand();

        cmd.Connection = conn;
        cmd.CommandText = sql;

        using (DbDataReader reader = cmd.ExecuteReader()) {
            if(reader.HasRows) {
                while(reader.Read()) {
                    
                }
            }
        }
    }
}