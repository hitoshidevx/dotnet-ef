using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ef.Domains
{
    /// <summary>
    /// Domínio referente ao Produto.
    /// </summary>
    public class Produto : BaseDomain
    {
        public string NomeProduto { get; set; }
        public float Preco { get; set; }

        //Relacionamento com a tabela PedidoItem = 1, N
        public List<PedidoItem> PedidosItens { get; set; }

        //Url da imagem do produto salva no servidor.
        public string UrlImagem { get; set; }

        [NotMapped] //Não mapeia a propriedade no banco de dados.
        public IFormFile Imagem { get; set; }

    }
}
