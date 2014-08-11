﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 28.06.2012
 * Time: 9:12
 * 
 * License: GPL 2.1
 */
using System;
using System.Xml;
using System.IO;

namespace Settings
{
	/// <summary>
	/// FileManagerSettings: класс для работы с сохранением в xml и чтением настроек Сортировщика
	/// </summary>
	public class FileManagerSettings
	{
		#region Закрытые статические данные класса ПО-УМОЛЧАНИЮ
		// пути к файлам-справкам
		private readonly static string m_FileManagerHelpPath	= Settings.ProgDir + "\\Help\\FileManagerHelp.rtf";
		private readonly static string m_DescTemplatePath		= Settings.ProgDir + "\\Help\\TemplatesDescription.rtf";
		private readonly static string m_FileSettingsPath		= Settings.ProgDir + @"\FileManagerSettings.xml";
		private readonly static XmlDocument m_xmlDoc			= new XmlDocument();
		private static bool m_FullSortingFB2LibrusecGenres		= true;
		private static bool m_SelectedSortingFB2LibrusecGenres	= true;

		// Настройки Полной сортировки
		private readonly static string m_FullSortTemplate			= @"*GROUP*\*LBAL*[ *BAF*][ *BAM*]\*G*\[# *SN*]\[#*SII* - ]*BT*";
		private readonly static bool m_FullSortScanSubDirs			= true;
		private readonly static bool m_FullSortToZip				= false;
		private readonly static bool m_FullSortNotDelFB2Files		= true;
		private readonly static string m_FullSortSourceDir 			= string.Empty;
		private readonly static string m_FullSortTargetDir			= string.Empty;
		private readonly static bool m_FullSortFB2GenresLibrusec	= true;
		private readonly static bool m_FullSortFB2GenresFB22		= false;
		
		// Настройки Избранной сортировки
		private readonly static string m_SelSortTemplate 		= @"*GROUP*\*LBAL*[ *BAF*][ *BAM*]\*G*\[# *SN*]\[#*SII* - ]*BT*";
		private readonly static bool m_SelSortScanSubDirs		= true;
		private readonly static bool m_SelSortToZip				= false;
		private readonly static bool m_SelSortNotDelFB2Files	= true;
		private readonly static string m_SelSortSourceDir 		= string.Empty;
		private readonly static string m_SelSortTargetDir 		= string.Empty;
		private readonly static bool m_SelSortFB2GenresLibrusec	= true;
		private readonly static bool m_SelSortFB2GenresFB22		= false;

		// прогресс
		private readonly static bool m_Progress				= false;
		
		// основные опции Сортировщиков
		private readonly static bool m_RegisterAsIs			= true;
		private readonly static bool m_RegisterAsSentence	= false;
		private readonly static bool m_RegisterLower		= false;
		private readonly static bool m_RegisterUpper		= false;
		private readonly static bool m_Translit				= false;
		private readonly static bool m_Strict				= false;
		private readonly static Int16 m_Space				= 0;
		private readonly static Int16 m_FileExist			= 1;
		
		private readonly static bool m_GenreOne		= true;
		private readonly static bool m_GenreAll		= false;
		private readonly static bool m_AuthorOne	= true;
		private readonly static bool m_AuthorAll	= false;
		private readonly static bool m_GenreSchema	= true;
		private readonly static bool m_GenreText	= false;
		private readonly static bool m_AllFB2		= true;
		private readonly static bool m_OnlyValidFB2	= false;
		
		// папки для "проблемных" файлов
		private readonly static string m_NotReadDir		= "_'Не читаемые' fb2 файлы";
		private readonly static string m_LongPathDir	= "_fb2 c длинными путями";
		private readonly static string m_NotValidDir	= "_Не валидные fb2 файлы";
		private readonly static string m_ArchNotOpenDir	= "_'Битые' fb2 архивы, не fb2 архивы";
		
