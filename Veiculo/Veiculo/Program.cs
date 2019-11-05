
namespace Veiculo {
    class Program {
        static void Main(string[] args) {
            Veiculo veiculo = null;
            Menu.menu(veiculo, new AgenciaViagem());
        }
    }
}