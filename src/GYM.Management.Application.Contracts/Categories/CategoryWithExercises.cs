using GYM.Management.Exercises;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Categories
{
    public class CategoryWithExercises
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ExerciseDto> ExerciseDtos { get; set; }
    }
}
