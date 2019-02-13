namespace Quadrocopter
{
    partial class Quadrocopters
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
            this.components = new System.ComponentModel.Container();
            this.drawTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.добавитьКвадрокоптерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запуститьПультыДУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.очиститьПолеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // drawTimer
            // 
            this.drawTimer.Interval = 40;
            this.drawTimer.Tick += new System.EventHandler(this.drawTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьКвадрокоптерToolStripMenuItem,
            this.запуститьПультыДУToolStripMenuItem,
            this.очиститьПолеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(786, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавитьКвадрокоптерToolStripMenuItem
            // 
            this.добавитьКвадрокоптерToolStripMenuItem.Name = "добавитьКвадрокоптерToolStripMenuItem";
            this.добавитьКвадрокоптерToolStripMenuItem.Size = new System.Drawing.Size(150, 20);
            this.добавитьКвадрокоптерToolStripMenuItem.Text = "Добавить квадрокоптер";
            this.добавитьКвадрокоптерToolStripMenuItem.Click += new System.EventHandler(this.добавитьКвадрокоптерToolStripMenuItem_Click);
            // 
            // запуститьПультыДУToolStripMenuItem
            // 
            this.запуститьПультыДУToolStripMenuItem.Name = "запуститьПультыДУToolStripMenuItem";
            this.запуститьПультыДУToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.запуститьПультыДУToolStripMenuItem.Text = "Запустить пульты ДУ";
            this.запуститьПультыДУToolStripMenuItem.Click += new System.EventHandler(this.запуститьПультыДУToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Quadrocopter.Properties.Resources.windows_xp;
            this.pictureBox1.InitialImage = global::Quadrocopter.Properties.Resources.windows_xp;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(762, 425);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // очиститьПолеToolStripMenuItem
            // 
            this.очиститьПолеToolStripMenuItem.Name = "очиститьПолеToolStripMenuItem";
            this.очиститьПолеToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.очиститьПолеToolStripMenuItem.Text = "Очистить поле";
            this.очиститьПолеToolStripMenuItem.Click += new System.EventHandler(this.очиститьПолеToolStripMenuItem_Click);
            // 
            // Quadrocopters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 461);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Name = "Quadrocopters";
            this.Text = "Квадрокоптеры";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer drawTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьКвадрокоптерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запуститьПультыДУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьПолеToolStripMenuItem;
    }
}

