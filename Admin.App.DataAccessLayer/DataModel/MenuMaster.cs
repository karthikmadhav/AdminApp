//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin.App.DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class MenuMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuMaster()
        {
            this.MenuPrivileges = new HashSet<MenuPrivilege>();
        }
    
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public Nullable<int> MenuParentId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string IconStyle { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenuPrivilege> MenuPrivileges { get; set; }
    }
}
