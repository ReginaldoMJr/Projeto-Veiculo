using Veiculo.Banco;

namespace Veiculo {
    class Program {
        static void Main(string[] args) {
            BancoDeDados banco = new BancoDeDados();
            AgenciaViagem agencia = banco.BuscarDados();
            if (agencia == null) {
                Menu.menu(new AgenciaViagem());
            }
            else
                Menu.menu(agencia);
        }
    }
}