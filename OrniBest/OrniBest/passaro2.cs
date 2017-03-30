using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using WPFCustomMessageBox;

namespace OrniBest
{
    class passaro2
    {
        private static List<passaro2> utilP = new List<passaro2>();
        public long nanilha;
        private string genero;
        public string nome;
        private string foto;
        private string Alimento;
        private long id_utilizador;
        private long id_especie;
        private long id_gaiola;

        public passaro2(long nanilha2, string genero2, string nome2, string foto2, string Alimento2, long id_utilizador2, long id_especie2, long id_gaiola2)
        {
            this.nanilha = nanilha2;
            this.genero = genero2;
            this.nome = nome2;
            this.foto = foto2;
            this.Alimento = Alimento2;
            this.id_utilizador = id_utilizador2;
            this.id_especie = id_especie2;
            this.id_gaiola = id_gaiola2;

        }


        #region Base de Dados

        public static List<passaro2> lerRegistos()
        {
            SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
            myConn.Open();
            string sql_select = "SELECT * FROM Passaro";
            SQLiteCommand myCommand = new SQLiteCommand(sql_select, myConn);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                //long n_anilha = (long)reader["n_anilha"];
                //string genero = (string)reader["genero"];
                //string nome = (string)reader["nome"];

                //    string foto = (string)reader["foto"];

                //string alimento = (string)reader["alimento"];
                //long id_utilizador = (long)reader["id_utilizador"];
                //long id_especie = (long)reader["id_especie"];
                //long id_gaiola = (long)reader["id_gaiola"];


                passaro2 newPassaro = new passaro2((long)reader["n_anilha"],
                                                    (string)reader["genero"],
                                                    (string)reader["nome"],
                                                    (string)reader["foto"],
                                                    (string)reader["alimento"],
                                                    (long)reader["id_utilizador"],
                                                    (long)reader["id_especie"],
                                                    (long)reader["id_gaiola"]);
                utilP.Add(newPassaro);
            }
            reader.Dispose();
            myConn.Close();
            return utilP;
        }
        public static int AddRegistos(passaro2 utilP)
        {

            SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
            myConn.Open();
            string sql_add = "INSERT INTO Passaro(n_anilha,genero,nome,foto,alimento, id_utilizador, id_especie, id_gaiola)" +
                    "VALUES ('" + utilP.nanilha + "'," + utilP.genero + "," + utilP.nome + ", " + utilP.foto + "," + utilP.Alimento + ",'" + utilP.id_utilizador + "' , '" + utilP.id_especie + "' , '" + utilP.id_especie + "' ) ";
           //"VALUES ('" + util.nome + "','" + util.telemovel + "','" + util.stam + "', '" + util.data_nascimento + "','" + util.morada + "')" + "','" + util.codigo_postal + "')" + "','" + util.clube + "')";
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
        


    }
    #endregion

}
