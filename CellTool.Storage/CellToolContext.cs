using CellTool.Storage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellTool.Storage
{
    /*
    DbContext; The context represents a session with the Db which allows us to query and 
    save data. 
    */
    public class CellToolContext : DbContext
    {
        /* 
        On the Context we define a property that is a DbSet for every type in our model
        DbSet allows us to query and set instances of those types in our model     
        */    
        public DbSet<CellData> CellData { get; set; }
    }


    public class CellToolInitializer : DropCreateDatabaseIfModelChanges<CellToolContext>
    {
        protected override void Seed(CellToolContext context)
        {

            context.CellData.Add(new CellData { Annotator = "Tommy" });
            context.CellData.Add(new CellData { Annotator = "Eben" });
            context.CellData.Add(new CellData { Annotator = "Rick" });

            context.CellData.Add(new CellData { Label = "Normal" });
            context.CellData.Add(new CellData { Label = "Abnormal" });
            context.CellData.Add(new CellData { Label = "Skip" });

            context.CellData.Add(new CellData { CellType = "Erythrocyte" });
            context.CellData.Add(new CellData { CellType = "Leukocyte" });

            context.SaveChanges();
        }
    }
}
