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
    DbContext; The context represents a session with the DB which allows us to query and 
    save data. This is the class to use if you want to hit the DB. 
    */
    public class CellToolInitializer : DropCreateDatabaseIfModelChanges<CellToolContext>
    {
        protected override void Seed(CellToolContext context)
        {
            context.SaveChanges();
        }
    }
    public class CellToolContext : DbContext
    {
        /* 
        On the Context we define a property that is a DbSet for every type in our model
        DbSet allows us to query and set instances of those types in our model     
        */
        // I think DbSet pluralizes your table to represent data plural 
        // DbSet connects to database. <> is the entity  
        // The public CellData property is returning a DbSet of <CellData>
        public DbSet<CellGroup> OriginalCellData { get; set; }
        public DbSet<CellLabel> CellLabels { get; set; }
        
        // If DbSet is going to make a connection it needs to know where to make
        // That connection; and connection strings go in the Web.Config file
        // When you make an instance of CellToolContext, it will look for a connection
        // string with the same "name=CellToolContext"
    }



}
