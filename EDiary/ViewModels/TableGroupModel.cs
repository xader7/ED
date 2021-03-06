using EDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDiary.ViewModels
{
    public class TableGroupModel
    {
        public IEnumerable<Teacher> teachers { get; set; }
        public IEnumerable<GroupModel> groups { get; set; }
        public string groupName { get; set; }
        public string curator { get; set; }
        public int groupId { get; set; }
    }
}
