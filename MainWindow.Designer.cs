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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.groupSource = new System.Windows.Forms.GroupBox();
            this.comboAdd = new System.Windows.Forms.ComboBox();
            this.labelSkip = new System.Windows.Forms.Label();
            this.textSkip = new System.Windows.Forms.TextBox();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.groupTrackers = new System.Windows.Forms.GroupBox();
            this.textTrackers = new System.Windows.Forms.TextBox();
            this.groupWebSeeds = new System.Windows.Forms.GroupBox();
            this.textWebSeeds = new System.Windows.Forms.TextBox();
            this.groupProperties = new System.Windows.Forms.GroupBox();
            this.checkPrivate = new System.Windows.Forms.CheckBox();
            this.labelPieceLength = new System.Windows.Forms.Label();
            this.comboPieceLength = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupRelated = new System.Windows.Forms.GroupBox();
            this.labelRelatedTorrents = new System.Windows.Forms.Label();
            this.textRelatedTorrents = new System.Windows.Forms.TextBox();
            this.labelRss = new System.Windows.Forms.Label();
            this.labelWeb = new System.Windows.Forms.Label();
            this.textRss = new System.Windows.Forms.TextBox();
            this.textWeb = new System.Windows.Forms.TextBox();
            this.groupComment = new System.Windows.Forms.GroupBox();
            this.textComment = new System.Windows.Forms.TextBox();
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
            resources.ApplyResources(this.groupSource, "groupSource");
            this.groupSource.Controls.Add(this.comboAdd);
            this.groupSource.Controls.Add(this.labelSkip);
            this.groupSource.Controls.Add(this.textSkip);
            this.groupSource.Controls.Add(this.buttonAddFolder);
            this.groupSource.Controls.Add(this.buttonAddFile);
            this.groupSource.Name = "groupSource";
            this.groupSource.TabStop = false;
            // 
            // comboAdd
            // 
            resources.ApplyResources(this.comboAdd, "comboAdd");
            this.comboAdd.FormattingEnabled = true;
            this.comboAdd.Name = "comboAdd";
            // 
            // labelSkip
            // 
            resources.ApplyResources(this.labelSkip, "labelSkip");
            this.labelSkip.Name = "labelSkip";
            // 
            // textSkip
            // 
            resources.ApplyResources(this.textSkip, "textSkip");
            this.textSkip.Name = "textSkip";
            // 
            // buttonAddFolder
            // 
            resources.ApplyResources(this.buttonAddFolder, "buttonAddFolder");
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.buttonAddFolder_Click);
            // 
            // buttonAddFile
            // 
            resources.ApplyResources(this.buttonAddFile, "buttonAddFile");
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // groupTrackers
            // 
            resources.ApplyResources(this.groupTrackers, "groupTrackers");
            this.groupTrackers.Controls.Add(this.textTrackers);
            this.groupTrackers.Name = "groupTrackers";
            this.groupTrackers.TabStop = false;
            // 
            // textTrackers
            // 
            resources.ApplyResources(this.textTrackers, "textTrackers");
            this.textTrackers.Name = "textTrackers";
            // 
            // groupWebSeeds
            // 
            resources.ApplyResources(this.groupWebSeeds, "groupWebSeeds");
            this.groupWebSeeds.Controls.Add(this.textWebSeeds);
            this.groupWebSeeds.Name = "groupWebSeeds";
            this.groupWebSeeds.TabStop = false;
            // 
            // textWebSeeds
            // 
            resources.ApplyResources(this.textWebSeeds, "textWebSeeds");
            this.textWebSeeds.Name = "textWebSeeds";
            // 
            // groupProperties
            // 
            resources.ApplyResources(this.groupProperties, "groupProperties");
            this.groupProperties.Controls.Add(this.checkPrivate);
            this.groupProperties.Controls.Add(this.labelPieceLength);
            this.groupProperties.Controls.Add(this.comboPieceLength);
            this.groupProperties.Name = "groupProperties";
            this.groupProperties.TabStop = false;
            // 
            // checkPrivate
            // 
            resources.ApplyResources(this.checkPrivate, "checkPrivate");
            this.checkPrivate.Name = "checkPrivate";
            this.checkPrivate.UseVisualStyleBackColor = true;
            // 
            // labelPieceLength
            // 
            resources.ApplyResources(this.labelPieceLength, "labelPieceLength");
            this.labelPieceLength.Name = "labelPieceLength";
            // 
            // comboPieceLength
            // 
            resources.ApplyResources(this.comboPieceLength, "comboPieceLength");
            this.comboPieceLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPieceLength.FormattingEnabled = true;
            this.comboPieceLength.Items.AddRange(new object[] {
            resources.GetString("comboPieceLength.Items"),
            resources.GetString("comboPieceLength.Items1"),
            resources.GetString("comboPieceLength.Items2"),
            resources.GetString("comboPieceLength.Items3"),
            resources.GetString("comboPieceLength.Items4"),
            resources.GetString("comboPieceLength.Items5"),
            resources.GetString("comboPieceLength.Items6"),
            resources.GetString("comboPieceLength.Items7"),
            resources.GetString("comboPieceLength.Items8"),
            resources.GetString("comboPieceLength.Items9"),
            resources.GetString("comboPieceLength.Items10"),
            resources.GetString("comboPieceLength.Items11")});
            this.comboPieceLength.Name = "comboPieceLength";
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // btnCreate
            // 
            resources.ApplyResources(this.btnCreate, "btnCreate");
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupRelated
            // 
            resources.ApplyResources(this.groupRelated, "groupRelated");
            this.groupRelated.Controls.Add(this.labelRelatedTorrents);
            this.groupRelated.Controls.Add(this.textRelatedTorrents);
            this.groupRelated.Controls.Add(this.labelRss);
            this.groupRelated.Controls.Add(this.labelWeb);
            this.groupRelated.Controls.Add(this.textRss);
            this.groupRelated.Controls.Add(this.textWeb);
            this.groupRelated.Name = "groupRelated";
            this.groupRelated.TabStop = false;
            // 
            // labelRelatedTorrents
            // 
            resources.ApplyResources(this.labelRelatedTorrents, "labelRelatedTorrents");
            this.labelRelatedTorrents.Name = "labelRelatedTorrents";
            // 
            // textRelatedTorrents
            // 
            resources.ApplyResources(this.textRelatedTorrents, "textRelatedTorrents");
            this.textRelatedTorrents.Name = "textRelatedTorrents";
            // 
            // labelRss
            // 
            resources.ApplyResources(this.labelRss, "labelRss");
            this.labelRss.Name = "labelRss";
            // 
            // labelWeb
            // 
            resources.ApplyResources(this.labelWeb, "labelWeb");
            this.labelWeb.Name = "labelWeb";
            // 
            // textRss
            // 
            resources.ApplyResources(this.textRss, "textRss");
            this.textRss.Name = "textRss";
            // 
            // textWeb
            // 
            resources.ApplyResources(this.textWeb, "textWeb");
            this.textWeb.Name = "textWeb";
            // 
            // groupComment
            // 
            resources.ApplyResources(this.groupComment, "groupComment");
            this.groupComment.Controls.Add(this.textComment);
            this.groupComment.Name = "groupComment";
            this.groupComment.TabStop = false;
            // 
            // textComment
            // 
            resources.ApplyResources(this.textComment, "textComment");
            this.textComment.Name = "textComment";
            // 
            // dialogAddFile
            // 
            resources.ApplyResources(this.dialogAddFile, "dialogAddFile");
            // 
            // dialogAddFolder
            // 
            resources.ApplyResources(this.dialogAddFolder, "dialogAddFolder");
            this.dialogAddFolder.ShowNewFolderButton = false;
            // 
            // dialogSaveTorrent
            // 
            resources.ApplyResources(this.dialogSaveTorrent, "dialogSaveTorrent");
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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

