//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Livraria.Sistema.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MOVIMENTACAO
    {
        public int IDMOVIMENTACAO { get; set; }
        public short QUANTIDADEPRODUTO { get; set; }
        public string OPERACAO { get; set; }
        public System.DateTime DATA { get; set; }
        public int IDDISTRIBUIDORA { get; set; }
        public int IDLIVRO { get; set; }
        public int IDFUNCIONARIO { get; set; }
    
        public virtual DISTRIBUIDORAS DISTRIBUIDORAS { get; set; }
        public virtual FUNCIONARIOS FUNCIONARIOS { get; set; }
        public virtual LIVROS LIVROS { get; set; }
    }
}
