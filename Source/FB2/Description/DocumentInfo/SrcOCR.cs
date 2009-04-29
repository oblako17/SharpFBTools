﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 28.04.2009
 * Time: 14:55
 * 
 * License: GPL 2.1
 */
using System;
using FB2.Description.Common;

namespace FB2.Description.DocumentInfo
{
	/// <summary>
	/// Description of SrcOCR.
	/// </summary>
	public class SrcOCR : TextFieldType
	{
		#region Конструкторы класса
		public SrcOCR()
		{
		}
		public SrcOCR( string sValue, string sLang ) :
			base( sValue, sLang )
        {
        }
		public SrcOCR( string sValue ) :
			base( sValue )
        {
        }
		#endregion
	}
}