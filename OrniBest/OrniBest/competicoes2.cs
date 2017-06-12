using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            public static int AddRegistos(competicoes2 utilC)
            {

                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();
                string sql_add = "INSERT INTO `Exposicao`(`id_exposicao`, `nome`, `data`, `localicao`, `morada`)" + "VALUES (" + utilC.id_exposicao + "," + utilC.nome + "," + utilC.data + "," + utilC.cidade + "," + utilC.morada + " ) ";


                //"VALUES ('" + util.nome + "','" + util.telemovel + "','" + util.stam + "', '" + util.data_nascimento + "','" + util.morada + "')" + "','" + util.codigo_postal + "')" + "','" + util.clube + "')";
                SQLiteCommand newCommand = new SQLiteCommand(sql_add, myConn);
                newCommand.ExecuteNonQuery();

                string sql_id = "SELECT MAX(id_exposicao) as idAtual FROM Exposicao ";
                SQLiteCommand idCommando = new SQLiteCommand(sql_id, myConn);
                SQLiteDataReader reader = idCommando.ExecuteReader();
                int idUltimoRegisto = 0;
                reader.Read(); // Ler na Base de Dados
                idUltimoRegisto = Convert.ToInt32(reader["idAtual"]);
                reader.Dispose();
                myConn.Close();
                MessageBox.Show("Adicionado com sucesso!");
                return idUltimoRegisto;


            }
            public static int UptadeExposicao(competicoes2 utilC)
            {

                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();
                string sql_add = "UPDATE `exposicao` SET `nome`= '" + utilC.nome + "', `data`= '" +utilC.data + "',`localizacao`= '"  + utilC.cidade + "',`morada`= '" + utilC.morada + "' WHERE `id_exposicao`=" + utilC.id_exposicao;



                SQLiteCommand newCommand = new SQLiteCommand(sql_add, myConn);
                newCommand.ExecuteNonQuery();

                string sql_id = "SELECT MAX(id_exposicao) as idAtual FROM Exposicao ";
                SQLiteCommand idCommando = new SQLiteCommand(sql_id, myConn);
                SQLiteDataReader reader = idCommando.ExecuteReader();
                int idUltimoRegisto = 0;
                reader.Read(); // Ler na Base de Dados
                idUltimoRegisto = Convert.ToInt32(reader["idAtual"]);
                reader.Dispose();
                myConn.Close();
                MessageBox.Show("Adicionado com sucesso!");
                return idUltimoRegisto;


            }
            public static int DeleteExposicao(int id_exposicao)
            {
                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();
                int exposicaoapagar = id_exposicao;
                string sql_add = "DELETE FROM `Exposicao` WHERE id_exposicao= " + exposicaoapagar;
                

            SQLiteCommand newCommand = new SQLiteCommand(sql_add, myConn);
                newCommand.ExecuteNonQuery();
            MessageBox.Show("Removido com sucesso!");
            return 1;
            }


        }
        #endregion
    
}
