using System;
using System.Data.SqlClient;

public static class VeritabaniIslemleri
{
    public static void VeritabaniKontrolVeKurulum()
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        using (SqlConnection baglanti = new SqlConnection(connectionString))
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("IF DB_ID('KurbanDB') IS NULL CREATE DATABASE KurbanDB", baglanti);
            komut.ExecuteNonQuery();
        }

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            // KurbanDB var mı kontrol et
            string checkDbQuery = "IF DB_ID('KurbanDB') IS NULL CREATE DATABASE KurbanDB";
            SqlCommand checkDbCmd = new SqlCommand(checkDbQuery, conn);
            checkDbCmd.ExecuteNonQuery();
        }

        string kurbanDbConnectionString = @"Server=.\SQLEXPRESS;Database=KurbanDB;Trusted_Connection=True;";
        using (SqlConnection conn = new SqlConnection(kurbanDbConnectionString))
        {
            conn.Open();

            string createTableQuery = @"
    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Hissedarlar' AND xtype='U')
    CREATE TABLE Hissedarlar (
        Id INT PRIMARY KEY IDENTITY(1,1),
        AdSoyad NVARCHAR(100),
        Telefon NVARCHAR(20),
        AgirlikAraligi NVARCHAR(20),
        AtandiMi BIT
    );

    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Hayvanlar' AND xtype='U')
    CREATE TABLE Hayvanlar (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Agirlik FLOAT,
        RandimanOrani FLOAT,
        HissedarAdedi INT,
        ToplamEt FLOAT,
        KisiBasiEt FLOAT
    );

    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='HayvanHissedar' AND xtype='U')
    CREATE TABLE HayvanHissedar (
        Id INT PRIMARY KEY IDENTITY(1,1),
        HayvanID INT,
        HissedarID INT
    );
    ";

            SqlCommand cmd = new SqlCommand(createTableQuery, conn);
            cmd.ExecuteNonQuery();
        }


    }
}
