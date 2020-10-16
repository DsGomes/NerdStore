using NerdStore.Core.DomainObjects;
using System;
using Xunit;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutosTests
    {
        [Fact]
        public void Produto_Sem_Nome_Deve_Retornar_Exception()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto(string.Empty, "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo Nome do produto não pode estar vazio", ex.Message);            
        }

        [Fact]
        public void Produto_Sem_Descricao_Deve_Retornar_Exception()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo Descricao do produto não pode estar vazio", ex.Message);
        }

        [Fact]
        public void Produto_Com_Valor_Menor_Igual_Zero_Deve_Retornar_Exception()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 0, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo Valor do produto não pode se menor igual a 0", ex.Message);
        }

        [Fact]
        public void Produto_Sem_Categoria_Deve_Retornar_Exception()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 100, Guid.Empty, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo CategoriaId do produto não pode estar vazio", ex.Message);
        }

        [Fact]
        public void Produto_Sem_Imagem_Deve_Retornar_Exception()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo Imagem do produto não pode estar vazio", ex.Message);
        }

        [Fact]
        public void Produto_Com_Altura_Menor_Igual_Zero_Deve_Retornar_Exception()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(0, 1, 1))
            );

            Assert.Equal("O campo Altura não pode ser menor ou igual a 0", ex.Message);
        }
    }
}
