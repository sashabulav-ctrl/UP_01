using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using org.mariuszgromada.math.mxparser;

namespace WinFormsApp_UP_01
{
    public partial class Form5 : Form
    {
        public string? CurrentFormula;

        public Form5()
        {
            InitializeComponent();

            if (trackBar1 != null)
            {
                trackBar1.Minimum = 4;
                trackBar1.Maximum = 10;
                trackBar1.Value = 6;
                trackBar1.TickFrequency = 1;
                trackBar1.Scroll += TrackBar1_Scroll;
            }

            if (button1 != null)
            {
                button1.Click += btnCalculate_Click;
            }

            if (textBox2 != null)
            {
                textBox2.ScrollBars = ScrollBars.Vertical;
                textBox2.ReadOnly = true;
            }
        }

        public void UpdateFormula(string newFormula)
        {
            CurrentFormula = newFormula;
            this.Text = $"Метод Ньютона: {newFormula}";
        }

        private void TrackBar1_Scroll(object? sender, EventArgs e)
        {
            double eps = Math.Pow(10, -trackBar1.Value);
            System.Diagnostics.Debug.WriteLine($"Точность изменена: {eps:E1}");
        }

        private double f(string formula, double x)
        {
            if (string.IsNullOrEmpty(formula)) return 0;
            string cleanFormula = formula.Split('=')[0];
            Expression e = new Expression(cleanFormula, new Argument("x", x));
            return e.calculate();
        }

        private double df(string formula, double x)
        {
            if (string.IsNullOrEmpty(formula)) return 0;
            string cleanFormula = formula.Split('=')[0];
            Argument xArg = new Argument("x", x);
            Expression der = new Expression("der(" + cleanFormula + ", x)", xArg);
            return der.calculate();
        }

        private double NewtonMethod(string formula, double x0, double eps, int maxIter = 1000)
        {
            double x = x0;
            int iter = 0;

            while (iter < maxIter)
            {
                double fx = f(formula, x);
                double dfx = df(formula, x);

                if (Math.Abs(dfx) < 1e-12)
                    throw new Exception("Производная близка к нулю");

                double x_next = x - fx / dfx;

                if (Math.Abs(x_next - x) < eps)
                    return x_next;

                x = x_next;
                iter++;
            }

            return x;
        }

        private List<double> FindAllRoots(string formula, double a, double b, double eps, int segments = 500)
        {
            List<double> roots = new List<double>();
            double step = (b - a) / segments;

            for (int i = 0; i <= segments; i++)
            {
                double x0 = a + i * step;
                double f0 = f(formula, x0);

                if (Math.Abs(f0) < eps)
                {
                    if (!IsRootExists(roots, x0, eps))
                        roots.Add(x0);
                    continue;
                }

                try
                {
                    double root = NewtonMethod(formula, x0, eps);

                    if (root >= a && root <= b)
                    {
                        if (!IsRootExists(roots, root, eps) && Math.Abs(f(formula, root)) < eps * 10)
                        {
                            roots.Add(root);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            for (int i = 0; i < segments; i++)
            {
                double x1 = a + i * step;
                double x2 = x1 + step;
                double f1 = f(formula, x1);
                double f2 = f(formula, x2);

                if (f1 * f2 <= 0 && Math.Abs(f1 - f2) > 1e-10)
                {
                    try
                    {
                        double root = NewtonMethod(formula, (x1 + x2) / 2, eps);
                        if (!IsRootExists(roots, root, eps) && Math.Abs(f(formula, root)) < eps * 10)
                        {
                            roots.Add(root);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            roots.Sort();
            return roots;
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

            string result = "";

            if (roots.Count == 1)
            {
                result = $"x = {roots[0]:F6}";
            }
            else
            {
                for (int i = 0; i < roots.Count; i++)
                {
                    result += $"x = {roots[i]:F6}";
                    if (i < roots.Count - 1) result += ", ";
                }
            }

            textBox2.Text = result;
        }

        private void btnCalculate_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(CurrentFormula))
                {
                    MessageBox.Show("Формула не задана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double a = double.Parse(textBox3.Text.Replace(",", "."),
                    System.Globalization.CultureInfo.InvariantCulture);
                double b = double.Parse(textBox1.Text.Replace(",", "."),
                    System.Globalization.CultureInfo.InvariantCulture);

                if (a >= b)
                {
                    MessageBox.Show("Левая граница (a) должна быть меньше правой (b)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double eps = Math.Pow(10, -trackBar1.Value);

                bool isZeroFunction = true;
                double step = (b - a) / 100;
                for (double x = a; x <= b; x += step)
                {
                    if (Math.Abs(f(CurrentFormula, x)) > eps * 100)
                    {
                        isZeroFunction = false;
                        break;
                    }
                }

                if (isZeroFunction)
                {
                    textBox2.Text = $"x ∈ [{a:F3}; {b:F3}]";
                    BuildChart(a, b, CurrentFormula, null);
                    return;
                }

                int segments = 500;
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    if (!int.TryParse(textBox4.Text, out segments) || segments <= 0)
                    {
                        segments = 500;
                        textBox4.Text = "500";
                    }
                    if (segments > 5000) segments = 5000;
                }

                List<double> roots = FindAllRoots(CurrentFormula, a, b, eps, segments);
                UpdateResultsDisplay(roots);
                BuildChart(a, b, CurrentFormula, roots);
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте правильность ввода чисел! Используйте точку или запятую.",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuildChart(double minX, double maxX, string formula, List<double>? roots = null)
        {
            if (chartControl1 == null) return;

            chartControl1.Series.Clear();

            Series functionSeries = new Series("f(x)", ViewType.Line);
            double start = minX - 1;
            double end = maxX + 1;
            double step = (end - start) / 200;

            for (double x = start; x <= end; x += step)
            {
                double y = f(formula, x);
                if (Math.Abs(y) < 1e6 && !double.IsInfinity(y) && !double.IsNaN(y))
                {
                    functionSeries.Points.Add(new SeriesPoint(x, y));
                }
            }

            functionSeries.View.Color = Color.Blue;
            chartControl1.Series.Add(functionSeries);

            if (roots != null && roots.Count > 0)
            {
                Series rootsSeries = new Series("Корни", ViewType.Point);

                if (rootsSeries.View is PointSeriesView pointView)
                {
                    pointView.PointMarkerOptions.Kind = MarkerKind.Circle;
                    pointView.PointMarkerOptions.Size = 11;
                }
                rootsSeries.View.Color = Color.Red;

                foreach (double root in roots)
                {
                    rootsSeries.Points.Add(new SeriesPoint(root, 0));
                }

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

                diagram.AxisX.Title.Text = "X";
                diagram.AxisX.Title.Visible = true;
                diagram.AxisY.Title.Text = "f(x)";
                diagram.AxisY.Title.Visible = true;

                diagram.AxisY.WholeRange.AutoSideMargins = true;
                diagram.AxisX.WholeRange.AutoSideMargins = true;
            }

            chartControl1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}