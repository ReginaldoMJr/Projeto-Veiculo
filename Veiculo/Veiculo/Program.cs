using Veiculo.Banco;

namespace Veiculo {
    class Program {
        static void Main(string[] args) {
            AgenciaViagem agencia = new AgenciaViagem();
            agencia = BancoDeDados.BuscarDados(agencia);
            if (agencia == null) {
                Menu.menu(new AgenciaViagem());
            }
            else
                Menu.menu(agencia);
        }
    }
}