using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellTool.Storage.Models
{
    // a blog has many posts and a post belongs to a blog.
    // could use this for image and associated data. 
    // This is our model for the CellData DB; also called an 'Entity'
    // [Table("CellDatas")]

    // Match this with model name
    public class CreateCellGroup
    {
        // fields 
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public long CellId { get; set; }
        public string CellType { get; set; }

        public byte[] ImageBin { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }

    }


    public class UpdateCellData
    {
        public long CellId { get; set; }
        public long GroupId { get; set; }
        public string GroupName { get; set; }

        public string Annotator { get; set; }
        public string Label { get; set; }
    }

}
