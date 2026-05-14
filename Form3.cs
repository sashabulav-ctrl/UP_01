using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace WinFormsApp_UP_01
{
    public partial class Form3 : Form
    {
        public string CurrentFormula;

        public Form3()
        {
            InitializeComponent();
        }

        public void UpdateFormula(string newFormula)
        {
            CurrentFormula = newFormula;
            this.Text = $"Решение уравнения: {newFormula}";
        }

        private double f(string formula, double x)
        {
            if (string.IsNullOrEmpty(formula)) return 0;
            string cleanFormula = formula.Split('=')[0];
            org.mariuszgromada.math.mxparser.Expression e =
                new org.mariuszgromada.math.mxparser.Expression(cleanFormula,
                    new org.mariuszgromada.math.mxparser.Argument("x", x));
            return e.calculate();
        }

        private List<double> FindRoots(string formula, double a, double b, double eps, int segments = 1000)
        {
            List<double> roots = new List<double>();
            double step = (b - a) / segments;

            for (int i = 0; i < segments; i++)
            {
                double x1 = a + i * step;
                double x2 = x1 + step;
                double f1 = f(formula, x1);

                if (f1 * f(formula, x2) <= 0 && Math.Abs(f(formula, x1) - f(formula, x2)) > 1e-10)
                {
                    double root = Bisection(formula, x1, x2, eps);
                    if (!IsRootExists(roots, root, eps) && Math.Abs(f(formula, root)) < eps * 10)
                        roots.Add(root);
                }
                else if (Math.Abs(f1) < eps && !IsRootExists(roots, x1, eps))
                    roots.Add(x1);
            }
            return roots;
        }

        private double Bisection(string formula, double a, double b, double eps)
        {
            double fa = f(formula, a), fb = f(formula, b);
            if (Math.Abs(fa) < eps) return a;
            if (Math.Abs(fb) < eps) return b;

            double x = (a + b) / 2;
            while ((b - a) > eps)
            {
                x = (a + b) / 2;
                double fx = f(formula, x);
                if (Math.Abs(fx) < eps) return x;
                if (fa * fx <= 0) { b = x; fb = fx; }
                else { a = x; fa = fx; }
            }
            return (a + b) / 2;
        }

        private bool IsRootExists(List<double> roots, double root, double eps)
        {
            foreach (double r in roots)
                if (Math.Abs(r - root) < eps * 10) return true;
            return false;
        }

        private void UpdateResultsDisplay(List<double> roots)
        {
            if (roots.Count == 0)
            {
                textBox2.Text = "Корни не найдены";
                return;
            }
            roots.Sort();
            string result = "";
            foreach (double root in roots)
                result += $"x = {root:F6}  (f(x) = {f(CurrentFormula, root):E2})\r\n";
            textBox2.Text = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(CurrentFormula))
                {
                    MessageBox.Show("Формула не задана!");
                    return;
                }

                double a = double.Parse(textBox3.Text.Replace(",", "."),
                                        System.Globalization.CultureInfo.InvariantCulture);
                double b = double.Parse(textBox1.Text.Replace(",", "."),
                                        System.Globalization.CultureInfo.InvariantCulture);
                double eps = 0.0001;

                if (a >= b)
                {
                    MessageBox.Show("Левая граница должна быть меньше правой!");
                    return;
                }

                List<double> roots = FindRoots(CurrentFormula, a, b, eps);
                UpdateResultsDisplay(roots);
                BuildChart(a, b, CurrentFormula, roots);
                MessageBox.Show($"Найдено корней: {roots.Count}\nНа интервале [{a}; {b}]");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void BuildChart(double minX, double maxX, string formula, List<double> roots = null)
        {
            chartControl1.Series.Clear();

            Series functionSeries = new Series("f(x)", ViewType.Line);
            double start = minX - 1;
            double end = maxX + 1;
            double step = (end - start) / 200;
            for (double x = start; x <= end; x += step)
            {
                double y = f(formula, x);
                if (Math.Abs(y) < 1e6)
                    functionSeries.Points.Add(new SeriesPoint(x, y));
            }
            chartControl1.Series.Add(functionSeries);

            if (roots != null && roots.Count > 0)
            {
                Series rootsSeries = new Series("Корни", ViewType.Point);

                if (rootsSeries.View is PointSeriesView pointView)
                {
                    pointView.PointMarkerOptions.Kind = MarkerKind.Circle;
                    pointView.PointMarkerOptions.Size = 12;
                }
                rootsSeries.View.Color = Color.Red;
                foreach (double root in roots)
                    rootsSeries.Points.Add(new SeriesPoint(root, 0));

                chartControl1.Series.Add(rootsSeries);
            }

            if (chartControl1.Diagram is XYDiagram diagram)
            {
                diagram.AxisY.ConstantLines.Clear();
                ConstantLine lineY0 = new ConstantLine("Y=0", 0);
                lineY0.Color = Color.Red;
                lineY0.LineStyle.DashStyle = DashStyle.Dash;
                diagram.AxisY.ConstantLines.Add(lineY0);

                diagram.AxisX.GridLines.Visible = true;
                diagram.AxisY.GridLines.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e) => this.Close();
    }
}