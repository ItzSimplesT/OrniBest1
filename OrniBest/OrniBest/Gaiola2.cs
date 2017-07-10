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
        public static int AddRegistos(Gaiola2 utilG, int codgaiola)
        {
            try
            {
                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();



                string sql_add = "UPDATE `gaiola` SET `lotacao`= " + utilG.lotacao + " ,`comprimento`=" + utilG.comprimento + ",`largura`=" + utilG.largura + ",`altura`=" + utilG.altura + "WHERE cod_gaiola = " + codgaiola;

                try
                {
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
                    MessageBox.Show("Adicionado com sucesso!");
                    return idUltimoRegisto;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nao consegui adicionar com sucesso" + " " + ex.Message);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nao consegui conectar a base de dados" + " " + ex.Message);
                return 0;
            }


        }
        public static int UptadeGaiola(Gaiola2 utilG, int codgaiola)
        {
            try {
                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();
                string sql_add = "UPDATE `gaiola` SET `lotacao`=" + utilG.lotacao + ",`comprimento`= " + utilG.comprimento + ",`largura`=" + utilG.largura + ",`altura`=" + utilG.altura + " WHERE `cod_gaiola`=" + codgaiola;
                try { 
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
                MessageBox.Show("Adicionado com sucesso!");
                return idUltimoRegisto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui adicionar com sucesso" + " " + ex.Message);
                return 0;
            }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui conectar a base de dados" + " " + ex.Message);
                return 0;
            }

        }
        public static int DeleteGaiola(int cod_gaioladelete)
        {
            try
            {
                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();
                int gaiolapagar = cod_gaioladelete;
                string sql_add = "DELETE FROM `Gaiola` WHERE cod_gaiola= " + gaiolapagar;

                try
                {
                    SQLiteCommand newCommand = new SQLiteCommand(sql_add, myConn);
                    newCommand.ExecuteNonQuery();
                    MessageBox.Show("Removido com sucesso!");

                    return 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não consegui adicionar com sucesso" + " " + ex.Message);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui conectar a base de dados" + " " + ex.Message);
                return 0;
            }
        }


    }
    #endregion
}

