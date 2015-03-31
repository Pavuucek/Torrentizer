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
            this.textWebSeeds = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCreate = new System.Windows.Forms.Button();
            this.textTrackers = new System.Windows.Forms.TextBox();
            this.comboPieceLength = new System.Windows.Forms.ComboBox();
            this.labelPieceLength = new System.Windows.Forms.Label();
            this.checkPrivate = new System.Windows.Forms.CheckBox();
            this.groupRelated = new System.Windows.Forms.GroupBox();
            this.groupComment = new System.Windows.Forms.GroupBox();
            this.textWeb = new System.Windows.Forms.TextBox();
            this.textRss = new System.Windows.Forms.TextBox();
            this.labelWeb = new System.Windows.Forms.Label();
            this.labelRss = new System.Windows.Forms.Label();
            this.labelRelatedTorrents = new System.Windows.Forms.Label();
            this.textRelatedTorrents = new System.Windows.Forms.TextBox();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.labelSkip = new System.Windows.Forms.Label();
            this.textSkip = new System.Windows.Forms.TextBox();
            this.textComment = new System.Windows.Forms.TextBox();
            this.comboAdd = new System.Windows.Forms.ComboBox();
            this.dialogAddFile = new System.Windows.Forms.OpenFileDialog();
            this.dialogAddFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.dialogSaveTorrent = new System.Windows.Forms.SaveFileDialog();
            this.groupSource.SuspendLayout();
            this.groupTrackers.SuspendLayout();
            this.groupWebSeeds.SuspendLayout();
            this.groupProperties.SuspendLayout();
            this.groupRelated.SuspendLayout();
            this.groupComment.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSource
            // 
            this.groupSource.Controls.Add(this.comboAdd);
            this.groupSource.Controls.Add(this.labelSkip);
            this.groupSource.Controls.Add(this.textSkip);
            this.groupSource.Controls.Add(this.buttonAddFolder);
            this.groupSource.Controls.Add(this.buttonAddFile);
            this.groupSource.Location = new System.Drawing.Point(9, 11);
            this.groupSource.Name = "groupSource";
            this.groupSource.Size = new System.Drawing.Size(433, 123);
            this.groupSource.TabIndex = 0;
            this.groupSource.TabStop = false;
            this.groupSource.Text = "Zdroj Torrentu:";
            // 
            // groupTrackers
            // 
            this.groupTrackers.Controls.Add(this.textTrackers);
            this.groupTrackers.Location = new System.Drawing.Point(9, 140);
            this.groupTrackers.Name = "groupTrackers";
            this.groupTrackers.Size = new System.Drawing.Size(433, 100);
            this.groupTrackers.TabIndex = 1;
            this.groupTrackers.TabStop = false;
            this.groupTrackers.Text = "Trackery (každá adresa na nový řádek):";
            // 
            // groupWebSeeds
            // 
            this.groupWebSeeds.Controls.Add(this.textWebSeeds);
            this.groupWebSeeds.Location = new System.Drawing.Point(7, 246);
            this.groupWebSeeds.Name = "groupWebSeeds";
            this.groupWebSeeds.Size = new System.Drawing.Size(432, 84);
            this.groupWebSeeds.TabIndex = 2;
            this.groupWebSeeds.TabStop = false;
            this.groupWebSeeds.Text = "Webové zdroje (každá adresa na nový řádek):";
            // 
            // groupProperties
            // 
            this.groupProperties.Controls.Add(this.checkPrivate);
            this.groupProperties.Controls.Add(this.labelPieceLength);
            this.groupProperties.Controls.Add(this.comboPieceLength);
            this.groupProperties.Location = new System.Drawing.Point(452, 13);
            this.groupProperties.Name = "groupProperties";
            this.groupProperties.Size = new System.Drawing.Size(399, 74);
            this.groupProperties.TabIndex = 3;
            this.groupProperties.TabStop = false;
            this.groupProperties.Text = "Vlastnosti torrentu:";
            // 
            // textWebSeeds
            // 
            this.textWebSeeds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textWebSeeds.Location = new System.Drawing.Point(3, 16);
            this.textWebSeeds.Multiline = true;
            this.textWebSeeds.Name = "textWebSeeds";
            this.textWebSeeds.Size = new System.Drawing.Size(426, 65);
            this.textWebSeeds.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 336);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(711, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(724, 336);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(121, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Vytvořit torrent";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // textTrackers
            // 
            this.textTrackers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textTrackers.Location = new System.Drawing.Point(3, 16);
            this.textTrackers.Multiline = true;
            this.textTrackers.Name = "textTrackers";
            this.textTrackers.Size = new System.Drawing.Size(427, 81);
            this.textTrackers.TabIndex = 0;
            this.textTrackers.Text = "udp://tracker.openbittorrent.com:80/announce\r\nudp://tracker.publicbt.com:80/annou" +
    "nce\r\nudp://tracker.ccc.de:80/announce";
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
            this.comboPieceLength.TabIndex = 1;
            // 
            // labelPieceLength
            // 
            this.labelPieceLength.AutoSize = true;
            this.labelPieceLength.Location = new System.Drawing.Point(7, 26);
            this.labelPieceLength.Name = "labelPieceLength";
            this.labelPieceLength.Size = new System.Drawing.Size(76, 13);
            this.labelPieceLength.TabIndex = 0;
            this.labelPieceLength.Text = "Velikost bloku:";
            // 
            // checkPrivate
            // 
            this.checkPrivate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkPrivate.Location = new System.Drawing.Point(6, 46);
            this.checkPrivate.Name = "checkPrivate";
            this.checkPrivate.Size = new System.Drawing.Size(387, 24);
            this.checkPrivate.TabIndex = 2;
            this.checkPrivate.Text = "Soukromý torrent:";
            this.checkPrivate.UseVisualStyleBackColor = true;
            // 
            // groupRelated
            // 
            this.groupRelated.Controls.Add(this.labelRelatedTorrents);
            this.groupRelated.Controls.Add(this.textRelatedTorrents);
            this.groupRelated.Controls.Add(this.labelRss);
            this.groupRelated.Controls.Add(this.labelWeb);
            this.groupRelated.Controls.Add(this.textRss);
            this.groupRelated.Controls.Add(this.textWeb);
            this.groupRelated.Location = new System.Drawing.Point(452, 93);
            this.groupRelated.Name = "groupRelated";
            this.groupRelated.Size = new System.Drawing.Size(399, 155);
            this.groupRelated.TabIndex = 4;
            this.groupRelated.TabStop = false;
            this.groupRelated.Text = "Související:";
            // 
            // groupComment
            // 
            this.groupComment.Controls.Add(this.textComment);
            this.groupComment.Location = new System.Drawing.Point(452, 259);
            this.groupComment.Name = "groupComment";
            this.groupComment.Size = new System.Drawing.Size(399, 71);
            this.groupComment.TabIndex = 5;
            this.groupComment.TabStop = false;
            this.groupComment.Text = "Komentář:";
            // 
            // textWeb
            // 
            this.textWeb.Location = new System.Drawing.Point(6, 34);
            this.textWeb.Name = "textWeb";
            this.textWeb.Size = new System.Drawing.Size(387, 20);
            this.textWeb.TabIndex = 1;
            // 
            // textRss
            // 
            this.textRss.Location = new System.Drawing.Point(6, 77);
            this.textRss.Name = "textRss";
            this.textRss.Size = new System.Drawing.Size(384, 20);
            this.textRss.TabIndex = 3;
            // 
            // labelWeb
            // 
            this.labelWeb.AutoSize = true;
            this.labelWeb.Location = new System.Drawing.Point(7, 18);
            this.labelWeb.Name = "labelWeb";
            this.labelWeb.Size = new System.Drawing.Size(33, 13);
            this.labelWeb.TabIndex = 0;
            this.labelWeb.Text = "Web:";
            // 
            // labelRss
            // 
            this.labelRss.AutoSize = true;
            this.labelRss.Location = new System.Drawing.Point(7, 61);
            this.labelRss.Name = "labelRss";
            this.labelRss.Size = new System.Drawing.Size(32, 13);
            this.labelRss.TabIndex = 2;
            this.labelRss.Text = "RSS:";
            // 
            // labelRelatedTorrents
            // 
            this.labelRelatedTorrents.AutoSize = true;
            this.labelRelatedTorrents.Location = new System.Drawing.Point(7, 100);
            this.labelRelatedTorrents.Name = "labelRelatedTorrents";
            this.labelRelatedTorrents.Size = new System.Drawing.Size(91, 13);
            this.labelRelatedTorrents.TabIndex = 4;
            this.labelRelatedTorrents.Text = "Podobné torrenty:";
            // 
            // textRelatedTorrents
            // 
            this.textRelatedTorrents.Location = new System.Drawing.Point(6, 116);
            this.textRelatedTorrents.Name = "textRelatedTorrents";
            this.textRelatedTorrents.Size = new System.Drawing.Size(384, 20);
            this.textRelatedTorrents.TabIndex = 5;
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(6, 45);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(121, 23);
            this.buttonAddFile.TabIndex = 1;
            this.buttonAddFile.Text = "Vybrat soubor";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Location = new System.Drawing.Point(306, 45);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(121, 23);
            this.buttonAddFolder.TabIndex = 2;
            this.buttonAddFolder.Text = "Vybrat složku";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.buttonAddFolder_Click);
            // 
            // labelSkip
            // 
            this.labelSkip.AutoSize = true;
            this.labelSkip.Location = new System.Drawing.Point(8, 77);
            this.labelSkip.Name = "labelSkip";
            this.labelSkip.Size = new System.Drawing.Size(55, 13);
            this.labelSkip.TabIndex = 3;
            this.labelSkip.Text = "Přeskočit:";
            // 
            // textSkip
            // 
            this.textSkip.Location = new System.Drawing.Point(7, 93);
            this.textSkip.Name = "textSkip";
            this.textSkip.Size = new System.Drawing.Size(420, 20);
            this.textSkip.TabIndex = 4;
            // 
            // textComment
            // 
            this.textComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textComment.Location = new System.Drawing.Point(3, 16);
            this.textComment.Multiline = true;
            this.textComment.Name = "textComment";
            this.textComment.Size = new System.Drawing.Size(393, 52);
            this.textComment.TabIndex = 0;
            // 
            // comboAdd
            // 
            this.comboAdd.FormattingEnabled = true;
            this.comboAdd.Location = new System.Drawing.Point(6, 20);
            this.comboAdd.Name = "comboAdd";
            this.comboAdd.Size = new System.Drawing.Size(421, 21);
            this.comboAdd.TabIndex = 0;
            // 
            // dialogAddFile
            // 
            this.dialogAddFile.Filter = "Všechny soubory|*.*";
            // 
            // dialogAddFolder
            // 
            this.dialogAddFolder.ShowNewFolderButton = false;
            // 
            // dialogSaveTorrent
            // 
            this.dialogSaveTorrent.Filter = "Torrenty|*.torrent|Všechny soubory|*.*";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 366);
            this.Controls.Add(this.groupComment);
            this.Controls.Add(this.groupRelated);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupProperties);
            this.Controls.Add(this.groupWebSeeds);
            this.Controls.Add(this.groupTrackers);
            this.Controls.Add(this.groupSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Torrentizer - Jednoduše vytvoří nový torrent";
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
            this.groupRelated.ResumeLayout(false);
            this.groupRelated.PerformLayout();
            this.groupComment.ResumeLayout(false);
            this.groupComment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSource;
        private System.Windows.Forms.GroupBox groupTrackers;
        private System.Windows.Forms.TextBox textTrackers;
        private System.Windows.Forms.GroupBox groupWebSeeds;
        private System.Windows.Forms.TextBox textWebSeeds;
        private System.Windows.Forms.GroupBox groupProperties;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox comboPieceLength;
        private System.Windows.Forms.Label labelPieceLength;
        private System.Windows.Forms.CheckBox checkPrivate;
        private System.Windows.Forms.ComboBox comboAdd;
        private System.Windows.Forms.Label labelSkip;
        private System.Windows.Forms.TextBox textSkip;
        private System.Windows.Forms.Button buttonAddFolder;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.GroupBox groupRelated;
        private System.Windows.Forms.Label labelRelatedTorrents;
        private System.Windows.Forms.TextBox textRelatedTorrents;
        private System.Windows.Forms.Label labelRss;
        private System.Windows.Forms.Label labelWeb;
        private System.Windows.Forms.TextBox textRss;
        private System.Windows.Forms.TextBox textWeb;
        private System.Windows.Forms.GroupBox groupComment;
        private System.Windows.Forms.TextBox textComment;
        private System.Windows.Forms.OpenFileDialog dialogAddFile;
        private System.Windows.Forms.FolderBrowserDialog dialogAddFolder;
        private System.Windows.Forms.SaveFileDialog dialogSaveTorrent;


    }
}

