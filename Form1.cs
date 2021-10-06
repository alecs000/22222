using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Asteroid b = new Asteroid();

        Random r = new Random();
        int i = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            Timer Timer1 = new Timer();//Таймер отвечающий за спавн пули раз в пол секунды


            Timer1.Interval = 500;
            Timer1.Enabled = true;
            Timer1.Tick += new EventHandler(Timer1_Tick);
        }

        private void Timer1_Tick(object Sender, EventArgs o)
        {

            i++;
            Timer timer = new Timer();//Таймер отвечающий за движение пули вверх
            timer.Interval = 10;

            int count = 0;
            int max = 270;
            
            int num = r.Next(0, 750);
            PictureBox picBull = new PictureBox();
            b.ShowMyImage(picBull, @"y.png", 20, 20, num);
            panel1.Controls.Add(picBull);
            timer.Tick += new EventHandler((o1, ev1) =>
            {
                count++;
                picBull.Location = new Point(picBull.Location.X, picBull.Location.Y + 2);
                if (count == max)
                {
                    picBull.Dispose();
                    timer.Stop();

                }
            });
            timer.Start();


        }

       
    }


    class Asteroid
    {

        int i = 0;
        private Bitmap MyImage;
        public PictureBox ShowMyImage(PictureBox bulletBox, String fileToDisplay, int xSize, int ySize, int ran)
        {
            
            // Sets up an image object to be displayed.
            if (MyImage != null)
            {
                MyImage.Dispose();
            }

            bulletBox.Name = Convert.ToString(i);
            i++;
            // Stretches the image to fit the pictureBox.
            bulletBox.SizeMode = PictureBoxSizeMode.StretchImage;
            MyImage = new Bitmap(fileToDisplay);
            bulletBox.ClientSize = new Size(xSize, ySize); //Размер пуль
            bulletBox.Image = (Image)MyImage;
            bulletBox.Location = new Point(ran, 0);//Начальное положение Пуль
            return bulletBox;
        }



    }
}