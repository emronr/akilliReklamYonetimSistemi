using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reklam1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
        }
        private void button2_Click(object sender, EventArgs e)
        {/*
            DateTime date = DateTime.Now;
            string Date = date.ToString("yyyy:MM:dd");
            string Time = date.ToString("HH:mm:ss");
            String Username1 = "emre";
            String Password1 = "onur";
            */
            String FirmaAdi1 = textBox1.Text;
            String KampanyaIcerik1 = richTextBox1.Text;
            String Kategori1 = textBox3.Text;
            String FirmaLokasyon1 = textBox2.Text;
            String KampanyaSuresi1 = textBox4.Text;

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                FirmaAdi = FirmaAdi1,
                FirmaLokasyon = FirmaLokasyon1,
                KampanyaIcerik = KampanyaIcerik1,
                Kampanyasuresi = KampanyaSuresi1,
                Kategori = Kategori1

            });
           



            var request = WebRequest.CreateHttp("https://reklam-eea50.firebaseio.com/FirmaKampanya/.json");
            request.Method = "POST";
            request.ContentType = "aplication/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUserEkle_Click(object sender, EventArgs e)
        {
            String Username1 = txtUserName.Text;
            String Password1 = txtPassword.Text;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Username = Username1,
                Password = Password1


            });
            var request = WebRequest.CreateHttp("https://reklam-eea50.firebaseio.com/Users/.json");
            request.Method = "POST";
            request.ContentType = "aplication/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
        }
    }
    }

