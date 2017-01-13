using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace OrniBest
{
    class utilizador2
    {
        private static Dictionary<int, utilizador2> util = new Dictionary<int, utilizador2>();
        private string nome;
        private int telemovel;
        private int stam;
        private string data_nascimento;
        private string morada;
        private string codigo_postal;
        private int clube;

        public utilizador2(string nome2, int telemovel2, int stam2, string data_nascimento2, string morada2, string codigo_postal2, int clube2)
        {
            this.nome = nome2;
            this.telemovel = telemovel2;
            this.stam = stam2;
            this.data_nascimento = data_nascimento2;
            this.morada = morada2;
            this.codigo_postal = codigo_postal2;
            this.clube = clube2;

        }


        #region Base de Dados

        public static Dictionary<int, utilizador2> lerRegistos()
        {
            SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1;version=3");
            myConn.Open();
            string sql_select = "SELECT * FROM Utilizador";
            SQLiteCommand myCommand = new SQLiteCommand(sql_select, myConn);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                utilizador2 newUtilizador = new utilizador2((string)reader["nome"], (int)reader["telemovel"],
                                                (int)reader["STAM"], (string)reader["data_nascimento"],
                                                (string)reader["Morada"], (string)reader["cod_postal"],
                                                (int)reader["id_clube"]);
                util.Add(Convert.ToInt32(reader["id_Utilizador"]), newUtilizador);
            }
            reader.Dispose();
            myConn.Close();
            return util;
        }
        public static int AddRegistos(utilizador2 util)
        {

            SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1;version=3");
            myConn.Open();
            string sql_add = "INSERT INTO Utilizador(nome,telemovel,STAM,data_nascimento,Morada, cod_postal, id_clube)" +
                             "VALUES ('" + util.nome + "','" + util.telemovel + "','" + util.stam + "', '" + util.data_nascimento + "','" + util.morada + "')" + "','" + util.codigo_postal + "')" + "','" + util.clube + "')";
            SQLiteCommand newCommand = new SQLiteCommand(sql_add, myConn);
            newCommand.ExecuteNonQuery();

            string sql_id = "SELECT MAX(id_Utilizador) as idAtual FROM ";
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
