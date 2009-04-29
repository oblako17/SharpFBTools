﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 29.04.2009
 * Time: 14:09
 * 
 * License: GPL 2.1
 */
using System;
using System.Collections.Generic;
using FB2.Common;

namespace FB2.Description.Common
{
	/// <summary>
	/// Description of IAuthorType.
	/// </summary>
	public interface IAuthorType
	{
		AuthorNameElement FirstName { get; set; }
        AuthorNameElement MiddleName { set; get; }
        AuthorNameElement LastName { get; set; }
        AuthorNameElement NickName { set; get; }
        IList<string> HomePages { set; get; }
        IList<string> Emails { set; get; }
        string ID { set; get; }
	}
}
