using System.ComponentModel.DataAnnotations;


namespace APPWebAcademiaTrainee.Models
{
    public class PessoaModel
    {
        [Key]
        public int PersonCode { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime Date { get; set; }

        [Display(Name = "Quantidade de Filhos")]
        public int ChildrenAmount { get; set; }
        
        public decimal Salary   { get; set; }

        [Display(Name = "Situacao")]
        public bool Status { get; set; } 
    }
}
