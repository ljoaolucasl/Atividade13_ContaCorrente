namespace Atividade13_ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente(5142, 1000, 1000, true);

            ContaCorrente conta2 = new ContaCorrente(6874, 350, 1000, false);

            conta1.Tranferir(200, "credito", conta2);

            conta1.Depositar(50);

            Console.WriteLine(conta1.VisualizarLimite());

            Console.WriteLine(conta1.VisualizarSaldo());

            conta1.PagarCartao(200);

            Console.WriteLine(conta1.VisualizarLimite());

            Console.WriteLine(conta1.VisualizarSaldo());

            Console.WriteLine(conta2.VisualizarSaldo());

            Console.WriteLine(conta2.VisualizarLimite());

            Console.ReadLine();
        }
    }
}