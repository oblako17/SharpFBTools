﻿/*
 * Created by SharpDevelop.
 * User: Вадим Кузнецов (DikBSD)
 * Date: 13.03.2009
 * Time: 14:34
 * 
 * License: GPL 2.1
 */

using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml;

namespace SharpFBTools.Controls.Panels
{
	/// <summary>
	/// Description of SFBTpValidator.
	/// </summary>
	public partial class SFBTpFB2Validator : UserControl
	{
		public SFBTpFB2Validator()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			cboxExistFile.SelectedIndex = 1;
			// инициализация контролов
			Init();
		}
		
		#region Закрытые данные класса
		// Color
		private Color	m_FB2ValidFontColor			= Color.Black;		// цвет для несжатых валидных fb2
		private Color	m_FB2NotValidFontColor		= Color.Black;		// цвет для несжатых не валидных fb2
		private Color	m_ZipFB2ValidFontColor		= Color.Blue;		// цвет для валидных fb2 в zip
		private Color	m_ZipFB2NotValidFontColor	= Color.Blue;		// цвет для не валидных fb2 в zip
		private Color	m_RarFB2ValidFontColor		= Color.DarkGreen;	// цвет для валидных fb2 в rar
		private Color	m_RarFB2NotValidFontColor	= Color.DarkGreen;	// цвет для не валидных fb2 в rar
		private Color	m_ZipFontColor				= Color.BlueViolet;	// цвет для zip не fb2
		private Color	m_RarFontColor				= Color.DarkCyan; 	// цвет для rar не fb2
		private Color	m_NotFB2FontColor			= Color.Black;		// цвет для всех остальных файлов
		//
		private long	m_lFB2Valid		= 0; // число валидных файлов
		private long	m_lFB2NotValid	= 0; // число не валидных файлов
		private long	m_lFB2Files		= 0; // число fb2 файлов (не сжатых)
		private long	m_lFB2ZipFiles	= 0; // число fb2.zip файлов
		private long	m_lFB2RarFiles	= 0; // число fb2.rar файлов
		private long	m_lNotFB2Files	= 0; // число других (не fb2) файлов
		//
		private	string	m_sReady		= "Готово.";
		private string	m_sNotValid		= " Не валидные fb2-файлы ";
		private	string	m_sValid		= " Валидные fb2-файлы ";
		private string	m_sNotFB2Files	= " Не fb2-файлы ";
		// Report
		private string	m_FB2NotValidReportEmpty	= "Список не валидных fb2-файлов пуст!\nОтчет не сохранен.";
		private string	m_FB2ValidReportEmpty		= "Список валидных fb2-файлов пуст!\nОтчет не сохранен.";
		private string	m_NotFB2FileReportEmpty		= "Список не fb2-файлов пуст!\nОтчет не сохранен.";
		private string	m_FB2NotValidFilesListReport = "Список не валидных fb2-файлов";
		private string	m_FB2ValidFilesListReport 	= "Список валидных fb2-файлов";
		private string	m_NotFB2FilesListReport 	= "Список не fb2-файлов";
		private string	m_GeneratingReport			= "Генерация отчета";
		private string	m_ReportSaveOk = "Отчет сохранен в файл:\n";
		private string	m_HTMLFilter 	= "HTML файлы (*.hml)|*.html|Все файлы (*.*)|*.*";
		private string	m_FB2Filter 	= "fb2 файлы (*.fb2)|*.fb2|Все файлы (*.*)|*.*";
		private string	m_CSV_csv_Filter = "CVS файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
		#endregion
		
		private void Init() {
			// инициализация контролов и переменных
			for( int i=0; i!=lvFilesCount.Items.Count; ++i ) {
				lvFilesCount.Items[i].SubItems[1].Text	= "0";
			}
			listViewNotValid.Items.Clear();
			listViewValid.Items.Clear();
			listViewNotFB2.Items.Clear();
			rеboxNotValid.Clear();
			tpNotValid.Text		= m_sNotValid;
			tpValid.Text		= m_sValid;
			tpNotFB2Files.Text	= m_sNotFB2Files;
			tsProgressBar.Value	= 1;
			tsslblProgress.Text		= m_sReady;
			tsProgressBar.Visible	= false;
			m_lFB2Valid		= 0;
			m_lFB2NotValid 	= 0;
			m_lFB2Files		= 0;
			m_lFB2ZipFiles 	= 0;
			m_lFB2RarFiles 	= 0;
			m_lNotFB2Files 	= 0;
			// очистка временной папки
			FilesWorker.FilesWorker.RemoveDir( FilesWorker.FilesWorker.GetTempDir() );
		}
		
