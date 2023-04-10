using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade13_ContaCorrente.ConsoleApp
{
    public class ContaCorrente
    {
        private int numeroCliente;
        private double saldoCliente;
        private double limiteCliente;
        private double limiteTotalCliente;
        private bool especialCliente;

        private ArrayList movimentacoes = new ArrayList();

        public ContaCorrente(int numero, double saldo, double limite, bool especial)
        {
            numeroCliente = numero;
            saldoCliente = saldo;
            limiteCliente = limite;
            limiteTotalCliente = limite;
            especialCliente = especial;
        }

        public void VisualizarMovimentacoes()
        {
            foreach (var movimentacao in movimentacoes)
            {
                Console.WriteLine(movimentacao);
            }
        }

        public string VisualizarSaldo()
        {
            return $"Cliente({numeroCliente}) seu saldo é de: R${saldoCliente}";
        }

        public string VisualizarLimite()
        {
            return $"Cliente({numeroCliente}) seu limite Total é de R${limiteTotalCliente} e no momento você possuí R${limiteCliente} de limite no cartão";
        }

        public void Sacar(double valor)
        {
            if (valor <= saldoCliente)
                saldoCliente -= valor;

            else if (valor <= limiteCliente)
                limiteCliente -= valor;

            else
                return;

            movimentacoes.Add($"Saque de R${valor} em {DateTime.Now}");
        }

        public void Depositar(double valor)
        {
            saldoCliente += valor;
            movimentacoes.Add($"Depósito de R${valor} em {DateTime.Now}");
        }

        public void Tranferir(double valor, string tipoDePagamento, ContaCorrente conta)
        {
            if (tipoDePagamento == "debito")
            {
                if (valor > saldoCliente)
                    return;

                saldoCliente -= valor;
                conta.saldoCliente += valor;
                movimentacoes.Add($"Transferência no Débito para {conta.numeroCliente} no valor de R${valor} em {DateTime.Now}");
                conta.movimentacoes.Add($"Transferência no Débito recebido de {numeroCliente} no valor de R${valor} em {DateTime.Now}");
            }
            else if (tipoDePagamento == "credito")
            {
                if (valor > limiteCliente)
                    return;

                limiteCliente -= valor;
                conta.saldoCliente += valor;
                movimentacoes.Add($"Transferência no Crédito para {conta.numeroCliente} no valor de R${valor} em {DateTime.Now}");
                conta.movimentacoes.Add($"Transferência no Crédito recebido de {numeroCliente} no valor de R${valor} em {DateTime.Now}");
            }
        }

        public void PagarCartao(double valor)
        {
            if (valor > saldoCliente)
                return;

            if (valor > limiteTotalCliente - limiteCliente)
                return;

            limiteCliente += valor;
            saldoCliente -= valor;
            movimentacoes.Add($"Cartão pago no valor de R${valor} em {DateTime.Now}");
        }
    }
}
