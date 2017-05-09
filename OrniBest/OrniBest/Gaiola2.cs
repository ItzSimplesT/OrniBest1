using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace OrniBest
{
    class Gaiola2
    {
        private static List<Gaiola2> utilG = new List<Gaiola2>();
        public long codgaiola;
        public long lotacao;
        public long comprimento;
        public long largura;
        public long altura;
      


        public Gaiola2(long codgaiola2, long lotacao2, long comprimento2, long largura2, long altura2)
        {
            this.codgaiola = codgaiola2;
            this.lotacao = lotacao2;
            this.comprimento = comprimento2;
            this.largura = largura2;
            this.altura = altura2;
          

        }


        #region Base de Dados

        public static List<Gaiola2> lerRegistos()
        {
            SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
            myConn.Open();
            string sql_select = "SELECT * FROM Gaiola";
            SQLiteCommand myCommand = new SQLiteCommand(sql_select, myConn);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            utilG.Clear();
            while (reader.Read())
            {

                Gaiola2 newGaiola = new Gaiola2((long)reader["cod_gaiola"],
                                                    (long)reader["lotacao"],
                                                    (long)reader["comprimento"],
                                                    (long)reader["largura"],
                                                    (long)reader["altura"]);
                                                    
                utilG.Add(newGaiola);
            }
            reader.Dispose();
            myConn.Close();
            return utilG;
        }
        public static int AddRegistos(Gaiola2 utilG)
        {

            SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
            myConn.Open();
            string sql_add = "INSERT INTO `gaiola`(`cod_gaiola`, `lotacao`, `comprimento`, `largura`, `altura`)" + "VALUES (" + utilG.codgaiola + "," + utilG.lotacao + "," + utilG.comprimento + "," + utilG.largura + "," + utilG.altura + " ) ";
            
 
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
        public static int UptadePassaro(Gaiola2 utilG)
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

