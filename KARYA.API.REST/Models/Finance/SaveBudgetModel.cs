using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.API.REST.Models.Finance
{
    public class SaveBudgetModel
    {
        public string ProjectCode { get; set; }

        public string BudgetName { get; set; }

        public short BuggetYear { get; set; }

        public List<BudgetModel> BugdetList { get; set; }
    }
}