		#region Парсеры файлов и архивов
		private void ParseFB2File( string sFile, FB2Parser.FB2Validator fv2Validator ) {
			// парсер несжатого fb2-файла
			string msg = fv2Validator.ValidatingFB2File( sFile );
			if ( msg == "" ) {
           		// файл валидный
           		++this.m_lFB2Valid;
				//listViewValid.Items.Add( sFile );
				ListViewItem item = new ListViewItem( sFile, 0 );
   				item.ForeColor = m_FB2ValidFontColor;
				FileInfo fi = new FileInfo( sFile );
   				item.SubItems.Add( FilesWorker.FilesWorker.FormatFileLenght( fi.Length ) );
				listViewValid.Items.AddRange( new ListViewItem[]{ item } );
				tpValid.Text = m_sValid + "( " + m_lFB2Valid.ToString() + " ) " ;
           	} else {
           		// файл не валидный
           		++this.m_lFB2NotValid;
				ListViewItem item = new ListViewItem( sFile, 0 );
   				item.ForeColor = m_FB2NotValidFontColor;
				item.SubItems.Add( msg );
   				FileInfo fi = new FileInfo( sFile );
   				item.SubItems.Add( FilesWorker.FilesWorker.FormatFileLenght( fi.Length ) );
				listViewNotValid.Items.AddRange( new ListViewItem[]{ item } );
				tpNotValid.Text = m_sNotValid + "( " + m_lFB2NotValid.ToString() + " ) " ;
           	}
			++tsProgressBar.Value;
		}
		
		private void ParseArchiveFile( string sArchiveFile, FB2Parser.FB2Validator fv2Validator, string sTempDir ) {
			// парсер архива
			string sExt = Path.GetExtension( sArchiveFile );
			if( sExt.ToLower() == ".zip" ) {
				Archiver.Archiver.unzip( "7za.exe", sArchiveFile, sTempDir );
			} else if( sExt.ToLower() == ".rar" ) {
				Archiver.Archiver.unrar( "unrar.exe", sArchiveFile, sTempDir );
			}
			string [] files = Directory.GetFiles( sTempDir );
			if( files.Length <= 0 ) return;
				
			string msg = fv2Validator.ValidatingFB2File( files[0] );
			string sFileName = Path.GetFileName( files[0] );

			if ( msg == "" ) {
           		// файл валидный - это fb2
           		++this.m_lFB2Valid;
				//listViewValid.Items.Add( sArchiveFile + "/" + sFileName );
				ListViewItem item = new ListViewItem( sArchiveFile + "/" + sFileName , 0 );
				if( sExt.ToLower() == ".zip" ) {
					item.ForeColor = m_ZipFB2ValidFontColor;
					++this.m_lFB2ZipFiles;
				} else if( sExt.ToLower() == ".rar" ) {
					item.ForeColor = m_RarFB2ValidFontColor;
					++this.m_lFB2RarFiles;
				}
				FileInfo fi = new FileInfo( sArchiveFile );
   				string s = FilesWorker.FilesWorker.FormatFileLenght( fi.Length );
   				fi = new FileInfo( FilesWorker.FilesWorker.GetTempDir()+"\\"+sFileName );
   				s += " / "+FilesWorker.FilesWorker.FormatFileLenght( fi.Length );
   				item.SubItems.Add( s );
				listViewValid.Items.AddRange( new ListViewItem[]{ item } );
				tpValid.Text = m_sValid + "( " + this.m_lFB2Valid.ToString() + " ) " ;
           	} else {
           		// архив не валидный - посмотрим, что это
        		if( sExt.ToLower() == ".zip" ) {
					// определяем тип разархивированного файла
           			sExt = Path.GetExtension( sFileName );
					if( sExt.ToLower() != ".fb2" ) {
           				msg = "Тип файла: " + sExt;
           				++this.m_lNotFB2Files;
           				ListViewItem item = new ListViewItem( sArchiveFile + "/" + sFileName, 0 );
   						item.ForeColor = m_ZipFontColor;
           				item.SubItems.Add( Path.GetExtension( sArchiveFile + "/" + sFileName ) );
   						FileInfo fi = new FileInfo( sArchiveFile );
   						string s = FilesWorker.FilesWorker.FormatFileLenght( fi.Length );
   						fi = new FileInfo( FilesWorker.FilesWorker.GetTempDir()+"\\"+sFileName );
   						s += " / "+FilesWorker.FilesWorker.FormatFileLenght( fi.Length );
   						item.SubItems.Add( s );
   						listViewNotFB2.Items.AddRange( new ListViewItem[]{ item } );
						tpNotFB2Files.Text = this.m_sNotFB2Files + "( " + this.m_lNotFB2Files.ToString() + " ) ";
					} else {
						++this.m_lFB2ZipFiles;
						++this.m_lFB2NotValid;
						ListViewItem item = new ListViewItem( sArchiveFile + "/" + sFileName, 0 );
   						item.ForeColor = m_ZipFB2NotValidFontColor;
						item.SubItems.Add( msg );
   						FileInfo fi = new FileInfo( sArchiveFile );
   						string s = FilesWorker.FilesWorker.FormatFileLenght( fi.Length );
   						fi = new FileInfo( FilesWorker.FilesWorker.GetTempDir()+"\\"+sFileName );
   						s += " / "+FilesWorker.FilesWorker.FormatFileLenght( fi.Length );
   						item.SubItems.Add( s );
						listViewNotValid.Items.AddRange( new ListViewItem[]{ item } );
						tpNotValid.Text = this.m_sNotValid + "( " + this.m_lFB2NotValid.ToString() + " ) ";
					}
				} else if( sExt.ToLower() == ".rar" ) {
					// определяем тип разархивированного файла
           			sExt = Path.GetExtension( sFileName );
					if( sExt.ToLower() != ".fb2" ) {
        				msg = "Тип файла: " + sExt;
          				++this.m_lNotFB2Files;
          				ListViewItem item = new ListViewItem( sArchiveFile + "/" + sFileName, 0 );
   						item.ForeColor = m_RarFontColor;
          				item.SubItems.Add( Path.GetExtension( sArchiveFile + "/" + sFileName ) );
   						FileInfo fi = new FileInfo( sArchiveFile );
   						string s = FilesWorker.FilesWorker.FormatFileLenght( fi.Length );
   						fi = new FileInfo( FilesWorker.FilesWorker.GetTempDir()+"\\"+sFileName );
   						s += " / "+FilesWorker.FilesWorker.FormatFileLenght( fi.Length );
   						item.SubItems.Add( s );
   						listViewNotFB2.Items.AddRange( new ListViewItem[]{ item } );
						tpNotFB2Files.Text = this.m_sNotFB2Files + "( " + this.m_lNotFB2Files.ToString() + " ) ";
					} else {
						++this.m_lFB2RarFiles;
						++this.m_lFB2NotValid;
						ListViewItem item = new ListViewItem( sArchiveFile + "/" + sFileName, 0 );
   						item.ForeColor = m_RarFB2NotValidFontColor;
						item.SubItems.Add( msg );
   						FileInfo fi = new FileInfo( sArchiveFile );
   						string s = FilesWorker.FilesWorker.FormatFileLenght( fi.Length );
   						fi = new FileInfo( FilesWorker.FilesWorker.GetTempDir()+"\\"+sFileName );
   						s += " / "+FilesWorker.FilesWorker.FormatFileLenght( fi.Length );
   						item.SubItems.Add( s );
						listViewNotValid.Items.AddRange( new ListViewItem[]{ item } );
						tpNotValid.Text = this.m_sNotValid + "( " + this.m_lFB2NotValid.ToString() + " ) ";
					}
				}
            }
			++tsProgressBar.Value;
		}
		#endregion
		
