using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElvisDataModel.EDMX;
using ElvisDataModel;

namespace BusinessLogic.Models.Reports.Incident
{
    public class Function
    {
        public int? FunctionId { get; set; }
        public string Description { get; set; }
        public string DescriptionFull { get; set; }

        public Function()
        {
            //use first returned record as default
            ElvisDataModel.EDMX.FunctionLookUp func = new ElvisDataModel.EDMX.FunctionLookUp();
            List<Function> functions = GetAllFunctions();
            func.FunctionId = functions[0].FunctionId.Value;
            func.FunctionDesc = functions[0].Description;
            func.FunctionDescFull = functions[0].DescriptionFull;
            SetUpObject(func);
        }

        public Function(ElvisDataModel.EDMX.FunctionLookUp func)
        {
            SetUpObject(func);
        }

        public Function(int newFunctionID, string newDescription, string newDescriptionFull)
        {
            ElvisDataModel.EDMX.FunctionLookUp func = new ElvisDataModel.EDMX.FunctionLookUp();
            func.FunctionId = newFunctionID;
            func.FunctionDesc = newDescription;
            func.FunctionDescFull = newDescriptionFull;
            SetUpObject(func);
        }

        private void SetUpObject(ElvisDataModel.EDMX.FunctionLookUp func)
        {
            FunctionId = func.FunctionId;
            Description = func.FunctionDesc;
            DescriptionFull = func.FunctionDescFull;
        }


        public static List<Function> GetAllFunctions()
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                return ctx.FunctionLookUps.ToList().Select(r => new Function(r)).ToList();
            }
        }

        /// <summary>
        /// Gets full list and adds a row at position 0 for an "All" option, useful for drop down lists.
        /// </summary>
        public static List<Function> GetAllFunctionsPlusAll()
        {
            List<Function> allItems;
            allItems = GetAllFunctions();

            Function allItem = new Function(0, "All", "All");

            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                allItems = ctx.FunctionLookUps.ToList().Select(r => new Function(r)).ToList();
                allItems.Insert(0, allItem);
                return allItems;
            }
        }
    }
}
