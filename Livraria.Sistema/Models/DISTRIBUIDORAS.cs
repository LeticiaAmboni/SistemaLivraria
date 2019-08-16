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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class DISTRIBUIDORAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISTRIBUIDORAS()
        {
            this.LIVROS = new HashSet<LIVROS>();
            this.MOVIMENTACAO = new HashSet<MOVIMENTACAO>();
        }

        [Display(Name = "Distribuidora")]
        public int IDDISTRIBUIDORA { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Este campo deve possuir 14 n�meros.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Este campo aceita apenas n�meros.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Nome inv�lido.")]
        [Display(Name = "Distribuidora")]
        public string NOMEFANTASIA { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string EMAIL { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Este campo aceita apenas n�meros.")]
        [StringLength(14, MinimumLength = 8, ErrorMessage = "Este campo deve possuir pelo menos 8 n�meros.")]
        [Display(Name = "Telefone")]
        public string TELEFONE { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Cidade inv�lida.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Este campo aceita apenas letras.")]
        [Display(Name = "Cidade")]
        public string CIDADE { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Apenas a sigla do estado � aceita.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Este campo aceita apenas letras.")]
        [Display(Name = "Estado")]
        public string ESTADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LIVROS> LIVROS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTACAO> MOVIMENTACAO { get; set; }
    }
}
