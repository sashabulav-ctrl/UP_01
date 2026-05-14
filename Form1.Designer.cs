namespace WinFormsApp_UP_01
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button5 = new Button();
            button6 = new Button();
            chartControl1 = new DevExpress.XtraCharts.ChartControl();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)chartControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splineSeriesView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.ForestGreen;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = Color.MintCream;
            button1.Location = new Point(11, 436);
            button1.Name = "button1";
            button1.Size = new Size(215, 55);
            button1.TabIndex = 0;
            button1.Text = "Деления пополам";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.ForestGreen;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Segoe UI", 10F);
            button2.ForeColor = Color.MintCream;
            button2.Location = new Point(255, 436);
            button2.Name = "button2";
            button2.Size = new Size(215, 55);
            button2.TabIndex = 1;
            button2.Text = "Хорд";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.ForestGreen;
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Segoe UI", 10F);
            button3.ForeColor = Color.MintCream;
            button3.Location = new Point(11, 504);
            button3.Name = "button3";
            button3.Size = new Size(215, 55);
            button3.TabIndex = 2;
            button3.Text = "Касательных(Ньютона)";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.ForestGreen;
            button4.Cursor = Cursors.Hand;
            button4.ForeColor = Color.MintCream;
            button4.Location = new Point(255, 505);
            button4.Name = "button4";
            button4.Size = new Size(215, 55);
            button4.TabIndex = 3;
            button4.Text = "Итераций";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(458, 35);
            label1.TabIndex = 4;
            label1.Text = "Решение нелинейных алгебраических уравнений";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(11, 387);
            label2.Name = "label2";
            label2.Size = new Size(273, 28);
            label2.TabIndex = 6;
            label2.Text = "Решить уравнение методом:";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(11, 341);
            label3.Name = "label3";
            label3.Size = new Size(81, 27);
            label3.TabIndex = 7;
            label3.Text = "Функция:";
            // 
            // button5
            // 
            button5.Cursor = Cursors.Hand;
            button5.Font = new Font("Segoe UI", 7F);
            button5.Location = new Point(11, 600);
            button5.Name = "button5";
            button5.Size = new Size(123, 27);
            button5.TabIndex = 8;
            button5.Text = "О программе...";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Firebrick;
            button6.Cursor = Cursors.Hand;
            button6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button6.ForeColor = Color.Black;
            button6.Location = new Point(337, 595);
            button6.Name = "button6";
            button6.Size = new Size(133, 32);
            button6.TabIndex = 9;
            button6.Text = "Выход";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // chartControl1
            // 
            chartControl1.BackColor = Color.Gainsboro;
            chartControl1.BorderOptions.Color = Color.White;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            chartControl1.Diagram = xyDiagram1;
            chartControl1.Legend.ItemVisibilityMode = DevExpress.XtraCharts.LegendItemVisibilityMode.AutoGeneratedAndCustom;
            chartControl1.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBox;
            chartControl1.Legend.TextColor = SystemColors.Desktop;
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl1.Location = new Point(11, 45);
            chartControl1.Name = "chartControl1";
            series1.Name = "x^2-3x+3=0";
            series1.SeriesID = 0;
            series1.View = splineSeriesView1;
            chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[]
    {
    series1
    };
            chartControl1.Size = new Size(458, 276);
            chartControl1.TabIndex = 10;
            chartControl1.Click += chartControl1_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.InactiveCaption;
            comboBox1.ForeColor = Color.DimGray;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "", "x^3+3*x^2-24*x+10=0", "x^3-12*x+10=0", "x^3-3*x^2+3=0", "2*x^3+9*x^2-21=0" });
            comboBox1.Location = new Point(99, 341);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(371, 28);
            comboBox1.TabIndex = 11;
            comboBox1.Text = "Введите функцию (например: 3*x-5=0)";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(482, 637);
            Controls.Add(comboBox1);
            Controls.Add(chartControl1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Решение уравнений";
            ((System.ComponentModel.ISupportInitialize)xyDiagram1).EndInit();
            ((System.ComponentModel.ISupportInitialize)splineSeriesView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)series1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button5;
        private Button button6;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private ComboBox comboBox1;
    }
}
