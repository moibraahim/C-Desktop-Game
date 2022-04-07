using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MMPractice
{

    public partial class Form1 : Form
    {
        public class hero
        {
            public int hx, hy, Idle, PosFlag, Shoot, Pos, Health, h, Lser;
            public Bitmap im;
            public List<hero> BulletList = new List<hero>();
            public List<hero> LaserList = new List<hero>();
            public List<hero> SingleBulletList = new List<hero>();
            public Rectangle rCD;
            public Rectangle rCSRC;
            public bool f = false;
        }
        public class enemy
        {
            public int x, y, idle, flagpos, shoot, whichpos, ys, dir, w, h, hp;
            public Bitmap im;
            public List<enemy> bullet = new List<enemy>();
            public List<enemy> monsters = new List<enemy>();
            public List<enemy> B = new List<enemy>();
        }
        Bitmap Buffer, b;
        List<hero> Hero1 = new List<hero>();
        List<enemy> Stones = new List<enemy>();
        List<enemy> Boss = new List<enemy>();
        List<enemy> BossBye = new List<enemy>();
        List<enemy> Enemies = new List<enemy>();
        List<hero> BackGroundPhotoList = new List<hero>();
        Timer tt = new Timer();
        int flag = 0, ct = 0, xs = 0, ct2 = 0, ct3 = 0, f1 = 0, p = 0, laserflag, f2 = 0, ctx = 0, cte = 0, start = 0, Bulletflag = 0, shield = 0;
        int Winner = 0;
        Bitmap Shield = new Bitmap("shield2.png");
        
        Random rr = new Random();
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            tt.Tick += Tt_Tick;
            tt.Start();
           
            this.KeyDown += Form1_KeyDown;


        }
        void CalcAchv(int Earned)
        {

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Not Yet
            if (start > 0)
            {

                // Laser
                if (e.KeyCode == Keys.L)
                {
                    shield = 0;
                    if (Hero1[0].Pos == 0)
                    {
                        hero pnn = new hero();
                        pnn.hx = Hero1[0].hx + 100;
                        pnn.hy = Hero1[0].hy + 55;
                        pnn.im = new Bitmap("lazer4.png");
                        laserflag = 1;
                        Hero1[0].LaserList.Add(pnn);
                        for (int i = 0; i < Enemies.Count; i++)
                        {
                            if (Hero1[0].LaserList[0].hx <= Enemies[i].x &&
                              Hero1[0].LaserList[0].hx <= Enemies[i].x + Enemies[i].im.Width &&
                              Hero1[0].LaserList[0].hy >= Enemies[i].y - 10 &&
                              Hero1[0].LaserList[0].hy <= Enemies[i].y + Enemies[i].im.Height + 10
                                )
                            {
                                Enemies.RemoveAt(i);
                                //Enemies.Clear();
                            }
                        }
                        for (int i = 0; i < Boss.Count; i++)
                        {
                            if (Hero1[0].LaserList[0].hx <= Boss[i].x &&
                              Hero1[0].LaserList[0].hx <= Boss[i].x + Boss[i].im.Width &&
                              Hero1[0].LaserList[0].hy >= Boss[i].y &&
                              Hero1[0].LaserList[0].hy <= Boss[i].y + Boss[i].im.Height + 10
                                )
                            {
                                Boss[0].hp--;
                                if (Boss[0].hp <= 0)
                                {
                                    
                                    Winner = 1;
                                }
                                //Enemies.Clear();
                            }
                        }
                    }
                    else
                    {
                        
                        hero pnn = new hero();
                        pnn.hx = 0;
                        pnn.hy = Hero1[0].hy + 55;
                        pnn.im = new Bitmap("lazer4.png");
                        laserflag = 1;
                        Hero1[0].LaserList.Add(pnn);
                        for (int i = 0; i < Enemies.Count; i++)
                        {
                            if (Hero1[0].LaserList[0].hx <= Enemies[i].x &&
                              Hero1[0].LaserList[0].hx <= Enemies[i].x + Enemies[i].im.Width &&
                              Hero1[0].LaserList[0].hy >= Enemies[i].y - 10 &&
                              Hero1[0].LaserList[0].hy <= Enemies[i].y + Enemies[i].im.Height + 10
                                )
                            {
                                Enemies.RemoveAt(i);
                                //Enemies.Clear();
                            }
                        }
                    }
                }
                // Multi Bullet
                if (e.KeyCode == Keys.F)
                {
                    Hero1[0].PosFlag = 1;
                    shield = 0;
                }
                //Single Bullet
                if (e.KeyCode == Keys.S)
                {
                    if (Hero1[0].hy + 50 <= this.Height - 100)
                    {
                        Hero1[0].hy += 25;
                        Hero1[1].hy += 25;
                    }

                }
                // Jump
                if (e.KeyCode == Keys.Space)
                {
                    if (flag != 2 && flag != 1)
                    {
                        if (flag != 1)
                        { flag = 1; }
                    }
                }
                
                if (e.KeyCode == Keys.A)
                {
                    if (Hero1[0].hx - 50 >= 0)
                    {
                        Hero1[0].hx -= 25;
                        Hero1[1].hx -= 25;
                    }
                }
                if (e.KeyCode == Keys.D)
                {
                    if (Hero1[0].hx + 50 <= this.Width)
                    {
                        Hero1[0].hx += 25;
                        Hero1[1].hx += 25;
                        xs += 2;
                    }
                }
                if (e.KeyCode == Keys.W)
                {
                    if (Hero1[0].hy - 50 >= 0)
                    {
                        Hero1[0].hy -= 25;
                        Hero1[1].hy -= 25;
                    }
                }
                if (e.KeyCode == Keys.E)
                {
                    if (Hero1[0].Pos % 2 == 0)
                    {
                        Hero1[0].Pos = 0;
                        Hero1[0].Pos++;
                        Hero1[1].hx += 40;
                    }
                    else
                    {
                        Hero1[0].Pos = 1;
                        Hero1[0].Pos--;
                        Hero1[1].hx -= 40;
                    }
                }
                if (e.KeyCode == Keys.G)
                {
                    shield = 0;
                    if (Bulletflag == 0)
                    {
                        hero pnn = new hero();
                        pnn.hx = Hero1[0].hx + 80;
                        pnn.hy = Hero1[0].hy + 55;
                        pnn.f = true;
                        pnn.im = new Bitmap("B2.png");
                        Bulletflag = 1;
                        Hero1[0].SingleBulletList.Add(pnn);
                    }
                }
                if (e.KeyCode == Keys.R)
                {
               
                    shield = 1;
                }
               
            }
        }
        private void Tt_Tick(object sender, EventArgs e)
        {
            // Flag = 0 No Flip
            // Flag = 1 Ther is Flip
            //////////////===[background movement]==========///////////////
            BackGroundPhotoList[p].rCD = new Rectangle(BackGroundPhotoList[p].rCD.Left - 10, BackGroundPhotoList[p].rCD.Top, BackGroundPhotoList[p].rCD.Width, BackGroundPhotoList[p].rCD.Height);
            BackGroundPhotoList[p + 1].rCD = new Rectangle(BackGroundPhotoList[p + 1].rCD.Left - 10, BackGroundPhotoList[p + 1].rCD.Top, BackGroundPhotoList[p + 1].rCD.Width, BackGroundPhotoList[p + 1].rCD.Height);
            if (BackGroundPhotoList[p + 1].PosFlag <= 0)
            {

                background();
                bg();
                p += 2;
            }
            else
            {
                BackGroundPhotoList[p + 1].PosFlag -= 10;
            }
            if (start == 0)
            {
                if (Hero1[0].hx + 30 > 500)
                {
                    start = 1;
                }
                else
                {
                    // Enter the Screen and move ->
                    Hero1[0].hx += 40;
                    Hero1[1].hx += 40;

                }
            }
            if (start > 0)
            {/////===[idle animation+ shooting animation]======/////
                if (Hero1[0].Pos == 0)
                {
                    if (Hero1[0].PosFlag == 0)
                    {
                        for (int i = 0; i < Hero1.Count - 1; i++)
                        {
                            if (Hero1[i].Idle == 0)
                            {
                                Hero1[i].im = new Bitmap("1.png");
                                Hero1[i].Idle++;
                            }
                            else if (Hero1[i].Idle == 1)
                            {
                                Hero1[i].im = new Bitmap("2.png");
                                Hero1[i].Idle++;
                            }
                            else if (Hero1[i].Idle == 2)
                            {
                                Hero1[i].im = new Bitmap("2.png");
                                Hero1[i].Idle = 0;
                            }
                        }
                    }
                    else if (Hero1[0].PosFlag == 1)
                    {
                        for (int i = 0; i < Hero1.Count; i++)
                        {
                            if (Hero1[i].Shoot == 0)
                            {
                                Hero1[i].im = new Bitmap("S1.png");
                                Hero1[i].Shoot++;
                            }
                            else if (Hero1[i].Shoot == 1)
                            {
                                Hero1[i].im = new Bitmap("S2.png");
                                Hero1[i].Shoot++;
                            }
                            else if (Hero1[i].Shoot == 2)
                            {
                                Hero1[i].im = new Bitmap("S3.png");
                                Hero1[i].Shoot = 0;
                                Hero1[i].PosFlag = 0;
                                hero pnn = new hero();
                                pnn.hx = Hero1[0].hx + 80;
                                pnn.hy = Hero1[0].hy + 55;
                                pnn.f = true;
                                pnn.im = new Bitmap("B1.png");

                                pnn.Pos = 0;
                                Hero1[0].BulletList.Add(pnn);
                            }
                        }
                    }
                }
                else
                {
                    if (Hero1[0].PosFlag == 0)
                    {
                        for (int i = 0; i < Hero1.Count; i++)
                        {
                            if (Hero1[i].Idle == 0)
                            {
                                Hero1[i].im = new Bitmap("L1.png");
                                Hero1[i].Idle++;
                            }
                            else if (Hero1[i].Idle == 1)
                            {
                                Hero1[i].im = new Bitmap("L2.png");
                                Hero1[i].Idle++;
                            }
                            else if (Hero1[i].Idle == 2)
                            {
                                Hero1[i].im = new Bitmap("L2.png");
                                Hero1[i].Idle = 0;
                            }
                        }
                    }
                    else if (Hero1[0].PosFlag == 1)
                    {
                        for (int i = 0; i < Hero1.Count; i++)
                        {
                            if (Hero1[i].Shoot == 0)
                            {
                                Hero1[i].im = new Bitmap("LS1.png");
                                Hero1[i].Shoot++;
                            }
                            else if (Hero1[i].Shoot == 1)
                            {
                                Hero1[i].im = new Bitmap("LS2.png");
                                Hero1[i].Shoot++;
                            }
                            else if (Hero1[i].Shoot == 2)
                            {
                                Hero1[i].im = new Bitmap("LS3.png");
                                Hero1[i].Shoot = 0;
                                Hero1[i].PosFlag = 0;
                                hero pnn = new hero();
                                pnn.hx = Hero1[0].hx + 20;
                                pnn.hy = Hero1[0].hy + 55;
                                pnn.f = true;
                                pnn.im = new Bitmap("B1.png");
                                pnn.Pos = 1;
                                Hero1[0].BulletList.Add(pnn);
                            }
                        }
                    }
                }
                ////=====[single bullet movement]====////
                if (Bulletflag == 1)
                {
                    if (Hero1[0].Pos == 0)
                    {
                        Hero1[0].SingleBulletList[0].hx += 20;
                        for (int j = 0; j < Hero1[0].SingleBulletList.Count; j++)
                        {
                            for (int i = 0; i < Enemies.Count; i++)
                            {
                                if (Hero1[0].SingleBulletList[j].hx > Enemies[i].x &&
                                   Hero1[0].SingleBulletList[j].hx <= Enemies[i].x + Enemies[i].im.Width &&
                                   Hero1[0].SingleBulletList[j].hy >= Enemies[i].y &&
                                   Hero1[0].SingleBulletList[j].hy <= Enemies[i].y + Enemies[i].im.Height)
                                {
                                    Enemies.RemoveAt(i);
                                    Hero1[0].SingleBulletList.Clear();
                                    Bulletflag = 0;
                                    break;
                                }

                            }
                        }
                        for (int i = 0; i < Hero1[0].SingleBulletList.Count; i++)
                        {
                            if (Hero1[0].SingleBulletList[i].hx >= this.Width)
                            {
                                Hero1[0].SingleBulletList.Clear();
                                Bulletflag = 0;
                            }
                        }
                    }
                }
                /////=====[bullet movement]=====/////////
                for (int i = 0; i < Hero1[0].BulletList.Count; i++)
                {
                    if (Hero1[0].BulletList[i].Pos == 0)
                    {
                        Hero1[0].BulletList[i].hx += 20;
                        if (Hero1[0].BulletList[i].hx + 20 > this.ClientSize.Width)
                        {
                            Hero1[0].BulletList[i].f = false;
                        }

                    }
                    else
                    {
                        Hero1[0].BulletList[i].hx -= 20;
                        if (Hero1[0].BulletList[i].hx - 20 < 0)
                        {
                            Hero1[0].BulletList[i].f = false;
                        }
                    }
                }
                ///=====[hit enemy?]======/////
                if (f1 == 3 && Enemies.Count == 0)
                {
                    for (int i = 0; i < Hero1[0].BulletList.Count; i++)
                    {
                        if (Hero1[0].BulletList[i].hx + 30 >= Boss[0].x &&
                               Hero1[0].BulletList[i].hx + 30 <= Boss[0].x + Boss[0].im.Width &&
                               Hero1[0].BulletList[i].hy >= Boss[0].y &&
                               Hero1[0].BulletList[i].hy <= Boss[0].y + Boss[0].im.Height
                            )
                        {
                            Boss[0].hp -= 5;
                            Hero1[0].BulletList.RemoveAt(i);

                            Hero1[0].BulletList[i].f = false;
                            if (Boss[0].hp <= 0)
                            {
                                tt.Stop();
                                MessageBox.Show("you won");
                            }

                            break;
                        }
                    }
                }
                for (int i = 0; i < Hero1[0].BulletList.Count; i++)
                {



                    for (int k = 0; k < Enemies.Count; k++)
                    {
                        if (Hero1[0].BulletList[i].hx + 30 >= Enemies[k].x - 5 &&
                            Hero1[0].BulletList[i].hx + 30 <= Enemies[k].x - 5 + Enemies[k].im.Width &&
                            Hero1[0].BulletList[i].hy >= Enemies[k].y - 5 &&
                            Hero1[0].BulletList[i].hy <= Enemies[k].y + Enemies[k].im.Height + 5
                          )
                        {

                            //H1[0].bullet.Remove(H1[0].bullet[i]);
                            Hero1[0].BulletList.RemoveAt(i);
                            // this.Text = "hit";
                            Hero1[0].BulletList[i].f = false;
                            Enemies.RemoveAt(k);
                            break;

                        }
                        else if (Hero1[0].BulletList[i].hx - 20 >= Enemies[k].x &&
                            Hero1[0].BulletList[i].hx - 30 <= Enemies[k].x + Enemies[k].im.Width &&
                            Hero1[0].BulletList[i].hy >= Enemies[k].y - 5 &&
                            Hero1[0].BulletList[i].hy <= Enemies[k].y + Enemies[k].im.Height + 5)
                        {
                            Hero1[0].BulletList.RemoveAt(i);
                            this.Text = "hit";
                            Hero1[0].BulletList[i].f = false;
                            Enemies.RemoveAt(k);
                            break;
                        }


                    }



                }
                for (int i = 0; i < Hero1[0].BulletList.Count; i++)
                {
                    if (Hero1[0].BulletList[i].f == false)
                    {
                        Hero1[0].BulletList.RemoveAt(i);
                    }
                }


                ///====[jump]========////
                if (flag == 1)
                {

                    if (ct < 7)
                    {
                        Hero1[0].hy -= 10;
                        Hero1[1].hy -= 10;
                        ct++;
                    }
                    else
                    {
                        ct = 0;
                        flag = 2;
                    }


                }
                else if (flag == 2)
                {
                    if (ct < 7)
                    {
                        Hero1[0].hy += 10;
                        Hero1[1].hy += 10;
                        ct++;
                    }
                    else
                    {
                        ct = 0;
                        flag = 0;
                    }
                }
                ////====[enemy creation]=====////

                if (f1 == 0)
                {
                    int ys = 100;
                    for (int i = 0; i < 5; i++)
                    {
                        enemy pnn = new enemy();
                        pnn.x = rr.Next(900, 1300);
                        pnn.y = ys;//rr.Next(H1[0].y - 100, H1[0].y + 100);
                        pnn.im = new Bitmap("EA1.png");
                        pnn.im.MakeTransparent(pnn.im.GetPixel(0, 0));
                        pnn.flagpos = 0;
                        if (i % 2 == 0)
                        { pnn.dir = 0; }
                        else
                        {
                            pnn.dir = 1;
                        }
                        pnn.ys = ys;
                        pnn.whichpos = 0;
                        Enemies.Add(pnn);
                        ys += 150;

                    }
                    f1 = 1;
                }
                if (Enemies.Count == 0 && f1 == 1)
                {
                    int ys = 100;
                    for (int i = 0; i < 5; i++)
                    {
                        enemy pnn = new enemy();
                        pnn.x = rr.Next(100, 300);
                        pnn.y = ys;//rr.Next(H1[0].y - 100, H1[0].y + 100);
                        pnn.im = new Bitmap("EAR1.png");
                        pnn.flagpos = 0;
                        if (i % 2 == 1)
                        { pnn.dir = 1; }
                        else
                        {
                            pnn.dir = 0;
                        }
                        pnn.ys = ys;
                        pnn.whichpos = 1;
                        Enemies.Add(pnn);
                        ys += 150;

                    }
                    f1 = 2;
                }
                if (Enemies.Count == 0 && f1 == 2)
                {
                    int ys = 50;
                    for (int i = 0; i < 5; i++)
                    {
                        enemy pnn = new enemy();
                        pnn.x = this.Width + 440;
                        pnn.y = ys;
                        pnn.im = new Bitmap("EA2 1.png");
                        pnn.dir = 2;
                        pnn.whichpos = 0;
                        pnn.ys = ys;
                        ys += 150;
                        Enemies.Add(pnn);
                    }
                    int ss = 50;
                    for (int i = 0; i < 5; i++)
                    {
                        enemy pnn = new enemy();
                        pnn.x = -450;
                        pnn.y = ss;//rr.Next(H1[0].y - 100, H1[0].y + 100);
                        pnn.im = new Bitmap("EAR1.png");
                        pnn.flagpos = 0;
                        pnn.dir = 3;
                        pnn.ys = ss;
                        pnn.whichpos = 1;
                        Enemies.Add(pnn);
                        ss += 125;

                    }
                    f2 = 1;
                    f1 = 3;
                }
                if (f2 == 1)
                {
                    if (ct2 % 40 == 0)
                    {

                    }
                    f2 = 0;
                }
                // Create Boss
                if (f1 == 3 && Enemies.Count == 0)
                {
                    enemy pnn = new enemy();
                    pnn.x = this.Width - 700;
                    pnn.y = 400;
                    pnn.ys = 400;
                    pnn.im = new Bitmap("Boss1.png");
                    pnn.dir = 2;
                    pnn.hp = 150;
                    pnn.flagpos = 0;
                    Boss.Add(pnn);
    
                }
                // Create ByeBoss
                if (Winner == 1)
                {
                    enemy pnn = new enemy();
                    pnn.x = this.Width - 700;
                    pnn.y = 400;
                    pnn.ys = 400;
                    pnn.im = new Bitmap("Boss1.png");
                    pnn.dir = 2;
                    pnn.hp = 0;
                    pnn.flagpos = 0;
                    BossBye.Add(pnn);
                }
                // Move and Animate BossBye
                for (int i = 0; i < BossBye.Count; i++)
                {
                    if (BossBye[i].flagpos == 0)
                    {
                        BossBye[i].flagpos++;
                        BossBye[i].im = new Bitmap("BossBye1.png");
                    }
                    else if (BossBye[i].flagpos == 1)
                    {
                        BossBye[i].flagpos++;
                        BossBye[i].im = new Bitmap("BossBye2.png");
                    }
                    else if (BossBye[i].flagpos == 2)
                    {
                        BossBye[i].flagpos++;
                        BossBye[i].im = new Bitmap("BossBye3.png");
                    }
                    else if (BossBye[i].flagpos == 3)
                    {
                        BossBye[i].flagpos++;
                        BossBye[i].im = new Bitmap("BossBye4.png");
                    }
                    else if (BossBye[i].flagpos == 4)
                    {
                        BossBye[i].flagpos++;
                        BossBye[i].im = new Bitmap("BossBye5.png");
                    }
                    else if (BossBye[i].flagpos == 5)
                    {
                        BossBye[i].flagpos++;
                        BossBye[i].im = new Bitmap("BossBye6.png");
                    }
                    else if (BossBye[i].flagpos == 6)
                    {
                        BossBye[i].flagpos++;
                        BossBye[i].im = new Bitmap("BossBye7.png");
                    }
                    else if (BossBye[i].flagpos == 7)
                    {
                        BossBye[i].flagpos++;
                        BossBye[i].im = new Bitmap("BossBye8.png");
                    }
                    else if (BossBye[i].flagpos == 8)
                    {
                        BossBye[i].flagpos++;
                        BossBye[i].im = new Bitmap("BossBye9.png");
                    }
                    else if (BossBye[i].flagpos == 9)
                    {
                        BossBye[i].flagpos++;
                        BossBye[i].im = new Bitmap("BossBye10.png");
                    }
                    else if (BossBye[i].flagpos == 10)
                    {
                        BossBye[i].flagpos++;
                        BossBye[i].im = new Bitmap("BossBye11.png");
                    }
                    else if (BossBye[i].flagpos == 11)
                    {
                        BossBye[i].flagpos = 0;
                        BossBye[i].im = new Bitmap("BossBye12.png");
                    }
                

                }

                // Move Boss And Animate
               
                for (int i = 0; i < Boss.Count; i++)
                {
                    if (Boss[i].flagpos == 0)
                    {
                        Boss[i].flagpos++;
                        Boss[i].im = new Bitmap("Boss1.png");
                    }
                    else if (Boss[i].flagpos == 1)
                    {
                        Boss[i].flagpos++;
                        Boss[i].im = new Bitmap("Boss2.png");
                    }
                    else if (Boss[i].flagpos == 2)
                    {
                        Boss[i].flagpos++;
                        Boss[i].im = new Bitmap("Boss3.png");
                    }
                    else if (Boss[i].flagpos == 3)
                    {
                        Boss[i].flagpos++;
                        Boss[i].im = new Bitmap("Boss4.png");
                    }
                    else if (Boss[i].flagpos == 4)
                    {
                        Boss[i].flagpos++;
                        Boss[i].im = new Bitmap("Boss5.png");
                    }
                    else if (Boss[i].flagpos == 5)
                    {
                        Boss[i].flagpos++;
                        Boss[i].im = new Bitmap("Boss6.png");
                    }
                    else if (Boss[i].flagpos == 6)
                    {
                        Boss[i].flagpos++;
                        Boss[i].im = new Bitmap("Boss7.png");
                    }
                    else if (Boss[i].flagpos == 7)
                    {
                        Boss[i].flagpos++;
                        Boss[i].im = new Bitmap("Boss8.png");
                    }
                    else if (Boss[i].flagpos == 8)
                    {
                        Boss[i].flagpos++;
                        Boss[i].im = new Bitmap("Boss9.png");
                    }
                    else if (Boss[i].flagpos == 9)
                    {
                        Boss[i].flagpos = 0;
                        Boss[i].im = new Bitmap("Boss10.png");
                    }
                 
                }
                for (int i = 0; i < Boss.Count; i++)
                {
                    if (Boss[i].dir == 2)
                    {
                        if (Boss[i].x - 50 < this.Width - 300 & ctx <= 0)
                        {
                            Boss[i].dir = 0;
                           
                        }
                        else
                        {
                            Boss[i].x -= 50;
                       
                        }
                    }
                    else if (Boss[i].dir == 0)
                    {
                        if (Boss[i].y - 20 < Boss[i].ys - 400)
                        {
                            Boss[i].dir = 1;
                        }
                        else
                        {
                            Boss[i].y -= 20;
                         
                        }
                    }
                    else if (Boss[i].dir == 1)
                    {
                        if (Boss[i].y + 20 > Boss[i].ys + 300)
                        {
                            Boss[i].dir = 0;
                        }
                        else
                        {
                            Boss[i].y += 20;
                         
                        }
                    }

                }
                cte++;
                // boss explotions
                if (f1 == 3 && Enemies.Count == 0)
                {
                    if (cte % 70 == 0)
                    {
                        for (int i = 0; i < 25; i++)
                        {


                            enemy pnn = new enemy();
                            pnn.x = rr.Next(0, this.Width);
                            pnn.y = rr.Next(Hero1[0].hy - 200, Hero1[0].hy + 200);
                            pnn.im = new Bitmap("explosion1.png");
                            pnn.flagpos = 1;
                            Boss[0].monsters.Add(pnn);

                        }

                    }
                    for (int i = 0; i < Boss[0].monsters.Count; i++)
                    {
                        if (Boss[0].monsters[i].flagpos == 1)
                        {
                            Boss[0].monsters[i].im = new Bitmap("explosion2.png");
                            Boss[0].monsters[i].flagpos++;
                            if (Boss[0].monsters[i].x >= Hero1[0].hx &&
                               Boss[0].monsters[i].x <= Hero1[0].hx + Hero1[0].im.Width &&
                               Boss[0].monsters[i].y >= Hero1[0].hy &&
                               Boss[0].monsters[i].y <= Hero1[0].hy + Hero1[0].im.Height && shield == 0)
                            {
                                Hero1[1].Health -= 2;
                            }
                        }
                        else if (Boss[0].monsters[i].flagpos == 2)
                        {
                            Boss[0].monsters[i].im = new Bitmap("explosion3.png");
                            Boss[0].monsters[i].flagpos++;
                            if (Boss[0].monsters[i].x >= Hero1[0].hx &&
                               Boss[0].monsters[i].x <= Hero1[0].hx + Hero1[0].im.Width &&
                               Boss[0].monsters[i].y >= Hero1[0].hy &&
                               Boss[0].monsters[i].y <= Hero1[0].hy + Hero1[0].im.Height && shield == 0)
                            {
                                Hero1[1].Health -= 2;
                            }
                        }
                        else if (Boss[0].monsters[i].flagpos == 3)
                        {
                            Boss[0].monsters[i].im = new Bitmap("explosion4.png");
                            Boss[0].monsters[i].flagpos++;
                            if (Boss[0].monsters[i].x >= Hero1[0].hx &&
                               Boss[0].monsters[i].x <= Hero1[0].hx + Hero1[0].im.Width &&
                               Boss[0].monsters[i].y >= Hero1[0].hy &&
                               Boss[0].monsters[i].y <= Hero1[0].hy + Hero1[0].im.Height && shield == 0)
                            {
                                Hero1[1].Health -= 2;
                            }
                        }
                        else if (Boss[0].monsters[i].flagpos == 4)
                        {
                            Boss[0].monsters[i].im = new Bitmap("explosion5.png");
                            Boss[0].monsters[i].flagpos++;
                            if (Boss[0].monsters[i].x >= Hero1[0].hx &&
                               Boss[0].monsters[i].x <= Hero1[0].hx + Hero1[0].im.Width &&
                               Boss[0].monsters[i].y >= Hero1[0].hy &&
                               Boss[0].monsters[i].y <= Hero1[0].hy + Hero1[0].im.Height && shield == 0)
                            {
                                Hero1[1].Health -= 2;
                            }
                        }
                        else if (Boss[0].monsters[i].flagpos == 5)
                        {
                            Boss[0].monsters[i].im = new Bitmap("explosion6.png");
                            Boss[0].monsters[i].flagpos++;
                            if (Boss[0].monsters[i].x >= Hero1[0].hx &&
                               Boss[0].monsters[i].x <= Hero1[0].hx + Hero1[0].im.Width &&
                               Boss[0].monsters[i].y >= Hero1[0].hy &&
                               Boss[0].monsters[i].y <= Hero1[0].hy + Hero1[0].im.Height && shield == 0)
                            {
                                Hero1[1].Health -= 2;
                            }
                        }
                        else if (Boss[0].monsters[i].flagpos == 6)
                        {
                            Boss[0].monsters[i].im = new Bitmap("explosion7.png");
                            Boss[0].monsters[i].flagpos++;
                            if (Boss[0].monsters[i].x >= Hero1[0].hx &&
                               Boss[0].monsters[i].x <= Hero1[0].hx + Hero1[0].im.Width &&
                               Boss[0].monsters[i].y >= Hero1[0].hy &&
                               Boss[0].monsters[i].y <= Hero1[0].hy + Hero1[0].im.Height && shield == 0)
                            {
                                Hero1[1].Health -= 2;
                            }
                        }
                        else if (Boss[0].monsters[i].flagpos == 7)
                        {
                            Boss[0].monsters[i].im = new Bitmap("explosion8.png");
                            Boss[0].monsters[i].flagpos++;
                            if (Boss[0].monsters[i].x >= Hero1[0].hx &&
                               Boss[0].monsters[i].x <= Hero1[0].hx + Hero1[0].im.Width &&
                               Boss[0].monsters[i].y >= Hero1[0].hy &&
                               Boss[0].monsters[i].y <= Hero1[0].hy + Hero1[0].im.Height && shield == 0)
                            {
                                Hero1[1].Health -= 2;
                            }
                        }
                        else if (Boss[0].monsters[i].flagpos == 8)
                        {
                            Boss[0].monsters[i].im = new Bitmap("explosion9.png");
                            Boss[0].monsters[i].flagpos++;
                        }
                        else if (Boss[0].monsters[i].flagpos == 9)
                        {
                            Boss[0].monsters[i].im = new Bitmap("explosion10.png");
                            Boss[0].monsters[i].flagpos++;
                        }
                        else if (Boss[0].monsters[i].flagpos == 10)
                        {
                            Boss[0].monsters[i].im = new Bitmap("explosion11.png");
                            Boss[0].monsters[i].flagpos++;
                        }
                        else
                        {
                            Boss[0].monsters[i].idle = 1;
                     
                        }
                    }
                    for (int i = 0; i < Boss[0].monsters.Count; i++)
                    {
                        if (Boss[0].monsters[i].idle == 1)
                        {
                            Boss[0].monsters.RemoveAt(i);
                        }
                    }

                    //////===[enemy grenedes]=====////
                    if (cte % 100 == 0)
                    {
                        int ls = 150;
                        for (int i = 0; i < 8; i++)
                        {
                            enemy pnn = new enemy();
                            pnn.x = ls;
                            pnn.y = 0;
                            pnn.im = new Bitmap("EA6 1.png");
                            pnn.flagpos = 1;
                            Boss[0].bullet.Add(pnn);
                            ls += 100;
                        }
                    }
                    for (int i = 0; i < Boss[0].bullet.Count; i++)
                    {
                        if (Boss[0].bullet[i].flagpos == 1)
                        {
                            Boss[0].bullet[i].im = new Bitmap("EA6 1.png");
                        }
                        if (Boss[0].bullet[i].x >= Hero1[0].hx &&
                               Boss[0].bullet[i].x <= Hero1[0].hx + Hero1[0].im.Width &&
                               Boss[0].bullet[i].y >= Hero1[0].hy &&
                               Boss[0].bullet[i].y <= Hero1[0].hy + Hero1[0].im.Height && shield == 0)
                        {
                            Hero1[1].Health -= 5;
                            Boss[0].bullet.RemoveAt(i);
                        }
                        else
                        {
                            Boss[0].bullet[i].y += 20;
                        }
                    }
                    int xs = Boss[0].x;
                    int ys = Boss[0].y;
                    /////===[boss bala7 xD]===////
                    if (cte % 10 == 0)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            enemy pnn = new enemy();
                            pnn.x = xs;
                            pnn.y = ys;
                            ys += 30;
                            pnn.im = new Bitmap("EA4 1.png");
                            Boss[0].B.Add(pnn);
                        }
                    }
                    for (int i = 0; i < Boss[0].B.Count; i++)
                    {

                        if (Boss[0].B[i].x >= Hero1[0].hx &&
                               Boss[0].B[i].x <= Hero1[0].hx + Hero1[0].im.Width &&
                               Boss[0].B[i].y >= Hero1[0].hy &&
                               Boss[0].B[i].y <= Hero1[0].hy + Hero1[0].im.Height && shield == 0)
                        {
                            Hero1[1].Health -= 5;
                            Boss[0].B.RemoveAt(i);
                        }
                        else
                        {
                            Boss[0].B[i].x -= 20;
                        }
                        if (Boss[0].B[i].x - 20 < 0)
                        {
                            Boss[0].B.RemoveAt(i);
                        }
                    }
                }

                ////====[enemy idle animation]====////
                for (int i = 0; i < Enemies.Count; i++)
                {

                    if (Enemies[i].whichpos == 0)
                    {
                        if (Enemies[i].flagpos == 0)
                        {
                            Enemies[i].flagpos++;
                            Enemies[i].im = new Bitmap("EA1.png");
                        }
                        else if (Enemies[i].flagpos == 1)
                        {
                            Enemies[i].flagpos++;
                            Enemies[i].im = new Bitmap("EA2.png");
                        }
                        else if (Enemies[i].flagpos == 2)
                        {
                            Enemies[i].flagpos = 0;
                            Enemies[i].im = new Bitmap("EA3.png");
                        }
                    }
                }
                //////=====[enemey movement]====////
                for (int i = 0; i < Enemies.Count; i++)
                {
                    if (Enemies[i].dir == 0)
                    {
                        if (Enemies[i].y + 10 >= Enemies[i].ys + 50)
                        {
                            Enemies[i].dir = 1;
                        }
                        else
                        {
                            Enemies[i].y += 10;
                        }
                    }
                    else if (Enemies[i].dir == 1)
                    {
                        if (Enemies[i].y - 10 <= Enemies[i].ys - 50)
                        {
                            Enemies[i].dir = 0;
                        }
                        else
                        {
                            Enemies[i].y -= 10;
                        }
                    }
                    else if (Enemies[i].dir == 2)
                    {
                        if (Enemies[i].x - 10 <= this.Width - 300)
                        {
                            if (i % 2 == 0)
                            { Enemies[i].dir = 0; }
                            else
                            {
                                Enemies[i].dir = 1;
                            }
                        }
                        else
                        {
                            Enemies[i].x -= 50;
                        }
                    }
                    else if (Enemies[i].dir == 3)
                    {
                        if (Enemies[i].x + 50 >= 300)
                        {
                            if (i % 2 == 0)
                            { Enemies[i].dir = 0; }
                            else
                            {
                                Enemies[i].dir = 1;
                            }
                        }
                        else
                        {
                            Enemies[i].x += 50;
                        }
                    }
                }
                /////====[enemy bullets]====///
                if (ct3 % 20 == 0)
                {
                    for (int i = 0; i < Enemies.Count; i++)
                    {
                        if (Enemies[i].whichpos == 0)
                        {
                            enemy pnn = new enemy();
                            pnn.x = Enemies[i].x - 5;
                            pnn.y = Enemies[i].y;
                            pnn.whichpos = 0;
                            pnn.im = new Bitmap("ea bomb.png");
                            Enemies[i].bullet.Add(pnn);
                        }
                        else
                        {
                            enemy pnn = new enemy();
                            pnn.x = Enemies[i].x + 10;
                            pnn.y = Enemies[i].y;
                            pnn.whichpos = 1;
                            pnn.im = new Bitmap("ea bomb.png");
                            Enemies[i].bullet.Add(pnn);
                        }
                    }
                }
                for (int i = 0; i < Enemies.Count; i++)
                {
                    for (int k = 0; k < Enemies[i].bullet.Count; k++)
                    {
                        if (Enemies[i].bullet[k].whichpos == 0)
                        {
                            if (Enemies[i].bullet[k].x - 40 <= 0)
                            {

                                Enemies[i].bullet.RemoveAt(k);
                            }
                        }
                        else
                        {
                            if (Enemies[i].bullet[k].x + 40 >= this.Width)
                            {

                                Enemies[i].bullet.RemoveAt(k);
                            }
                        }
                    }
                }
                for (int i = 0; i < Enemies.Count; i++)
                {
                    for (int k = 0; k < Enemies[i].bullet.Count; k++)
                    {
                        if (Enemies[i].bullet[k].whichpos == 0)
                        {
                            Enemies[i].bullet[k].x -= 40;
                            if (Enemies[i].bullet[k].x - 40 <= Hero1[0].hx + Hero1[0].im.Width &&
                               Enemies[i].bullet[k].x - 40 >= Hero1[0].hx &&
                                Enemies[i].bullet[k].y >= Hero1[0].hy &&
                                Enemies[i].bullet[k].y <= Hero1[0].hy + Hero1[0].im.Height + 5 && shield == 0)
                            {
                                // Hero Health
                                Hero1[1].Health -= 1;
                                Enemies[i].bullet.RemoveAt(k);
                            }
                        }
                        else
                        {
                            Enemies[i].bullet[k].x += 40;
                            if (Enemies[i].bullet[k].x + 40 <= Hero1[0].hx + Hero1[0].im.Width &&
                               Enemies[i].bullet[k].x + 40 >= Hero1[0].hx &&
                                Enemies[i].bullet[k].y >= Hero1[0].hy &&
                                Enemies[i].bullet[k].y <= Hero1[0].hy + Hero1[0].im.Height + 5 && shield == 0)
                            {
                               
                                // Hero Health
                                Hero1[1].Health -= 1;
                                Enemies[i].bullet.RemoveAt(k);
                            }
                        }
                    }
                }
                if (f1 == 3 && Enemies.Count == 0)
                { this.Text = ("HERO HP= " + Hero1[1].Health + (" BOSS HP= ") + Boss[0].hp); }
                else
                {
                    this.Text = ("HERO HP= " + Hero1[1].Health);
                }
                //////====[lose condition]=====////
                if (Hero1[1].Health <= 0)
                {
                    tt.Stop();
                    MessageBox.Show("you lost");
                }
            }
            //this.Text = ("hp= " + H1[1].w);
            ct2++;
            ct3++;
            dbuffer(this.CreateGraphics());
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            dbuffer(this.CreateGraphics());
            Text = (" " + Hero1[1].Health);
        }
        void background()
        {
            hero pnn = new hero();
            pnn.hx = 0;
            pnn.hy = 0;
            pnn.im = new Bitmap("sky2.png");
            pnn.rCD = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            pnn.rCSRC = new Rectangle(0, 0, pnn.im.Width, pnn.im.Height);
            BackGroundPhotoList.Add(pnn);

        }
        void bg()
        {
            hero pnn = new hero();
            pnn.hx = 0;
            pnn.hy = 0;
            pnn.im = new Bitmap("sky2.png");
            pnn.rCD = new Rectangle(this.ClientSize.Width - 1, 0, this.ClientSize.Width, this.ClientSize.Height);
            pnn.rCSRC = new Rectangle(0, 0, pnn.im.Width, pnn.im.Height);
            pnn.PosFlag = this.ClientSize.Width - 5;
            BackGroundPhotoList.Add(pnn);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Buffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            hero pnn = new hero();
            pnn.hx = -350;
            pnn.hy = 350;
            pnn.im = new Bitmap("1.png");
            pnn.Idle = 0;
            pnn.PosFlag = 0;
            pnn.Shoot = 0;
            pnn.Pos = 0;
            pnn.im.MakeTransparent(pnn.im.GetPixel(0, 0));
            Hero1.Add(pnn);
            hero pnn1 = new hero();
            pnn1.hx = Hero1[0].hx + 20;
            pnn1.hy = Hero1[0].hy - 5;
            pnn1.h = 10;
            pnn1.Health = 50;
            Hero1.Add(pnn1);
            hero pnn2 = new hero();
            pnn2.hx = Hero1[0].hx - 10;
            pnn2.hy = Hero1[0].hy - 5;
            pnn2.Health = 135;
            pnn2.h = 110;
            pnn2.im = new Bitmap("shield2.png");
            Hero1.Add(pnn2);
            background();
            bg();

        }
        void dbuffer(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(Buffer);
            DrawScreen(g2);
            g.DrawImage(Buffer, 0, 0);
        }

        void DrawScreen(Graphics g)
        {
            g.Clear(Color.Black);
            g.DrawString("Health " + Hero1[1].Health.ToString(), new Font("Arial", 15), Brushes.White, 5, 5);
            g.DrawRectangle(Pens.White, 5, 5, 200, 130);
            g.DrawString("Press E to Flip", new Font("Arial", 15), Brushes.White, 5, 30);
            g.DrawString("Press F for Multi", new Font("Arial", 15), Brushes.White, 5, 50);
            g.DrawString("Press G for Single", new Font("Arial", 15), Brushes.White, 5, 70);
            g.DrawString("Press L for Laser", new Font("Arial", 15), Brushes.White, 5, 90);

            if (Winner == 1 && start != 0)
            {
                for (int i = 0; i < BossBye.Count; i++)
                {
                    g.DrawImage(BossBye[i].im, BossBye[i].x, BossBye[i].y);
                    
                }

                start = 0;
               
            }
            if (Winner!=1)
            {
                for (int i = 0; i < Boss.Count; i++)
                {
                    if (i == 0)
                    {
                        g.DrawImage(Boss[i].im, Boss[i].x, Boss[i].y);
                    }
                    else
                    {
                        SolidBrush b = new SolidBrush(Color.Red);
                        g.FillRectangle(b, Boss[i].x, Boss[i].y, Boss[i].w, Boss[i].h);
                    }
                }
            }
           
             
        

            // Scrolling
            for (int i = p; i < BackGroundPhotoList.Count; i++)
            { g.DrawImage(BackGroundPhotoList[i].im, BackGroundPhotoList[i].rCD, BackGroundPhotoList[i].rCSRC, GraphicsUnit.Pixel); }






     
            // Draw Single Bullet
            for (int i = 0; i < Hero1[0].SingleBulletList.Count; i++)
            {
                g.DrawImage(Hero1[0].SingleBulletList[i].im, Hero1[0].SingleBulletList[i].hx, Hero1[0].SingleBulletList[i].hy);
            }

            




            for (int i = 0; i < Hero1.Count; i++)
            {
                if (i == 0)
                {
                    g.DrawImage(Hero1[i].im,
                                  new Rectangle(Hero1[i].hx, Hero1[i].hy, 200, 200),  
                                  new Rectangle(0, 0, 100, 100),  
                                  GraphicsUnit.Pixel);
                 
                }

                else if (i == 1)
                {
                    // Draw Hero Red Rectang;e
                    SolidBrush b = new SolidBrush(Color.Red);
                    g.FillRectangle(b, Hero1[i].hx, Hero1[i].hy, Hero1[i].Health, Hero1[i].h);
                    if (shield == 1)
                    { 
                        // Draw Shield
                        g.DrawImage(Shield, Hero1[i].hx - 30, Hero1[i].hy, Hero1[i].Health + 100, Hero1[i].h + 120);
                    }
                }
               
            }

            // Draw Laser
            if (laserflag == 1)
            {
                // Draw Laser With No Flip
                if (Hero1[0].Pos == 0)
                {
                    g.DrawImage(Hero1[0].LaserList[0].im, Hero1[0].LaserList[0].hx, Hero1[0].LaserList[0].hy, this.Width - Hero1[0].LaserList[0].hx, Hero1[0].LaserList[0].im.Height);
                    laserflag = 0;
                    Hero1[0].LaserList.Clear();
                }

                // Draw Laser With  Flip
                else
                {
                    g.DrawImage(Hero1[0].LaserList[0].im, Hero1[0].LaserList[0].hx, Hero1[0].LaserList[0].hy, Hero1[0].LaserList[0].hx + Hero1[0].hx, Hero1[0].LaserList[0].im.Height);
                    laserflag = 0;
                    Hero1[0].LaserList.Clear();
                }
            }





            // Draw Red Bullet
            for (int i = 0; i < Hero1[0].BulletList.Count; i++)
            {
                g.DrawImage(Hero1[0].BulletList[i].im, Hero1[0].BulletList[i].hx, Hero1[0].BulletList[i].hy);
            }









            // Draw Stage 1 Enemy
            for (int i = 0; i < Enemies.Count; i++)
            {
                // Draw Stage 1 Enemy
                g.DrawImage(Enemies[i].im, Enemies[i].x, Enemies[i].y);
                for (int k = 0; k < Enemies[i].bullet.Count; k++)
                {
                    // Draw Shots From Stage 1 Enemy
                    g.DrawImage(Enemies[i].bullet[k].im, Enemies[i].bullet[k].x, Enemies[i].bullet[k].y);
                }
            }






            // Draw Boss
            if (f1 == 3 && Enemies.Count == 0)
            {
                for (int i = 0; i < Boss[0].monsters.Count; i++)
                {
                    
                    g.DrawImage(Boss[0].monsters[i].im, Boss[0].monsters[i].x, Boss[0].monsters[i].y);
                }
                for (int i = 0; i < Boss[0].bullet.Count; i++)
                {
                    // Draw Boss Bullet 1
                    g.DrawImage(Boss[0].bullet[i].im, Boss[0].bullet[i].x, Boss[0].bullet[i].y);
                }
                // Draw Boss Bullet 2
                for (int i = 0; i < Boss[0].B.Count; i++)
                {
                    g.DrawImage(Boss[0].B[i].im, Boss[0].B[i].x, Boss[0].B[i].y);
                }
            }
        }






    }
}
