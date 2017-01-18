namespace FEM_chislyaki
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DoMagicBtn = new System.Windows.Forms.Button();
            this.hxBox = new System.Windows.Forms.TextBox();
            this.hyBox = new System.Windows.Forms.TextBox();
            this.hzBox = new System.Windows.Forms.TextBox();
            this.nxBox = new System.Windows.Forms.TextBox();
            this.nyBox = new System.Windows.Forms.TextBox();
            this.nzBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DoMagicBtn
            // 
            this.DoMagicBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DoMagicBtn.Location = new System.Drawing.Point(0, 465);
            this.DoMagicBtn.Name = "DoMagicBtn";
            this.DoMagicBtn.Size = new System.Drawing.Size(741, 24);
            this.DoMagicBtn.TabIndex = 0;
            this.DoMagicBtn.Text = "Перестроить сетку";
            this.DoMagicBtn.UseVisualStyleBackColor = true;
            this.DoMagicBtn.Click += new System.EventHandler(this.DoMagicBtn_Click);
            // 
            // hxBox
            // 
            this.hxBox.Location = new System.Drawing.Point(12, 439);
            this.hxBox.Name = "hxBox";
            this.hxBox.Size = new System.Drawing.Size(100, 20);
            this.hxBox.TabIndex = 1;
            this.hxBox.Text = "10";
            // 
            // hyBox
            // 
            this.hyBox.Location = new System.Drawing.Point(118, 439);
            this.hyBox.Name = "hyBox";
            this.hyBox.Size = new System.Drawing.Size(100, 20);
            this.hyBox.TabIndex = 2;
            this.hyBox.Text = "10";
            // 
            // hzBox
            // 
            this.hzBox.Location = new System.Drawing.Point(224, 439);
            this.hzBox.Name = "hzBox";
            this.hzBox.Size = new System.Drawing.Size(100, 20);
            this.hzBox.TabIndex = 3;
            this.hzBox.Text = "10";
            // 
            // nxBox
            // 
            this.nxBox.Location = new System.Drawing.Point(359, 439);
            this.nxBox.Name = "nxBox";
            this.nxBox.Size = new System.Drawing.Size(100, 20);
            this.nxBox.TabIndex = 4;
            this.nxBox.Text = "4";
            // 
            // nyBox
            // 
            this.nyBox.Location = new System.Drawing.Point(465, 439);
            this.nyBox.Name = "nyBox";
            this.nyBox.Size = new System.Drawing.Size(100, 20);
            this.nyBox.TabIndex = 5;
            this.nyBox.Text = "4";
            // 
            // nzBox
            // 
            this.nzBox.Location = new System.Drawing.Point(571, 439);
            this.nzBox.Name = "nzBox";
            this.nzBox.Size = new System.Drawing.Size(100, 20);
            this.nzBox.TabIndex = 6;
            this.nzBox.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "hx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "hy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "hz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(568, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "nz";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "ny";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "nx";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 489);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nzBox);
            this.Controls.Add(this.nyBox);
            this.Controls.Add(this.nxBox);
            this.Controls.Add(this.hzBox);
            this.Controls.Add(this.hyBox);
            this.Controls.Add(this.hxBox);
            this.Controls.Add(this.DoMagicBtn);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 200);
            this.Name = "Form1";
            this.Text = "FEM";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoMagicBtn;
        private System.Windows.Forms.TextBox hxBox;
        private System.Windows.Forms.TextBox hyBox;
        private System.Windows.Forms.TextBox hzBox;
        private System.Windows.Forms.TextBox nxBox;
        private System.Windows.Forms.TextBox nyBox;
        private System.Windows.Forms.TextBox nzBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

