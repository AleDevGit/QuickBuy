using QuickBuy.Dominio.Entidades.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }

        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }

        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        /// <summary>
        /// Pedido deve ter pelo menos um Itempedido ou muitos ItensPedidos
        /// </summary>
        public ICollection<ItemPedido> ItensPedidos { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();
            if (!ItensPedidos.Any())
                AdicionarCritica("Pedido não pode ficar sem item de pedido");
                
            if(string.IsNullOrEmpty(CEP))
                AdicionarCritica("Cep deve estar preenchido");
        }
    }
}
