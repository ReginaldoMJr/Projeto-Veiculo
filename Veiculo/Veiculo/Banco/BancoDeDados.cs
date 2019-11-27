using System.Data.SqlClient;
using System;
using System.Text;

namespace Veiculo.Banco {
    static class BancoDeDados {
        static public AgenciaViagem BuscarDados(AgenciaViagem agenciaViagem) {
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
                            Veiculo veiculo = new Veiculo {
                                Placa = reader[0].ToString(),
                                Marca = reader[1].ToString(),
                                Modelo = reader[2].ToString(),
                                Ano = reader[3].ToString(),
                                CapacidadeTanque = uint.Parse(reader[4].ToString()),
                                TipoCombustivel = reader[5].ToString(),
                                AutonomiaOriginalG = double.Parse(reader[6].ToString()),
                                AutonomiaOriginalA = double.Parse(reader[7].ToString()),
                                AutonomiaG = double.Parse(reader[8].ToString()),
                                AutonomiaA = double.Parse(reader[9].ToString()),
                                QtdCombustivel = double.Parse(reader[10].ToString()),
                                QtdGasolina = double.Parse(reader[11].ToString()),
                                QtdAlcool = double.Parse(reader[12].ToString()),
                                Pneu = reader[13].ToString()
                            };
                            agenciaViagem.Veiculos.Add(veiculo);
                        }
                    }
                    reader.Close();
                    command = new SqlCommand("select * from Percurso", connection);
                    reader = command.ExecuteReader();
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            Percurso percurso = new Percurso {
                                Id = int.Parse(reader[0].ToString()),
                                Clima = reader[1].ToString(),
                                Trajeto = double.Parse(reader[2].ToString())
                            };
                            agenciaViagem.Percursos.Add(percurso);
                        }
                    }
                    reader.Close();
                    command = new SqlCommand("select * from Carro_Percurso", connection);
                    reader = command.ExecuteReader();
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            CarroPercurso carroPercurso = new CarroPercurso();
                            carroPercurso.Veiculo = agenciaViagem.Veiculos.Find(x => x.Placa == reader[0].ToString());
                            carroPercurso.Percurso = agenciaViagem.Percursos.Find(x => x.Id == int.Parse(reader[1].ToString()));
                            agenciaViagem.CarroPercursos.Add(carroPercurso);
                        }
                    }
                    reader.Close();
                    command = new SqlCommand("select * from Relatorio", connection);
                    reader = command.ExecuteReader();
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            CarroPercurso carro = new CarroPercurso();
                            carro.Veiculo = agenciaViagem.Veiculos.Find(x => x.Placa == reader[0].ToString());
                            carro.Percurso = agenciaViagem.Percursos.Find(x => x.Id == int.Parse(reader[1].ToString()));
                            Relatorio relatorio = new Relatorio {
                                CarroPercurso = carro,
                                KmPercorrida = double.Parse(reader[3].ToString()),
                                QtdAbastecimentos = uint.Parse(reader[4].ToString()),
                                QtdCalibragens = uint.Parse(reader[5].ToString()),
                                LitrosConsumidos = double.Parse(reader[6].ToString()),
                                DesgastePneu = (StringBuilder)reader[7],
                                AlteracaoClimatica = (StringBuilder)reader[8]
                            };
                        }
                    }
                    connection.Close();
                }
                return agenciaViagem;
            }
            catch (SqlException e) {
                Console.WriteLine("Deu ruim");
                Console.WriteLine(e.Message);
                return agenciaViagem;
            }
        }
        static public void Salvar(Object obj) {
            try {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DEV4JOBS1";
                builder.UserID = "DEV4JOBS1/Dev4Jobs1";
                builder.IntegratedSecurity = true;
                builder.Password = "";
                builder.InitialCatalog = "Veiculo";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString)) {
                    connection.Open();
                    Veiculo veiculo = new Veiculo();
                    Percurso percurso = new Percurso();
                    CarroPercurso carroPercurso = new CarroPercurso();
                    Relatorio relatorio = new Relatorio();
                    if (obj.GetType().Equals(veiculo.GetType())) {
                        veiculo = (Veiculo)obj;
                        var sql = $"insert into Veiculo values ('{veiculo.Placa}','{veiculo.Marca}','{veiculo.Modelo}',{veiculo.Ano},{veiculo.CapacidadeTanque},'{veiculo.TipoCombustivel}',"
                            + $"{veiculo.AutonomiaOriginalG},{veiculo.AutonomiaOriginalA},{veiculo.AutonomiaG},{veiculo.AutonomiaA},{veiculo.QtdCombustivel},{veiculo.QtdGasolina},{veiculo.QtdAlcool},{veiculo.Pneu})";
                        SqlCommand command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                    }
                    else if(obj.GetType() == percurso.GetType()) {
                        percurso = (Percurso)obj;
                        SqlCommand command = new SqlCommand($"insert into Percurso values ({percurso.Id},{percurso.Clima},{percurso.Trajeto})", connection);
                        command.ExecuteNonQuery();
                    }
                    else  if(obj.GetType() == carroPercurso.GetType()) {
                        carroPercurso = (CarroPercurso)obj;
                        SqlCommand command = new SqlCommand($"insert into Carro_Percurso values ('{carroPercurso.Veiculo.Placa}',{carroPercurso.Percurso.Id})", connection);
                        command.ExecuteNonQuery();
                    }
                    else if(obj.GetType() == relatorio.GetType()) {
                        relatorio = (Relatorio)obj;
                        SqlCommand command = new SqlCommand($"insert into Relatorio values ('{relatorio.CarroPercurso.Veiculo.Placa}',{relatorio.CarroPercurso.Percurso.Id},{relatorio.KmPercorrida}"
                            + $"{relatorio.QtdAbastecimentos},{relatorio.QtdCalibragens},{relatorio.LitrosConsumidos},'{relatorio.DesgastePneu}','{relatorio.AlteracaoClimatica}')", connection);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch(SqlException e) {
                Console.WriteLine("Erro ao salvar veiculo");
                Console.WriteLine(e.Message);
            }
        }
    }
}
