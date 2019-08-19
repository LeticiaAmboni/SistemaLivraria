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

    public partial class LIVROS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LIVROS()
        {
            this.MOVIMENTACAO = new HashSet<MOVIMENTACAO>();
        }

        [Display(Name = "Livro")]
        public int IDLIVRO { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Este campo deve possuir 13 n�meros.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Este campo aceita apenas n�meros.")]
        public string EAN13 { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Este campo deve possuir 13 n�meros.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Este campo aceita apenas n�meros.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "T�tulo inv�lido.")]
        [Display(Name = "T�tulo")]
        public string TITULO { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Nome inv�lido.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo aceita apenas letras.")]
        [Display(Name = "Autor")]
        public string AUTOR { get; set; }

        [Range(1, 20, ErrorMessage = "N�mero inv�lido.")]
        [Display(Name = "Edi��o")]
        public Nullable<byte> EDICAO { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Este campo aceita apenas 4 n�meros.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Este campo aceita apenas n�meros.")]
        [Display(Name = "Ano")]
        public string ANOEDICAO { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo aceita apenas letras.")]
        [Display(Name = "Formato")]
        public string FORMATO { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [Range(2, 5000, ErrorMessage = "N�mero inv�lido")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Este campo aceita apenas n�meros.")]
        [Display(Name = "P�ginas")]
        public short NUMEROPAGINAS { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [Display(Name = "Origem")]
        public string ORIGEM { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Pre�o")]
        public decimal PRECO { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        public int IDDISTRIBUIDORA { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        public int IDEDITORA { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio.")]
        public int IDCATEGORIA { get; set; }
    
        public virtual CATEGORIAS CATEGORIAS { get; set; }
        public virtual DISTRIBUIDORAS DISTRIBUIDORAS { get; set; }
        public virtual EDITORAS EDITORAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTACAO> MOVIMENTACAO { get; set; }
    }
}
