namespace Tromino
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonResult = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonStart.Location = new System.Drawing.Point(12, 551);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(109, 58);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonResult
            // 
            this.buttonResult.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonResult.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonResult.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonResult.Location = new System.Drawing.Point(127, 551);
            this.buttonResult.Name = "buttonResult";
            this.buttonResult.Size = new System.Drawing.Size(85, 58);
            this.buttonResult.TabIndex = 11;
            this.buttonResult.Text = "result";
            this.buttonResult.UseVisualStyleBackColor = false;
            this.buttonResult.Click += new System.EventHandler(this.buttonResult_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPrev.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPrev.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonPrev.Location = new System.Drawing.Point(218, 551);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(101, 58);
            this.buttonPrev.TabIndex = 11;
            this.buttonPrev.Text = "Pre_step";
            this.buttonPrev.UseVisualStyleBackColor = false;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNext.Location = new System.Drawing.Point(325, 551);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(111, 58);
            this.buttonNext.TabIndex = 11;
            this.buttonNext.Text = "Nex_step";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonEnd.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEnd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonEnd.Location = new System.Drawing.Point(442, 551);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(90, 58);
            this.buttonEnd.TabIndex = 11;
            this.buttonEnd.Text = "restart";
            this.buttonEnd.UseVisualStyleBackColor = false;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SeaShell;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(601, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "size";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SeaShell;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(601, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 32);
            this.label2.TabIndex = 14;
            this.label2.Text = "缺块的X";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SeaShell;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(601, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 32);
            this.label3.TabIndex = 14;
            this.label3.Text = "缺块的Y";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.BackColor = System.Drawing.Color.Snow;
            this.domainUpDown1.Font = new System.Drawing.Font("Source Code Pro", 10.8F);
            this.domainUpDown1.Items.Add("1");
            this.domainUpDown1.Items.Add("2");
            this.domainUpDown1.Items.Add("4");
            this.domainUpDown1.Items.Add("8");
            this.domainUpDown1.Items.Add("16");
            this.domainUpDown1.Items.Add("32");
            this.domainUpDown1.Items.Add("64");
            this.domainUpDown1.Items.Add("128");
            this.domainUpDown1.Items.Add("256");
            this.domainUpDown1.Location = new System.Drawing.Point(724, 148);
            this.domainUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(75, 26);
            this.domainUpDown1.TabIndex = 15;
            this.domainUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // textBoxX
            // 
            this.textBoxX.BackColor = System.Drawing.Color.Snow;
            this.textBoxX.Font = new System.Drawing.Font("Source Code Pro", 10.8F);
            this.textBoxX.Location = new System.Drawing.Point(724, 207);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(75, 26);
            this.textBoxX.TabIndex = 16;
            this.textBoxX.Text = "1";
            this.textBoxX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxX.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBoxY
            // 
            this.textBoxY.BackColor = System.Drawing.Color.Snow;
            this.textBoxY.Font = new System.Drawing.Font("Source Code Pro", 10.8F);
            this.textBoxY.Location = new System.Drawing.Point(724, 273);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(75, 26);
            this.textBoxY.TabIndex = 16;
            this.textBoxY.Text = "1";
            this.textBoxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxY.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(854, 631);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonResult);
            this.Controls.Add(this.buttonStart);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MinimumSize = new System.Drawing.Size(870, 648);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonResult;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Timer timer1;
    }
}

