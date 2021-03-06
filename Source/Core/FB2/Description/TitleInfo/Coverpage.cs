﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 28.04.2009
 * Time: 16:56
 * 
 * License: GPL 2.1
 */
using System;

namespace Core.FB2.Description.TitleInfo
{
	/// <summary>
	/// Description of Coverpage.
	/// </summary>
	public class Coverpage
	{
		#region Закрытые данные класса
        private string m_sValue	= null;
        #endregion
        
		#region Конструкторы класса
        public Coverpage()
		{
        	m_sValue = null;
		}
        public Coverpage( string sValue )
		{
        	m_sValue = !string.IsNullOrEmpty(sValue) ? sValue.Trim() : null;
		}
        #endregion
        
		#region Открытые свойства класса - элементы fb2-элементов
        public virtual string Value {
            get { return !string.IsNullOrEmpty(m_sValue) ? m_sValue.Trim() : null; }
			set { m_sValue = !string.IsNullOrEmpty(value) ? value.Trim() : value; }
        }
        #endregion
	}
}
