using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace OrniBest
{
    class competicoes2
    {
        
       
            private static List<competicoes2> utilC = new List<competicoes2>();
            public long id_exposicao;
            public string nome;
            public string data;
            public string cidade;
            public string morada;



            public competicoes2(long id_exposicao2, string nome2, string data2, string cidade2, string morada2)
            {
                this.id_exposicao = id_exposicao2;
                this.nome = nome2;
                this.data = data2;
                this.cidade = cidade2;
                this.morada = morada2;


            }


            #region Base de Dados

            public static List<competicoes2> lerRegistos()
            {
                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();
                string sql_select = "SELECT * FROM Exposicao";
                SQLiteCommand myCommand = new SQLiteCommand(sql_select, myConn);
                SQLiteDataReader reader = myCommand.ExecuteReader();
                utilC.Clear();
                while (reader.Read())
                {

                competicoes2 newExposicao = new competicoes2((long)reader["id_exposicao"],
                                                                (string)reader["nome"],
                                                                (string)reader["data"],
                                                                (string)reader["cidade"],
                                                                (string)reader["morada"]);

                    utilC.Add(newExposicao);
                }
                reader.Dispose();
                myConn.Close();
                return utilC;
            }
            public static int AddRegistos(competicoes2 utilG)
            {

                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();
                string sql_add = "INSERT INTO `Exposicao`(`cod_gaiola`, `lotacao`, `comprimento`, `largura`, `altura`)" + "VALUES (" + utilG.codgaiola + "," + utilG.lotacao + "," + utilG.comprimento + "," + utilG.largura + "," + utilG.altura + " ) ";


                //"VALUES ('" + util.nome + "','" + util.telemovel + "','" + util.stam + "', '" + util.data_nascimento + "','" + util.morada + "')" + "','" + util.codigo_postal + "')" + "','" + util.clube + "')";
                SQLiteCommand newCommand = new SQLiteCommand(sql_add, myConn);
                newCommand.ExecuteNonQuery();

                string sql_id = "SELECT MAX(cod_gaiola) as idAtual FROM Gaiola ";
                SQLiteCommand idCommando = new SQLiteCommand(sql_id, myConn);
                SQLiteDataReader reader = idCommando.ExecuteReader();
                int idUltimoRegisto = 0;
                reader.Read(); // Ler na Base de Dados
                idUltimoRegisto = Convert.ToInt32(reader["idAtual"]);
                reader.Dispose();
                myConn.Close();
                return idUltimoRegisto;


            }
            public static int UptadePassaro(competicoes2 utilG)
            {

                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();
                string sql_add = "INSERT INTO Passaro(n_anilha,genero,nome,foto,alimento, id_utilizador, id_especie, id_gaiola)" +
                         "VALUES (" + utilG.codgaiola + "," + utilG.lotacao + "," + utilG.comprimento + "," + utilG.largura + "," + utilG.altura + " ) ";

                SQLiteCommand newCommand = new SQLiteCommand(sql_add, myConn);
                newCommand.ExecuteNonQuery();

                string sql_id = "SELECT MAX(n_anilha) as idAtual FROM Passaro ";
                SQLiteCommand idCommando = new SQLiteCommand(sql_id, myConn);
                SQLiteDataReader reader = idCommando.ExecuteReader();
                int idUltimoRegisto = 0;
                reader.Read(); // Ler na Base de Dados
                idUltimoRegisto = Convert.ToInt32(reader["idAtual"]);
                reader.Dispose();
                myConn.Close();
                return idUltimoRegisto;


            }
            public static int DeletePassaro(int cod_gaioladelete)
            {
                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();
                int gaiolapagar = cod_gaioladelete;
                string sql_add = "DELETE FROM `Gaiola` WHERE cod_gaiola= " + gaiolapagar;


                SQLiteCommand newCommand = new SQLiteCommand(sql_add, myConn);
                newCommand.ExecuteNonQuery();

                return 1;
            }


        }
        #endregion
    
}
