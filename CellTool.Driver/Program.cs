﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CellTool.Driver
{
    public class Program
    {
        static void Main(string[] args)
        {
            ImageHandler ih = new ImageHandler();
            ih.BulkImportImages();

        }
    }
}
