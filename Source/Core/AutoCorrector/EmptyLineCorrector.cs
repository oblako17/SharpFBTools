﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Кузнецов Вадим (DikBSD)
 * Дата: 04.12.2015
 * Время: 14:37
 * 
 * License: GPL 2.1
 */
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Core.AutoCorrector
{
	/// <summary>
	/// Обработка пустых строк empty-line
	/// </summary>
	public class EmptyLineCorrector
	{
		private const string _MessageTitle = "Автокорректор";
		
		private string _xmlText = string.Empty;
		
		/// <summary>
		/// Конструктор класса EmptyLineCorrector
		/// </summary>
		/// <param name="xmlText">Строка для корректировки</param>
		public EmptyLineCorrector( string xmlText )
		{
			_xmlText = xmlText;
		}
		
		/// <summary>
		/// Обработка тегов empty-line
		/// </summary>
		/// <returns>Откорректированную строку типа string </returns>
		public string correct() {
			// удаление тегов <p> и </p> в структуре <p> <empty-line /> </p>
			try {
				_xmlText = Regex.Replace(
					_xmlText, @"(?:(?:<p>\s*)(?'empty'<empty-line\s*?/>)(?:\s*</p>))",
					"${empty}", RegexOptions.IgnoreCase | RegexOptions.Multiline
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление тегов <p> и </p> в структуре <p> <empty-line /> </p>.\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			// Удаление <empty-line/> между </section> и <section>
			try {
				_xmlText = Regex.Replace(
					_xmlText, @"(?<=</section>)\s*?(?:<empty-line\s*?/>\s*?){1,}\s*?(?=<section>)",
					"", RegexOptions.IgnoreCase | RegexOptions.Multiline
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление <empty-line/> между </section> и <section>.\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			// Удаление <empty-line/> между </section> и </section>
			try {
				_xmlText = Regex.Replace(
					_xmlText, @"(?<=</section>)\s*?(?:<empty-line\s*?/>\s*?){1,}\s*?(?=</section>)",
					"", RegexOptions.IgnoreCase | RegexOptions.Multiline
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление <empty-line/> между </section> и </section>.\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			// Удаление <empty-line/> между </epigraph> и </section>
			try {
				_xmlText = Regex.Replace(
					_xmlText, @"(?<=</epigraph>)\s*?(?:<empty-line\s*?/>\s*?){1,}\s*?(?=</section>)",
					"", RegexOptions.IgnoreCase | RegexOptions.Multiline
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление <empty-line/> между </epigraph> и </section>.\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			// Удаление <empty-line/> между </section> и </body>
			try {
				_xmlText = Regex.Replace(
					_xmlText, @"(?<=</section>)\s*?(?:<empty-line\s*?/>\s*?){1,}\s*?(?=</body>)",
					"", RegexOptions.IgnoreCase | RegexOptions.Multiline
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление <empty-line/> между </section> и </body>.\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			// Удаление <empty-line/> между </title> и <section>
			try {
				_xmlText = Regex.Replace(
					_xmlText, @"(?<=</title>)\s*?(?:<empty-line\s*?/>\s*?){1,}\s*?(?=<section>)",
					"", RegexOptions.IgnoreCase | RegexOptions.Multiline
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление <empty-line/> между </title> и <section>.\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			// удаление <empty-line /> из текста до тега </p>: <empty-line /></p>
			try {
				_xmlText = Regex.Replace(
					_xmlText, @"<empty-line */>\s*(?=</p>)",
					"", RegexOptions.Multiline // регистр не игнорировать!!!
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление <empty-line/> из текста до тега </p>: <empty-line /></p>.\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			// удаление <empty-line /> из текста после тега <p>: <p><empty-line />
			try {
				_xmlText = Regex.Replace(
					_xmlText, @"(?<=<p>)\s*<empty-line */>",
					"", RegexOptions.Multiline // регистр не игнорировать!!!
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление <empty-line /> из текста после тега <p>: <p><empty-line />.\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			// удаление <empty-line /> из текста внутри тегов <p> ... </p> (в перечисление не добавил <> - они работают неверно - удаляются <empty-line /> и между целыми тегами)
			try {
				_xmlText = Regex.Replace(
					_xmlText, "(?'start'(?:[-\\w\\+=\\*—,\\.\\?!:;…\"'`#&%$@«»\\(\\{\\[\\)\\}\\]])|<p>)\\s*?<empty-line *?/>\\s*?(?'end'[-\\w\\+=\\*—,\\.\\?!:;\"'`#&%$@«»\\(\\{\\[\\)\\}\\]])",
					"${start} ${end}", RegexOptions.Multiline // регистр не игнорировать!!!
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление <empty-line /> из текста внутри тегов <p> ... </p> (в перечисление не добавил <> - они работают неверно - удаляются <empty-line /> и между целыми тегами).\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			// удаление <empty-line /> из текста до тега </v>: <empty-line /></v>
			try {
				_xmlText = Regex.Replace(
					_xmlText, @"<empty-line */>\s*(?=</v>)",
					"", RegexOptions.Multiline // регистр не игнорировать!!!
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление <empty-line /> из текста до тега </v>: <empty-line /></v>.\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			// удаление <empty-line /> из текста после тега <v>: <v><empty-line />
			try {
				_xmlText = Regex.Replace(
					_xmlText, @"(?<=<v>)\s*<empty-line */>",
					"", RegexOptions.Multiline // регистр не игнорировать!!!
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление <empty-line /> из текста после тега <v>: <v><empty-line />.\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			// удаление <empty-line /> из текста до тега </stanza>: <empty-line /></stanza>
			try {
				_xmlText = Regex.Replace(
					_xmlText, @"<empty-line */>\s*(?=</stanza>)",
					"", RegexOptions.Multiline // регистр не игнорировать!!!
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление <empty-line /> из текста до тега </stanza>: <empty-line /></stanza>.\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			// удаление <empty-line /> из текста после тега <stanza>: <stanza><empty-line />
			try {
				_xmlText = Regex.Replace(
					_xmlText, @"(?<=<stanza>)\s*<empty-line */>",
					"", RegexOptions.Multiline // регистр не игнорировать!!!
				);
			} catch ( RegexMatchTimeoutException /*ex*/ ) {}
			catch ( Exception ex ) {
				if ( Settings.Settings.ShowDebugMessage ) {
					// Показывать сообщения об ошибках при падении работы алгоритмов
					MessageBox.Show(
						string.Format("EmptyLineCorrector:\r\nУдаление <empty-line /> из текста после тега <stanza>: <stanza><empty-line />.\r\nОшибка:\r\n{0}", ex.Message), _MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error
					);
				}
			}
			
			return _xmlText;
		}
	}
}
