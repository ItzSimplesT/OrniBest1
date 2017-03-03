using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using WPFCustomMessageBox;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace OrniBest
{
    class passaro2
    {
        private static Dictionary<int, passaro2> utilP = new Dictionary<int, passaro2>();
        private int nanilha;
        private string genero;
        private string nome;
        private string foto;
        private string Alimento;
        private int id_utilizador;
        private int id_especie;
        private int id_gaiola;

        public passaro2(int nanilha2, string genero2, string nome2, string foto2, string Alimento2, int id_utilizador2, int id_especie2, int id_gaiola2)
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

        public static Dictionary<int, passaro2> lerRegistos()
        {
            SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1;version=3");
            myConn.Open();
            string sql_select = "SELECT * FROM Passaro";
            SQLiteCommand myCommand = new SQLiteCommand(sql_select, myConn);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                passaro2 newPassaro = new passaro2((int)reader["n_anilha"], (string)reader["genero"],
                                                (string)reader["nome"], (string)reader["foto"],
                                                (string)reader["alimento"], (int)reader["id_utilizador"],
                                                (int)reader["id_especie"], (int)reader["id_gaiola"]);
              utilP.Add(Convert.ToInt32(reader["n_anilha"]), newPassaro);
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
                    "VALUES ('" + utilP.nanilha + "', '" + utilP.genero + "','" + utilP.nome + "', '" + utilP.foto + "','" + utilP.Alimento + "','" + utilP.id_utilizador + "' , '" + utilP.id_especie + "' , '" + utilP.id_especie + "' ) ";
           
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
            MessageBox.Show("Foi adicionado com sucesso!");
            return idUltimoRegisto;


        }


    }
    #endregion

}
