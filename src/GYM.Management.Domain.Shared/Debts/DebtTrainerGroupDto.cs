using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Debts
{
    public class DebtTrainerGroupDto
    {
        public Guid TrainerId { get; set; }
        public string TrainerName { get; set; }
        public decimal TotalSafeAmount { get; set; }
    }
}
