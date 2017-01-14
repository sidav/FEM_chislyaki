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
            this.SuspendLayout();
            // 
            // DoMagicBtn
            // 
            this.DoMagicBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DoMagicBtn.Location = new System.Drawing.Point(0, 319);
            this.DoMagicBtn.Name = "DoMagicBtn";
            this.DoMagicBtn.Size = new System.Drawing.Size(567, 38);
            this.DoMagicBtn.TabIndex = 0;
            this.DoMagicBtn.Text = "Расчёт";
            this.DoMagicBtn.UseVisualStyleBackColor = true;
            this.DoMagicBtn.Click += new System.EventHandler(this.DoMagicBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 357);
            this.Controls.Add(this.DoMagicBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DoMagicBtn;
    }
}

