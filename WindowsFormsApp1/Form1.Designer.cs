namespace WindowsFormsApp1
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.trackBar2 = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.trackBar3 = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pictureBox1.Location = new System.Drawing.Point(14, 13);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(828, 531);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
			// 
			// trackBar1
			// 
			this.trackBar1.AutoSize = false;
			this.trackBar1.Location = new System.Drawing.Point(845, 35);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Minimum = 1;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(225, 30);
			this.trackBar1.TabIndex = 1;
			this.trackBar1.TabStop = false;
			this.trackBar1.Value = 1;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// trackBar2
			// 
			this.trackBar2.AutoSize = false;
			this.trackBar2.Location = new System.Drawing.Point(846, 95);
			this.trackBar2.Maximum = 100;
			this.trackBar2.Minimum = 1;
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new System.Drawing.Size(225, 30);
			this.trackBar2.TabIndex = 2;
			this.trackBar2.TabStop = false;
			this.trackBar2.Value = 1;
			this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(846, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "width";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(846, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "height";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 548);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip1.Size = new System.Drawing.Size(1086, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.AutoSize = false;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(80, 17);
			this.toolStripStatusLabel2.Text = "0*0";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.AutoSize = false;
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(80, 17);
			this.toolStripStatusLabel3.Text = "0/0";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.AutoSize = false;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(910, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Window;
			this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.textBox1.Location = new System.Drawing.Point(852, 524);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(215, 20);
			this.textBox1.TabIndex = 6;
			this.textBox1.TabStop = false;
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pictureBox2.Location = new System.Drawing.Point(852, 305);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(215, 215);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 9;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
			// 
			// trackBar3
			// 
			this.trackBar3.AutoSize = false;
			this.trackBar3.Location = new System.Drawing.Point(846, 155);
			this.trackBar3.Maximum = 100;
			this.trackBar3.Name = "trackBar3";
			this.trackBar3.Size = new System.Drawing.Size(225, 30);
			this.trackBar3.TabIndex = 10;
			this.trackBar3.TabStop = false;
			this.trackBar3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar3_MouseUp);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(846, 135);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 17);
			this.label3.TabIndex = 11;
			this.label3.Text = "progress";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(1018, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 17);
			this.label4.TabIndex = 12;
			this.label4.Text = "1%";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(1018, 75);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 17);
			this.label5.TabIndex = 13;
			this.label5.Text = "1%";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(1018, 135);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 17);
			this.label6.TabIndex = 14;
			this.label6.Text = "0%";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = global::WindowsFormsApp1.Properties.Resources.gridoff;
			this.pictureBox3.Location = new System.Drawing.Point(852, 206);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(80, 20);
			this.pictureBox3.TabIndex = 15;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1086, 570);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.trackBar3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.trackBar2);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.pictureBox1);
			this.Font = new System.Drawing.Font("等线", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Images Marker";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TrackBar trackBar2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.TrackBar trackBar3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.PictureBox pictureBox3;
	}
}

