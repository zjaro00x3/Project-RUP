﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Rup
{
    public partial class AdmWin : Form
    {
        public AdmWin(string login, string password)
        {
            InitializeComponent();
            loginLabel.Text = "Zalogowano administratora: " + login + " " + password;
            label1.Text = "Oczekujące plany";

            string connetionString, sql = "";
            SqlConnection DBconnect;
            connetionString = @"Data Source=mssql-2017.labs.wmi.amu.edu.pl;Initial Catalog=s434903_inzopr2019z;User ID=s444513;Password=Gxrbqfvw7L";
            DBconnect = new SqlConnection(connetionString);
            DBconnect.Open();
            sql = "SELECT * FROM Plan_Zajec WHERE Status LIKE 'Oczekujący'";
            SqlCommand command = new SqlCommand(sql, DBconnect);
            SqlDataReader reader = command.ExecuteReader();

            int counter = 0;

            while (reader.Read())
            {

                counter++;
                //wyczytuje ile jest wierszy w stworzonej tabeli
            }
            // Console.WriteLine("Ilosc wierszy: " +counter); 
            DBconnect = new SqlConnection(connetionString);
            DBconnect.Open();
            sql = "SELECT * FROM Plan_Zajec WHERE Status LIKE 'Oczekujący'";
            SqlCommand command1 = new SqlCommand(sql, DBconnect);
            SqlDataReader reader1 = command1.ExecuteReader();
            ArrayList uzyteid = new ArrayList();
            if (counter > 0)
            //jesli jest wiecej niz 0 wierszy, zaczyna czytac
            {
                for (int i = 1; i <= counter; i++)
                {

                    reader1.Read();
                    string id_studenta;
                    id_studenta = reader1.GetValue(1).ToString();

                    // Console.WriteLine("id studenta: " + id_studenta);


                    //  Console.WriteLine("wielkosc listy: " + uzyteid.Count);




                    if (!uzyteid.Contains(id_studenta))
                    {
                        uzyteid.Add(id_studenta);
                        // Console.WriteLine("wielkosc listy po dodaniu: " + uzyteid.Count);
                        DBconnect = new SqlConnection(connetionString);
                        DBconnect.Open();
                        sql = "Select * from Studenci where id=" + id_studenta;
                        SqlCommand command2 = new SqlCommand(sql, DBconnect);
                        SqlDataReader reader2 = command2.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader2.Read();
                            string name;
                            string surname;
                            name = reader2.GetValue(1).ToString();

                            surname = reader2.GetValue(2).ToString();
                            //Console.WriteLine(name + " " + surname);

                            string status = "oczekujący";
                            tabela1.Rows.Add(name + " " + surname, status, "Zaakceptuj", "Odrzuć");


                        }

                    }

                }
            }
            
        }
        

    }
    private void accept_Click(object sender, EventArgs e)
        {


        }
}