		#region Копирование, перемещение файлов
		void CopyOrMoveFilesTo( bool bCopy, string sSource, string sTarget,
		                       ListView lw, TabPage tp, string sFileType1, string sFileType,
		                       string sProgressText, string sTabPageDefText ) {
			// копировать или переместить файлы в...
			#region Код
			int nCount = lw.Items.Count;
			if( nCount == 0) {
				MessageBox.Show( "Список "+sFileType1+" пуст!\nРабота прекращена.", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			if( sTarget == "") {
				MessageBox.Show( "Не указана папка-приемник файлов!\nРабота прекращена.", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			if( sSource == sTarget ) {
				MessageBox.Show( "Папка-приемник файлов совпадает с папкой сканирования!\nРабота прекращена.", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			string sMess = "";
			if( bCopy ) {
				sMess = "Вы действительно хотите скопировать "+sFileType+" в указанную папку?";
			} else {
				sMess = "Вы действительно хотите переместить "+sFileType+" в указанную папку?";
			}
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;
			result = MessageBox.Show( sMess, "SharpFBTools", buttons, MessageBoxIcon.Question );
	        if(result == DialogResult.No) {
	            return;
			}
			tsslblProgress.Text = sProgressText;
			tsProgressBar.Visible = true;
			tsProgressBar.Maximum = nCount+1;
			tsProgressBar.Value = 1;
			for( int i=0; i!=nCount; ++i ) {
				string sItemText = lw.Items[i].SubItems[0].Text;
				string sFilePath = sItemText.Split('/')[0];
				string sNewPath = sTarget + sFilePath.Remove( 0, sSource.Length );
				FileInfo fi = new FileInfo( sNewPath );
				if( !fi.Directory.Exists ) {
					Directory.CreateDirectory( fi.Directory.ToString() );
				}
				string sSufix = "";
				if( File.Exists( sNewPath ) ) {
					if( cboxExistFile.SelectedIndex==0 ) {
						File.Delete( sNewPath );
					} else {
						string sExt = Path.GetExtension( sNewPath );
						DateTime dt = DateTime.Now;
						sSufix = "_"+dt.Year.ToString()+"-"+dt.Month.ToString()+"-"+dt.Day.ToString()+"-"+
									dt.Hour.ToString()+"-"+dt.Minute.ToString()+"-"+dt.Second.ToString()+"-"+dt.Millisecond.ToString();
						sNewPath = sNewPath.Remove( sNewPath.Length - sExt.Length ) + sSufix + sExt;
					}
				}
				if( bCopy ) {
					File.Copy( sFilePath, sNewPath );
				} else {
					File.Move( sFilePath, sNewPath );
				}
				++tsProgressBar.Value;
				ssProgress.Refresh();
			}
			if( !bCopy ) {
				// только для перемещения файлов
				lw.Items.Clear();
				tp.Text	= sTabPageDefText;
				sMess = "Перемещение файлов в указанную папку завершено!";
			} else {
				sMess = "Копирование файлов в указанную папку завершено!";
			}
			lvFilesCount.Items[1].SubItems[1].Text = ( listViewNotValid.Items.Count + listViewValid.Items.Count +
														listViewNotFB2.Items.Count ).ToString();
			MessageBox.Show( sMess, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Information );
			tsslblProgress.Text = m_sReady;
			tsProgressBar.Visible = false;
			#endregion
		}
		
		void DeleteFiles( ListView lw, TabPage tp, string sFileType, string sFileType1,
		                  string sProgressText, string sTabPageDefText ) {
			// удалить файлы...
			#region Код
			int nCount = lw.Items.Count;
			if( nCount == 0) {
				MessageBox.Show( "Список "+sFileType+" пуст!\nРабота прекращена.", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			string sMess = "Вы действительно хотите удалить "+sFileType1+"?";
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;
			result = MessageBox.Show( sMess, "SharpFBTools", buttons, MessageBoxIcon.Question );
	        if(result == DialogResult.No) {
	            return;
			}
			tsslblProgress.Text = sProgressText;
			tsProgressBar.Visible = true;
			tsProgressBar.Maximum = nCount+1;
			tsProgressBar.Value = 1;
			for( int i=0; i!=nCount; ++i ) {
				string sFilePath = lw.Items[i].SubItems[0].Text.Split('/')[0];
				if( File.Exists( sFilePath) ) {
					File.Delete( sFilePath );
				}
				++tsProgressBar.Value;
				ssProgress.Refresh();
			}
			lw.Items.Clear();
			tp.Text	= sTabPageDefText;
			lvFilesCount.Items[1].SubItems[1].Text = ( listViewNotValid.Items.Count + listViewValid.Items.Count +
			        			       				   listViewNotFB2.Items.Count ).ToString();
			sMess = "Удаление файлов завершено!";
			MessageBox.Show( sMess, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Information );
			tsslblProgress.Text = m_sReady;
			tsProgressBar.Visible = false;
			#endregion
		}
		#endregion
		
		#region Генерация отчетов
		void MakeReport( int nModeReport ) {
			// создание отчета заданного через nModeReport вида для разных вкладок (видов найденных файлов)
			// 0 - html; 1 - fb2; 3 - csv(csv); 4 - csv(txt)
			switch( tcResult.SelectedIndex ) {
				case 0:
					// не валидные fb2-файлы
					MakeReport( listViewNotValid, m_FB2NotValidReportEmpty, m_FB2NotValidFilesListReport, nModeReport );
					break;
				case 1:
					// валидные fb2-файлы
					MakeReport( listViewValid, m_FB2ValidReportEmpty, m_FB2ValidFilesListReport, nModeReport );
					break;
				case 2:
					// не fb2-файлы
					MakeReport( listViewNotFB2, m_NotFB2FileReportEmpty, m_NotFB2FilesListReport, nModeReport );
					break;
			}
		}
		
		private bool MakeReport( ListView lw, string sReportListEmpty, string sReportTitle, int nModeReport ) {
			// создание отчета
			string sDelem = ";";
			switch( nModeReport ) {
				case 0: // Как html-файл
					// сохранение списка не валидных файлов как html-файла
					if( lw.Items.Count < 1 ) {
						MessageBox.Show( sReportListEmpty, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
						return false;
					} else {
						sfdReport.Filter = m_HTMLFilter;
						sfdReport.FileName = "";
						DialogResult result = sfdReport.ShowDialog();
						if (result == DialogResult.OK) {
    	          			tsslblProgress.Text = m_GeneratingReport;
    	          			tsProgressBar.Visible = true;
							ReportGenerator.ReportGenerator.MakeHTMLReport( lw, sfdReport.FileName, sReportTitle, tsProgressBar, ssProgress  );
							MessageBox.Show( m_ReportSaveOk+sfdReport.FileName, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Information );
							tsProgressBar.Visible = false;
							tsslblProgress.Text = m_sReady;
	          			}
					}
					break;
				case 1: // Как fb2-файл
					// сохранение списка не валидных файлов как fb2-файла
					if( lw.Items.Count < 1 ) {
						MessageBox.Show( sReportListEmpty, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
						return false;
					} else {
						sfdReport.Filter = m_FB2Filter;
						sfdReport.FileName = "";
						DialogResult result = sfdReport.ShowDialog();
						if (result == DialogResult.OK) {
    	          			tsslblProgress.Text = m_GeneratingReport;
    	          			tsProgressBar.Visible = true;
							ReportGenerator.ReportGenerator.MakeFB2Report( lw, sfdReport.FileName, sReportTitle, tsProgressBar, ssProgress );
							MessageBox.Show( m_ReportSaveOk+sfdReport.FileName, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Information );
							tsProgressBar.Visible = false;
							tsslblProgress.Text = m_sReady;
	          			}
					}
					break;
				case 2: // Как csv-файл (.csv)
					// сохранение списка не валидных файлов как csv-файла
					if( lw.Items.Count < 1 ) {
						MessageBox.Show( sReportListEmpty, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
						return false;
					} else {
						sfdReport.Filter = m_CSV_csv_Filter;
						sfdReport.FileName = "";
						DialogResult result = sfdReport.ShowDialog();
						if (result == DialogResult.OK) {
							tsslblProgress.Text = m_GeneratingReport;
    	          			tsProgressBar.Visible = true;
    	       				ReportGenerator.ReportGenerator.MakeCSVReport( lw, sfdReport.FileName, sDelem, tsProgressBar, ssProgress );
							MessageBox.Show( m_ReportSaveOk+sfdReport.FileName, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Information );
							tsProgressBar.Visible = false;
							tsslblProgress.Text = m_sReady;
	        			}
					}
					break;
			}
			return true;
		}
		#endregion
		
		#region Обработчики событий
		void ListViewNotValidSelectedIndexChanged(object sender, EventArgs e)
		{
			// занесение ошибки валидации в бокс
			ListView.SelectedListViewItemCollection si = listViewNotValid.SelectedItems;
			foreach ( ListViewItem item in si ) {
				rеboxNotValid.Text = item.SubItems[1].Text;
			}
		}
		
		void ListViewNotValidDoubleClick(object sender, EventArgs e)
		{
			// открытие папки с указанным файлом
			FilesWorker.FilesWorker.ShowDir( listViewNotValid );
		}
		
		void ListViewValidDoubleClick(object sender, System.EventArgs e)
		{
			// открытие папки с указанным файлом
			FilesWorker.FilesWorker.ShowDir( listViewValid );
		}
		
		void ListViewNotFB2DoubleClick(object sender, EventArgs e)
		{
			// открытие папки с указанным файлом
			FilesWorker.FilesWorker.ShowDir( listViewNotFB2 );
		}
		
		void BtnFB2NotValidCopyToClick(object sender, EventArgs e)
		{
			// задание папки для копирования невалидных fb2-файлов
			DialogResult result = fbdNotValidFB2.ShowDialog();
			if (result == DialogResult.OK) {
                string openFolderName = fbdNotValidFB2.SelectedPath;
                tboxFB2NotValidDirCopyTo.Text = openFolderName;
            }
		}
		
		void BtnFB2NotValidMoveToClick(object sender, EventArgs e)
		{
			// задание папки для перемещения невалидных fb2-файлов
			DialogResult result = fbdNotValidFB2.ShowDialog();
			if (result == DialogResult.OK) {
                string openFolderName = fbdNotValidFB2.SelectedPath;
                tboxFB2NotValidDirMoveTo.Text = openFolderName;
            }
		}
		
		void BtnFB2ValidCopyToClick(object sender, EventArgs e)
		{
			// задание папки для валидных fb2-файлов
			DialogResult result = fbdValidFB2.ShowDialog();
			if (result == DialogResult.OK) {
                string openFolderName = fbdValidFB2.SelectedPath;
                tboxFB2ValidDirCopyTo.Text = openFolderName;
            }
		}
		
		void BtnFB2ValidMoveToClick(object sender, EventArgs e)
		{
			// задание папки для перемещения валидных fb2-файлов
			DialogResult result = fbdValidFB2.ShowDialog();
			if (result == DialogResult.OK) {
                string openFolderName = fbdValidFB2.SelectedPath;
                tboxFB2ValidDirMoveTo.Text = openFolderName;
            }
		}
		
		void BtnNotFB2CopyToClick(object sender, EventArgs e)
		{
			// задание папки для не fb2-файлов
			DialogResult result = fbdNotFB2.ShowDialog();
			if (result == DialogResult.OK) {
                string openFolderName = fbdNotFB2.SelectedPath;
                tboxNotFB2DirCopyTo.Text = openFolderName;
            }
		}
		
		void BtnNotFB2MoveToClick(object sender, EventArgs e)
		{
			// задание папки для перемещения не fb2-файлов
			DialogResult result = fbdNotFB2.ShowDialog();
			if (result == DialogResult.OK) {
                string openFolderName = fbdNotFB2.SelectedPath;
                tboxNotFB2DirMoveTo.Text = openFolderName;
            }
		}
		
		void TsbtnOpenDirClick(object sender, EventArgs e)
		{
			// задание папки с fb2-файлами для сканирования
			DialogResult result = fbdSource.ShowDialog();
			if (result == DialogResult.OK) {
                string openFolderName = fbdSource.SelectedPath;
                tboxSourceDir.Text = openFolderName;
                // инициализация контролов
				Init();
            }
		}
		
		void TSBValidateClick(object sender, EventArgs e)
		{
			// Ввлидация fb2-файлов в выбранной папке
			tlCentral.Refresh(); // обновление контролов на форме
			if( tboxSourceDir.Text == "" ) {
				MessageBox.Show( "Выберите папку для сканирования!", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			DirectoryInfo diFolder = new DirectoryInfo(tboxSourceDir.Text);
			if( !diFolder.Exists ) {
				MessageBox.Show( "Папка не найдена:" + tboxSourceDir.Text, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			
			DateTime dtStart = DateTime.Now;
			// инициализация контролов
			Init();
			tsProgressBar.Visible = true;
			// сортированный список всех вложенных папок
			List<string> lDirList = FilesWorker.FilesWorker.DirsParser( diFolder.FullName, lvFilesCount );
			lDirList.Sort();
			// сортированный список всех файлов
			tsslblProgress.Text = "Создание списка файлов:";
			tlCentral.Refresh(); // обновление контролов на форме
			List<string> lFilesList = FilesWorker.FilesWorker.AllFilesParser( lDirList, ssProgress, lvFilesCount, tsProgressBar );
			lFilesList.Sort();
			
			if( lFilesList.Count == 0 ) {
				MessageBox.Show( "Не найдено ни одного файла!\nРабота прекращена.", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				Init();
				return;
			}
			
			// проверка файлов
			tsslblProgress.Text = "Проверка найденных файлов на соответствие схеме (валидация):";
			tsProgressBar.Maximum = lFilesList.Count+1;
			tsProgressBar.Value = 1;
			ssProgress.Refresh();
			tlCentral.Refresh(); // обновление контролов на форме
			FB2Parser.FB2Validator fv2V = new FB2Parser.FB2Validator();
			foreach( string sFile in lFilesList ) {
				string sExt = Path.GetExtension( sFile );
				if( sExt.ToLower() == ".fb2" ) {
					++this.m_lFB2Files;
					ParseFB2File( sFile, fv2V );
				} else if( sExt.ToLower() == ".zip" || sExt.ToLower() == ".rar" ) {
					// очистка временной папки
					FilesWorker.FilesWorker.RemoveDir( FilesWorker.FilesWorker.GetTempDir() );
					Directory.CreateDirectory( FilesWorker.FilesWorker.GetTempDir() );
					ParseArchiveFile( sFile, fv2V, FilesWorker.FilesWorker.GetTempDir() );
				} else {
					// разные файлы
					++this.m_lNotFB2Files;
					ListViewItem item = new ListViewItem( sFile, 0 );
   					item.ForeColor = m_NotFB2FontColor;
					item.SubItems.Add( Path.GetExtension( sFile ) );
   					FileInfo fi = new FileInfo( sFile );
   					item.SubItems.Add( FilesWorker.FilesWorker.FormatFileLenght( fi.Length ) );
					listViewNotFB2.Items.AddRange( new ListViewItem[]{ item } );
					tpNotFB2Files.Text = m_sNotFB2Files + "( " + m_lNotFB2Files.ToString() + " ) " ;
					++tsProgressBar.Value;
				}
			}
			lvFilesCount.Items[2].SubItems[1].Text = m_lFB2Files.ToString();
			lvFilesCount.Items[3].SubItems[1].Text = m_lFB2ZipFiles.ToString();
			lvFilesCount.Items[4].SubItems[1].Text = m_lFB2RarFiles.ToString();
			lvFilesCount.Items[5].SubItems[1].Text = m_lNotFB2Files.ToString();
			
			DateTime dtEnd = DateTime.Now;
			string sTime = dtEnd.Subtract( dtStart ).ToString() + " (час.:мин.:сек.)";
			MessageBox.Show( "Проверка файлов на соответствие FictionBook.xsd схеме завершена!\nЗатрачено времени: "+sTime, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Information );
			tsslblProgress.Text = m_sReady;
			tsProgressBar.Visible = false;
			// очистка временной папки
			FilesWorker.FilesWorker.RemoveDir( FilesWorker.FilesWorker.GetTempDir() );
		}
		
		void TsbtnCopyFilesToClick(object sender, EventArgs e)
		{
			// копирование файлов в зависимости от выбранной вкладки
			switch( tcResult.SelectedIndex ) {
				case 0:
					// не валидные fb2-файлы
					CopyOrMoveFilesTo( true, tboxSourceDir.Text, tboxFB2NotValidDirCopyTo.Text,
		                       listViewNotValid, tpNotValid, "не валидных fb2-файлов", "не валидные fb2-файлы",
		                       "Копирование не валидных fb2-файлов:", m_sNotValid );
					break;
				case 1:
					// валидные fb2-файлы
					CopyOrMoveFilesTo( true, tboxSourceDir.Text, tboxFB2ValidDirCopyTo.Text,
		                       listViewValid, tpValid, "валидных fb2-файлов", "валидные fb2-файлы",
		                       "Копирование валидных fb2-файлов:", m_sValid );
					break;
				case 2:
					// не fb2-файлы
					CopyOrMoveFilesTo( true, tboxSourceDir.Text, tboxNotFB2DirCopyTo.Text,
		                       listViewNotFB2, tpNotFB2Files, "не fb2-файлов", "не fb2-файлы",
		                       "Копирование не fb2-файлов:", m_sNotFB2Files );
					break;
			}
		}
		
		void TsbtnMoveFilesToClick(object sender, EventArgs e)
		{
			// перемещение файлов в зависимости от выбранной вкладки
			switch( tcResult.SelectedIndex ) {
				case 0:
					// не валидные fb2-файлы
					CopyOrMoveFilesTo( false, tboxSourceDir.Text, tboxFB2NotValidDirCopyTo.Text,
		                       listViewNotValid, tpNotValid, "не валидных fb2-файлов", "не валидные fb2-файлы",
		                       "Перемещение не валидных fb2-файлов:", m_sNotValid );
					break;
				case 1:
					// валидные fb2-файлы
					CopyOrMoveFilesTo( false, tboxSourceDir.Text, tboxFB2ValidDirCopyTo.Text,
		                       listViewValid, tpValid, "валидных fb2-файлов", "валидные fb2-файлы",
		                       "Перемещение валидных fb2-файлов:", m_sValid );
					break;
				case 2:
					// не fb2-файлы
					CopyOrMoveFilesTo( false, tboxSourceDir.Text, tboxNotFB2DirCopyTo.Text,
		                       listViewNotFB2, tpNotFB2Files, "не fb2-файлов", "не fb2-файлы",
		                       "Перемещение не fb2-файлов:", m_sNotFB2Files );
					break;
			}
		}
		
		void TsbtnDeleteFilesClick(object sender, EventArgs e)
		{
			// удаление файлов в зависимости от выбранной вкладки
			switch( tcResult.SelectedIndex ) {
				case 0:
					// не валидные fb2-файлы
					DeleteFiles( listViewNotValid, tpNotValid, "не валидных fb2-файлов", "не валидные fb2-файлы",
		                       "Удаление не валидных fb2-файлов:", m_sNotValid );
					break;
				case 1:
					// валидные fb2-файлы
					DeleteFiles( listViewValid, tpValid, "валидных fb2-файлов", "валидные fb2-файлы",
		                       "Удаление валидных fb2-файлов:", m_sValid );
					break;
				case 2:
					// не fb2-файлы
					DeleteFiles( listViewNotFB2, tpNotFB2Files, "не fb2-файлов", "не fb2-файлы",
		                       "Удаление не fb2-файлов:", m_sNotFB2Files );
					break;
			}
		}
		
		void TsmiReportAsHTMLClick(object sender, EventArgs e)
		{
			// отчет в виде html-файла
			MakeReport( 0 );
		}
		
		void TsmiReportAsFB2Click(object sender, EventArgs e)
		{
			// отчет в виде fb2-файла
			MakeReport( 1 );
		}
		
		void TsmiReportAsCSV_CSVClick(object sender, EventArgs e)
		{
			// отчет в виде cvs-файла
			MakeReport( 2 );
		}

		void TsmiEditInTextEditorClick(object sender, EventArgs e)
		{
			// редактировать выделенный файл в текстовом редакторе
			// читаем путь к текстовому редактору из настроек
			string sTFB2Path = Options.OptionsForm.GetDefTFB2Path();
			if( File.Exists( Options.OptionsForm.GetSettingsPath() ) ) {
				XmlReaderSettings settings = new XmlReaderSettings();
				settings.IgnoreWhitespace = true;
				using (XmlReader reader = XmlReader.Create(Options.OptionsForm.GetSettingsPath(), settings)) {
					reader.ReadToFollowing("Editors");
					sTFB2Path = reader.GetAttribute("TextFB2EPath");
					reader.Close();
				}
			}
			switch( tcResult.SelectedIndex ) {
				case 0:
					// не валидные fb2-файлы
					if( listViewNotValid.Items.Count > 0 && listViewNotValid.SelectedItems.Count != 0 ) {
						ListView.SelectedListViewItemCollection si = listViewNotValid.SelectedItems;
						FilesWorker.FilesWorker.StartFile( sTFB2Path + " " + si[0].SubItems[0].Text.Split('/')[0] );
					}
					break;
				case 1:
					// валидные fb2-файлы
					if( listViewValid.Items.Count > 0 && listViewValid.SelectedItems.Count != 0 ) {
						ListView.SelectedListViewItemCollection si = listViewValid.SelectedItems;
						FilesWorker.FilesWorker.StartFile( sTFB2Path + " " + si[0].SubItems[0].Text.Split('/')[0] );
					}
					break;
				case 2:
					// не fb2-файлы
					if( listViewNotFB2.Items.Count > 0 && listViewNotFB2.SelectedItems.Count != 0 ) {
						ListView.SelectedListViewItemCollection si = listViewNotFB2.SelectedItems;
						FilesWorker.FilesWorker.StartFile( sTFB2Path + " " + si[0].SubItems[0].Text.Split('/')[0] );
					}
					break;
			}
		}
		
		void TsmiEditInFB2EditorClick(object sender, EventArgs e)
		{
			// редактировать выделенный файл в fb2-редакторе
			// читаем путь к FBE из настроек
			string sFBEPath = Options.OptionsForm.GetDefFBEPath();
			if( File.Exists( Options.OptionsForm.GetSettingsPath() ) ) {
				XmlReaderSettings settings = new XmlReaderSettings();
				settings.IgnoreWhitespace = true;
				using (XmlReader reader = XmlReader.Create(Options.OptionsForm.GetSettingsPath(), settings)) {
					reader.ReadToFollowing("Editors");
					sFBEPath = reader.GetAttribute("FBEPath");
					reader.Close();
				}
			}
			switch( tcResult.SelectedIndex ) {
				case 0:
					// не валидные fb2-файлы
					if( listViewNotValid.Items.Count > 0 && listViewNotValid.SelectedItems.Count != 0 ) {
						ListView.SelectedListViewItemCollection si = listViewNotValid.SelectedItems;
						FilesWorker.FilesWorker.StartFile( sFBEPath + " " + si[0].SubItems[0].Text.Split('/')[0] );
					}
					break;
				case 1:
					// валидные fb2-файлы
					if( listViewValid.Items.Count > 0 && listViewValid.SelectedItems.Count != 0 ) {
						ListView.SelectedListViewItemCollection si = listViewValid.SelectedItems;
						FilesWorker.FilesWorker.StartFile( sFBEPath + " " + si[0].SubItems[0].Text.Split('/')[0] );
					}
					break;
				case 2:
					// не fb2-файлы
					if( listViewNotFB2.Items.Count > 0 && listViewNotFB2.SelectedItems.Count != 0 ) {
						ListView.SelectedListViewItemCollection si = listViewNotFB2.SelectedItems;
						FilesWorker.FilesWorker.StartFile( sFBEPath + " " + si[0].SubItems[0].Text.Split('/')[0] );
					}
					break;
			}
		}
		
		void TsmiVienInReaderClick(object sender, EventArgs e)
		{
			// запустить файл в fb2-читалке (Просмотр)
			// читаем путь к читалке из настроек
			string sFBReaderPath = Options.OptionsForm.GetDefFBReaderPath();
			if( File.Exists( Options.OptionsForm.GetSettingsPath() ) ) {
				XmlReaderSettings settings = new XmlReaderSettings();
				settings.IgnoreWhitespace = true;
				using (XmlReader reader = XmlReader.Create(Options.OptionsForm.GetSettingsPath(), settings)) {
					reader.ReadToFollowing("Reader");
					sFBReaderPath = reader.GetAttribute("FBReaderPath");
					reader.Close();
				}
			}
			switch( tcResult.SelectedIndex ) {
				case 0:
					// не валидные fb2-файлы
					if( listViewNotValid.Items.Count > 0 && listViewNotValid.SelectedItems.Count != 0 ) {
						ListView.SelectedListViewItemCollection si = listViewNotValid.SelectedItems;
						FilesWorker.FilesWorker.StartFile( sFBReaderPath + " " + si[0].SubItems[0].Text.Split('/')[0] );
					}
					break;
				case 1:
					// валидные fb2-файлы
					if( listViewValid.Items.Count > 0 && listViewValid.SelectedItems.Count != 0 ) {
						ListView.SelectedListViewItemCollection si = listViewValid.SelectedItems;
						FilesWorker.FilesWorker.StartFile( sFBReaderPath + " " + si[0].SubItems[0].Text.Split('/')[0] );
					}
					break;
				case 2:
					// не fb2-файлы
					if( listViewNotFB2.Items.Count > 0 && listViewNotFB2.SelectedItems.Count != 0 ) {
						ListView.SelectedListViewItemCollection si = listViewNotFB2.SelectedItems;
						FilesWorker.FilesWorker.StartFile( sFBReaderPath + " " + si[0].SubItems[0].Text.Split('/')[0] );
					}
					break;
			}
		}
		
		void TsmiOpenFileDirClick(object sender, EventArgs e)
		{
			// Открыть папку для выделенного файла
			switch( tcResult.SelectedIndex ) {
				case 0:
					// не валидные fb2-файлы
					if( listViewNotValid.Items.Count > 0 && listViewNotValid.SelectedItems.Count != 0 ) {
						FilesWorker.FilesWorker.ShowDir( listViewNotValid );
					}
					break;
				case 1:
					// валидные fb2-файлы
					if( listViewValid.Items.Count > 0 && listViewValid.SelectedItems.Count != 0 ) {
						FilesWorker.FilesWorker.ShowDir( listViewValid );
					}
					break;
				case 2:
					// не fb2-файлы
					if( listViewNotFB2.Items.Count > 0 && listViewNotFB2.SelectedItems.Count != 0 ) {
						FilesWorker.FilesWorker.ShowDir( listViewNotFB2 );
					}
					break;
			}
		}
		
		void TsmiFileStartClick(object sender, EventArgs e)
		{
			// Запустить выделенный файл
			switch( tcResult.SelectedIndex ) {
				case 0:
					// не валидные fb2-файлы
					if( listViewNotValid.Items.Count > 0 && listViewNotValid.SelectedItems.Count != 0 ) {
						ListView.SelectedListViewItemCollection si = listViewNotValid.SelectedItems;
						FilesWorker.FilesWorker.StartFile( si[0].SubItems[0].Text.Split('/')[0] );
					}
					break;
				case 1:
					// валидные fb2-файлы
					if( listViewValid.Items.Count > 0 && listViewValid.SelectedItems.Count != 0 ) {
						ListView.SelectedListViewItemCollection si = listViewValid.SelectedItems;
						FilesWorker.FilesWorker.StartFile( si[0].SubItems[0].Text.Split('/')[0] ); 
					}
					break;
				case 2:
					// не fb2-файлы
					if( listViewNotFB2.Items.Count > 0 && listViewNotFB2.SelectedItems.Count != 0 ) {
						ListView.SelectedListViewItemCollection si = listViewNotFB2.SelectedItems;
						FilesWorker.FilesWorker.StartFile( si[0].SubItems[0].Text.Split('/')[0] ); 
					}
					break;
			}
		}
		#endregion

	}
}
