//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDImoestudante.App_Db_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public curso()
        {
            this.areaCursoes = new HashSet<areaCurso>();
            this.users = new HashSet<user>();
        }
    
        public int idCurso { get; set; }
        public int idInstituicao { get; set; }
        public string nomeCurso { get; set; }
        public int anoCurso { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<areaCurso> areaCursoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
        public virtual instituicaoEnsino instituicaoEnsino { get; set; }
    }
}
