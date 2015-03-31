namespace Torrentizer
{
    partial class MainWindow
    {
        /// <summary>
        /// Vyžadovaná proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolnit všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by měl být spravovaný prostředek odstraněn, jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupSource = new System.Windows.Forms.GroupBox();
            this.groupTrackers = new System.Windows.Forms.GroupBox();
            this.groupWebSeeds = new System.Windows.Forms.GroupBox();
            this.groupProperties = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCreate = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboPieceLength = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupSource.SuspendLayout();
            this.groupTrackers.SuspendLayout();
            this.groupWebSeeds.SuspendLayout();
            this.groupProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSource
            // 
            this.groupSource.Controls.Add(this.textBox3);
            this.groupSource.Location = new System.Drawing.Point(12, 12);
            this.groupSource.Name = "groupSource";
            this.groupSource.Size = new System.Drawing.Size(433, 113);
            this.groupSource.TabIndex = 0;
            this.groupSource.TabStop = false;
            this.groupSource.Text = "groupBox1";
            // 
            // groupTrackers
            // 
            this.groupTrackers.Controls.Add(this.textBox2);
            this.groupTrackers.Location = new System.Drawing.Point(12, 131);
            this.groupTrackers.Name = "groupTrackers";
            this.groupTrackers.Size = new System.Drawing.Size(433, 100);
            this.groupTrackers.TabIndex = 1;
            this.groupTrackers.TabStop = false;
            this.groupTrackers.Text = "Trackery (každá adresa na nový řádek):";
            // 
            // groupWebSeeds
            // 
            this.groupWebSeeds.Controls.Add(this.textBox1);
            this.groupWebSeeds.Location = new System.Drawing.Point(13, 238);
            this.groupWebSeeds.Name = "groupWebSeeds";
            this.groupWebSeeds.Size = new System.Drawing.Size(432, 100);
            this.groupWebSeeds.TabIndex = 2;
            this.groupWebSeeds.TabStop = false;
            this.groupWebSeeds.Text = "Webové zdroje (každá adresa na nový řádek):";
            // 
            // groupProperties
            // 
            this.groupProperties.Controls.Add(this.label1);
            this.groupProperties.Controls.Add(this.comboPieceLength);
            this.groupProperties.Location = new System.Drawing.Point(452, 13);
            this.groupProperties.Name = "groupProperties";
            this.groupProperties.Size = new System.Drawing.Size(399, 218);
            this.groupProperties.TabIndex = 3;
            this.groupProperties.TabStop = false;
            this.groupProperties.Text = "Vlastnosti torrentu:";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(426, 81);
            this.textBox1.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(452, 254);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(399, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(619, 315);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "button1";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 19);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(421, 20);
            this.textBox3.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(313, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 0;
            // 
            // comboPieceLength
            // 
            this.comboPieceLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPieceLength.FormattingEnabled = true;
            this.comboPieceLength.Items.AddRange(new object[] {
            "auto",
            "16 kB",
            "32 kB",
            "64 kB",
            "128 kB",
            "256 kB",
            "512 kB",
            "1 MB",
            "2 MB",
            "4 MB",
            "8 MB",
            "16 MB"});
            this.comboPieceLength.Location = new System.Drawing.Point(272, 19);
            this.comboPieceLength.Name = "comboPieceLength";
            this.comboPieceLength.Size = new System.Drawing.Size(121, 21);
            this.comboPieceLength.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 366);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupProperties);
            this.Controls.Add(this.groupWebSeeds);
            this.Controls.Add(this.groupTrackers);
            this.Controls.Add(this.groupSource);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.Move += new System.EventHandler(this.MainWindow_Move);
            this.groupSource.ResumeLayout(false);
            this.groupSource.PerformLayout();
            this.groupTrackers.ResumeLayout(false);
            this.groupTrackers.PerformLayout();
            this.groupWebSeeds.ResumeLayout(false);
            this.groupWebSeeds.PerformLayout();
            this.groupProperties.ResumeLayout(false);
            this.groupProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSource;
        private System.Windows.Forms.GroupBox groupTrackers;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupWebSeeds;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupProperties;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox comboPieceLength;
        private System.Windows.Forms.Label label1;


    }
}