		// названия папок для шаблонных тэгов без данных
		private readonly static string m_NoGenreGroup		= "_Нестандартные Жанры";
		private readonly static string m_NoGenre			= "Без Жанра";
		private readonly static string m_NoLang				= "Без Языка Книги";
		private readonly static string m_NoFirstName		= "Без Имени";
		private readonly static string m_NoMiddleName		= "Без Отчества";
		private readonly static string m_NoLastName			= "Без Фамилия";
		private readonly static string m_NoNickName			= "Без Ника";
		private readonly static string m_NoBookTitle		= "Без Названия Книги";
		private readonly static string m_NoSequence			= "Без Серии";
		private readonly static string m_NoNSequence		= "Без Номера Серии";
		private readonly static string m_NoDateText			= "Без Даты (Текст)";
		private readonly static string m_NoDateValue		= "Без Даты (Значение)";
		private readonly static string m_NoYear				= "Без Года издания";
		private readonly static string m_NoPublisher		= "Без Издательства";
		private readonly static string m_NoCity				= "Без Города Издания";
		private readonly static string m_NoFB2FirstName		= "Без Имени fb2-создателя";
		private readonly static string m_NoFB2MiddleName	= "Без Отчества fb2-создателя";
		private readonly static string m_NoFB2LastName		= "Без Фамилия fb2-создателя";
		private readonly static string m_NoFB2NickName		= "Без Ника fb2-создателя";
		
		// название Групп Жанров
		private readonly static string m_sf			= "ФАНТАСТИКА, ФЭНТЕЗИ";
		private readonly static string m_detective	= "ДЕТЕКТИВЫ, БОЕВИКИ";
		private readonly static string m_prose		= "ПРОЗА";
		private readonly static string m_love		= "ЛЮБОВНЫЕ РОМАНЫ";
		private readonly static string m_adventure	= "ПРИКЛЮЧЕНИЯ";
		private readonly static string m_children	= "ДЕТСКОЕ";
		private readonly static string m_poetry		= "ПОЭЗИЯ, ДРАМАТУРГИЯ";
		private readonly static string m_antique	= "СТАРИННОЕ";
		private readonly static string m_science	= "НАУКА, ОБРАЗОВАНИЕ";
		private readonly static string m_computers	= "КОМПЬЮТЕРЫ";
		private readonly static string m_reference	= "СПРАВОЧНИКИ";
		private readonly static string m_nonfiction	= "ДОКУМЕНТАЛЬНОЕ";
		private readonly static string m_religion	= "РЕЛИГИЯ";
		private readonly static string m_humor		= "ЮМОР";
		private readonly static string m_home		= "ДОМ, СЕМЬЯ";
		private readonly static string m_business	= "БИЗНЕС";
		private readonly static string m_tech		= "ТЕХНИКА";
		private readonly static string m_military	= "ВОЕННОЕ ДЕЛО";
		private readonly static string m_folklore	= "ФОЛЬКЛЕР";
		private readonly static string m_other		= "ПРОЧЕЕ";
		#endregion
		
		public FileManagerSettings()
		{
		}
		
		#region Открытые статические общие свойства класса
		public static string FileManagerSettingsPath {
			get { return m_FileSettingsPath; }
		}
		public static string FileManagerHelpPath {
			get { return m_FileManagerHelpPath; }
		}
		public static string DefFMDescTemplatePath {
			get { return m_DescTemplatePath; }
		}
		#endregion
		
		#region Открытые статические свойства класса для данных Сортировок
		public static bool FullSortingFB2LibrusecGenres {
			get { return m_FullSortingFB2LibrusecGenres; }
			set { m_FullSortingFB2LibrusecGenres = value; }
		}
		public static bool SelectedSortingFB2LibrusecGenres {
			get { return m_SelectedSortingFB2LibrusecGenres; }
			set { m_SelectedSortingFB2LibrusecGenres = value; }
		}
		#endregion
		
