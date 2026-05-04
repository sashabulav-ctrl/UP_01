namespace WinFormsApp_UP_01
{
    partial class Form3
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
            chartControl1 = new DevExpress.XtraCharts.ChartControl();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)chartControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lineSeriesView1).BeginInit();
            SuspendLayout();
            // 
            // chartControl1
            // 
            chartControl1.BackColor = Color.Gainsboro;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            chartControl1.Diagram = xyDiagram1;
            chartControl1.Location = new Point(12, 61);
            chartControl1.Name = "chartControl1";
            series1.Name = "Series 1";
            series1.SeriesID = 0;
            series1.View = lineSeriesView1;
            chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[]
    {
    series1
    };
            chartControl1.Size = new Size(388, 220);
            chartControl1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(396, 22);
            label1.TabIndex = 1;
            label1.Text = "Решение уравнения методом деления пополам";
            // 
            // button2
            // 
            button2.BackColor = Color.Firebrick;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.Location = new Point(306, 453);
            button2.Name = "button2";
            button2.Size = new Size(94, 33);
            button2.TabIndex = 4;
            button2.Text = "Закрыть";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.ForestGreen;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.Location = new Point(306, 295);
            button1.Name = "button1";
            button1.Size = new Size(94, 37);
            button1.TabIndex = 5;
            button1.Text = "Решить ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Gainsboro;
            textBox1.Location = new Point(250, 301);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(27, 23);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Gainsboro;
            textBox2.Location = new Point(12, 362);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(388, 76);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Gainsboro;
            textBox3.Location = new Point(115, 301);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(27, 23);
            textBox3.TabIndex = 8;
            // 
            // label4
            // 
            label4.Cursor = Cursors.No;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 330);
            label4.Name = "label4";
            label4.Size = new Size(76, 29);
            label4.TabIndex = 11;
            label4.Text = "Ответ:";
            // 
            // label2
            // 
            label2.Cursor = Cursors.No;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 299);
            label2.Name = "label2";
            label2.Size = new Size(97, 23);
            label2.TabIndex = 12;
            label2.Text = "Введите a:";
            // 
            // label3
            // 
            label3.Cursor = Cursors.No;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(148, 299);
            label3.Name = "label3";
            label3.Size = new Size(96, 23);
            label3.TabIndex = 13;
            label3.Text = "Введите b:";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(412, 498);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(chartControl1);
            Name = "Form3";
            Text = "Метод деления пополам";
            ((System.ComponentModel.ISupportInitialize)xyDiagram1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lineSeriesView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)series1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private Label label1;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label4;
        private Label label2;
        private Label label3;
    }
}