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
    
    public partial class LibraryHistory
    {
        public decimal BOOK_ID { get; set; }
        public decimal MEMBER_ID { get; set; }
        public System.DateTime ISSUE_DATE { get; set; }
        public System.DateTime RETURN_DATE { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual MEMBERINFO MEMBERINFO { get; set; }
    }
}
