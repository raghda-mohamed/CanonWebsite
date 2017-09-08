using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanonCore.ViewModels
{
    public class ItemVM
    {
        public int ItemID { get; set; }
        public int CategoryID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public Nullable<int> CreatorUserID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> ModifierUserID { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
    }
}
