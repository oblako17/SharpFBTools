﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 28.04.2009
 * Time: 14:49
 * 
 * License: GPL 2.1
 */
using System;
using FB2.Common;

namespace FB2.Description.PublishInfo
{
	/// <summary>
	/// Description of Publisher.
	/// </summary>
	public class Publisher : IAttrLang
	{
		#region Закрытые данные класса
		private string m_sText	= "";
		private string m_sLang	= "";
		#endregion
		
		#region Конструкторы класса
		public Publisher()
		{
			m_sText	= "";
        	m_sLang	= "";
		}
		public Publisher( string sText, string sLang )
        {
            m_sText	= sText;
        	m_sLang	= sLang;
        }
        public Publisher( string sText )
        {
            m_sText	= sText;
        	m_sLang	= "";
        }
		#endregion
		
		#region Открытые свойства класса - атрибуты fb2-элементов
		public virtual string Lang {
            get { return m_sLang; }
            set { m_sLang = value; }
        }
		#endregion
		
		#region Открытые свойства класса - элементы fb2-элементов
        public virtual string Text {
            get { return m_sText; }
            set { m_sText = value; }
        }
        #endregion
	}
}
