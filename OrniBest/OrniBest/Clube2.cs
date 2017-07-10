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
    class Clube2
    {
        private static List<Clube2> utilC = new List<Clube2>();
        public long id_clube;
        public string nome;
      


        public Clube2(long id_clube2, string nome2)
        {
            this.id_clube = id_clube2;
            this.nome = nome2;
          

        }


        #region Base de Dados

        public static List<Clube2> lerRegistos()
        {
            try
            {
                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();

                string sql_select = "SELECT * FROM Clube";
                try
                {
                    SQLiteCommand myCommand = new SQLiteCommand(sql_select, myConn);
                    SQLiteDataReader reader = myCommand.ExecuteReader();
                    utilC.Clear();
                    while (reader.Read())
                    {



                        Clube2 newclube = new Clube2((long)reader["id_clube"],
                                                            (string)reader["nome"]);
                        utilC.Add(newclube);
                    }
                    reader.Dispose();
                    myConn.Close();
                    return utilC;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não consegui ler os registos. " + " " + ex.Message);
                    return utilC;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui conetar a base de dados." + " " + ex.Message);
                return utilC;

            }
        }
    }
}
#endregion