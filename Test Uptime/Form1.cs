using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Net.Mail;



namespace Test_Uptime
{
    public partial class Form1 : Form
    {
        //تعریف متغیر
        string site;

        double a ;
       

        
        int Min=10;
        int uptime=0;
        int downtime=0;
        string phone;
        

        bool Condition=false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            site = textBox1.Text;
            label5.Text = "Request to : "+ site ;
            label6.Visible = true;
            label5.Visible = true;
            label4.Visible = true;

            
            
            //فعال کردن تایمر
            timer1.Interval = 1000*(Convert.ToInt32( textBox2.Text));
            timer2.Enabled = true;

            

            timer1.Enabled = true;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;

           phone = textBox3.Text;
            

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            
                

            
            var request = (HttpWebRequest)WebRequest.Create("http://" + site);

            //a = (downtime * 100) / uptime;
            //a = (100) - (a);
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    timer3.Enabled = true;
                    timer4.Enabled = false;

                    label4.Text = "is Up";
                    if (Condition==false)
                    {
                        
                        


                        

                        Condition = true;

                       
                        var message = "Website : " + " ' " + "http://" + textBox1.Text + " ' " + "  " + "is UP  " +"  "+"Uptime: "/*+ Math.Round(a, 2)*/+"%    " + "Time : " + DateTime.Now;
                        var api = new Kavenegar.KavenegarApi("715563754B717570346856327444397139673037754F4A6E4F4D55736661504747624233384A492F77434D3D");
                        api.Send("1000596446", phone, message);

                       

                       

                       



                    }


                    label4.ForeColor = System.Drawing.Color.Green;
                    if (timer2.Enabled==false)
                    {
                        timer2.Enabled = true;
                    }

                }

        }
            catch (Exception)
            {

                label4.Text = "is Down";

                timer3.Enabled = false;
                timer4.Enabled = true;

                if (Condition==true)
                {

                    Condition = false;

                    

                    var receptor = "09028932071";
                    var message = "Website : " + " ' " + "http://" + textBox1.Text + " ' " + "  " + "is DOWN !  " + "Time : " + DateTime.Now;
                    var api = new Kavenegar.KavenegarApi("715563754B717570346856327444397139673037754F4A6E4F4D55736661504747624233384A492F77434D3D");
                    api.Send("1000596446", receptor, message);


                    

                }
                label4.ForeColor = System.Drawing.Color.Red;

               

                

                
                
               

                
            }




        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Min++;
            label8.Text ="Mins" + Convert.ToString(Min) ;
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {

            uptime++;
            

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            a = (downtime * 100)/(uptime);
            a = (100)-(a) ;

            textBox3.Text = Convert.ToString(Math.Round(a,2));
            label11.Text = "Uptime:  "+Convert.ToString(Math.Round(a, 2)) +"%" ;
        }

        private void Timer4_Tick(object sender, EventArgs e)
        {
            downtime++;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            a = (downtime * 100) / uptime;
            a = (100) - (a);

            

           
            var message = "Website : " + " ' " + "http://" + textBox1.Text + " ' " + "  " + "is UP  " + "  " + "Uptime: " + Math.Round(a, 2) + "%    " + "Time : " + DateTime.Now;
            var api = new Kavenegar.KavenegarApi("715563754B717570346856327444397139673037754F4A6E4F4D55736661504747624233384A492F77434D3D");
            api.Send("1000596446", phone, message);
        }
    }
}
