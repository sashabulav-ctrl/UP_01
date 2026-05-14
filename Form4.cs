using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace WinFormsApp_UP_01
{
    public partial class Form4 : Form
    {
        public string? CurrentFormula;

        public Form4()
        {
            InitializeComponent();

            if (trackBar1 != null)
            {
                trackBar1.Minimum = 0;
                trackBar1.Maximum = 10;
                trackBar1.Value = 5;
                trackBar1.TickFrequency = 1;
                trackBar1.Scroll += TrackBar1_Scroll;
            }

            if (button1 != null)
            {
                button1.Click += btnCalculate_Click;
            }
        }

        public void UpdateFormula(string newFormula)
        {
            CurrentFormula = newFormula;
            this.Text = $"Метод хорд: {newFormula}";
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
            org.mariuszgromada.math.mxparser.Expression e =
                new org.mariuszgromada.math.mxparser.Expression(cleanFormula,
                    new org.mariuszgromada.math.mxparser.Argument("x", x));
            return e.calculate();
        }

        private double ChordMethod(string formula, double a, double b, double eps, int maxIter = 1000)
        {
            double fa = f(formula, a);
            double fb = f(formula, b);

            if (Math.Abs(fa) < eps) return a;
            if (Math.Abs(fb) < eps) return b;

            if (fa * fb > 0)
                throw new Exception("На отрезке нет корня или чётное количество корней!");

            double x_prev = a;
            double x_current = b;
            int iter = 0;

            bool isLeftFixed = (fa * f(formula, (a + b) / 2) > 0);

            while (Math.Abs(x_current - x_prev) > eps && iter < maxIter)
            {
                iter++;
                x_prev = x_current;

                if (isLeftFixed)
                    x_current = b - fb * (b - a) / (fb - fa);
                else
                    x_current = a - fa * (b - a) / (fb - fa);

                double fx = f(formula, x_current);

                if (fa * fx < 0)
                {
                    b = x_current;
                    fb = fx;
                }
                else
                {
                    a = x_current;
                    fa = fx;
                }

                if (Math.Abs(fx) < eps)
                    break;
            }

            return x_current;
        }

        private List<double> FindAllRoots(string formula, double a, double b, double eps, int segments = 500)
        {
            List<double> roots = new List<double>();
            double step = (b - a) / segments;

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
                        double root = ChordMethod(formula, x1, x2, eps);
                        if (!IsRootExists(roots, root, eps) && Math.Abs(f(formula, root)) < eps * 10)
                        {
                            roots.Add(root);
                        }
                    }
                    catch (Exception){}
                }
                else if (Math.Abs(f1) < eps && !IsRootExists(roots, x1, eps))
                {
                    roots.Add(x1);
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

        private void UpdateResultsDisplay(List<double> roots, double eps)
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
                    result += $"x{i + 1} = {roots[i]:F6}";
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
                    MessageBox.Show("Формула не задана!\nПожалуйста, введите формулу в главном окне.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double a = double.Parse(textBox3.Text.Replace(",", "."),
                    System.Globalization.CultureInfo.InvariantCulture);
                double b = double.Parse(textBox1.Text.Replace(",", "."),
                    System.Globalization.CultureInfo.InvariantCulture);

                if (a >= b)
                {
                    MessageBox.Show("Левая граница (a) должна быть меньше правой (b)!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double eps = Math.Pow(10, -trackBar1.Value);

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

                DateTime startTime = DateTime.Now;
                List<double> roots = FindAllRoots(CurrentFormula, a, b, eps, segments);
                TimeSpan elapsed = DateTime.Now - startTime;

                UpdateResultsDisplay(roots, eps);

                BuildChart(a, b, CurrentFormula, roots);

                if (roots.Count > 0)
                {
                    toolTip1.SetToolTip(button1, $"Выполнено за {elapsed.TotalMilliseconds:F0} мс");
                }
                else
                {
                    MessageBox.Show($"Корни не найдены на интервале [{a:F3}; {b:F3}]\n\n" +
                                  $"Возможные причины:\n" +
                                  $"• На интервале нет корней\n" +
                                  $"• Слишком маленькое количество разбиений (сейчас {segments})\n" +
                                  $"• Попробуйте увеличить шаг в поле 'Введите шаг'",
                                  "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте правильность ввода чисел!\n" +
                              "Используйте точку или запятую для разделения дробной части.\n" +
                              "Пример: 0.5 или 0,5",
                              "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Series rootsSeries = new Series("Корни (метод хорд)", ViewType.Point);

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