
namespace AplClient
{
    partial class ProgramWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ImageSplitContainer = new System.Windows.Forms.SplitContainer();
            this.AsmTable = new System.Windows.Forms.TableLayoutPanel();
            this.AsmImage = new System.Windows.Forms.PictureBox();
            this.AsmDescriptionTable = new System.Windows.Forms.TableLayoutPanel();
            this.AsmTimeTable = new System.Windows.Forms.TableLayoutPanel();
            this.AsmTimeLabel = new System.Windows.Forms.Label();
            this.AsmTimeTaknLabel = new System.Windows.Forms.Label();
            this.AsmRendererTableLabel = new System.Windows.Forms.Label();
            this.CSTable = new System.Windows.Forms.TableLayoutPanel();
            this.CSImage = new System.Windows.Forms.PictureBox();
            this.CsDescriptionTable = new System.Windows.Forms.TableLayoutPanel();
            this.CsTimeTable = new System.Windows.Forms.TableLayoutPanel();
            this.CsTimeTextLabel = new System.Windows.Forms.Label();
            this.CsTimeLabel = new System.Windows.Forms.Label();
            this.CsRendererTableLabel = new System.Windows.Forms.Label();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ToolboxTable = new System.Windows.Forms.TableLayoutPanel();
            this.SamplesLabel = new System.Windows.Forms.Label();
            this.AsmCheckbox = new System.Windows.Forms.CheckBox();
            this.CsCheckbox = new System.Windows.Forms.CheckBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.TrackBarTable = new System.Windows.Forms.TableLayoutPanel();
            this.SamplesTrackBar = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ImageSplitContainer)).BeginInit();
            this.ImageSplitContainer.Panel1.SuspendLayout();
            this.ImageSplitContainer.Panel2.SuspendLayout();
            this.ImageSplitContainer.SuspendLayout();
            this.AsmTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AsmImage)).BeginInit();
            this.AsmDescriptionTable.SuspendLayout();
            this.AsmTimeTable.SuspendLayout();
            this.CSTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CSImage)).BeginInit();
            this.CsDescriptionTable.SuspendLayout();
            this.CsTimeTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.ToolboxTable.SuspendLayout();
            this.TrackBarTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SamplesTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageSplitContainer
            // 
            this.ImageSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ImageSplitContainer.Name = "ImageSplitContainer";
            // 
            // ImageSplitContainer.Panel1
            // 
            this.ImageSplitContainer.Panel1.Controls.Add(this.AsmTable);
            // 
            // ImageSplitContainer.Panel2
            // 
            this.ImageSplitContainer.Panel2.Controls.Add(this.CSTable);
            this.ImageSplitContainer.Size = new System.Drawing.Size(1020, 586);
            this.ImageSplitContainer.SplitterDistance = 510;
            this.ImageSplitContainer.TabIndex = 0;
            // 
            // AsmTable
            // 
            this.AsmTable.AutoSize = true;
            this.AsmTable.ColumnCount = 1;
            this.AsmTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AsmTable.Controls.Add(this.AsmImage, 0, 0);
            this.AsmTable.Controls.Add(this.AsmDescriptionTable, 0, 1);
            this.AsmTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AsmTable.Location = new System.Drawing.Point(0, 0);
            this.AsmTable.Name = "AsmTable";
            this.AsmTable.RowCount = 2;
            this.AsmTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AsmTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.AsmTable.Size = new System.Drawing.Size(510, 586);
            this.AsmTable.TabIndex = 0;
            this.AsmTable.Resize += new System.EventHandler(this.AsmTable_Resize);
            // 
            // AsmImage
            // 
            this.AsmImage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AsmImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.AsmImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AsmImage.Location = new System.Drawing.Point(3, 3);
            this.AsmImage.Name = "AsmImage";
            this.AsmImage.Size = new System.Drawing.Size(504, 500);
            this.AsmImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AsmImage.TabIndex = 0;
            this.AsmImage.TabStop = false;
            // 
            // AsmDescriptionTable
            // 
            this.AsmDescriptionTable.ColumnCount = 1;
            this.AsmDescriptionTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AsmDescriptionTable.Controls.Add(this.AsmTimeTable, 0, 1);
            this.AsmDescriptionTable.Controls.Add(this.AsmRendererTableLabel, 0, 0);
            this.AsmDescriptionTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AsmDescriptionTable.Location = new System.Drawing.Point(3, 523);
            this.AsmDescriptionTable.MaximumSize = new System.Drawing.Size(0, 60);
            this.AsmDescriptionTable.MinimumSize = new System.Drawing.Size(0, 50);
            this.AsmDescriptionTable.Name = "AsmDescriptionTable";
            this.AsmDescriptionTable.RowCount = 2;
            this.AsmDescriptionTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AsmDescriptionTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AsmDescriptionTable.Size = new System.Drawing.Size(504, 60);
            this.AsmDescriptionTable.TabIndex = 1;
            // 
            // AsmTimeTable
            // 
            this.AsmTimeTable.ColumnCount = 2;
            this.AsmTimeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AsmTimeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AsmTimeTable.Controls.Add(this.AsmTimeLabel, 1, 0);
            this.AsmTimeTable.Controls.Add(this.AsmTimeTaknLabel, 0, 0);
            this.AsmTimeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AsmTimeTable.Location = new System.Drawing.Point(3, 33);
            this.AsmTimeTable.Name = "AsmTimeTable";
            this.AsmTimeTable.RowCount = 1;
            this.AsmTimeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AsmTimeTable.Size = new System.Drawing.Size(498, 24);
            this.AsmTimeTable.TabIndex = 0;
            // 
            // AsmTimeLabel
            // 
            this.AsmTimeLabel.AutoSize = true;
            this.AsmTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AsmTimeLabel.Location = new System.Drawing.Point(252, 0);
            this.AsmTimeLabel.Name = "AsmTimeLabel";
            this.AsmTimeLabel.Size = new System.Drawing.Size(243, 24);
            this.AsmTimeLabel.TabIndex = 0;
            this.AsmTimeLabel.Text = "0.0";
            this.AsmTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AsmTimeTaknLabel
            // 
            this.AsmTimeTaknLabel.AutoSize = true;
            this.AsmTimeTaknLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AsmTimeTaknLabel.Location = new System.Drawing.Point(3, 0);
            this.AsmTimeTaknLabel.Name = "AsmTimeTaknLabel";
            this.AsmTimeTaknLabel.Size = new System.Drawing.Size(243, 24);
            this.AsmTimeTaknLabel.TabIndex = 1;
            this.AsmTimeTaknLabel.Text = "Time taken:";
            this.AsmTimeTaknLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AsmRendererTableLabel
            // 
            this.AsmRendererTableLabel.AutoSize = true;
            this.AsmRendererTableLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AsmRendererTableLabel.Location = new System.Drawing.Point(3, 0);
            this.AsmRendererTableLabel.Name = "AsmRendererTableLabel";
            this.AsmRendererTableLabel.Size = new System.Drawing.Size(498, 30);
            this.AsmRendererTableLabel.TabIndex = 1;
            this.AsmRendererTableLabel.Text = "Assembly renderer";
            this.AsmRendererTableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CSTable
            // 
            this.CSTable.AutoSize = true;
            this.CSTable.ColumnCount = 1;
            this.CSTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CSTable.Controls.Add(this.CSImage, 0, 0);
            this.CSTable.Controls.Add(this.CsDescriptionTable, 0, 1);
            this.CSTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CSTable.Location = new System.Drawing.Point(0, 0);
            this.CSTable.Name = "CSTable";
            this.CSTable.RowCount = 2;
            this.CSTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CSTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.CSTable.Size = new System.Drawing.Size(506, 586);
            this.CSTable.TabIndex = 0;
            this.CSTable.Resize += new System.EventHandler(this.CsTable_Resize);
            // 
            // CSImage
            // 
            this.CSImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CSImage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CSImage.Location = new System.Drawing.Point(3, 3);
            this.CSImage.Name = "CSImage";
            this.CSImage.Size = new System.Drawing.Size(500, 500);
            this.CSImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CSImage.TabIndex = 1;
            this.CSImage.TabStop = false;
            // 
            // CsDescriptionTable
            // 
            this.CsDescriptionTable.ColumnCount = 1;
            this.CsDescriptionTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CsDescriptionTable.Controls.Add(this.CsTimeTable, 0, 1);
            this.CsDescriptionTable.Controls.Add(this.CsRendererTableLabel, 0, 0);
            this.CsDescriptionTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CsDescriptionTable.Location = new System.Drawing.Point(3, 523);
            this.CsDescriptionTable.MaximumSize = new System.Drawing.Size(0, 60);
            this.CsDescriptionTable.MinimumSize = new System.Drawing.Size(0, 50);
            this.CsDescriptionTable.Name = "CsDescriptionTable";
            this.CsDescriptionTable.RowCount = 2;
            this.CsDescriptionTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CsDescriptionTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CsDescriptionTable.Size = new System.Drawing.Size(500, 60);
            this.CsDescriptionTable.TabIndex = 2;
            // 
            // CsTimeTable
            // 
            this.CsTimeTable.ColumnCount = 2;
            this.CsTimeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CsTimeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CsTimeTable.Controls.Add(this.CsTimeTextLabel, 0, 0);
            this.CsTimeTable.Controls.Add(this.CsTimeLabel, 1, 0);
            this.CsTimeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CsTimeTable.Location = new System.Drawing.Point(3, 33);
            this.CsTimeTable.Name = "CsTimeTable";
            this.CsTimeTable.RowCount = 1;
            this.CsTimeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CsTimeTable.Size = new System.Drawing.Size(494, 24);
            this.CsTimeTable.TabIndex = 0;
            // 
            // CsTimeTextLabel
            // 
            this.CsTimeTextLabel.AutoSize = true;
            this.CsTimeTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CsTimeTextLabel.Location = new System.Drawing.Point(3, 0);
            this.CsTimeTextLabel.Name = "CsTimeTextLabel";
            this.CsTimeTextLabel.Size = new System.Drawing.Size(241, 24);
            this.CsTimeTextLabel.TabIndex = 0;
            this.CsTimeTextLabel.Text = "Time taken:";
            this.CsTimeTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CsTimeLabel
            // 
            this.CsTimeLabel.AutoSize = true;
            this.CsTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CsTimeLabel.Location = new System.Drawing.Point(250, 0);
            this.CsTimeLabel.Name = "CsTimeLabel";
            this.CsTimeLabel.Size = new System.Drawing.Size(241, 24);
            this.CsTimeLabel.TabIndex = 1;
            this.CsTimeLabel.Text = "0.0";
            this.CsTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CsRendererTableLabel
            // 
            this.CsRendererTableLabel.AutoSize = true;
            this.CsRendererTableLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CsRendererTableLabel.Location = new System.Drawing.Point(3, 0);
            this.CsRendererTableLabel.Name = "CsRendererTableLabel";
            this.CsRendererTableLabel.Size = new System.Drawing.Size(494, 30);
            this.CsRendererTableLabel.TabIndex = 1;
            this.CsRendererTableLabel.Text = "C# renderer";
            this.CsRendererTableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.ImageSplitContainer);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.ToolboxTable);
            this.MainSplitContainer.Size = new System.Drawing.Size(1020, 651);
            this.MainSplitContainer.SplitterDistance = 586;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // ToolboxTable
            // 
            this.ToolboxTable.ColumnCount = 5;
            this.ToolboxTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ToolboxTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolboxTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ToolboxTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ToolboxTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.ToolboxTable.Controls.Add(this.SamplesLabel, 0, 0);
            this.ToolboxTable.Controls.Add(this.AsmCheckbox, 2, 0);
            this.ToolboxTable.Controls.Add(this.CsCheckbox, 3, 0);
            this.ToolboxTable.Controls.Add(this.StartButton, 4, 0);
            this.ToolboxTable.Controls.Add(this.TrackBarTable, 1, 0);
            this.ToolboxTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolboxTable.Location = new System.Drawing.Point(0, 0);
            this.ToolboxTable.Name = "ToolboxTable";
            this.ToolboxTable.RowCount = 1;
            this.ToolboxTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolboxTable.Size = new System.Drawing.Size(1020, 61);
            this.ToolboxTable.TabIndex = 0;
            // 
            // SamplesLabel
            // 
            this.SamplesLabel.AutoSize = true;
            this.SamplesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SamplesLabel.Location = new System.Drawing.Point(3, 0);
            this.SamplesLabel.Name = "SamplesLabel";
            this.SamplesLabel.Size = new System.Drawing.Size(68, 61);
            this.SamplesLabel.TabIndex = 1;
            this.SamplesLabel.Text = "Samples:";
            this.SamplesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AsmCheckbox
            // 
            this.AsmCheckbox.AutoSize = true;
            this.AsmCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AsmCheckbox.Location = new System.Drawing.Point(628, 3);
            this.AsmCheckbox.Name = "AsmCheckbox";
            this.AsmCheckbox.Size = new System.Drawing.Size(154, 55);
            this.AsmCheckbox.TabIndex = 3;
            this.AsmCheckbox.Text = "Assembly renderer";
            this.AsmCheckbox.UseVisualStyleBackColor = true;
            // 
            // CsCheckbox
            // 
            this.CsCheckbox.AutoSize = true;
            this.CsCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CsCheckbox.Location = new System.Drawing.Point(788, 3);
            this.CsCheckbox.Name = "CsCheckbox";
            this.CsCheckbox.Size = new System.Drawing.Size(109, 55);
            this.CsCheckbox.TabIndex = 4;
            this.CsCheckbox.Text = "C# renderer";
            this.CsCheckbox.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartButton.Location = new System.Drawing.Point(903, 3);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(114, 55);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // TrackBarTable
            // 
            this.TrackBarTable.ColumnCount = 1;
            this.TrackBarTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TrackBarTable.Controls.Add(this.SamplesTrackBar, 0, 0);
            this.TrackBarTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackBarTable.Location = new System.Drawing.Point(77, 3);
            this.TrackBarTable.Name = "TrackBarTable";
            this.TrackBarTable.RowCount = 2;
            this.TrackBarTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TrackBarTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.TrackBarTable.Size = new System.Drawing.Size(545, 55);
            this.TrackBarTable.TabIndex = 6;
            // 
            // SamplesTrackBar
            // 
            this.SamplesTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SamplesTrackBar.LargeChange = 10;
            this.SamplesTrackBar.Location = new System.Drawing.Point(3, 3);
            this.SamplesTrackBar.Maximum = 100;
            this.SamplesTrackBar.Minimum = 1;
            this.SamplesTrackBar.Name = "SamplesTrackBar";
            this.SamplesTrackBar.Size = new System.Drawing.Size(539, 48);
            this.SamplesTrackBar.SmallChange = 5;
            this.SamplesTrackBar.TabIndex = 0;
            this.SamplesTrackBar.Value = 10;
            this.SamplesTrackBar.Scroll += new System.EventHandler(this.SampleTrackbar_Scroll);
            // 
            // ProgramWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 651);
            this.Controls.Add(this.MainSplitContainer);
            this.Name = "ProgramWindow";
            this.Text = "Hybrid renderer";
            this.ResizeEnd += new System.EventHandler(this.AsmTable_Resize);
            this.ImageSplitContainer.Panel1.ResumeLayout(false);
            this.ImageSplitContainer.Panel1.PerformLayout();
            this.ImageSplitContainer.Panel2.ResumeLayout(false);
            this.ImageSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSplitContainer)).EndInit();
            this.ImageSplitContainer.ResumeLayout(false);
            this.AsmTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AsmImage)).EndInit();
            this.AsmDescriptionTable.ResumeLayout(false);
            this.AsmDescriptionTable.PerformLayout();
            this.AsmTimeTable.ResumeLayout(false);
            this.AsmTimeTable.PerformLayout();
            this.CSTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CSImage)).EndInit();
            this.CsDescriptionTable.ResumeLayout(false);
            this.CsDescriptionTable.PerformLayout();
            this.CsTimeTable.ResumeLayout(false);
            this.CsTimeTable.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.ToolboxTable.ResumeLayout(false);
            this.ToolboxTable.PerformLayout();
            this.TrackBarTable.ResumeLayout(false);
            this.TrackBarTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SamplesTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ImageSplitContainer;
        private System.Windows.Forms.TableLayoutPanel CSTable;
        private System.Windows.Forms.PictureBox CSImage;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.TableLayoutPanel ToolboxTable;
        private System.Windows.Forms.Label SamplesLabel;
        private System.Windows.Forms.CheckBox AsmCheckbox;
        private System.Windows.Forms.CheckBox CsCheckbox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TableLayoutPanel AsmTable;
        private System.Windows.Forms.PictureBox AsmImage;
        private System.Windows.Forms.TableLayoutPanel AsmDescriptionTable;
        private System.Windows.Forms.Label AsmRendererTableLabel;
        private System.Windows.Forms.TableLayoutPanel CsDescriptionTable;
        private System.Windows.Forms.Label CsRendererTableLabel;
        private System.Windows.Forms.TableLayoutPanel AsmTimeTable;
        private System.Windows.Forms.Label AsmTimeLabel;
        private System.Windows.Forms.Label AsmTimeTaknLabel;
        private System.Windows.Forms.TableLayoutPanel CsTimeTable;
        private System.Windows.Forms.Label CsTimeTextLabel;
        private System.Windows.Forms.Label CsTimeLabel;
        private System.Windows.Forms.TableLayoutPanel TrackBarTable;
        private System.Windows.Forms.TrackBar SamplesTrackBar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

