using System.ComponentModel.DataAnnotations;


namespace APPWebAcademiaTrainee.Models
{
    public class PessoaModel
    {
        [Key]
        public int PersonCode { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }

        public int ChildrenAmount { get; set; }

        public decimal Salary   { get; set; }
    }
}
