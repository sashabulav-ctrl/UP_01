namespace WinFormsApp_UP_01
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            button2 = new Button();
            label1 = new Label();
            chartControl1 = new DevExpress.XtraCharts.ChartControl();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            trackBar1 = new TrackBar();
            label6 = new Label();
            textBox4 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)chartControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lineSeriesView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Firebrick;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.Location = new Point(306, 508);
            button2.Name = "button2";
            button2.Size = new Size(94, 33);
            button2.TabIndex = 8;
            button2.Text = "Закрыть";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(400, 49);
            label1.TabIndex = 7;
            label1.Text = "Решение уравнения методом Ньютона(касательных)";
            // 
            // chartControl1
            // 
            chartControl1.BackColor = Color.Gainsboro;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            chartControl1.Diagram = xyDiagram1;
            chartControl1.Location = new Point(11, 61);
            chartControl1.Name = "chartControl1";
            series1.Name = "Series 1";
            series1.SeriesID = 0;
            series1.View = lineSeriesView1;
            chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[]
    {
    series1
    };
            chartControl1.Size = new Size(389, 220);
            chartControl1.TabIndex = 6;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(11, 333);
            label5.Name = "label5";
            label5.Size = new Size(192, 25);
            label5.TabIndex = 30;
            label5.Text = "Точность вычислений:";
            // 
            // label3
            // 
            label3.Cursor = Cursors.No;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(154, 295);
            label3.Name = "label3";
            label3.Size = new Size(96, 23);
            label3.TabIndex = 29;
            label3.Text = "Введите b:";
            // 
            // label2
            // 
            label2.Cursor = Cursors.No;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(11, 295);
            label2.Name = "label2";
            label2.Size = new Size(97, 23);
            label2.TabIndex = 28;
            label2.Text = "Введите a:";
            // 
            // label4
            // 
            label4.Cursor = Cursors.No;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(11, 392);
            label4.Name = "label4";
            label4.Size = new Size(75, 29);
            label4.TabIndex = 27;
            label4.Text = "Ответ:";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Gainsboro;
            textBox3.Location = new Point(102, 295);
            textBox3.MaxLength = 10;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(45, 27);
            textBox3.TabIndex = 26;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Gainsboro;
            textBox2.Location = new Point(11, 424);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(388, 76);
            textBox2.TabIndex = 25;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Gainsboro;
            textBox1.Location = new Point(242, 295);
            textBox1.MaxLength = 10;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(45, 27);
            textBox1.TabIndex = 24;
            // 
            // button1
            // 
            button1.BackColor = Color.ForestGreen;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.Location = new Point(306, 381);
            button1.Name = "button1";
            button1.Size = new Size(94, 37);
            button1.TabIndex = 23;
            button1.Text = "Решить ";
            button1.UseVisualStyleBackColor = false;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(11, 363);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(192, 56);
            trackBar1.TabIndex = 22;
            // 
            // label6
            // 
            label6.Cursor = Cursors.No;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(210, 333);
            label6.Name = "label6";
            label6.Size = new Size(113, 23);
            label6.TabIndex = 31;
            label6.Text = "Введите шаг:";
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.Gainsboro;
            textBox4.Location = new Point(329, 332);
            textBox4.MaxLength = 10;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(45, 27);
            textBox4.TabIndex = 32;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(411, 553);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(textBox4);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(trackBar1);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(chartControl1);
            Name = "Form5";
            Text = "Метод Ньютона(касательных)";
            ((System.ComponentModel.ISupportInitialize)xyDiagram1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lineSeriesView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)series1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Label label1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
        private TrackBar trackBar1;
        private Label label6;
        private TextBox textBox4;
    }
}