		#region Открытые статические методы класса для чтения из xml настроек
		// чтение FullSortingFB2Librusec из xml-файла
		public static bool ReadXmlFullSortingFB2Librusec() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/FullSorting/FB2Genres");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return FullSortingFB2LibrusecGenres = Convert.ToBoolean(attrs.GetNamedItem("Librusec").InnerText);
				}
			}
			return FullSortingFB2LibrusecGenres;
		}
		// чтение SelectedSortingFB2Librusec из xml-файла
		public static bool ReadXmlSelectedSortingFB2Librusec() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/SelectedSorting/FB2Genres");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return SelectedSortingFB2LibrusecGenres = Convert.ToBoolean(attrs.GetNamedItem("Librusec").InnerText);
				}
			}
			return SelectedSortingFB2LibrusecGenres;
		}
		#endregion
		
		#region Открытые статические ОБЩИЕ свойства класса ПО-УМОЛЧАНИЮ
		// =====================================================================================================
		// 									Настройки Полной сортировки
		// =====================================================================================================
		#region Настройки Полной сортировки
		// Обрабатывать подкаталоги
		public static bool DefFullSortSubDirs {
			get { return m_FullSortScanSubDirs; }
		}
		// Архивировать в zip
		public static bool DefFullSortToZip {
			get { return m_FullSortToZip; }
		}
		// Сохранять оригиналы
		public static bool DefFullSortNotDelFB2Files {
			get { return m_FullSortNotDelFB2Files; }
		}
		// Шаблон подстановки
		public static string DefFullSortTemplate {
			get { return m_FullSortTemplate; }
		}
		// Папка исходник
		public static string DefFullSortSourceDir {
			get { return m_FullSortSourceDir; }
		}
		// Папка приемник
		public static string DefFullSortTargetDir {
			get { return m_FullSortTargetDir; }
		}
		// Жанр Либрусек?
		public static bool DefFullSortFB2GenresLibrusec {
			get { return m_FullSortFB2GenresLibrusec; }
		}
		// Жанр FB2.2?
		public static bool DefFullSortFB2GenresFB22 {
			get { return m_FullSortFB2GenresFB22; }
		}
		#endregion
		// =====================================================================================================
		// 									Настройки Избранной сортировки
		// =====================================================================================================
		#region Настройки Избранной сортировки
		// Обрабатывать подкаталоги
		public static bool DefSelScanSubDirs {
			get { return m_SelSortScanSubDirs; }
		}
		// Архивировать в zip
		public static bool DefSelToZip {
			get { return m_SelSortToZip; }
		}
		// Сохранять оригиналы
		public static bool DefSelNotDelFB2Files {
			get { return m_SelSortNotDelFB2Files; }
		}
		// Шаблон подстановки
		public static string DefSelSortTemplate {
			get { return m_SelSortTemplate; }
		}
		// Папка исходник
		public static string DefSelSortSourceDir {
			get { return m_SelSortSourceDir; }
		}
		// Папка приемник
		public static string DefSelSortTargetDir {
			get { return m_SelSortTargetDir; }
		}
		// Жанр Либрусек?
		public static bool DefSelSortFB2GenresLibrusec {
			get { return m_SelSortFB2GenresLibrusec; }
		}
		// Жанр FB2.2?
		public static bool DefSelSortFB2GenresFB22 {
			get { return m_SelSortFB2GenresFB22; }
		}
		#endregion
		
		// =====================================================================================================
		// 									Настройки Избранной сортировки
		// =====================================================================================================
		#region Настройки Избранной сортировки
		// Обрабатывать подкаталоги
		public static bool DefSelSortSubDirs {
			get { return m_SelSortScanSubDirs; }
		}
		// Архивировать в zip
		public static bool DefSelSortToZip {
			get { return m_SelSortToZip; }
		}
		// Сохранять оригиналы
		public static bool DefSelSortNotDelFB2Files {
			get { return m_SelSortNotDelFB2Files; }
		}
		#endregion
		
		// =====================================================================================================
		// 									основные опции Сортировщиков
		// =====================================================================================================
		#region основные опции Сортировщиков
		// отображение прогресса
		public static bool DefProgress {
			get { return m_Progress; }
		}
		// транслитерация имен файлов
		public static bool DefTranslit {
			get { return m_Translit; }
		}
		// 'Строгие' имена файлов
		public static bool DefStrict {
			get { return m_Strict; }
		}
		// Обработка пробелов
		public static Int16 DefSpace {
			get { return m_Space; }
		}
		// обработка файлов с одинаковыми именами
		public static Int16 DefFileExist {
			get { return m_FileExist; }
		}
		// регистр имени файла: как есть
		public static bool DefRegisterAsIs {
			get { return m_RegisterAsIs; }
		}
		// регистр имени файла: Каждое Слово С Большой Буквы
		public static bool DefRegisterAsSentence {
			get { return m_RegisterAsSentence; }
		}
		// регистр имени файла: строчные буквы
		public static bool DefRegisterLower {
			get { return m_RegisterLower; }
		}
		// регистр имени файла: ПРОПИСНЫЕ БУКВЫ
		public static bool DefRegisterUpper {
			get { return m_RegisterUpper; }
		}
		// Сортировка файлов: любые fb2 файлы
		public static bool DefAllFB2 {
			get { return m_AllFB2; }
		}
		// Сортировка файлов: только валидные файлы
		public static bool DefOnlyValidFB2 {
			get { return m_OnlyValidFB2; }
		}
		// Раскладка файлов по папкам: Жанры: по первому жанру
		public static bool DefGenreOne {
			get { return m_GenreOne; }
		}
		// Раскладка файлов по папкам: Жанры: по всем жанрам
		public static bool DefGenreAll {
			get { return m_GenreAll; }
		}
		// Раскладка файлов по папкам: Авторы: по первому автору
		public static bool DefAuthorOne {
			get { return m_AuthorOne; }
		}
		// Раскладка файлов по папкам: Авторы: по всем авторам
		public static bool DefAuthorAll {
			get { return m_AuthorAll; }
		}
		// Раскладка файлов по папкам: Вид папки-жанра: как в схеме
		public static bool DefGenreSchema {
			get { return m_GenreSchema; }
		}
		// Раскладка файлов по папкам: Вид папки-жанра: расшифровано
		public static bool DefGenreText {
			get { return m_GenreText; }
		}
		#endregion
		// =====================================================================================================
		// 									папки для "проблемных" файлов
		// =====================================================================================================
		#region папки для "проблемных" файлов
		// 'Не читаемые' fb2 файлы
		public static string DefNotReadDir {
			get { return m_NotReadDir; }
		}
		// fb2 c длинными путями
		public static string DefLongPathDir {
			get { return m_LongPathDir; }
		}
		// Не валидные fb2 файлы
		public static string DefNotValidDir {
			get { return m_NotValidDir; }
		}
		// 'Битые' fb2 архивы, не fb2 архивы
		public static string DefArchNotOpenDir {
			get { return m_ArchNotOpenDir; }
		}
		#endregion
		// =====================================================================================================
		// 								названия папок для шаблонных тэгов без данных
		// =====================================================================================================
		#region названия папок для шаблонных тэгов без данных
		// _Нестандартные Жанры
		public static string DefNoGenreGroup {
			get { return m_NoGenreGroup; }
		}
		// Жанра Нет
		public static string DefNoGenre {
			get { return m_NoGenre; }
		}
		// Языка Книги Нет
		public static string DefNoLang {
			get { return m_NoLang; }
		}
		// Имени Автора Нет
		public static string DefNoFirstName {
			get { return m_NoFirstName; }
		}
		// Отчества Автора Нет
		public static string DefNoMiddleName {
			get { return m_NoMiddleName; }
		}
		// Фамилия Автора Нет
		public static string DefNoLastName {
			get { return m_NoLastName; }
		}
		// Ника Автора Нет
		public static string DefNoNickName {
			get { return m_NoNickName; }
		}
		// Названия Книги Нет
		public static string DefNoBookTitle {
			get { return m_NoBookTitle; }
		}
		// Серии Нет
		public static string DefNoSequence {
			get { return m_NoSequence; }
		}
		// Номера Серии Нет
		public static string DefNoNSequence {
			get { return m_NoNSequence; }
		}
		// Даты (Текст) Нет
		public static string DefNoDateText {
			get { return m_NoDateText; }
		}
		// Даты (Значение) Нет
		public static string DefNoDateValue {
			get { return m_NoDateValue; }
		}
		// Года издания Нет
		public static string DefNoYear {
			get { return m_NoYear; }
		}
		// Издательства Нет
		public static string DefNoPublisher {
			get { return m_NoPublisher; }
		}
		// Города Издания Нет
		public static string DefNoCity {
			get { return m_NoCity; }
		}
		// Имени fb2-создателя Нет
		public static string DefNoFB2FirstName {
			get { return m_NoFB2FirstName; }
		}
		// Отчества fb2-создателя Нет
		public static string DefNoFB2MiddleName {
			get { return m_NoFB2MiddleName; }
		}
		// Фамилия fb2-создателя Нет
		public static string DefNoFB2LastName {
			get { return m_NoFB2LastName; }
		}
		// Ника fb2-создателя Нет
		public static string DefNoFB2NickName {
			get { return m_NoFB2NickName; }
		}
		#endregion
		// =====================================================================================================
		// 										название Групп Жанров
		// =====================================================================================================
		#region название Групп Жанров
		// Фантастика, Фэнтэзи
		public static string DefGenresGroupSf {
			get { return m_sf; }
		}
		// Детективы, Боевики
		public static string DefGenresGroupDetective {
			get { return m_detective; }
		}
		// Проза
		public static string DefGenresGroupProse {
			get { return m_prose; }
		}
		// Любовные романы
		public static string DefGenresGroupLove {
			get { return m_love; }
		}
		// Приключения
		public static string DefGenresGroupAdventure {
			get { return m_adventure; }
		}
		// Детское
		public static string DefGenresGroupChildren {
			get { return m_children; }
		}
		// Поэзия, Драматургия
		public static string DefGenresGroupPoetry {
			get { return m_poetry; }
		}
		// Старинное
		public static string DefGenresGroupAntique {
			get { return m_antique; }
		}
		// Наука, Образование
		public static string DefGenresGroupScience {
			get { return m_science; }
		}
		// Компьютеры
		public static string DefGenresGroupComputers {
			get { return m_computers; }
		}
		// Справочники
		public static string DefGenresGroupReference {
			get { return m_reference; }
		}
		// Документальное
		public static string DefGenresGroupNonfiction {
			get { return m_nonfiction; }
		}
		// Религия
		public static string DefGenresGroupReligion {
			get { return m_religion; }
		}
		// Юмор
		public static string DefGenresGroupHumor {
			get { return m_humor; }
		}
		// Дом, Семья
		public static string DefGenresGroupHome {
			get { return m_home; }
		}
		// Бизнес
		public static string DefGenresGroupBusiness {
			get { return m_business; }
		}
		// Техника
		public static string DefGenresGroupTech {
			get { return m_tech; }
		}
		// Военное дело
		public static string DefGenresGroupMilitary {
			get { return m_military; }
		}
		// Фольклор
		public static string DefGenresGroupFolklore {
			get { return m_folklore; }
		}
		// Прочее
		public static string DefGenresGroupOther {
			get { return m_other; }
		}
		#endregion
		
		// =====================================================================================================
		// 					Открытые статические ОБЩИЕ свойства класса для чтения отдельных настроек
		// =====================================================================================================
		#region Открытые статические ОБЩИЕ свойства класса для чтения отдельных настроек
		// =====================================================================================================
		// 									Настройки Полной сортировки
		// =====================================================================================================
		#region Настройки Полной сортировки
		public static string ReadFullSortTemplate() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/FullSorting/Template");
				if(node != null)
					return node.InnerText;
			}
			return DefFullSortTemplate;
		}
		public static string ReadFullSortSourceDir() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/FullSorting/SourceDir");
				if(node != null)
					return node.InnerText;
			}
			return DefFullSortSourceDir;
		}
		public static string ReadFullSortTargetDir() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/FullSorting/TargetDir");
				if(node != null)
					return node.InnerText;
			}
			return DefFullSortTargetDir;
		}
		public static bool ReadFullSortFB2GenresLibrusec() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/FullSorting/FB2Genres");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("Librusec").InnerText );
				}
			}
			return DefFullSortFB2GenresLibrusec;
		}
		public static bool ReadFullSortFB2GenresFB22() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/FullSorting/FB2Genres");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("FB22").InnerText );
				}
			}
			return DefFullSortFB2GenresFB22;
		}
		
		public static bool ReadFullSortScanSubDirs() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/FullSorting/Options/ScanSubDirs");
				if(node != null)
					return Convert.ToBoolean( node.InnerText );
			}
			return DefFullSortSubDirs;
		}
		public static bool ReadFullSortToZip() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/FullSorting/Options/ToZip");
				if(node != null)
					return Convert.ToBoolean( node.InnerText );
			}
			return DefFullSortToZip;
		}
		public static bool ReadFullSortNotDelFB2Files() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/FullSorting/Options/NotDelFB2Files");
				if(node != null)
					return Convert.ToBoolean( node.InnerText );
			}
			return DefFullSortNotDelFB2Files;
		}
		#endregion
		// =====================================================================================================
		// 									Настройки Избранной сортировки
		// =====================================================================================================
		#region Настройки Избранной сортировки
		public static string ReadSelSortTemplate() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/SelectedSorting/Template");
				if(node != null)
					return node.InnerText;
			}
			return DefSelSortTemplate;
		}
		public static string ReadSelSortSourceDir() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/SelectedSorting/SourceDir");
				if(node != null)
					return node.InnerText;
			}
			return DefSelSortSourceDir;
		}
		public static string ReadSelSortTargetDir() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/SelectedSorting/TargetDir");
				if(node != null)
					return node.InnerText;
			}
			return DefSelSortTargetDir;
		}
		public static bool ReadSelSortFB2GenresLibrusec() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/SelectedSorting/FB2Genres");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("Librusec").InnerText );
				}
			}
			return DefSelSortFB2GenresLibrusec;
		}
		public static bool ReadSelSortFB2GenresFB22() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/SelectedSorting/FB2Genres");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("FB22").InnerText );
				}
			}
			return DefSelSortFB2GenresFB22;
		}
		
		public static bool ReadSelSortScanSubDirs() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/SelectedSorting/Options/ScanSubDirs");
				if(node != null)
					return Convert.ToBoolean( node.InnerText );
			}
			return DefSelSortSubDirs;
		}
		public static bool ReadSelSortToZip() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/SelectedSorting/Options/ToZip");
				if(node != null)
					return Convert.ToBoolean( node.InnerText );
			}
			return DefSelSortToZip;
		}
		public static bool ReadSelSortNotDelFB2Files() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/SelectedSorting/Options/NotDelFB2Files");
				if(node != null)
					return Convert.ToBoolean( node.InnerText );
			}
			return DefSelSortNotDelFB2Files;
		}
		#endregion
		
		// =====================================================================================================
		// 									основные опции Сортировщиков
		// =====================================================================================================
		#region основные опции Сортировщиков
		// Отображение прогресса
		public static bool ReadProgress() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/Log/Progress");
				if(node != null)
					return Convert.ToBoolean( node.InnerText );
			}
			return DefProgress;
		}
		// Регистр имени файла: как есть
		public static bool ReadRegisterAsIs() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/Register");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("AsIs").InnerText );
				}
			}
			return DefRegisterAsIs;
		}
		// Регистр имени файла: строчные буквы
		public static bool ReadRegisterLower() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/Register");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("Lower").InnerText );
				}
			}
			return DefRegisterLower;
		}
		// Регистр имени файла: ПРОПИСНЫЕ БУКВЫ
		public static bool ReadRegisterUpper() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/Register");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("Upper").InnerText );
				}
			}
			return DefRegisterUpper;
		}
		// Регистр имени файла:Каждое Слово С Большой Буквы
		public static bool ReadRegisterAsSentence() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/Register");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("AsSentence").InnerText );
				}
			}
			return DefRegisterAsSentence;
		}
		
		// возврат 0 - КАК есть; 2 - строчные; 3 - ПРОПИСНЫЕ; 3 - Все Слова С Большой Буквы; 
		public static int ReadRegister() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/Register");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					if( Convert.ToBoolean( attrs.GetNamedItem("AsIs").InnerText ) )
						return 0;
					else if ( Convert.ToBoolean( attrs.GetNamedItem("Lower").InnerText ) )
						return 1;
					else if ( Convert.ToBoolean( attrs.GetNamedItem("Upper").InnerText ) )
						return 2;
					else if ( Convert.ToBoolean( attrs.GetNamedItem("AsSentence").InnerText ) )
						return 3;
				}
			}
			return 0;
		}
		
		// Транслитерация имен файлов
		public static bool ReadTranslit() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/Translit");
				if(node != null)
					return Convert.ToBoolean( node.InnerText );
			}
			return DefTranslit;
		}
		// 'Строгие' имена файлов: алфавитно-цифровые символы, а так же [](){}-_
		public static bool ReadStrict() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/Strict");
				if(node != null)
					return Convert.ToBoolean( node.InnerText );
			}
			return DefStrict;
		}
		// Обработка пробелов
		public static int ReadSpaceProcess() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/Space");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToInt16( attrs.GetNamedItem("index").InnerText );
				}
			}
			return DefSpace;
		}
		// Одинаковые файлы
		public static int ReadFileExist() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/FileExistMode");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToInt16( attrs.GetNamedItem("index").InnerText );
				}
			}
			return DefFileExist;
		}
		// Сортировка файлов: все fb2
		public static bool ReadSortAllFB2() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/SortType");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("AllFB2").InnerText );
				}
			}
			return DefAllFB2;
		}
		// Сортировка файлов: только валидные
		public static bool ReadSortOnlyValidFB2() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/SortType");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("OnlyValidFB2").InnerText );
				}
			}
			return DefOnlyValidFB2;
		}
		
		// Раскладка файлов по папкам: По 1-му Автору
		public static bool ReadAuthorOne() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/FilesToDirs/AuthorsToDirs");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("AuthorOne").InnerText );
				}
			}
			return DefAuthorOne;
		}
		// Раскладка файлов по папкам: По всем Авторам
		public static bool ReadAuthorAll() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/FilesToDirs/AuthorsToDirs");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("AuthorAll").InnerText );
				}
			}
			return DefAuthorAll;
		}
		
		// Раскладка файлов по папкам: По 1-му Жанрам
		public static bool ReadGenreOne() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/FilesToDirs/GenresToDirs");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("GenreOne").InnerText );
				}
			}
			return DefGenreOne;
		}
		// Раскладка файлов по папкам: По всем Жанрам
		public static bool ReadGenreAll() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/FilesToDirs/GenresToDirs");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("GenreAll").InnerText );
				}
			}
			return DefGenreAll;
		}
		
		// Раскладка файлов по папкам: Вид папки-Жанра - схема
		public static bool ReadGenreSchema() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/FilesToDirs/GenresType");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("GenreSchema").InnerText );
				}
			}
			return DefGenreSchema;
		}
		// Раскладка файлов по папкам: Вид папки-Жанра - расшифрованный текст
		public static bool ReadGenreText() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/General/FilesToDirs/GenresType");
				if(node != null) {
					XmlAttributeCollection attrs = node.Attributes;
					return Convert.ToBoolean( attrs.GetNamedItem("GenreText").InnerText );
				}
			}
			return DefGenreText;
		}
		#endregion
		// =====================================================================================================
		// 								названия папок для шаблонных тэгов без данных
		// =====================================================================================================
		#region названия папок для шаблонных тэгов без данных
		// данные о книге
		public static string ReadFMNoGenreGroup() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/BookInfo/NoGenreGroup");
				if(node != null)
					return node.InnerText;
			}
			return DefNoGenreGroup;
		}
		public static string ReadFMNoGenre() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/BookInfo/NoGenre");
				if(node != null)
					return node.InnerText;
			}
			return DefNoGenre;
		}
		public static string ReadFMNoLang() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/BookInfo/NoLang");
				if(node != null)
					return node.InnerText;
			}
			return DefNoLang;
		}
		public static string ReadFMNoFirstName() {
			if( File.Exists( FileManagerSettingsPath ) ) {
				m_xmlDoc.Load( FileManagerSettingsPath );
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/BookInfo/NoFirstName");
				if(node != null)
					return node.InnerText;
			}
			return DefNoFirstName;
		}
		public static string ReadFMNoMiddleName() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/BookInfo/NoMiddleName");
				if(node != null)
					return node.InnerText;
			}
			return DefNoMiddleName;
		}
		public static string ReadFMNoLastName() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/BookInfo/NoLastName");
				if(node != null)
					return node.InnerText;
			}
			return DefNoLastName;
		}
		public static string ReadFMNoNickName() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/BookInfo/NoNickName");
				if(node != null)
					return node.InnerText;
			}
			return DefNoNickName;
		}
		public static string ReadFMNoBookTitle() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/BookInfo/NoBookTitle");
				if(node != null)
					return node.InnerText;
			}
			return DefNoBookTitle;
		}
		public static string ReadFMNoSequence() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/BookInfo/NoSequence");
				if(node != null)
					return node.InnerText;
			}
			return DefNoSequence;
		}
		public static string ReadFMNoNSequence() {
			if( m_xmlDoc != null ) {
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/BookInfo/NoNSequence");
				if(node != null)
					return node.InnerText;
			}
			return DefNoNSequence;
		}
		public static string ReadFMNoDateText() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/BookInfo/NoDateText");
				if(node != null)
					return node.InnerText;
			}
			return DefNoDateText;
		}
		public static string ReadFMNoDateValue() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/BookInfo/NoDateValue");
				if(node != null)
					return node.InnerText;
			}
			return DefNoDateValue;
		}
		// Издательство
		public static string ReadFMNoPublisher() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/PublishInfo/NoPublisher");
				if(node != null)
					return node.InnerText;
			}
			return DefNoPublisher;
		}
		public static string ReadFMNoYear() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/PublishInfo/NoYear");
				if(node != null)
					return node.InnerText;
			}
			return DefNoYear;
		}
		public static string ReadFMNoCity() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/PublishInfo/NoCity");
				if(node != null)
					return node.InnerText;
			}
			return DefNoCity;
		}
		// данные о создателе fb2-файле
		public static string ReadFMNoFB2FirstName() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/FB2Info/NoFB2FirstName");
				if(node != null)
					return node.InnerText;
			}
			return DefNoFB2FirstName;
		}
		public static string ReadFMNoFB2MiddleName() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/FB2Info/NoFB2MiddleName");
				if(node != null)
					return node.InnerText;
			}
			return DefNoFB2MiddleName;
		}
		public static string ReadFMNoFB2LastName() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/FB2Info/NoFB2LastName");
				if(node != null)
					return node.InnerText;
			}
			return DefNoFB2LastName;
		}
		public static string ReadFMNoFB2NickName() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/NoTags/FB2Info/NoFB2NickName");
				if(node != null)
					return node.InnerText;
			}
			return DefNoFB2NickName;
		}
		#endregion
		// =====================================================================================================
		// 										название Групп Жанров
		// =====================================================================================================
		#region название Групп Жанров
		public static string ReadFMSf() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/sf");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupSf;
		}
		public static string ReadFMDetective() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/detective");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupDetective;
		}
		public static string ReadFMProse() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/prose");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupProse;
		}
		public static string ReadFMLove() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/love");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupLove;
		}
		public static string ReadFMAdventure() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/adventure");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupAdventure;
		}
		public static string ReadFMChildren() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/children");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupChildren;
		}
		public static string ReadFMPoetry() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/poetry");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupPoetry;
		}
		public static string ReadFMAntique() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/antique");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupAntique;
		}
		public static string ReadFMScience() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/science");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupScience;
		}
		public static string ReadFMComputers() {
			if( m_xmlDoc != null ) {
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/computers");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupComputers;
		}
		public static string ReadFMReference() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/reference");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupReference;
		}
		public static string ReadFMNonfiction() {
			if( m_xmlDoc != null ) {
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/nonfiction");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupNonfiction;
		}
		public static string ReadFMReligion() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/religion");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupReligion;
		}
		public static string ReadFMHumor() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/humor");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupHumor;
		}
		public static string ReadFMHome() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/home");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupHome;
		}
		public static string ReadFMBusiness() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/business");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupBusiness;
		}
		public static string ReadFMTech() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/tech");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupTech;
		}
		public static string ReadFMMilitary() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/military");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupMilitary;
		}
		public static string ReadFMFolklore() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/folklore");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupFolklore;
		}
		public static string ReadFMOther() {
			if(File.Exists(m_FileSettingsPath)) {
				m_xmlDoc.Load(m_FileSettingsPath);
				XmlNode node = m_xmlDoc.SelectSingleNode("Settings/CommonOptions/GenreGroups/other");
				if(node != null)
					return node.InnerText;
			}
			return DefGenresGroupOther;
		}
		#endregion
		#endregion
		
		#endregion
	}
}