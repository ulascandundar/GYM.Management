using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GYM.Management.Categories
{
    public class CategoryCreateDto
    {
        [MaxLength(20)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
