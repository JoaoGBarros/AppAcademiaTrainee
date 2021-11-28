namespace AcademiaTrainee.Aplicacao
{
    public class PessoaBusiness
    {
        public static bool ValidaDataDeNascimento(DateTime data)
        {
            DateTime limite = new DateTime(1990, 1, 1);

            if (data < limite)
            {
                return false;
            }

            return true;
        }

        public static bool ChecaEmailCadastrado(int qtd_cadastrados)
        {
            if (qtd_cadastrados > 0)
            {
                return false;
            }

            return true;
        }

        public static bool ValidaQuantidadeDeFilhos(int qtd_filhos)
        {
            if (qtd_filhos < 0)
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
        public static bool ValidaSituacao(bool pessoaModelStatus, bool pessoaModelBDStatus)
        {
            /*
             * Unico modo de aparecer mensagem de erro para o usuario
             * sera se:
             * 
             *      . No momento da edição o usuario estiver inativo E o usuario estiver com a situacao: inativo no banco de dados, tornando possivel
             *      alterar o status do usuario na pagina de edicao.
             *      
             * 
             * 
             * 
             * 
             * | PessoaModel | PessoaModelBD |  Saida    |              Alteracoes           |
             * -------------------------------------------------------------------------------
             * |    True     |      True     |  Sem erro |  Pessoa Ativa  -> Pessoa Ativa    |  
             * |    True     |      False    |  Sem erro |  Pessoa Inativa -> Pessoa Ativa   |
             * |    False    |      True     |  Sem erro |  Pessoa Ativa -> Pessoa Inativa   |
             * |    False    |      False    |    Erro   |  Pessoa Inativa -> Pessoa Inativa |
            */
            if (!pessoaModelStatus && !pessoaModelBDStatus)
            {
                return false;
            }

            return true;
        }

        public static bool ValidaExclusao(bool pessoaModelStatus)
        {
            if(pessoaModelStatus)
            {
                return false;
            }

            return true;
        }
    }
}
