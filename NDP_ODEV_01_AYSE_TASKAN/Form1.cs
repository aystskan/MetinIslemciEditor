/****************************************************************************
**					SAKARYA ÜNÝVERSÝTESÝ
**				BÝLGÝSAYAR VE BÝLÝÞÝM BÝLÝMLERÝ FAKÜLTESÝ
**				    BÝLGÝSAYAR MÜHENDÝSLÝÐÝ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSÝ
**					2023-2024 BAHAR DÖNEMÝ
**	
**				ÖDEV NUMARASI        : 1        
**				ÖÐRENCÝ ADI          : AYÞE TAÞKAN
**				ÖÐRENCÝ NUMARASI     : G231210043
**              DERSÝN ALINDIÐI GRUP : B
****************************************************************************/

using System.Windows.Forms;

namespace NDP_ODEV_01_AYSE_TASKAN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                rtDisplay.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dosyaAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Text Files(*.txt)|*.txt|All files(*.*)|*.*";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    rtDisplay.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            yeniToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dosyaAçToolStripMenuItem_Click(sender, e);
        }

        private void dosyaKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtDisplay.Text != "")
                {
                    DialogResult kayit;
                    kayit = MessageBox.Show("Ýçerik harici düzenlemeler (renk/font) dahil edilsin mi ?", "! Kayýt Biçimi !", MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question);
                    if (kayit == DialogResult.Yes)
                    {
                        saveFileDialog1.Filter = "Rich Text Format (*.rtf) | *.rtf";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            rtDisplay.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);

                        this.Text = saveFileDialog1.FileName;


                    }
                    else if (kayit == DialogResult.No)
                    {
                        saveFileDialog1.Filter = "txt Files (*.txt)|*.txt|All files(*.*)|*.*";

                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            System.IO.File.WriteAllText(saveFileDialog1.FileName, rtDisplay.Text);
                        }
                    }
                }
                else
                {
                    saveFileDialog1.Filter = "txt Files (*.txt)|*.txt|All files(*.*)|*.*";

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveFileDialog1.FileName, rtDisplay.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            dosyaKaydetToolStripMenuItem_Click(sender, e);
        }

        private void yazdýrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            yazdýrToolStripMenuItem_Click(sender, e);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawString(rtDisplay.Text, new Font("Arial", 18, FontStyle.Regular)
                    , Brushes.Black, 120, 120);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void çýkýþToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtDisplay.Text == "")
            {
                try
                {
                    DialogResult cikis;
                    cikis = MessageBox.Show("Çýkýþ yapmak istediðinize emin misiniz", "! Çýkýþ Uyarý Mesajý !", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (cikis == DialogResult.Yes)
                    {
                        Application.Exit();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            else
            {
                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Kaydetmeden çýkmak istediðinize emin misiniz?", "! Kayýt Uyarý Mesajý !", MessageBoxButtons.YesNoCancel);
                if (cikis == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (cikis == DialogResult.No)
                {
                    dosyaKaydetToolStripMenuItem_Click(sender, e);
                }
            }
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            çýkýþToolStripMenuItem_Click(sender, e);
        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                rtDisplay.Undo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void yineleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                rtDisplay.Redo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            geriAlToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            yineleToolStripMenuItem_Click(sender, e);
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                rtDisplay.Copy();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                rtDisplay.Cut();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void yapýþtýrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                rtDisplay.Paste();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void yazýRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    rtDisplay.ForeColor = colorDialog1.Color;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void zeminRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    rtDisplay.BackColor = colorDialog1.Color;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    rtDisplay.Font = fontDialog1.Font;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kesToolStripMenuItem_Click(sender, e);
        }

        private void kopyalaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kopyalaToolStripMenuItem_Click(sender, e);
        }

        private void yapýþtýrToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            yapýþtýrToolStripMenuItem_Click(sender, e);
        }

        private void yazýRengiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            yazýRengiToolStripMenuItem_Click(sender, e);
        }

        private void zeminRengiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            zeminRengiToolStripMenuItem_Click(sender, e);
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fontToolStripMenuItem_Click(sender, e);
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtDisplay.Text != "")
            {
                try
                {
                    DialogResult c;
                    c = MessageBox.Show("Yenilenmiþ temiz sayfada mý devam etmek istersiniz ? ", "! Þablon Dosya Uyarý Mesajý !", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (c == DialogResult.Yes)
                    {
                        rtDisplay.Clear();
                        rtDisplay.AppendText("#include <stdio.h>\r\n\r\nint main() \r\n{\r\n    printf(\"Hello World!\\n\");\r\n    return 0;\r\n}\r\n");
                    }
                    else
                    {
                        rtDisplay.AppendText("#include <stdio.h>\r\n\r\nint main() \r\n{\r\n    printf(\"Hello World!\\n\");\r\n    return 0;\r\n}\r\n");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            else
            {
                rtDisplay.AppendText("#include <stdio.h>\r\n\r\nint main() \r\n{\r\n    printf(\"Hello World!\\n\");\r\n    return 0;\r\n}\r\n");
            }
            
        }

        private void cToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (rtDisplay.Text != "")
            {
                try
                {
                    DialogResult c;
                    c = MessageBox.Show("Yenilenmiþ temiz sayfada mý devam etmek istersiniz ? ", "! Þablon Dosya Uyarý Mesajý !", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (c == DialogResult.Yes)
                    {
                        rtDisplay.Clear();
                        rtDisplay.AppendText("#include <iostream>\r\n\r\nint main() \r\n{\r\n    std::cout << \"Hello World!\\n\" ;\r\n    return 0;\r\n}\r\n");
                    }
                    else
                    {
                        rtDisplay.AppendText("#include <iostream>\r\n\r\nint main() \r\n{\r\n    std::cout << \"Hello World!\\n\" ;\r\n    return 0;\r\n}\r\n");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            else
            {
                rtDisplay.AppendText("#include <iostream>\r\n\r\nint main() \r\n{\r\n    std::cout << \"Hello World!\\n\" ;\r\n    return 0;\r\n}\r\n");
            }
             
        }

        private void cToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (rtDisplay.Text != "")
            {
                try
                {
                    DialogResult c;
                    c = MessageBox.Show("Yenilenmiþ temiz sayfada mý devam etmek istersiniz ? ", "! Þablon Dosya Uyarý Mesajý !", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (c == DialogResult.Yes)
                    {
                        rtDisplay.Clear();
                        rtDisplay.AppendText("using System;\r\n\r\nclass Program\r\n{\r\n    static void Main()\r\n    {\r\n        Console.WriteLine(\"Hello, World!\");\r\n    }\r\n}\r\n");
                    }
                    else
                    {
                        rtDisplay.AppendText("using System;\r\n\r\nclass Program\r\n{\r\n    static void Main()\r\n    {\r\n        Console.WriteLine(\"Hello, World!\");\r\n    }\r\n}\r\n");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            else
            {
                rtDisplay.AppendText("using System;\r\n\r\nclass Program\r\n{\r\n    static void Main()\r\n    {\r\n        Console.WriteLine(\"Hello, World!\");\r\n    }\r\n}\r\n");
            }
            
        }

        
    }
}


/*Kodda görülen try-catch bloklarý,
belirli iþlemlerin hataya neden olabileceði durumlarý ele alýr.
Örneðin, bir dosya açma iþlemi sýrasýnda dosya bulunamazsa veya bir dosya kaydetme iþlemi sýrasýnda bir hata oluþursa,
bu hatalar try-catch bloklarý içinde yakalanýr ve kullanýcýya bir hata iletilir.*/
