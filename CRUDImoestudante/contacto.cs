//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDImoestudante
{
    using System;
    using System.Collections.Generic;
    
    public partial class contacto
    {
        public int idContacto { get; set; }
        public int idUser { get; set; }
        public int nivel { get; set; }
        public string tipo { get; set; }
        public string valor { get; set; }
    
        public virtual user user { get; set; }
    }
}