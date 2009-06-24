﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 24.06.2009
 * Time: 15:53
 * 
 * License: GPL 2.1
 */
using System;

namespace SharpFBTools.Tools
{
	/// <summary>
	/// Description of SelectedSortQueryCriteria.
	/// </summary>
	public class SelectedSortQueryCriteria
	{
		#region Закрытые члены класса
		private string m_Lang	= "";
		private string m_Last	= "";
		private string m_First	= "";
		private string m_Middle	= "";
		private string m_Nick	= "";
		private string m_GenresGroup	= "";
		private string m_Genre			= "";
		private string m_Sequence		= "";
		#endregion
		
		public SelectedSortQueryCriteria()
		{
		}
		public SelectedSortQueryCriteria( string sLang,
		                                 string sLast, string sFirst, string sMiddle, string sNick,
		                                 string sGenresGroup, string sGenre, string sSequence )
		{
			m_Lang		= sLang;
			m_Last		= sLast;
			m_First		= sFirst;
			m_Middle	= sMiddle;
			m_Nick		= sNick;
			m_GenresGroup	= sGenresGroup;
			m_Genre			= sGenre;
			m_Sequence		= sSequence;
		}
		
		#region Свойства класса
		public virtual string Lang {
			get { return m_Lang; }
			set { m_Lang = value; }
        }
		public virtual string LastName {
			get { return m_Last; }
			set { m_Last = value; }
        }
		public virtual string FirstName {
			get { return m_First; }
			set { m_First = value; }
        }
		public virtual string MiddleName {
			get { return m_Middle; }
			set { m_Middle = value; }
        }
		public virtual string NickName {
			get { return m_Nick; }
			set { m_Nick = value; }
        }
		public virtual string GenresGroup {
			get { return m_GenresGroup; }
			set { m_GenresGroup = value; }
        }
		public virtual string Genre {
			get { return m_Genre; }
			set { m_Genre = value; }
        }
		public virtual string Sequence {
			get { return m_Sequence; }
			set { m_Sequence = value; }
        }
		#endregion
	}
}
