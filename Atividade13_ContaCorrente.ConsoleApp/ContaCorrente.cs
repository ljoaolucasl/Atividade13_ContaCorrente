using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade13_ContaCorrente.ConsoleApp
{
    public class ContaCorrente
    {
        private int numeroCliente;
        private int saldoCliente;
        private int limiteCliente;
        private int limiteTotalCliente;
        private bool especialCliente;

        public ContaCorrente(int numero, int saldo, int limite, bool especial)
        {
            numeroCliente = numero;
            saldoCliente = saldo;
            limiteCliente = limite;
            limiteTotalCliente = limite;
            especialCliente = especial;
        }

        public string VisualizarSaldo()
        {
            return $"Cliente({numeroCliente}) seu saldo é de: R${saldoCliente}";
        }

        public string VisualizarLimite()
        {
            return $"Cliente({numeroCliente}) seu limite Total é de R${limiteTotalCliente} e no momento você possuí R${limiteCliente} de limite";
        }

        public void Sacar(int valor)
        {
            if (valor > saldoCliente)
                return;

            saldoCliente -= valor;
        }

        public void Depositar(int valor)
        {
            saldoCliente += valor;
        }

        public void Tranferir(int valor, string tipoDePagamento, ContaCorrente conta)
        {
            if (tipoDePagamento == "debito")
            {
                if (valor > saldoCliente)
                    return;

                saldoCliente -= valor;
                conta.saldoCliente += valor;
            }
            else if (tipoDePagamento == "credito")
            {
                if (valor > limiteCliente)
                    return;

                limiteCliente -= valor;
                conta.saldoCliente += valor;
            }
        }

        public void PagarCartao(int valor)
        {
            if (valor > saldoCliente)
                return;

            if (valor > limiteTotalCliente - limiteCliente)
                return;

            limiteCliente += valor;
            saldoCliente -= valor;
        }
    }
}
