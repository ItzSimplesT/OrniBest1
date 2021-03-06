﻿using System;
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
    class passaro2
    {
        private static List<passaro2> utilP = new List<passaro2>();
        public long nanilha;
        public long nanilhamae;
        public long nanilhapai;
        public string genero;
        public string nome;
        public string foto;
        public string Alimento;
        public long id_utilizador;
        public long id_especie;
        public long id_gaiola;


        public passaro2(long nanilha2, long nanilhamae2, long nanilhapai2, string genero2, string nome2, string foto2, string Alimento2, long id_utilizador2, long id_especie2, long id_gaiola2)
        {
            this.nanilha = nanilha2;
            this.nanilhamae = nanilhamae2;
            this.nanilhapai = nanilhapai2;
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
            try
            {
                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();
                string sql_select = "SELECT * FROM Passaro";
                SQLiteCommand myCommand = new SQLiteCommand(sql_select, myConn);
                SQLiteDataReader reader = myCommand.ExecuteReader();
                utilP.Clear();
                while (reader.Read())
                {

                    passaro2 newPassaro = new passaro2((long)reader["n_anilha"],
                                                        (long)reader["n_anilhamae"],
                                                        (long)reader["n_anilhapai"],
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
            }
            catch (Exception)
            {
                MessageBox.Show("Nao consegui ler a base de dados.");
                throw;
            }
            return utilP;
        }
        public static int AddRegistos(passaro2 utilP)
        {
            try
            {
                SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
                myConn.Open();
                string sql_add = "INSERT INTO Passaro(n_anilha,n_anilhamae,n_anilhapai,genero,nome,foto,alimento, id_utilizador, id_especie, id_gaiola)" +
                        "VALUES (" + utilP.nanilha + "," + utilP.nanilhamae + "," + utilP.nanilhapai + ",'" + utilP.genero + "','" + utilP.nome + "', '" + utilP.foto + "','" + utilP.Alimento + "'," + utilP.id_utilizador + " , " + utilP.id_especie + " , " + utilP.id_gaiola + " ) ";
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
                MessageBox.Show("Adiocionado com sucesso!");
                return idUltimoRegisto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nao consegui adicionar com sucesso" + " " + ex.Message  );
                return 0;
            }



        }
        public static int UptadePassaro(passaro2 utilP, long n_anilha)
        {

            SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
            myConn.Open();
            utilP.id_utilizador = 1;
            string sql_add = "UPDATE `passaro` SET  `n_anilhamae` = " + utilP.nanilhamae + " ,`n_anilhapai` = " + utilP.nanilhapai + ",`genero` = '" + utilP.genero + "',`nome` = '" + utilP.nome + "',`foto`= '" + utilP.foto + "',`alimento`= '" + utilP.Alimento + "',`id_utilizador`= " + utilP.id_utilizador + ",`id_especie`=" + utilP.id_especie + ",`id_gaiola`=" + utilP.id_gaiola + " WHERE `n_anilha` = " + n_anilha;
            try
            {

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
                MessageBox.Show("Adicionado com sucesso!");
                return idUltimoRegisto;
            }
            catch (Exception)
            {
                MessageBox.Show("Nao consegui ediar com sucesso");
                throw;
            }


        }
        public static int DeletePassaro(int n_anilhadelete)
        {
            SQLiteConnection myConn = new SQLiteConnection("Data Source=OrniFile_v1.db; version=3");
            myConn.Open();
            int anilhapagar = n_anilhadelete;
            try
            {
                string sql_add = "DELETE FROM `passaro` WHERE n_anilha= " + anilhapagar;


                SQLiteCommand newCommand = new SQLiteCommand(sql_add, myConn);
                newCommand.ExecuteNonQuery();
                MessageBox.Show("Removido com sucesso!");

                return 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Nao consegui ediar com sucesso");
                throw;
            }



        }
        #endregion
    }
}
