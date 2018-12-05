//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.Prestamoes = new HashSet<Prestamo>();
        }
    
        public int cliente_id { get; set; }
        [Required]
        [Display(Name = "Cliente")]
        public string cliente_name { get; set; }
        [Required]
        [Display(Name = "C�dula")]
        public string cliente_cedula { get; set; }
        [Required]
        [Display(Name = "Tel�fono")]
        public string cliente_telefono { get; set; }
        public Nullable<int> ciudad_id { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prestamo> Prestamoes { get; set; }
    }
}
