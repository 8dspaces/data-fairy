using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_Fairy_Editor
{
    public class DoubleBufferedDataGrid : DataGridView
    {
        public DoubleBufferedDataGrid()
        {
            DoubleBuffered = true;
        }   
    }
}
