using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace OrniBest
{
    class Especie
    {
        private static List<Especie> utilE = new List<Especie>();
        public long id_especie;
        public string nome;



        public Especie(long id_especie2, string nome2)
        {
            this.id_especie = id_especie2;
            this.nome = nome2;


        }


        #region Base de Dados

        public static List<Especie> lerRegistos()
        {
            SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
            myConn.Open();
            string sql_select = "SELECT * FROM Especie";
            SQLiteCommand myCommand = new SQLiteCommand(sql_select, myConn);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            utilE.Clear();
            while (reader.Read())
            {
                

                Especie newespecie = new Especie((long)reader["id_especie"],
                                                    (string)reader["nome"]);
                utilE.Add(newespecie);
            }
            reader.Dispose();
            myConn.Close();
            return utilE;
        }
    }
}
#endregion
    

