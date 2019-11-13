using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Veiculo.Banco {
    class BancoDeDados {
        public string NomeArquivo { get; set; } = $@"{Directory.GetCurrentDirectory()}\base.json";

        public AgenciaViagem BuscarDados() {
            if (!File.Exists(NomeArquivo)) {
                return null;
            }

            JObject Ler = JObject.Parse(File.ReadAllText(NomeArquivo));
            AgenciaViagem agencia = JsonConvert.DeserializeObject<AgenciaViagem>(Ler.ToString());
            return agencia;
        }

        public void Salvar(AgenciaViagem agencia) {
            using (StreamWriter file = File.CreateText(NomeArquivo)) {
                string json = JsonConvert.SerializeObject(agencia);
                file.WriteLine(json);
            }
        }
    }
}
