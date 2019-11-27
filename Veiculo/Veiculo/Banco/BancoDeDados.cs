using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System;
using 

namespace Veiculo.Banco {
    class BancoDeDados {
        /*public string NomeArquivo { get; set; } = $@"{Directory.GetCurrentDirectory()}\base.json";

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
        }*/
        public AgenciaViagem BuscarDados(AgenciaViagem agenciaViagem) {

            try {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DEV4JOBS1";
                builder.UserID = "DEV4JOBS1/Dev4Jobs1";
                builder.IntegratedSecurity = true;
                builder.Password = "";
                builder.InitialCatalog = "Veiculo";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString)) {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select * from Veiculo", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) {
                        while (reader.Read()) {
                            var adsa = reader["uf"];
                            Console.WriteLine($"{reader[0]} - {reader[1]} - {reader[2]}");
                        }
                    }
                    else {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();

                }
                return agenciaViagem;
            }
            catch (SqlException e) {
                Console.WriteLine("Deu ruim");
                Console.WriteLine(e.Message);
            }
        }
    }
}
