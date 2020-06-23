//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScoreSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class criminal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public criminal()
        {
            this.exam_record = new HashSet<exam_record>();
            this.prison_score = new HashSet<prison_score>();
        }
    
        public int id_criminal { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public string education { get; set; }
        public string profession { get; set; }
        public string hometown { get; set; }
        public string address { get; set; }
        public Nullable<int> time_of_crime { get; set; }
        public Nullable<System.DateTime> crime_date { get; set; }
        public string addition { get; set; }
        public Nullable<int> id_group { get; set; }
        public Nullable<int> id_work { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<exam_record> exam_record { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prison_score> prison_score { get; set; }
        public virtual group_admin group_admin { get; set; }
        public virtual work work { get; set; }
    }
}