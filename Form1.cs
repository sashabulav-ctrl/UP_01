using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using org.mariuszgromada.math.mxparser;

namespace WinFormsApp_UP_01
{
    public partial class Form1 : Form
    {

        private double _xMin = -10;
        private double _xMax = 10;
        private double _step = 0.1;
        private Series _functionSeries;

        public event Action<string> FormulaChanged;

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            comboBox1.Enter += ComboBox1_Enter;
            comboBox1.Leave += ComboBox1_Leave;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string functionText = comboBox1.Text;

                if (string.IsNullOrWhiteSpace(functionText)) return;

                try
                {
                    chartControl1.Series[0].Points.Clear();
                    chartControl1.Series[0].Name = functionText;

                    for (double x = _xMin; x <= _xMax; x += _step)
                    {
                        double y = _EvaluateFunction(functionText, x);

                        chartControl1.Series[0].Points.Add(new SeriesPoint(x, y));
                    }

                    FormulaChanged?.Invoke(functionText);

                    e.SuppressKeyPress = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }


        private double _EvaluateFunction(string function, double x)
        {
            string formula = function.Split('=')[0];

            Argument xArg = new Argument("x", x);

            Expression e = new Expression(formula, xArg);

            double result = e.calculate();

            if (double.IsNaN(result))
            {
                throw new Exception("Ошибка в синтаксисе функции");
            }

            return result;
        }

        private void ComboBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Введите функцию (например: 3*x-5=0)")
            {
                comboBox1.Text = "";
                comboBox1.ForeColor = SystemColors.WindowText;
            }
        }

        private void ComboBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                comboBox1.Text = "Введите функцию (например: 3*x-5=0)";
                comboBox1.ForeColor = SystemColors.GrayText;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.CurrentFormula = comboBox1.Text;
            this.FormulaChanged += form4.UpdateFormula;
            form4.Show();
            form4.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.CurrentFormula = comboBox1.Text;
            this.FormulaChanged += form5.UpdateFormula;
            form5.Show();
            form5.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.CurrentFormula = comboBox1.Text;
            this.FormulaChanged += form3.UpdateFormula;
            form3.Show();
            form3.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.CurrentFormula = comboBox1.Text;
            this.FormulaChanged += form6.UpdateFormula;
            form6.Show();
            form6.BringToFront();
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}