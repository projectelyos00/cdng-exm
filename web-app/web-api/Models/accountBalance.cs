//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web_api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class accountBalance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public accountBalance()
        {
            this.paymentLists = new HashSet<paymentList>();
        }
    
        public int aB_Id { get; set; }
        public string aB_Name { get; set; }
        public Nullable<int> aB_Balance { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<paymentList> paymentLists { get; set; }
    }
}
