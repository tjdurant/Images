using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class CellGroup
    {
        // fields 
        [Key]
        public int CreateCellGroupsId { get; set; }

        public string CellType { get; set; }
        public string GroupName { get; set; }

        public byte[] ImageBin { get; set; }


        public virtual List<CellLabel> CellLabels { get; set; }


    }


    public class CellLabel
    {
        [Key]
        public int CellLabelsId { get; set; }
        public string Label { get; set; }
        public string Annotator { get; set; }

        //  the following class definitions would result in a CreateCellGroup_GroupId parameter 
        // being expected in the stored procedures to insert and update UpdateCellData.
        public virtual CellGroup CreateCellGroup { get; set; }
    }

}
