using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesatyUkol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (pictureBox1.Image != null)
                {
                    MessageBox.Show("Chyba: V PictureBoxu 1 je již nahrán obrázek.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    VlozitObrázekDoPictureBoxu(pictureBox1);
                }
            }
            else if (radioButton2.Checked)
            {
                if (pictureBox2.Image != null)
                {
                    MessageBox.Show("Chyba: V PictureBoxu 2 je již nahrán obrázek.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    VlozitObrázekDoPictureBoxu(pictureBox2);
                }
            }
            else if (radioButton3.Checked)
            {
                if (pictureBox3.Image != null)
                {
                    MessageBox.Show("Chyba: V PictureBoxu 3 je již nahrán obrázek.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    VlozitObrázekDoPictureBoxu(pictureBox3);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Chyba: V PictureBoxu 1 není žádný obrázek.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            else if (radioButton5.Checked)
            {
                if (pictureBox2.Image == null)
                {
                    MessageBox.Show("Chyba: V PictureBoxu 2 není žádný obrázek.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    pictureBox2.Image = null;
                }
            }
            else if (radioButton4.Checked)
            {
                if (pictureBox3.Image == null)
                {
                    MessageBox.Show("Chyba: V PictureBoxu 3 není žádný obrázek.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    pictureBox3.Image = null;
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
                radioButton1.Checked = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
                radioButton2.Checked = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                radioButton3.Checked = true;
        }
        private void VlozitObrázekDoPictureBoxu(PictureBox pictureBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Obrázky|*.jpg;*.jpeg;*.png;";
            openFileDialog.Title = "Vyberte obrázek";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Načíst vybraný obrázek
                Image selectedImage = Image.FromFile(openFileDialog.FileName);

                // Zobrazit obrázek v předaném PictureBoxu
                pictureBox.Image = selectedImage;
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            ZobrazitZvetsenyObrazek(pictureBox1);
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            ZobrazitZvetsenyObrazek(pictureBox2);

        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            ZobrazitZvetsenyObrazek(pictureBox3);
        }

        private void ZobrazitZvetsenyObrazek(PictureBox pictureBox)
        {
            if (pictureBox.Image != null)
            {
                Form zvetsenyObrazekForm = new Form();
                zvetsenyObrazekForm.StartPosition = FormStartPosition.CenterScreen;
                zvetsenyObrazekForm.Size = new Size(pictureBox.Image.Width, pictureBox.Image.Height);
                zvetsenyObrazekForm.BackgroundImage = pictureBox.Image;
                zvetsenyObrazekForm.Text = "Zvětšený obrázek";
                zvetsenyObrazekForm.BackgroundImageLayout = ImageLayout.Zoom;
                zvetsenyObrazekForm.ShowDialog();
            }
            else
            {
                MessageBox.Show($"Chyba: V PictureBoxu {(pictureBox.Name == "pictureBox1" ? "1" : pictureBox.Name == "pictureBox2" ? "2" : "3")} není žádný obrázek.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
