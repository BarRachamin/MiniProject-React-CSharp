using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerSide.Modul;

namespace ServerSide.Entiteis
{
    public class EUserMessage
    {
        //function that Send the new input to the Data layer
        public void SendNewInputToDataLayer(MUserMessage data)
        {
            Data.Sql.UserMessageDB message = new Data.Sql.UserMessageDB();

            message.SendSqlQueryToInsertToDB(data);

        }
    }
}
