using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yilanOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point basinKonumu; // yılanımızın baş noktasının konumu
        public int sizeMatrix; // yılanımızın matrixnin boyutu
        public int[,] matrix; // yılanımızın matrixi
        public int sonParca; // yılanımızın son kuyruğu
        Random rassal; // rastgele sayı
        public int yonDegeri = 2; // yonumuzun değerleri var 2 sağa 4 sola 1 yukarı 3 aşağı
        public int oyunDegeri = 0; // oyuna kaç kez başladığımızı tutuyor ki bunun nedeni B tuşunun içerisinde timer1_Tick += Timer1_Tick yapmamız, B tuşuna bastığımda oyunDegerim 1 oluyor ve her seferinde timer tickimiz çalışmıyor, değerlerimiz değişmiyor!!

        public int salise; // zaman değişkenlerimiz
        public double checkPoint;
        public double saniye;
        public double dakika;
        public double toplamZaman;
        public double degisken;

        public double Puan; // puan değişkenleri
        public double tutPuan;

        public string oyuncuIsmi; // oyuncu ismi
        public string dizin = Application.StartupPath; // uygulamanın çalıştığı dizin

        public int zorlukOgren = 0; // kolay seviye = 1 , zor seviye = 2;
        public bool dYiOgren = false; // D tuşuna basıp basmadığını kontrol ediyor.
        public bool bYeBastiMi = false;// VİDEODA BU DEĞİŞKENİM YOKTU SONRASINDA FARKETTİM Kİ OYUNUM D TUŞUNA BASINCA BAŞLIYORDU, BUNU ÖNLEMEK AMACIYLA OLUŞTURDUĞUM BİR DEĞİŞKEN // 172 , 331 ve 348.satırlara ekleme yaptım.

        public enum matrixNesne
        {
            yem = -1, // yemi tanımlayıp değerini -1 veriyoruz
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Yılan Oyunu"; // Oyunumuz çalıştığı zaman adı Yılan oyunu oluyor
            rassal = new Random();

            timer2.Interval = 10; // salisemizin timerı

            lblOzet.Text = "                 Oyuna Başlamak için \"B\" tuşunu\n\nDurdurmak ve devam etmek için \"D\" tuşunu kullanınız.\n\n                               İyi oyunlar"; //lblOzetin texti
            lblOzet.BackColor = Color.LightSkyBlue; // lblOzet in arkaplan rengi
            lblOzet.Visible = true; 

            rdKolay.Enabled = false; // kaydet demeden öncesinde seviye seçimi yapılmasın diye radio butonlarımız disable
            rdZor.Enabled = false;

            sizeMatrix = 69; // matriximizin boyutu 69 çünkü pictureBoxumuzun genişliği 690 
            matrix = new int[sizeMatrix, sizeMatrix]; // yılanımızın matrixini 69,69 tanımladık çünkü genişlik 69 olduğuı için tüm kareleri dolduracak kadar uzayabilir max olarak yani her bir satır için 69 kuyruğu olabilir.
        }

        private void Init() // Initalize , oyunu başlatınca olacaklar
        {
            for (int i = 0; i < sizeMatrix; i++) // bu for döngüsü haritamızı gezer ve temizler
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                    matrix[i, j] = 0;   
                }
            }

            yemOlustur();
            basinKonumu = new Point(30, 15); // yılanımızın konumu
            matrix[30, 15] = 1; 
            matrix[31, 15] = 2;
            matrix[32, 15] = 3; 
            sonParca = 3; // 3 parça olarak başlıyoruz 
            yonDegeri = 2; // varsayılan olarak sağa gidiyoruz
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            oyun(); // Intervalde belirttiğimiz zamanda yapılmasını istediğimiz 2 metodumuz var.
            Draw();
        }

        private void Draw()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // yeni bir bitmap oluşturuyoruz ve boyutu 690 a 350 yapıyoruz yani pictureBox ımızın maximum sınırları kadar
            Graphics g = Graphics.FromImage(bitmap); // grafiğimizi bitmap olarak belirliyoruz

            g.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);

            SizeF sizeCell = new SizeF((float)pictureBox1.Width / 69, (float)pictureBox1.Height / 35); // Dikdörtgen çizeceğimden dolayı genişliği ve yüksekliği burada depoladım. SizeF kayan noktalı sayı çifti depoladığı için (genel olarak) float olarak tuttum.

            for(int i = 0; i < 69; i++) // ilk döngüm genişliğe
            {
                for (int j = 0; j < 35; j++) // ikinci döngüm yüksekliğe 
                {
                    if (matrix[i, j] == 0)
                    {
                        g.FillRectangle(Brushes.White, i * sizeCell.Width , j * sizeCell.Height  , sizeCell.Width  , sizeCell.Height  ); // arkaplan rengimiz (oyun alanı)
                    }
                    else if(matrix[i,j] == (int)matrixNesne.yem) // eğer oluşturduğumuz yemin oluşturduğumuz noktasına geldiysek kırmıza boyuyoruz
                    {
                        g.FillRectangle(Brushes.Red, (i * sizeCell.Width) , (j * sizeCell.Height), sizeCell.Width  , sizeCell.Height ); 
                    }
                    else // yılanımız rengini yeşil olarak boyadık ve her saniye hareket ettikçe her hareketinde noktaları boyuyoruz
                    {
                        g.FillRectangle(Brushes.Green, (i * sizeCell.Width), (j * sizeCell.Height), sizeCell.Width  , sizeCell.Height);
                    }
                }
            }
            pictureBox1.BackgroundImage = bitmap; // picturebox ımızın arkaplan resmini bitmap yapmalıyız ki ekrana aktaralım
        }

        public void Yes() // kaybettiğimizde yeni oyun için evet dersek ; 
        {
            salise = 0;
            saniye = 0;
            dakika = 0;
            toplamZaman = 0;
            Puan = 0;
            tutPuan = 0;
            checkPoint = 0;

            lblPuan.Text = Puan.ToString();
            lblSalise.Text = salise.ToString();
            lblZaman.Text = "00:00";

            Init();
            timer1.Start();
            timer2.Start();
        }

        public void No() // kaybettiğimizde yeni oyun için hayır dersek ; 
        {
            salise = 0;
            saniye = 0;
            dakika = 0;
            toplamZaman = 0;
            Puan = 0;
            tutPuan = 0;
            checkPoint = 0;

            lblPuan.Text = Puan.ToString();
            lblSalise.Text = salise.ToString();
            lblZaman.Text = "00:00";
            txtOyuncu.Text = "";

            rdKolay.Checked = false;
            rdZor.Checked = false;
            txtOyuncu.Enabled = true;
            btnKaydet.Enabled = true;
            btnYardım.Enabled = true;
            btnSkorlariGorntule.Enabled = true;

            btnKaydet.Visible = true;
            btnSkorlariGorntule.Visible = true;
            btnYardım.Visible = true;
            rdKolay.Visible = true;
            rdZor.Visible = true;
            txtOyuncu.Visible = true;
            lblOzet.Visible = true;
            bYeBastiMi = false;  // OYUNU KAYBETME DURUMUNDA FALSE YAPMALIYIZ Kİ KAYBETTİKTEN SONRA B TUŞUNA BASARAK BAŞLAMAK MÜMKÜN OLMASIN
        }

        private void oyun() // oyunun en önemli metodu ;
        {
            Point yolumuz; // bi yolumuz olmalı onu da Point cinsinde tutmalıyız ki nerede olduğumuzu nereye gittiğimizi bilip ona göre işlem yapalım
            switch (yonDegeri)
            {
                case 4:
                    yolumuz = new Point(basinKonumu.X + 1, basinKonumu.Y); // bastığımız yön değerlerine göre bas noktamızı yeniden konumlandırıyoruz ve hareket ettiriyoruz her saniye olduğu için devamlı hareketimiz var. 
                    break;
                case 2:
                    yolumuz = new Point(basinKonumu.X - 1, basinKonumu.Y);
                    break;
                case 1:
                    yolumuz = new Point(basinKonumu.X, basinKonumu.Y - 1);
                    break;
                case 3:
                    yolumuz = new Point(basinKonumu.X, basinKonumu.Y + 1);
                    break;
                default:
                    yolumuz = new Point(basinKonumu.X - 1, basinKonumu.Y);
                    break;
            }
            if (yolumuz.X < 0 || yolumuz.Y < 0 || yolumuz.X == 69 || yolumuz.Y == 35 || matrix[yolumuz.X, yolumuz.Y] > 0) // duvara ve kendine çarpma koşulları
            {
                timer1.Stop(); timer2.Stop(); // oyunumuz durur
                oyunDegeri = 1; // kaybettiğimizde oyun değeri 1 olur.

                FileStream fs = new FileStream(dizin + "\\Skor Tablosu.txt", FileMode.Append, FileAccess.Write); // not defterine süremiz ve puanımız yazdırılır
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(lblZaman.Text + " Skor :" + Puan + "\n");
                sw.Flush();
                sw.Close();
                fs.Close();

                DialogResult = MessageBox.Show("Kaybettiniz, tekrar oynamak ister misiniz ?", "Yeni Oyun", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if(DialogResult == DialogResult.Yes)
                {
                    Yes(); // evet dediğimizde ismimizi tekrar not defterine yazdırırız.

                    FileStream fse = new FileStream(dizin + "\\Skor Tablosu.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter swe = new StreamWriter(fse);
                    swe.Write(oyuncuIsmi + "  ");
                    swe.Flush();
                    swe.Close();
                    fse.Close();
                }
                else
                {
                    No();
                }

                return;
            }
            if (matrix[yolumuz.X, yolumuz.Y] == (int)matrixNesne.yem) // Eğer yem yediysek ;
            {
                /*kontrol satır 1 */  //timer1.Stop(); timer2.Stop(); 


                tutPuan = 0;
                /*kontrol satır 2*/ //MessageBox.Show("checkPoint : "+ checkPoint);
                
                if (toplamZaman - checkPoint > 100) // 100 saniyeden uzun bir süre içerisinde yem yediysek puan alamayacağız
                {
                    tutPuan = 0;
                    checkPoint = ((double)(toplamZaman + (double)salise / 100));
                }
                else if (toplamZaman - checkPoint <= 100) // eğer 100 ve daha aşağısı bir saniyede yediysek puanımızı alıyoruz. Saliseleri de işleme kattığımız için işlemlerimizi double olarak yapıyoruz. Eğer saliseleri işleme katmayacaksak bir if daha ekleyik toplamZaman - checkPoint < 0 ise puanımızı 100 vermeliyiz çünkü saliseler olmadan bu işlemi yaptımızda Inf puan alırız (0 a bölme hatası)
                {
                    tutPuan = 100 / (double)(toplamZaman + (double)salise / 100 - (double)checkPoint);
                    checkPoint = ((double)(toplamZaman + (double)salise / 100));
                    Puan += tutPuan;
                    Puan = Math.Round(Puan, 1);
                }

                if ((yolumuz.X == 0 && yolumuz.Y == 0) || (yolumuz.X == 690 && yolumuz.Y == 350) || (yolumuz.X == 690 && yolumuz.Y == 0) || (yolumuz.X == 0 && yolumuz.Y == 350)) // eğer köşe noktalarda yem yerse +10 puan alırız
                {
                    tutPuan += 10;
                }
                

                lblPuan.Text = Puan.ToString(); // ekrana puanımızı yazdırırız.

                /*kontrol satır 3 */  // MessageBox.Show("bu tur alınan Puan : " + tutPuan + "\ntoplam zaman : " + (toplamZaman) + ","+salise);
                /*kontrol satır 4 */   //timer1.Start(); timer2.Start();

                // bu 4 satırı yorum satırından çıakrtıp çalıştırarak doğru olup olmadığını kontrol edebilirsiniz.

                sonParca++; // kuyruğumuz 1 arttırırz ve yeni yem oluştururuz.
                yemOlustur();
            } 
            matrix[yolumuz.X, yolumuz.Y] = 1; 
            matrix[basinKonumu.X, basinKonumu.Y]++; // basın konumu 1 arttırırız ki yem yediğimizde en öndeki baş noktası olsun 

            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                    if(basinKonumu.X == i && basinKonumu.Y == j) // bunu yapmadığımız zaman haritaya bir parça bırakıyoruz :D
                    {
                        continue;
                    }
                    if (matrix[i, j] == sonParca) // her hareketimizde arkadaki kuyrukları temizlemek için
                    {
                        matrix[i, j] = 0;
                    }
                    else if (matrix[i, j] > 1) // her şey normal ise devam ediyoruz yolumuza
                    {
                        matrix[i, j]++;
                    } 
                }
            }
            basinKonumu = yolumuz; 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (yonDegeri != 3) // yönlerimizi ayarlıyoruz tekrar hatırlatalım : 2 sağa, 4 sola, 1 yukarı , 3 aşağı
                    {
                        yonDegeri = 1;
                    }
                    break;
                case Keys.Right:
                    if (yonDegeri != 2)
                    {
                        yonDegeri = 4;
                    }
                    break;
                case Keys.Down:
                    if (yonDegeri != 1)
                    {
                        yonDegeri = 3;
                    }
                    break;
                case Keys.Left:
                    if (yonDegeri != 4)
                    {
                        yonDegeri = 2;
                    }
                    break;
            }

            if (e.KeyCode == Keys.B && zorlukOgren != 0 && salise == 0 && (rdKolay.Checked == true || rdZor.Checked == true)) // B tuşuna basıp oyuna başladığımızda butonlarımız görünmez olur ve timerlarımız yani oyunumuz başlar
            {                                                           //, radio buton kısımlarını da sonradan ekledim kaybettikten sonra B tuşuna basınca başlamaması için.
                lblOzet.Visible = false;
                Init();
                timer1.Start();

                btnKaydet.Visible = false;
                btnSkorlariGorntule.Visible = false;
                btnYardım.Visible = false;
                rdKolay.Visible = false;
                rdZor.Visible = false;
                txtOyuncu.Visible = false;
                bYeBastiMi = true; // BURADA TRUE YAPIYORUM VE 348. SATIRDA EĞER TRUE İSE D TUŞUNU KABUL EDİYORUM AKSİ TAKDİRDE OYUN BAŞLAMAMIŞ DEMEKTİR

                if(oyunDegeri == 0) // oyuna ilk başladığımız zaman buraya girecek 1 kez oluşturacak aslında yılanı hızlarını 1 kez ayarlayacakk bunu sürekli olarak yaptığımızda yılanımız sürekli olarak hızlanıyor.
                {
                    timer1.Tick += Timer1_Tick;
                }
                timer2.Start();

                if (zorlukOgren == 1)
                {
                    timer1.Interval = 80;
                }
                else if (zorlukOgren == 2)
                {
                    timer1.Interval = 30;
                }
            }
            else if(e.KeyCode == Keys.D && bYeBastiMi == true) // d tuşu için bool bir değer tutuyorum çünkü d tuşumuz aslında 2 farklı işlem yapıyor ve bu işlemler birbirinin tam tersi. (1,0) ve ( % ) ile de yapılabilir. B tuşuna basılıp basılmadığını da kontrol ediyoruz.
            {
                if(dYiOgren == false)
                {
                    dYiOgren = true;
                    lblOzet.Visible = true;
                    timer1.Stop();
                    timer2.Stop();
                }
                else if(dYiOgren == true)
                {
                    dYiOgren = false;
                    lblOzet.Visible = false;
                    timer1.Start();
                    timer2.Start();
                }
            }
        }

        private void yemOlustur() 
        {
            Point yeminKonumu; // yeme bir nokta atıyoruz.

            do
            {
                yeminKonumu = new Point(rassal.Next() % 69, rassal.Next() % 35);
                //yeminKonumu = new Point(0, 0); // kontrol ama yiyince donuyor iki kontrolü aynı anda yapınca görebilirsiniz.
            } while (matrix[yeminKonumu.X, yeminKonumu.Y] != 0); // bunun anlamı yemin konumu boş değilse yani yem varsa ki yukarıda oluşturduk do while a sokmamızın nedeni bu
            {
                matrix[yeminKonumu.X, yeminKonumu.Y] = (int)matrixNesne.yem;
            }          
        }

        private void timer2_Tick(object sender, EventArgs e) // sizin örnek fotoğraflarda gösterdiğiniz gibi yapabilmek için bir saat tasarladım ve ekstra olarak salise ekledim ve ekranda gösterdim
        {
            salise++;
            lblSalise.Text = salise.ToString();

            if(saniye < 10 && dakika < 10)
            {
                lblZaman.Text = "0" + dakika + ":0" + saniye;
            }
            else if(saniye < 10)
            {
                lblZaman.Text = dakika + ":0" + saniye;
            }
            else if(dakika < 10)
            {
                lblZaman.Text = "0" + dakika + ":" + saniye;
            }
            else
            {
                lblZaman.Text = "" + dakika + ":" + saniye;
            }

            if(salise == 60)
            {
                toplamZaman++; // toplam zaman sürekli artacak çünkü saniye 60 olunca sıfırlanıyor. saniyeye göre işlem yaparsak hata yapmış oluruz.
                salise = 0;
                saniye++;
            }
            if(saniye == 60)
            {
                saniye = 0;
                dakika++;
            }
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(txtOyuncu.Text == "") // oyuncu ismi boş olmamalı ki kaydedebilelim
            {
                MessageBox.Show("Oyuncu ismi boş olamaz!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {               
                oyuncuIsmi = txtOyuncu.Text;

                FileStream fs = new FileStream(dizin + "\\Skor Tablosu.txt", FileMode.Append, FileAccess.Write); // not defterine yazdırıyoruz
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(oyuncuIsmi + "  ");
                sw.Flush();
                sw.Close();
                fs.Close();

                MessageBox.Show(oyuncuIsmi + " kaydedildi.", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnKaydet.Enabled = false;
                txtOyuncu.Enabled = false;
                rdKolay.Enabled = true;
                rdZor.Enabled = true;
            }
        }

        private void rdKolay_CheckedChanged(object sender, EventArgs e)
        {
            zorlukOgren = 1; // zorluğu seçmiş oluyoruz
            rdKolay.Enabled = false;
            rdZor.Enabled = false;
            btnYardım.Enabled = false;
            btnSkorlariGorntule.Enabled = false;
        }

        private void rdZor_CheckedChanged(object sender, EventArgs e)
        {
            zorlukOgren = 2;
            rdKolay.Enabled = false;
            rdZor.Enabled = false;
            btnYardım.Enabled = false;
            btnSkorlariGorntule.Enabled = false;
        }

        private void btnYardım_Click(object sender, EventArgs e) // yardım butonu
        {
            MessageBox.Show("Lütfen ilk önce isim girip sonra kaydet butonuna basınız.\nDaha sonra seviye seçimi yaptıktan sonra [B] tuşuna basarak oyuna başlayabilir ve sonrasında [D] tuşu ile durdurup [D] tuşu ile kaldığınız yerden devam edebilirsiniz.\nOyun bittikten sonrasında aynı isim ve seviye ile tekrar başlamak isterseniz çıkan seçeneğe evet, en baştan isim ve seviye ile başlamak isterseniz hayır butonuna basınız.\n\n\t\t İyi Oyunlar, Kürşat Arslan","Yardım Penceresi", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnSkorlariGorntule_Click(object sender, EventArgs e) // skorları görüntüle butonu
        {
            System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo(dizin + "\\Skor Tablosu.txt");
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = ps;
            proc.Start();
            proc.WaitForExit();
        }
    }
}
