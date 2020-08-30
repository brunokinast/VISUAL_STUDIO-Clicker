using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caixinha
{
    public partial class Form1 : Form
    {
        //Valores "Instalados"
        int baidu = 0;
        int hao123 = 0;
        int toolbar = 0;
        int adware = 0;
        int antivirus = 0;

        //Cliques Gerados por segundo
        int baiduPss = 0;
        int hao123Pss = 0;
        int toolbarPss = 0;
        int adwarePss = 0;
        int antivirusPss = 0;

        //Preços
        double baiduClkrP = 0.02;
        double hao123ClkrP = 0.2;
        double toolbarClkrP = 2;
        double adwareClkrP = 6;
        double antivirusClkrP = 10;
        double cliqueP = 0.2;
        double chanceCritP = 0.2;
        double critQuantP = 0.2;

        //Cliques
        int clique = 1;
        int chanceCrit = 0; //Ex: 10 = 10%
        double critQuant = 1.05; //Ex: 1.20 = 20%+ 
        Random rnd = new Random();

        //Temporizador
        Timer criticoPisca = new Timer();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Caixinha.Properties.Resources.critsound);

        //$$$
        double money = 0;

        //Info
        double iMoneyPs = 0;
        double iBonusCrit = 0;

        //Compras
        bool hao123Comp = false;
        bool toolbarComp = false;
        bool adwareComp = false;
        bool antivirusComp = false;
        bool secreto = false;

        public Form1()
        {
            InitializeComponent();
            //Inicializa Background Workers
            geradorMoney.RunWorkerAsync();
            baiduPs.RunWorkerAsync();
            baiduTxt.RunWorkerAsync();
            infoWorker.RunWorkerAsync();
            //Timer
            criticoPisca.Interval = 150;
            criticoPisca.Tick += criticoPisca_Tick;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (money < 1000)
            {
                MessageBox.Show("?");
            }
            else
            {
                money -= 1000;
                MessageBox.Show("Trollei kk");
                secreto = true;
                reloadAll();
            }
            
        }

        private void geradorMoney_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                //"Algoritmo" gerador de dinheiro
                money += (baidu * 0.00001) + (hao123 * 0.00003) + (toolbar * 0.00006) + (adware * 0.00010) + (antivirus * 0.00020);
                geradorMoney.ReportProgress(1);
                geradorMoney.ReportProgress(0);
                System.Threading.Thread.Sleep(500);
            }
        }

        private void geradorMoney_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Atualiza o contador de dinheiro
            moneyT.Text = ("$" + (Math.Truncate(money * 100) / 100).ToString("0.00"));
        }

        //Clica
        private void baiduB_Click(object sender, EventArgs e)
        {
            if (rnd.Next(1,101) <= chanceCrit)
            {
                player.Play();
                baidu += Convert.ToInt32(Math.Round(clique * critQuant));
                criticoT.Visible = true;
                criticoPisca.Start();
            }
            else
            {
                baidu += clique;
                baiduT.Text = ("Baidus instalados:" + System.Environment.NewLine + baidu);
            }
        }

        private void hao123B_Click(object sender, EventArgs e)
        {
            if (rnd.Next(1, 101) <= chanceCrit)
            {
                player.Play();
                hao123 += Convert.ToInt32(Math.Round(clique * critQuant));
                criticoT.Visible = true;
                criticoPisca.Start();
            }
            else
            {
                hao123 += clique;
                hao123T.Text = ("Hao123s instalados:" + System.Environment.NewLine + hao123);
            }
        }

        private void toolbarB_Click(object sender, EventArgs e)
        {
            if (rnd.Next(1, 101) <= chanceCrit)
            {
                player.Play();
                toolbar += Convert.ToInt32(Math.Round(clique * critQuant));
                criticoT.Visible = true;
                criticoPisca.Start();
            }
            else
            {
                toolbar += clique;
                toolbarT.Text = ("Toolbars instaladas:" + System.Environment.NewLine + toolbar);
            }
        }

        private void adwareB_Click(object sender, EventArgs e)
        {
            if (rnd.Next(1, 101) <= chanceCrit)
            {
                player.Play();
                adware += Convert.ToInt32(Math.Round(clique * critQuant));
                criticoT.Visible = true;
                criticoPisca.Start();
            }
            else
            {
                adware += clique;
                adwareT.Text = ("Adwares instalados:" + System.Environment.NewLine + adware);
            }
        }

        private void antivirusB_Click(object sender, EventArgs e)
        {
            if (rnd.Next(1, 101) <= chanceCrit)
            {
                player.Play();
                antivirus += Convert.ToInt32(Math.Round(clique * critQuant));
                criticoT.Visible = true;
                criticoPisca.Start();
            }
            else
            {
                antivirus += clique;
                antivirusT.Text = ("Anti-Vírus instalados:" + System.Environment.NewLine + antivirus);
            }
        }

        //UI Loja
        private void hao123C_Click(object sender, EventArgs e)
        {
            if (baidu >= 400)
            {
                baidu -= 400;
                hao123Comp = true;
                reloadAll();
            }
            else
            {
                MessageBox.Show("Você precisa de mais coisinhas pra comprar isso, poxa vida, clica mais.");
            }
        }

        private void toolbarC_Click(object sender, EventArgs e)
        {
            if (hao123 >= 1200)
            {
                hao123 -= 1200;
                toolbarComp = true;
                reloadAll();
            }
            else
            {
                MessageBox.Show("Você precisa de mais coisinhas pra comprar isso, poxa vida, clica mais.");
            }
        }

        private void adwareC_Click(object sender, EventArgs e)
        {
            if (toolbar >= 4000)
            {
                toolbar -= 4000;
                adwareComp = true;
                reloadAll();
            }
            else
            {
                MessageBox.Show("Você precisa de mais coisinhas pra comprar isso, poxa vida, clica mais.");
            }
        }

        private void baiduPs_DoWork(object sender, DoWorkEventArgs e)
        {
            //Apesar do nome, serve para todos os "instaladores"
            while (true)
            {
                baidu += baiduPss;
                hao123 += hao123Pss;
                toolbar += toolbarPss;
                adware += adwarePss;
                antivirus += antivirusPss;
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void baiduClkr_Click(object sender, EventArgs e)
        {
            if (money >= baiduClkrP)
            {
                money -= baiduClkrP;
                baiduPss += 1;
                baiduPsT.Text = ("Gera 1 Baidu/s. Total:"+System.Environment.NewLine+baiduPss);
                baiduClkrP *= 1.5;
                baiduClkrP = Math.Truncate(baiduClkrP * 100) / 100;
                baiduClkr.Text = ("Injetar Baidu em instaladores [$" + baiduClkrP.ToString("0.00")+"]");
                moneyT.Text = ("$" + (Math.Truncate(money * 100) / 100).ToString("0.00"));
            }
            else
            {
                MessageBox.Show("Você precisa de mais coisinhas pra comprar isso, poxa vida, clica mais.");
            }
        }

        private void baiduTxt_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                baiduTxt.ReportProgress(0);
                baiduTxt.ReportProgress(1);
                System.Threading.Thread.Sleep(200);
            }
        }

        private void baiduTxt_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            baiduT.Text = ("Baidus instalados:" + System.Environment.NewLine + baidu);
            hao123T.Text = ("Hao123s instalados:" + System.Environment.NewLine + hao123);
            toolbarT.Text = ("Toolbars instaladas:" + System.Environment.NewLine + toolbar);
            adwareT.Text = ("Adwares instalados:" + System.Environment.NewLine + adware);
            antivirusT.Text = ("Anti-Vírus instalados:" + System.Environment.NewLine + antivirus);
            if (money >= 200)
            {
                secretoC.Text = ("Viajar");
                secretoT.Text = ("$1000");
            }
        }

        private void hao123Clkr_Click(object sender, EventArgs e)
        {
            if (money >= hao123ClkrP)
            {
                money -= hao123ClkrP;
                hao123Pss += 1;
                hao123ClkrP *= 1.5;
                hao123ClkrP = Math.Truncate(hao123ClkrP * 100) / 100;
                hao123Clkr.Text = ("Definir Hao123 como Homepage [$" + hao123ClkrP.ToString("0.00") + "]");
                hao123PsT.Text = ("Gera 1 Hao123/s. Total:" + System.Environment.NewLine + hao123Pss);
                moneyT.Text = ("$" + (Math.Truncate(money * 100) / 100).ToString("0.00"));
            }
            else
            {
                MessageBox.Show("Você precisa de mais coisinhas pra comprar isso, poxa vida, clica mais.");
            }
        }

        private void toolbarClkr_Click(object sender, EventArgs e)
        {
            if (money >= toolbarClkrP)
            {
                money -= toolbarClkrP;
                toolbarPss += 1;
                toolbarClkrP *= 1.5;
                toolbarClkrP = Math.Truncate(toolbarClkrP * 100) / 100;
                toolbarClkr.Text = ("Toolbars com borboletas e gatos [$" + toolbarClkrP.ToString("0.00") + "]");
                toolbarPsT.Text = ("Gera 1 Toolbar/s. Total:" + System.Environment.NewLine + toolbarPss);
                moneyT.Text = ("$" + (Math.Truncate(money * 100) / 100).ToString("0.00"));
            }
            else
            {
                MessageBox.Show("Você precisa de mais coisinhas pra comprar isso, poxa vida, clica mais.");
            }
        }

        private void adwareClkr_Click(object sender, EventArgs e)
        {
            if (money >= adwareClkrP)
            {
                money -= adwareClkrP;
                adwarePss += 1;
                adwareClkrP *= 1.5;
                adwareClkrP = Math.Truncate(adwareClkrP * 100) / 100;
                adwareClkr.Text = ("Propagandas mais eficazes [$" + adwareClkrP.ToString("0.00") + "]");
                adwarePsT.Text = ("Gera 1 Adware/s. Total:" + System.Environment.NewLine + adwarePss);
                moneyT.Text = ("$" + (Math.Truncate(money * 100) / 100).ToString("0.00"));
            }
            else
            {
                MessageBox.Show("Você precisa de mais coisinhas pra comprar isso, poxa vida, clica mais.");
            }
        }

        private void antivirusClkr_Click(object sender, EventArgs e)
        {
            if (money >= antivirusClkrP)
            {
                money -= antivirusClkrP;
                antivirusPss += 1;
                antivirusClkrP *= 1.5;
                antivirusClkrP = Math.Truncate(antivirusClkrP * 100) / 100;
                antivirusClkr.Text = ("Anti-Vírus com ainda mais vírus [$" + antivirusClkrP.ToString("0.00") + "]");
                antivirusPsT.Text = ("Gera 1 Anti-Vírus/s. Total:" + System.Environment.NewLine + antivirusPss);
                moneyT.Text = ("$" + (Math.Truncate(money * 100) / 100).ToString("0.00"));
            }
            else
            {
                MessageBox.Show("Você precisa de mais coisinhas pra comprar isso, poxa vida, clica mais.");
            }
        }

        private void criticoPisca_Tick(object sender, EventArgs e)
        {
            criticoT.Visible = false;
            criticoPisca.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 Baidu = $0.00002 por segundo\n1 Hao123 = $0.00006 por segundo\n1 Toolbar = $0.00012 por segundo\n1 Adware = $0.00020 por segundo\n1 Anti-Vírus = $0.00040 por segundo\nPreços aumentam em 50% a cada compra.\nO crítico funciona como um multiplicador\npara os cliques. Ex:\n'total = cliques + cliques * bônus%'.");
        }

        private void cliqueB_Click(object sender, EventArgs e)
        {
            if (money >= cliqueP)
            {
                money -= cliqueP;
                cliqueP *= 1.5;
                cliqueP = Math.Truncate(cliqueP * 100) / 100;
                cliquePT.Text = ("$" + cliqueP.ToString("0.00"));
                clique++;
                cliqueT.Text = ("Nº por clique:" + System.Environment.NewLine +clique);
                moneyT.Text = ("$" + (Math.Truncate(money * 100) / 100).ToString("0.00"));
            }
            else
            {
                MessageBox.Show("Você precisa de mais coisinhas pra comprar isso, poxa vida, clica mais.");
            }
        }

        private void chanceCritB_Click(object sender, EventArgs e)
        {
            if (money >= chanceCritP)
            {
                money -= chanceCritP;
                chanceCritP *= 1.5;
                chanceCritP = Math.Truncate(chanceCritP * 100) / 100;
                chanceCritPT.Text = ("$" + chanceCritP.ToString("0.00"));
                chanceCrit++;
                chanceCritT.Text = ("Chance crít:" + System.Environment.NewLine + chanceCrit+"%");
            }
            else
            {
                MessageBox.Show("Você precisa de mais coisinhas pra comprar isso, poxa vida, clica mais.");
            }
        }

        private void critQuantB_Click(object sender, EventArgs e)
        {
            if (money >= critQuantP)
            {
                money -= critQuantP;
                critQuantP *= 1.5;
                critQuantP = Math.Truncate(critQuantP * 100) / 100;
                critQuantPT.Text = ("$" + critQuantP.ToString("0.00"));
                critQuant += 0.1;
                critQuantT.Text = ("Bônus crít:" + System.Environment.NewLine +"+"+ ((critQuant - 1) * 100).ToString("00") +"%");
            }
            else
            {
                MessageBox.Show("Você precisa de mais coisinhas pra comprar isso, poxa vida, clica mais.");
            }
        }

        private void infoB_Click(object sender, EventArgs e)
        {
            infoT.Visible = !infoT.Visible;
        }

        private void infoWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                infoWorker.ReportProgress(0);
                iMoneyPs = ((baidu * 0.00001) + (hao123 * 0.00003) + (toolbar * 0.00006) + (adware * 0.00010) + (antivirus * 0.00020))*2;
                iBonusCrit = clique * critQuant;
                infoWorker.ReportProgress(1);
                System.Threading.Thread.Sleep(100);
            }
        }

        private void infoWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            infoT.Text = ("Dinheiro por segundo:"+System.Environment.NewLine+iMoneyPs+System.Environment.NewLine+"Bônus crítico:"+System.Environment.NewLine+iBonusCrit);
        }

        private void antivirusC_Click(object sender, EventArgs e)
        {
            if (adware >= 8000)
            {
                adware -= 8000;
                antivirusComp = true;
                reloadAll();
            }
            else
            {
                MessageBox.Show("Você precisa de mais coisinhas pra comprar isso, poxa vida, clica mais.");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            temasPanel.Visible = !temasPanel.Visible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(244,244,0);
            baiduB.BackColor = Color.FromArgb(98, 192, 255);
            hao123B.BackColor = Color.FromArgb(98, 192, 255);
            toolbarB.BackColor = Color.FromArgb(98, 192, 255);
            adwareB.BackColor = Color.FromArgb(98, 192, 255);
            antivirusB.BackColor = Color.FromArgb(98, 192, 255);
            baiduT.BackColor = Color.FromArgb(255, 255, 255);
            hao123T.BackColor = Color.FromArgb(255, 255, 255);
            toolbarT.BackColor = Color.FromArgb(255, 255, 255);
            adwareT.BackColor = Color.FromArgb(255, 255, 255);
            antivirusT.BackColor = Color.FromArgb(255, 255, 255);
            infoT.BackColor = Color.FromArgb(255, 255, 255);
            infoT.ForeColor = Color.FromArgb(0, 0, 0);
            moneyT.BackColor = Color.FromArgb(255, 255, 255);
            moneyT.ForeColor = Color.FromArgb(0, 0, 0);
            tabPage1.BackColor = Color.FromArgb(255, 253, 157);
            tabPage2.BackColor = Color.FromArgb(255, 253, 157);
            hao123C.BackColor = Color.FromArgb(98, 192, 255);
            toolbarC.BackColor = Color.FromArgb(98, 192, 255);
            adwareC.BackColor = Color.FromArgb(98, 192, 255);
            antivirusC.BackColor = Color.FromArgb(98, 192, 255);
            hao123CT.BackColor = Color.FromArgb(255, 192, 255);
            toolbarCT.BackColor = Color.FromArgb(255, 192, 255);
            adwareCT.BackColor = Color.FromArgb(255, 192, 255);
            antivirusCT.BackColor = Color.FromArgb(255, 192, 255);
            baiduClkr.BackColor = Color.FromArgb(113, 120, 255);
            hao123Clkr.BackColor = Color.FromArgb(113, 120, 255);
            toolbarClkr.BackColor = Color.FromArgb(113, 120, 255);
            adwareClkr.BackColor = Color.FromArgb(113, 120, 255);
            antivirusClkr.BackColor = Color.FromArgb(113, 120, 255);
            baiduPsT.BackColor = Color.FromArgb(192, 255, 255);
            hao123PsT.BackColor = Color.FromArgb(192, 255, 255);
            toolbarPsT.BackColor = Color.FromArgb(192, 255, 255);
            adwarePsT.BackColor = Color.FromArgb(192, 255, 255);
            antivirusPsT.BackColor = Color.FromArgb(192, 255, 255);
            cliqueB.BackColor = Color.FromArgb(210, 77, 255);
            chanceCritB.BackColor = Color.FromArgb(210, 77, 255);
            critQuantB.BackColor = Color.FromArgb(210, 77, 255);
            secretoC.BackColor = Color.FromArgb(255, 23, 23);
            secretoT.BackColor = Color.FromArgb(255, 168, 253);
            concordo.ForeColor = Color.FromArgb(0, 0, 0);
            cliqueT.BackColor = Color.FromArgb(255, 255, 255);
            chanceCritT.BackColor = Color.FromArgb(255, 255, 255);
            critQuantT.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(22,22,22);
            baiduB.BackColor = Color.Lime;
            hao123B.BackColor = Color.Lime;
            toolbarB.BackColor = Color.Lime;
            adwareB.BackColor = Color.Lime;
            antivirusB.BackColor = Color.Lime;
            baiduT.BackColor = Color.FromArgb(181, 255, 255);
            hao123T.BackColor = Color.FromArgb(181, 255, 255);
            toolbarT.BackColor = Color.FromArgb(181, 255, 255);
            adwareT.BackColor = Color.FromArgb(181, 255, 255);
            antivirusT.BackColor = Color.FromArgb(181, 255, 255);
            infoT.BackColor = Color.FromArgb(21,21,21);
            infoT.ForeColor = Color.Lime;
            moneyT.BackColor = Color.FromArgb(0,0,0);
            moneyT.ForeColor = Color.Lime;
            tabPage1.BackColor = Color.FromArgb(0, 0, 0);
            tabPage2.BackColor = Color.FromArgb(0, 0, 0);
            hao123C.BackColor = Color.Lime;
            toolbarC.BackColor = Color.Lime;
            adwareC.BackColor = Color.Lime;
            antivirusC.BackColor = Color.Lime;
            hao123CT.BackColor = Color.FromArgb(181, 255, 255);
            toolbarCT.BackColor = Color.FromArgb(181, 255, 255);
            adwareCT.BackColor = Color.FromArgb(181, 255, 255);
            antivirusCT.BackColor = Color.FromArgb(181, 255, 255);
            baiduClkr.BackColor = Color.Lime;
            hao123Clkr.BackColor = Color.Lime;
            toolbarClkr.BackColor = Color.Lime;
            adwareClkr.BackColor = Color.Lime;
            antivirusClkr.BackColor = Color.Lime;
            baiduPsT.BackColor = Color.FromArgb(181, 255, 255);
            hao123PsT.BackColor = Color.FromArgb(181, 255, 255);
            toolbarPsT.BackColor = Color.FromArgb(181, 255, 255);
            adwarePsT.BackColor = Color.FromArgb(181, 255, 255);
            antivirusPsT.BackColor = Color.FromArgb(181, 255, 255);
            cliqueB.BackColor = Color.Lime;
            chanceCritB.BackColor = Color.Lime;
            critQuantB.BackColor = Color.Lime;
            secretoC.BackColor = Color.Lime;
            secretoT.BackColor = Color.FromArgb(181, 255, 255);
            concordo.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.BackColor = default(Color);
            baiduB.BackColor = default(Color);
            hao123B.BackColor = default(Color);
            toolbarB.BackColor = default(Color);
            adwareB.BackColor = default(Color);
            antivirusB.BackColor = default(Color);
            baiduT.BackColor = Color.White;
            hao123T.BackColor = Color.White;
            toolbarT.BackColor = Color.White;
            adwareT.BackColor = Color.White;
            antivirusT.BackColor = Color.White;
            infoT.BackColor = default(Color);
            infoT.ForeColor = default(Color);
            moneyT.BackColor = Color.White;
            moneyT.ForeColor = default(Color);
            tabPage1.BackColor = default(Color);
            tabPage2.BackColor = default(Color);
            hao123C.BackColor = default(Color);
            toolbarC.BackColor = default(Color);
            adwareC.BackColor = default(Color);
            antivirusC.BackColor = default(Color);
            hao123CT.BackColor = Color.White;
            toolbarCT.BackColor = Color.White;
            adwareCT.BackColor = Color.White;
            antivirusCT.BackColor = Color.White;
            baiduClkr.BackColor = default(Color);
            hao123Clkr.BackColor = default(Color);
            toolbarClkr.BackColor = default(Color);
            adwareClkr.BackColor = default(Color);
            antivirusClkr.BackColor = default(Color);
            baiduPsT.BackColor = Color.White;
            hao123PsT.BackColor = Color.White;
            toolbarPsT.BackColor = Color.White;
            adwarePsT.BackColor = Color.White;
            antivirusPsT.BackColor = Color.White;
            cliqueB.BackColor = default(Color);
            chanceCritB.BackColor = default(Color);
            critQuantB.BackColor = default(Color);
            secretoC.BackColor = default(Color);
            secretoT.BackColor = Color.White;
            concordo.ForeColor = default(Color);
            cliqueT.BackColor = default(Color);
            chanceCritT.BackColor = default(Color);
            critQuantT.BackColor = default(Color);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(221, 0, 66);
            baiduB.BackColor = Color.FromArgb(221, 0, 66);
            hao123B.BackColor = Color.FromArgb(221, 0, 66);
            toolbarB.BackColor = Color.FromArgb(221, 0, 66);
            adwareB.BackColor = Color.FromArgb(221, 0, 66);
            antivirusB.BackColor = Color.FromArgb(221, 0, 66);
            baiduT.BackColor = Color.FromArgb(255, 140, 252);
            hao123T.BackColor = Color.FromArgb(255, 140, 252);
            toolbarT.BackColor = Color.FromArgb(255, 140, 252);
            adwareT.BackColor = Color.FromArgb(255, 140, 252);
            antivirusT.BackColor = Color.FromArgb(255, 140, 252);
            infoT.BackColor = Color.FromArgb(221, 0, 66);
            infoT.ForeColor = Color.FromArgb(0, 0, 0);
            moneyT.BackColor = Color.FromArgb(255, 34, 167);
            moneyT.ForeColor = Color.FromArgb(255, 255, 255);
            tabPage1.BackColor = Color.FromArgb(255, 26, 135);
            tabPage2.BackColor = Color.FromArgb(255, 26, 135);
            hao123C.BackColor = Color.FromArgb(221, 0, 66);
            toolbarC.BackColor = Color.FromArgb(221, 0, 66);
            adwareC.BackColor = Color.FromArgb(221, 0, 66);
            antivirusC.BackColor = Color.FromArgb(221, 0, 66);
            hao123CT.BackColor = Color.FromArgb(255, 140, 252);
            toolbarCT.BackColor = Color.FromArgb(255, 140, 252);
            adwareCT.BackColor = Color.FromArgb(255, 140, 252);
            antivirusCT.BackColor = Color.FromArgb(255, 140, 252);
            baiduClkr.BackColor = Color.FromArgb(221, 0, 66);
            hao123Clkr.BackColor = Color.FromArgb(221, 0, 66);
            toolbarClkr.BackColor = Color.FromArgb(221, 0, 66);
            adwareClkr.BackColor = Color.FromArgb(221, 0, 66);
            antivirusClkr.BackColor = Color.FromArgb(221, 0, 66);
            baiduPsT.BackColor = Color.FromArgb(255, 140, 252);
            hao123PsT.BackColor = Color.FromArgb(255, 140, 252);
            toolbarPsT.BackColor = Color.FromArgb(255, 140, 252);
            adwarePsT.BackColor = Color.FromArgb(255, 140, 252);
            antivirusPsT.BackColor = Color.FromArgb(255, 140, 252);
            cliqueB.BackColor = Color.FromArgb(244, 0, 177);
            chanceCritB.BackColor = Color.FromArgb(244, 0, 177);
            critQuantB.BackColor = Color.FromArgb(244, 0, 177);
            secretoC.BackColor = Color.FromArgb(221, 0, 66);
            secretoT.BackColor = Color.FromArgb(255, 140, 252);
            concordo.ForeColor = Color.FromArgb(255, 255, 255);
            cliqueT.BackColor = Color.FromArgb(255, 140, 252);
            chanceCritT.BackColor = Color.FromArgb(255, 140, 252);
            critQuantT.BackColor = Color.FromArgb(255, 140, 252);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.TextWriter Salvar = new System.IO.StreamWriter("save.sv", false);
            Salvar.WriteLine(money);
            Salvar.WriteLine(baidu);
            Salvar.WriteLine(hao123);
            Salvar.WriteLine(toolbar);
            Salvar.WriteLine(adware);
            Salvar.WriteLine(antivirus);
            Salvar.WriteLine(baiduPss);
            Salvar.WriteLine(hao123Pss);
            Salvar.WriteLine(toolbarPss);
            Salvar.WriteLine(adwarePss);
            Salvar.WriteLine(antivirusPss);
            Salvar.WriteLine(baiduClkrP);
            Salvar.WriteLine(hao123ClkrP);
            Salvar.WriteLine(toolbarClkrP);
            Salvar.WriteLine(adwareClkrP);
            Salvar.WriteLine(antivirusClkrP);
            Salvar.WriteLine(cliqueP);
            Salvar.WriteLine(chanceCritP);
            Salvar.WriteLine(critQuantP);
            Salvar.WriteLine(clique);
            Salvar.WriteLine(chanceCrit);
            Salvar.WriteLine(critQuant);
            Salvar.WriteLine(hao123Comp);
            Salvar.WriteLine(toolbarComp);
            Salvar.WriteLine(adwareComp);
            Salvar.WriteLine(antivirusComp);
            Salvar.WriteLine(secreto);
            Salvar.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.IO.TextReader Carregar = new System.IO.StreamReader("save.sv");
            money = Convert.ToDouble(Carregar.ReadLine());
            baidu = Convert.ToInt32(Carregar.ReadLine());
            hao123 = Convert.ToInt32(Carregar.ReadLine());
            toolbar = Convert.ToInt32(Carregar.ReadLine());
            adware = Convert.ToInt32(Carregar.ReadLine());
            antivirus = Convert.ToInt32(Carregar.ReadLine());
            baiduPss = Convert.ToInt32(Carregar.ReadLine());
            hao123Pss = Convert.ToInt32(Carregar.ReadLine());
            toolbarPss = Convert.ToInt32(Carregar.ReadLine());
            adwarePss = Convert.ToInt32(Carregar.ReadLine());
            antivirusPss = Convert.ToInt32(Carregar.ReadLine());
            baiduClkrP = Convert.ToDouble(Carregar.ReadLine());
            hao123ClkrP = Convert.ToDouble(Carregar.ReadLine());
            toolbarClkrP = Convert.ToDouble(Carregar.ReadLine());
            adwareClkrP = Convert.ToDouble(Carregar.ReadLine());
            antivirusClkrP = Convert.ToDouble(Carregar.ReadLine());
            cliqueP = Convert.ToDouble(Carregar.ReadLine());
            chanceCritP = Convert.ToDouble(Carregar.ReadLine());
            critQuantP = Convert.ToDouble(Carregar.ReadLine());
            clique = Convert.ToInt32(Carregar.ReadLine());
            chanceCrit = Convert.ToInt32(Carregar.ReadLine());
            critQuant = Convert.ToDouble(Carregar.ReadLine());
            hao123Comp = Convert.ToBoolean(Carregar.ReadLine());
            toolbarComp = Convert.ToBoolean(Carregar.ReadLine());
            adwareComp = Convert.ToBoolean(Carregar.ReadLine());
            antivirusComp = Convert.ToBoolean(Carregar.ReadLine());
            secreto = Convert.ToBoolean(Carregar.ReadLine());
            Carregar.Close();
            reloadAll();
        }
        private void reloadAll()
        {
            baiduPsT.Text = ("Gera 1 Baidu/s. Total:" + System.Environment.NewLine + baiduPss);
            baiduClkr.Text = ("Injetar Baidu em instaladores [$" + baiduClkrP.ToString("0.00") + "]");
            hao123PsT.Text = ("Gera 1 Hao123/s. Total:" + System.Environment.NewLine + hao123Pss);
            hao123Clkr.Text = ("Definir Hao123 como Homepage [$" + hao123ClkrP.ToString("0.00") + "]");
            toolbarPsT.Text = ("Gera 1 Toolbar/s. Total:" + System.Environment.NewLine + toolbarPss);
            toolbarClkr.Text = ("Toolbars com borboletas e gatos [$" + toolbarClkrP.ToString("0.00") + "]");
            adwarePsT.Text = ("Gera 1 Adware/s. Total:" + System.Environment.NewLine + adwarePss);
            adwareClkr.Text = ("Propagandas mais eficazes [$" + adwareClkrP.ToString("0.00") + "]");
            antivirusPsT.Text = ("Gera 1 Anti-Vírus/s. Total:" + System.Environment.NewLine + antivirusPss);
            antivirusClkr.Text = ("Anti-Vírus com ainda mais vírus [$" + antivirusClkrP.ToString("0.00") + "]");
            cliqueT.Text = ("Nº por clique:" + System.Environment.NewLine + clique);
            chanceCritT.Text = ("Chance crít:" + System.Environment.NewLine + chanceCrit + "%");
            critQuantT.Text = ("Bônus crít:" + System.Environment.NewLine + "+" + ((critQuant - 1) * 100).ToString("00") + "%");
            cliquePT.Text = ("$" + cliqueP.ToString("0.00"));
            chanceCritPT.Text = ("$" + chanceCritP.ToString("0.00"));
            critQuantPT.Text = ("$" + critQuantP.ToString("0.00"));
            if (hao123Comp)
            {
                hao123B.Visible = true;
                hao123T.Visible = true;
                hao123Clkr.Visible = true;
                hao123PsT.Visible = true;
                toolbarC.Visible = true;
                toolbarCT.Visible = true;
                hao123C.Visible = false;
                hao123CT.Visible = false;
            }
            if (toolbarComp)
            {
                toolbarB.Visible = true;
                toolbarT.Visible = true;
                toolbarClkr.Visible = true;
                toolbarPsT.Visible = true;
                adwareC.Visible = true;
                adwareCT.Visible = true;
                toolbarC.Visible = false;
                toolbarCT.Visible = false;
            }
            if (adwareComp)
            {
                adwareB.Visible = true;
                adwareT.Visible = true;
                adwareClkr.Visible = true;
                adwarePsT.Visible = true;
                antivirusC.Visible = true;
                antivirusCT.Visible = true;
                adwareC.Visible = false;
                adwareCT.Visible = false;
            }
            if (antivirusComp)
            {
                antivirusB.Visible = true;
                antivirusT.Visible = true;
                antivirusClkr.Visible = true;
                antivirusPsT.Visible = true;
                antivirusC.Visible = false;
                antivirusCT.Visible = false;
            }
            if (secreto)
            {
                secretoT.Visible = false;
                secretoC.Visible = false;
            }
        }
    }
}
