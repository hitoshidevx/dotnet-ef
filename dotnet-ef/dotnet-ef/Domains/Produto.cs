using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ef.Domains
{
    public class Produto : BaseDomain
    {
        public string NomeProduto { get; set; }
        public float Preco { get; set; }

        //Relacionamento com a tabela PedidoItem = 1, N
        public List<PedidoItem> PedidosItens { get; set; }

    }
}
