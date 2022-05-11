using TaskService.CommonTypes.Sql;
using TaskService.Plugin.EDBanks.Models;

namespace TaskService.Plugin.CBRTasks.DataManager
{
    public class EDDataManager
    {
        public void InsertIntoTemp(EDBanksModel[] model)
        {
            string dest = "";

            SqlDapper.ClearTable(dest);
            var table = SqlDapper.CreateDataTable(model);
            var mapping = SqlDapper.PrepareColumnMapping(table);

            SqlDapper.BulkInsertIntoTable(table, dest, mapping);
        }

        public void ImportFromTemp() => SqlDapper.ExecuteNonQuerySP("[dbo].[Service_ED_Import]");
    }
}
