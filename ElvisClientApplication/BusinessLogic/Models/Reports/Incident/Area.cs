using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElvisDataModel.EDMX;
using ElvisDataModel;

namespace BusinessLogic.Models.Reports.Incident
{
    public class Area
    {
        public enum AreaCode { Primary = 1, Secondary = 2, Casting = 3, CMM = 4, QA = 5, All = 99 };

        public int? AreaId { get; set; }
        public string Description { get; set; }
        public string DescriptionFull { get; set; }

        public Area()
        {
            //use first returned record as default
            ElvisDataModel.EDMX.AreaLookUp area = new ElvisDataModel.EDMX.AreaLookUp();
            List<Area> areas = GetDefaultArea();
            area.AreaId = areas[0].AreaId.Value;
            area.AreaDesc = areas[0].Description;
            area.AreaDescFull = areas[0].DescriptionFull;
            SetUpObject(area);
        }

        public Area(ElvisDataModel.EDMX.AreaLookUp area)
        {
            SetUpObject(area);
        }

        public Area(int newAreaID, string newDescription, string newDescriptionFull)
        {
            ElvisDataModel.EDMX.AreaLookUp area = new ElvisDataModel.EDMX.AreaLookUp();
            area.AreaId = newAreaID;
            area.AreaDesc = newDescription;
            area.AreaDescFull = newDescriptionFull;
            SetUpObject(area);
        }

        private void SetUpObject(ElvisDataModel.EDMX.AreaLookUp area)
        {
            AreaId = area.AreaId;
            Description = area.AreaDesc;
            DescriptionFull = area.AreaDescFull;
        }

        public static List<Area> GetDefaultArea()
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                return ctx.AreaLookUps.ToList().Select(r => new Area(r)).ToList();
            }
        }

        public static List<Area> GetAllAreas()
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                return ctx.AreaLookUps.ToList().Select(r => new Area(r)).ToList();
            }
        }

        /// <summary>
        /// Gets full list and adds a row at position 0 for an "All" option, useful for drop down lists.
        /// </summary>
        public static List<Area> GetAllAreasPlusAll()
        {
            List<Area> allItems;
            allItems = GetAllAreas();

            Area allItem = new Area(0, "All", "All");

            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                allItems = ctx.AreaLookUps.ToList().Select(r => new Area(r)).ToList();
                allItems.Insert(0, allItem);
                return allItems;
            }
        }
    }
}
