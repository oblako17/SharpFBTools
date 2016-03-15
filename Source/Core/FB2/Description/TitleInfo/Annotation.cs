﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 28.04.2009
 * Time: 11:14
 * 
 * License: GPL 2.1
 */
using System;

namespace Core.FB2.Description.TitleInfo
{
	/// <summary>
	/// Description of Annotation.
	/// </summary>
	public class Annotation : IAnnotationType
	{
		#region Закрытые данные класса
        private string m_sValue	= null;
		private string m_sId	= null;
        private string m_sLang	= null;
        #endregion
		
		#region Конструкторы класса
        public Annotation()
		{
		}
		public Annotation( string sValue, string sId, string sLang )
        {
            m_sValue	= sValue.Trim();
			m_sId		= sId.Trim();
            m_sLang		= sLang.Trim();
        }
		public Annotation( string sValue, string sId )
        {
            m_sValue	= sValue.Trim();
			m_sId		= sId.Trim();
			m_sLang		= null;
        }
        #endregion
        
        #region Открытые свойства класса - атрибуты fb2-элементов
		public virtual string Id {
            get { return m_sId.Trim(); }
            set { m_sId = value.Trim(); }
        }

        public virtual string Lang {
            get { return m_sLang.Trim(); }
            set { m_sLang = value.Trim(); }
        }
        #endregion
        
        #region Открытые свойства класса - элементы fb2-элементов
        public virtual string Value {
            get { return m_sValue.Trim(); }
            set { m_sValue = value.Trim(); }
        }
        #endregion
	}
}
