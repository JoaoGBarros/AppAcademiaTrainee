using System.ComponentModel.DataAnnotations;

namespace APPWebAcademiaTrainee.Models
{
    public class EmpresaModel
    {
        [Key]
        public int CompanyCode { get; set; }

        public string CompanyName { get; set; }

        public string CompanyFantasyName { get; set; }

        public string CompanyCNPJ { get; set; }
    }
}
