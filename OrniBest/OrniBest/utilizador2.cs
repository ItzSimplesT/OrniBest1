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
    class utilizador2
    {
        private static List<utilizador2> util = new List<utilizador2>();
        public string nome;
        public long telemovel;
        public long stam;
        public string data_nascimento;
        public string morada;
        public string codigo_postal;
        public long clube;

        public utilizador2(string nome2, long telemovel2, long stam2, string data_nascimento2, string morada2, string codigo_postal2, long clube2)
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

        public static List<utilizador2> lerRegistos()
        {
            SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
            myConn.Open();
            string sql_select = "SELECT * FROM Utilizador";
            SQLiteCommand myCommand = new SQLiteCommand(sql_select, myConn);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                utilizador2 newUtilizador = new utilizador2((string)reader["nome"], (long)reader["telemovel"],
                                                (long)reader["STAM"], (string)reader["data_nascimento"],
                                                (string)reader["Morada"], (string)reader["cod_postal"],
                                                (long)reader["id_clube"]);
                util.Add(newUtilizador);
            }
            reader.Dispose();
            myConn.Close();
            return util;
        }
        public static int AddRegistos(utilizador2 util)
        {
            try
            {
                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();
                string sql_add = "UPDATE `utilizador` SET `nome`= '" + util.nome + "',`morada`= '" + util.morada + "',`cod_postal`= '" + util.codigo_postal + "',`telemovel`= " + util.telemovel + ",`STAM`= " + util.stam + ",`id_clube`= " + util.clube + ",`data_nascimento`= '" + util.data_nascimento + "' WHERE `id_utilizador` = 1";

                //"VALUES ('" + util.nome + "','" + util.telemovel + "','" + util.stam + "', '" + util.data_nascimento + "','" + util.morada + "')" + "','" + util.codigo_postal + "')" + "','" + util.clube + "')";
                SQLiteCommand newCommand = new SQLiteCommand(sql_add, myConn);
                newCommand.ExecuteNonQuery();

                string sql_id = "SELECT MAX(id_Utilizador) as idAtual FROM Utilizador ";
                SQLiteCommand idCommando = new SQLiteCommand(sql_id, myConn);
                SQLiteDataReader reader = idCommando.ExecuteReader();
                int idUltimoRegisto = 0;
                reader.Read(); // Ler na Base de Dados
                idUltimoRegisto = Convert.ToInt32(reader["idAtual"]);
                reader.Dispose();
                myConn.Close();
                MessageBox.Show("Foi Registado com sucesso");
                return idUltimoRegisto;
            }
            catch (Exception)
            {
                MessageBox.Show("Nao consegui adicionar com sucesso");
                throw;
            }
            
            
            
        }


    } 
    #endregion


}
