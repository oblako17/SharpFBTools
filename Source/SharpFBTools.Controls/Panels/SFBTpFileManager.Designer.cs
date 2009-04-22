﻿/*
 * Created by SharpDevelop.
 * User: Вадим Кузнецов (DikBSD)
 * Date: 16.03.2009
 * Time: 9:03
 * 
 * License: GPL 2.1
 */
namespace SharpFBTools.Controls.Panels
{
	partial class SFBTpFileManager
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFBTpFileManager));
			this.ssProgress = new System.Windows.Forms.StatusStrip();
			this.tsslblProgress = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.tsFileManager = new System.Windows.Forms.ToolStrip();
			this.tsbtnOpenDir = new System.Windows.Forms.ToolStripButton();
			this.tsSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnSortFilesTo = new System.Windows.Forms.ToolStripButton();
			this.tsSep2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsddbtnMakeReport = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsmiReportAsHTML = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiReportAsFB2 = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiReportAsCSV_CSV = new System.Windows.Forms.ToolStripMenuItem();
			this.pOptions = new System.Windows.Forms.Panel();
			this.cboxScanSubDir = new System.Windows.Forms.CheckBox();
			this.tboxSourceDir = new System.Windows.Forms.TextBox();
			this.lblDir = new System.Windows.Forms.Label();
			this.tcFileManager = new System.Windows.Forms.TabControl();
			this.tpSortAll = new System.Windows.Forms.TabPage();
			this.twSortAll = new System.Windows.Forms.TreeView();
			this.pSortAllToDir = new System.Windows.Forms.Panel();
			this.lblSortAllTargetDir = new System.Windows.Forms.Label();
			this.btnSortAllToDir = new System.Windows.Forms.Button();
			this.tboxSortAllToDir = new System.Windows.Forms.TextBox();
			this.tsSortSelected = new System.Windows.Forms.TabPage();
			this.pSortSelectedToDir = new System.Windows.Forms.Panel();
			this.lblSortSelectedTargetDir = new System.Windows.Forms.Label();
			this.btnSortSelectedToDir = new System.Windows.Forms.Button();
			this.tboxSortSelectedToDir = new System.Windows.Forms.TextBox();
			this.fbdScanDir = new System.Windows.Forms.FolderBrowserDialog();
			this.ssProgress.SuspendLayout();
			this.tsFileManager.SuspendLayout();
			this.pOptions.SuspendLayout();
			this.tcFileManager.SuspendLayout();
			this.tpSortAll.SuspendLayout();
			this.pSortAllToDir.SuspendLayout();
			this.tsSortSelected.SuspendLayout();
			this.pSortSelectedToDir.SuspendLayout();
			this.SuspendLayout();
			// 
			// ssProgress
			// 
			this.ssProgress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsslblProgress,
									this.tsProgressBar});
			this.ssProgress.Location = new System.Drawing.Point(0, 538);
			this.ssProgress.Name = "ssProgress";
			this.ssProgress.Size = new System.Drawing.Size(828, 22);
			this.ssProgress.TabIndex = 18;
			this.ssProgress.Text = "statusStrip1";
			// 
			// tsslblProgress
			// 
			this.tsslblProgress.Name = "tsslblProgress";
			this.tsslblProgress.Size = new System.Drawing.Size(47, 17);
			this.tsslblProgress.Text = "Готово.";
			// 
			// tsProgressBar
			// 
			this.tsProgressBar.Name = "tsProgressBar";
			this.tsProgressBar.Size = new System.Drawing.Size(400, 16);
			// 
			// tsFileManager
			// 
			this.tsFileManager.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.tsFileManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsbtnOpenDir,
									this.tsSep1,
									this.tsbtnSortFilesTo,
									this.tsSep2,
									this.tsddbtnMakeReport});
			this.tsFileManager.Location = new System.Drawing.Point(0, 0);
			this.tsFileManager.Name = "tsFileManager";
			this.tsFileManager.Size = new System.Drawing.Size(828, 31);
			this.tsFileManager.TabIndex = 19;
			// 
			// tsbtnOpenDir
			// 
			this.tsbtnOpenDir.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenDir.Image")));
			this.tsbtnOpenDir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnOpenDir.Name = "tsbtnOpenDir";
			this.tsbtnOpenDir.Size = new System.Drawing.Size(114, 28);
			this.tsbtnOpenDir.Text = "Открыть папку";
			this.tsbtnOpenDir.ToolTipText = "Открыть папку с fb2, fb2.zip, fb2.rar, zip или rar файлами...";
			this.tsbtnOpenDir.Click += new System.EventHandler(this.TsbtnOpenDirClick);
			// 
			// tsSep1
			// 
			this.tsSep1.Name = "tsSep1";
			this.tsSep1.Size = new System.Drawing.Size(6, 31);
			// 
			// tsbtnSortFilesTo
			// 
			this.tsbtnSortFilesTo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSortFilesTo.Image")));
			this.tsbtnSortFilesTo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSortFilesTo.Name = "tsbtnSortFilesTo";
			this.tsbtnSortFilesTo.Size = new System.Drawing.Size(102, 28);
			this.tsbtnSortFilesTo.Text = "Сортировать";
			this.tsbtnSortFilesTo.ToolTipText = "Сортировать файлы (для выбранной вкладки)";
			// 
			// tsSep2
			// 
			this.tsSep2.Name = "tsSep2";
			this.tsSep2.Size = new System.Drawing.Size(6, 31);
			// 
			// tsddbtnMakeReport
			// 
			this.tsddbtnMakeReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsmiReportAsHTML,
									this.tsmiReportAsFB2,
									this.tsmiReportAsCSV_CSV});
			this.tsddbtnMakeReport.Image = ((System.Drawing.Image)(resources.GetObject("tsddbtnMakeReport.Image")));
			this.tsddbtnMakeReport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsddbtnMakeReport.Name = "tsddbtnMakeReport";
			this.tsddbtnMakeReport.Size = new System.Drawing.Size(120, 28);
			this.tsddbtnMakeReport.Text = "Создать отчет";
			this.tsddbtnMakeReport.ToolTipText = "Создать отчет (для  выбранной вкладки)";
			// 
			// tsmiReportAsHTML
			// 
			this.tsmiReportAsHTML.Name = "tsmiReportAsHTML";
			this.tsmiReportAsHTML.Size = new System.Drawing.Size(196, 22);
			this.tsmiReportAsHTML.Text = "Как html-файл...";
			// 
			// tsmiReportAsFB2
			// 
			this.tsmiReportAsFB2.Name = "tsmiReportAsFB2";
			this.tsmiReportAsFB2.Size = new System.Drawing.Size(196, 22);
			this.tsmiReportAsFB2.Text = "Как fb2-файл...";
			// 
			// tsmiReportAsCSV_CSV
			// 
			this.tsmiReportAsCSV_CSV.Name = "tsmiReportAsCSV_CSV";
			this.tsmiReportAsCSV_CSV.Size = new System.Drawing.Size(196, 22);
			this.tsmiReportAsCSV_CSV.Text = "Как csv-файл (.csv)...";
			// 
			// pOptions
			// 
			this.pOptions.Controls.Add(this.cboxScanSubDir);
			this.pOptions.Controls.Add(this.tboxSourceDir);
			this.pOptions.Controls.Add(this.lblDir);
			this.pOptions.Dock = System.Windows.Forms.DockStyle.Top;
			this.pOptions.Location = new System.Drawing.Point(0, 31);
			this.pOptions.Name = "pOptions";
			this.pOptions.Size = new System.Drawing.Size(828, 123);
			this.pOptions.TabIndex = 20;
			// 
			// cboxScanSubDir
			// 
			this.cboxScanSubDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cboxScanSubDir.Checked = true;
			this.cboxScanSubDir.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cboxScanSubDir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.cboxScanSubDir.ForeColor = System.Drawing.Color.Navy;
			this.cboxScanSubDir.Location = new System.Drawing.Point(652, 5);
			this.cboxScanSubDir.Name = "cboxScanSubDir";
			this.cboxScanSubDir.Size = new System.Drawing.Size(172, 24);
			this.cboxScanSubDir.TabIndex = 8;
			this.cboxScanSubDir.Text = "Сканировать и подпапки";
			this.cboxScanSubDir.UseVisualStyleBackColor = true;
			// 
			// tboxSourceDir
			// 
			this.tboxSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tboxSourceDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tboxSourceDir.Location = new System.Drawing.Point(162, 5);
			this.tboxSourceDir.Name = "tboxSourceDir";
			this.tboxSourceDir.ReadOnly = true;
			this.tboxSourceDir.Size = new System.Drawing.Size(484, 20);
			this.tboxSourceDir.TabIndex = 7;
			// 
			// lblDir
			// 
			this.lblDir.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lblDir.Location = new System.Drawing.Point(2, 8);
			this.lblDir.Name = "lblDir";
			this.lblDir.Size = new System.Drawing.Size(162, 19);
			this.lblDir.TabIndex = 6;
			this.lblDir.Text = "Папка для сканирования:";
			// 
			// tcFileManager
			// 
			this.tcFileManager.Controls.Add(this.tpSortAll);
			this.tcFileManager.Controls.Add(this.tsSortSelected);
			this.tcFileManager.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcFileManager.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.tcFileManager.Location = new System.Drawing.Point(0, 154);
			this.tcFileManager.Name = "tcFileManager";
			this.tcFileManager.SelectedIndex = 0;
			this.tcFileManager.Size = new System.Drawing.Size(828, 384);
			this.tcFileManager.TabIndex = 21;
			// 
			// tpSortAll
			// 
			this.tpSortAll.Controls.Add(this.twSortAll);
			this.tpSortAll.Controls.Add(this.pSortAllToDir);
			this.tpSortAll.Location = new System.Drawing.Point(4, 22);
			this.tpSortAll.Name = "tpSortAll";
			this.tpSortAll.Padding = new System.Windows.Forms.Padding(3);
			this.tpSortAll.Size = new System.Drawing.Size(820, 358);
			this.tpSortAll.TabIndex = 0;
			this.tpSortAll.Text = " Полная Сортировка ";
			this.tpSortAll.UseVisualStyleBackColor = true;
			// 
			// twSortAll
			// 
			this.twSortAll.Dock = System.Windows.Forms.DockStyle.Fill;
			this.twSortAll.Location = new System.Drawing.Point(3, 36);
			this.twSortAll.Name = "twSortAll";
			this.twSortAll.Size = new System.Drawing.Size(814, 319);
			this.twSortAll.TabIndex = 4;
			// 
			// pSortAllToDir
			// 
			this.pSortAllToDir.Controls.Add(this.lblSortAllTargetDir);
			this.pSortAllToDir.Controls.Add(this.btnSortAllToDir);
			this.pSortAllToDir.Controls.Add(this.tboxSortAllToDir);
			this.pSortAllToDir.Dock = System.Windows.Forms.DockStyle.Top;
			this.pSortAllToDir.Location = new System.Drawing.Point(3, 3);
			this.pSortAllToDir.Name = "pSortAllToDir";
			this.pSortAllToDir.Size = new System.Drawing.Size(814, 33);
			this.pSortAllToDir.TabIndex = 3;
			// 
			// lblSortAllTargetDir
			// 
			this.lblSortAllTargetDir.AutoSize = true;
			this.lblSortAllTargetDir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.lblSortAllTargetDir.Location = new System.Drawing.Point(3, 9);
			this.lblSortAllTargetDir.Name = "lblSortAllTargetDir";
			this.lblSortAllTargetDir.Size = new System.Drawing.Size(152, 13);
			this.lblSortAllTargetDir.TabIndex = 18;
			this.lblSortAllTargetDir.Text = "Папка-приемник файлов:";
			// 
			// btnSortAllToDir
			// 
			this.btnSortAllToDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSortAllToDir.Image = ((System.Drawing.Image)(resources.GetObject("btnSortAllToDir.Image")));
			this.btnSortAllToDir.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnSortAllToDir.Location = new System.Drawing.Point(766, 3);
			this.btnSortAllToDir.Name = "btnSortAllToDir";
			this.btnSortAllToDir.Size = new System.Drawing.Size(37, 24);
			this.btnSortAllToDir.TabIndex = 7;
			this.btnSortAllToDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSortAllToDir.UseVisualStyleBackColor = true;
			// 
			// tboxSortAllToDir
			// 
			this.tboxSortAllToDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tboxSortAllToDir.Location = new System.Drawing.Point(155, 5);
			this.tboxSortAllToDir.Name = "tboxSortAllToDir";
			this.tboxSortAllToDir.ReadOnly = true;
			this.tboxSortAllToDir.Size = new System.Drawing.Size(605, 20);
			this.tboxSortAllToDir.TabIndex = 6;
			// 
			// tsSortSelected
			// 
			this.tsSortSelected.Controls.Add(this.pSortSelectedToDir);
			this.tsSortSelected.Location = new System.Drawing.Point(4, 22);
			this.tsSortSelected.Name = "tsSortSelected";
			this.tsSortSelected.Padding = new System.Windows.Forms.Padding(3);
			this.tsSortSelected.Size = new System.Drawing.Size(820, 307);
			this.tsSortSelected.TabIndex = 1;
			this.tsSortSelected.Text = " Избранная Сортировка ";
			this.tsSortSelected.UseVisualStyleBackColor = true;
			// 
			// pSortSelectedToDir
			// 
			this.pSortSelectedToDir.Controls.Add(this.lblSortSelectedTargetDir);
			this.pSortSelectedToDir.Controls.Add(this.btnSortSelectedToDir);
			this.pSortSelectedToDir.Controls.Add(this.tboxSortSelectedToDir);
			this.pSortSelectedToDir.Dock = System.Windows.Forms.DockStyle.Top;
			this.pSortSelectedToDir.Location = new System.Drawing.Point(3, 3);
			this.pSortSelectedToDir.Name = "pSortSelectedToDir";
			this.pSortSelectedToDir.Size = new System.Drawing.Size(814, 33);
			this.pSortSelectedToDir.TabIndex = 4;
			// 
			// lblSortSelectedTargetDir
			// 
			this.lblSortSelectedTargetDir.AutoSize = true;
			this.lblSortSelectedTargetDir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.lblSortSelectedTargetDir.Location = new System.Drawing.Point(3, 9);
			this.lblSortSelectedTargetDir.Name = "lblSortSelectedTargetDir";
			this.lblSortSelectedTargetDir.Size = new System.Drawing.Size(152, 13);
			this.lblSortSelectedTargetDir.TabIndex = 18;
			this.lblSortSelectedTargetDir.Text = "Папка-приемник файлов:";
			// 
			// btnSortSelectedToDir
			// 
			this.btnSortSelectedToDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSortSelectedToDir.Image = ((System.Drawing.Image)(resources.GetObject("btnSortSelectedToDir.Image")));
			this.btnSortSelectedToDir.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnSortSelectedToDir.Location = new System.Drawing.Point(766, 3);
			this.btnSortSelectedToDir.Name = "btnSortSelectedToDir";
			this.btnSortSelectedToDir.Size = new System.Drawing.Size(37, 24);
			this.btnSortSelectedToDir.TabIndex = 7;
			this.btnSortSelectedToDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSortSelectedToDir.UseVisualStyleBackColor = true;
			// 
			// tboxSortSelectedToDir
			// 
			this.tboxSortSelectedToDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tboxSortSelectedToDir.Location = new System.Drawing.Point(155, 5);
			this.tboxSortSelectedToDir.Name = "tboxSortSelectedToDir";
			this.tboxSortSelectedToDir.ReadOnly = true;
			this.tboxSortSelectedToDir.Size = new System.Drawing.Size(605, 20);
			this.tboxSortSelectedToDir.TabIndex = 6;
			// 
			// fbdScanDir
			// 
			this.fbdScanDir.Description = "Укажите папку для сканирования с fb2-файлами и архивами";
			// 
			// SFBTpFileManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tcFileManager);
			this.Controls.Add(this.pOptions);
			this.Controls.Add(this.tsFileManager);
			this.Controls.Add(this.ssProgress);
			this.Name = "SFBTpFileManager";
			this.Size = new System.Drawing.Size(828, 560);
			this.ssProgress.ResumeLayout(false);
			this.ssProgress.PerformLayout();
			this.tsFileManager.ResumeLayout(false);
			this.tsFileManager.PerformLayout();
			this.pOptions.ResumeLayout(false);
			this.pOptions.PerformLayout();
			this.tcFileManager.ResumeLayout(false);
			this.tpSortAll.ResumeLayout(false);
			this.pSortAllToDir.ResumeLayout(false);
			this.pSortAllToDir.PerformLayout();
			this.tsSortSelected.ResumeLayout(false);
			this.pSortSelectedToDir.ResumeLayout(false);
			this.pSortSelectedToDir.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TreeView twSortAll;
		private System.Windows.Forms.TextBox tboxSortSelectedToDir;
		private System.Windows.Forms.Button btnSortSelectedToDir;
		private System.Windows.Forms.Label lblSortSelectedTargetDir;
		private System.Windows.Forms.Panel pSortSelectedToDir;
		private System.Windows.Forms.TextBox tboxSortAllToDir;
		private System.Windows.Forms.Button btnSortAllToDir;
		private System.Windows.Forms.Label lblSortAllTargetDir;
		private System.Windows.Forms.Panel pSortAllToDir;
		private System.Windows.Forms.FolderBrowserDialog fbdScanDir;
		private System.Windows.Forms.TabControl tcFileManager;
		private System.Windows.Forms.Label lblDir;
		private System.Windows.Forms.TextBox tboxSourceDir;
		private System.Windows.Forms.CheckBox cboxScanSubDir;
		private System.Windows.Forms.TabPage tsSortSelected;
		private System.Windows.Forms.TabPage tpSortAll;
		private System.Windows.Forms.ToolStrip tsFileManager;
		private System.Windows.Forms.Panel pOptions;
		private System.Windows.Forms.ToolStripButton tsbtnSortFilesTo;
		private System.Windows.Forms.ToolStripMenuItem tsmiReportAsCSV_CSV;
		private System.Windows.Forms.ToolStripMenuItem tsmiReportAsFB2;
		private System.Windows.Forms.ToolStripMenuItem tsmiReportAsHTML;
		private System.Windows.Forms.ToolStripDropDownButton tsddbtnMakeReport;
		private System.Windows.Forms.ToolStripSeparator tsSep2;
		private System.Windows.Forms.ToolStripSeparator tsSep1;
		private System.Windows.Forms.ToolStripButton tsbtnOpenDir;
		private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
		private System.Windows.Forms.ToolStripStatusLabel tsslblProgress;
		private System.Windows.Forms.StatusStrip ssProgress;
	}
}
