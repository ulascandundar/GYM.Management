using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.ExpenseTypes
{
    public class ExpenseTypeCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEffect { get; set; }
    }

}
