using APPWebAcademiaTrainee.Models;

namespace APPWebAcademiaTrainee.Business
{
    public class PessoaBusiness
    {
        public static bool ValidaDataDeNascimento(DateTime data)
        {
            DateTime limite = new DateTime(1990, 1, 1);

            if(data < limite)
            {
                return false;
            }

            return true;
        }

        public static bool ChecaEmailCadastrado(IQueryable<PessoaModel> pessoa)
        {
            if(pessoa.Count() > 0)
            {
                return false;
            }

            return true;
        }

        public static bool ValidaQuantidadeDeFilhos(int num)
        {
            if(num < 0)
            {
                return false;
            }

            return true;
        }

        public static bool ValidaSalario(decimal salario)
        {
            if (salario < 1200 || salario > 13000)
            {
                return false;
            }

            return true;

        }
    }
}
