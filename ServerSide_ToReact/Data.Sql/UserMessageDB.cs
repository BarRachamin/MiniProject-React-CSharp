using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerSide.Modul;
namespace Data.Sql
{
    public class UserMessageDB
    {
        MUserMessage data = new MUserMessage();

        //Function that send Sql Query to insert int the DB the user message
        public void SendSqlQueryToInsertToDB(MUserMessage data)
        {
            string uploadMessageQuery = "insert into ContactUs values('" + data.Name  + "','" + data.Message + "','" + data.CellPhone + "','" + data.Email + "',getdate())";
            ServerSide.Dal.DB_Connection.InputToDB(uploadMessageQuery);

        }
    }
}
