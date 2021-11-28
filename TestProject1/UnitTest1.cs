using Microsoft.VisualStudio.TestTools.UnitTesting;
using APPWebAcademiaTrainee.Models;
using AcademiaTrainee.Aplicacao;

namespace TestProject1
{
    [TestClass]
    public class PessoaBusinessTest
    {
        [TestMethod]
        public void TestDeletarPessoaAtiva()
        {
            var pessoa = new PessoaModel()
            {
                Status = true
            };

            Assert.IsFalse(PessoaBusiness.ValidaExclusao(pessoa.Status));
        }

        [TestMethod]
        public void TestDeletarPessoaInativa()
        {
            var pessoa = new PessoaModel()
            {
                Status = false
            };

            Assert.IsFalse(!PessoaBusiness.ValidaExclusao(pessoa.Status));
        }

        [TestMethod]
        public void TestEditarPessoaAtiva()
        {
            // Alteracao Pessoa Ativa -> Pessoa Ativa
            var pessoa = new PessoaModel()
            {
                Status = true
            };

            var pessoaBD = new PessoaModel()
            {
                Status = true
            };

            Assert.IsTrue(PessoaBusiness.ValidaSituacao(pessoa.Status, pessoaBD.Status));
        }

        [TestMethod]
        public void TestEditarPessoaInativaAtiva()
        {
            // Alteracao Pessoa Inativa -> Pessoa Ativa
            var pessoa = new PessoaModel()
            {
                Status = true
            };

            var pessoaBD = new PessoaModel()
            {
                Status = false
            };

            Assert.IsTrue(PessoaBusiness.ValidaSituacao(pessoa.Status, pessoaBD.Status));
        }

        [TestMethod]
        public void TestEditarPessoaAtivaInativa()
        {
            // Alteracao Pessoa Ativa -> Pessoa Inativa
            var pessoa = new PessoaModel()
            {
                Status = false
            };

            var pessoaBD = new PessoaModel()
            {
                Status = true
            };

            Assert.IsTrue(PessoaBusiness.ValidaSituacao(pessoa.Status, pessoaBD.Status));
        }

        [TestMethod]
        public void TestEditarPessoaInativaInativa()
        {
            // Alteracao Pessoa Ativa -> Pessoa Inativa
            var pessoa = new PessoaModel()
            {
                Status = false
            };

            var pessoaBD = new PessoaModel()
            {
                Status = false
            };

            Assert.IsTrue(!PessoaBusiness.ValidaSituacao(pessoa.Status, pessoaBD.Status));
        }

        [TestMethod]
        public void TestValidaSalarioMenor()
        {
            // Pessoa com salario menor que a regra
            var pessoa = new PessoaModel()
            {
                Salary = 1199
            };

            Assert.IsTrue(!PessoaBusiness.ValidaSalario(pessoa.Salary));
        }

        [TestMethod]
        public void TestValidaSalarioMaior()
        {
            // Pessoa com salario maior que a regra
            var pessoa = new PessoaModel()
            {
                Salary = 13001
            };

            Assert.IsTrue(!PessoaBusiness.ValidaSalario(pessoa.Salary));
        }

        public void TestValidaSalario()
        {
            // Pessoa com salario dentro da regra
            var pessoa = new PessoaModel()
            {
                Salary = 1500
            };

            Assert.IsTrue(PessoaBusiness.ValidaSalario(pessoa.Salary));
        }

        [TestMethod]
        public void TestValidaQuantidadeDeFilhosErrado()
        {
            // Quantidade de filhos fora da regra
            var pessoa = new PessoaModel()
            {
                ChildrenAmount = -1
            };

            Assert.IsTrue(!PessoaBusiness.ValidaQuantidadeDeFilhos(pessoa.ChildrenAmount));
        }

        [TestMethod]
        public void TestValidaQuantidadeDeFilhosCerto()
        {
            // Quantidade de filhos dentro da regra
            var pessoa = new PessoaModel()
            {
                ChildrenAmount = 3
            };

            Assert.IsTrue(PessoaBusiness.ValidaQuantidadeDeFilhos(pessoa.ChildrenAmount));
        }

        [TestMethod]
        public void TestValidaDataDeNascimentoErrado()
        {
            // Data de Nascimento antes de 01/01/1990
            var pessoa = new PessoaModel()
            {
                Date = new System.DateTime(1980, 5, 6)
            };

            Assert.IsTrue(!PessoaBusiness.ValidaDataDeNascimento(pessoa.Date));
        }

        [TestMethod]
        public void TestValidaDataDeNascimentoCerto()
        {
            // Data de Nascimento depois de 01/01/1990
            var pessoa = new PessoaModel()
            {
                Date = new System.DateTime(2012, 12, 12)
            };

            Assert.IsTrue(PessoaBusiness.ValidaQuantidadeDeFilhos(pessoa.ChildrenAmount));
        }
    }
}