//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Finall_project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MEMBERINFO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEMBERINFO()
        {
            this.LibraryHistories = new HashSet<LibraryHistory>();
        }
    
        public decimal MEMBER_ID { get; set; }
        public string MEMBER_NAME { get; set; }
        public string EMAIL { get; set; }
        public decimal MOBILE_NO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LibraryHistory> LibraryHistories { get; set; }
    }
}
