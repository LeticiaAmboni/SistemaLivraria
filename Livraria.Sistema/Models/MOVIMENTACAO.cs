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

    public partial class MOVIMENTACAO
    {
        [Display(Name = "Movimentação")]
        public int IDMOVIMENTACAO { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Range(1, 500, ErrorMessage = "Número inválido")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Este campo aceita apenas números.")]
        [Display(Name = "Quantidade")]
        public short QUANTIDADEPRODUTO { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Insira apenas um caractere. C (compra) | V (venda)")]
        [Display(Name = "Operação")]
        public string OPERACAO { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data")]
        public System.DateTime DATA { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int IDDISTRIBUIDORA { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int IDLIVRO { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int IDFUNCIONARIO { get; set; }

        public virtual DISTRIBUIDORAS DISTRIBUIDORAS { get; set; }
        public virtual FUNCIONARIOS FUNCIONARIOS { get; set; }
        public virtual LIVROS LIVROS { get; set; }
    }
}
