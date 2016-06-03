using System;
using System.Windows.Forms;

namespace VerificationTaskCSharp
{
    /// <summary>
    /// Класс главного окна
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Конструктор главного окна
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события: создание главного окна
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            actor = new Actor();
        }

        /// <summary>
        /// Обработчик события: нажатие кнопки "input file"
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                actor.setPathToInputFile(openFileDialog1.FileName);
                label1.Text = openFileDialog1.FileName;
            }
            
        }

        /// <summary>
        /// Обработчик события: нажатие кнопки "dictionary"
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                actor.setPathToDictionary(openFileDialog1.FileName);
                label2.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Обработчик события: нажатие кнопки "output file"
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                actor.setPathToOutputFile(saveFileDialog1.FileName);
                label3.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Обработчик события: нажатие кнопки "START"
        /// </summary>
        private void btn_start_Click(object sender, EventArgs e)
        {
            string value = maskedTextBox1.Text;
            actor.setMaxCountOfStrings(Int32.Parse(value));
            try
            {
                actor.start();
            }
            catch (WrongPathToFileExeption exception)
            {
                MessageBox.Show(exception.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (WrongSizeOfFileExeption exception)
            {
                MessageBox.Show(exception.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
