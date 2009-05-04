﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 04.05.2009
 * Time: 11:30
 * 
 * License: GPL 2.1
 */
using System;
using System.Collections.Generic;

namespace FilesWorker
{
	public class TP {
		private string m_sLexem			= "";
		private bool m_bIsConditional	= false;
		public TP()
		{
		}
		public TP( string sLexem, bool bIsConditional )
		{
			m_sLexem			= sLexem;
			m_bIsConditional	= bIsConditional;
		}
		public virtual string Lexem {
            get { return m_sLexem; }
        }
		public virtual bool IsConditional {
            get { return m_bIsConditional; }
        }
	}
	/// <summary>
	/// Description of TemplatesParser.
	/// </summary>
	public class TemplatesParser
	{
		public TemplatesParser()
		{
		}
		
		private static string GetTemplateLexem( string sLine, char cRChar ) {
			// выделение лексемы для символа cRChar с начала строки sLine
			int n = sLine.IndexOf( cRChar );
			return ( n > 0 ? sLine.Substring( 0, n+1 )
			        		: sLine.Substring( 0, sLine.Length ) );
			
		}
		private static string GetSymbolsLexem( string sLine ) {
			// выделение лексемы с начала строки sLine до (,[ или *. Порядок поиска важен!
			int n = sLine.IndexOf( '(' );
			if( n!=-1 ) {
				return sLine.Substring( 0, n );
			}
			n = sLine.IndexOf( '[' );
			if( n!=-1 ) {
				return sLine.Substring( 0, n );
			}
			n = sLine.IndexOf( '*' );
			if( n!=-1 ) {
				return sLine.Substring( 0, n );
			}
			return sLine.Substring( 0, sLine.Length );
		}
		
		public static List<string> GetLexems( string sLine ) {
			// разбивка строки на лексемы для дальнейшего анализа
			if( sLine==null || sLine=="" ) return null;
			string sTemp = sLine;
			List<string> ls = new List<string>();
			string s = "";
			while( sTemp.Length!=0 ) {
				if( sTemp[0]=='[' ) {
					s =  GetTemplateLexem( sTemp, ']' );
					sTemp = sTemp.Remove( 0, s.Length );
				} else if( sTemp[0]=='(' ) {
					s =  GetTemplateLexem( sTemp, ')' );
					sTemp = sTemp.Remove( 0, s.Length );
				} else if( sTemp[0]=='*' ) {
					s =  GetTemplateLexem( sTemp, '*' );
					sTemp = sTemp.Remove( 0, s.Length );
				} else {
					s =  GetSymbolsLexem( sTemp );
					sTemp = sTemp.Remove( 0, s.Length );
				}
				ls.Add( s );
			}
			
			return ls;
		}
		
		
/*		private static string GetTemplateLexem( string sLine, char cRChar ) {
			// выделение лексемы для символа cRChar с начала строки sLine
			int n = sLine.IndexOf( cRChar );
			return ( n > 0 ? sLine.Substring( 1, n-1 )
			        		: sLine.Substring( 0, sLine.Length ) );
			
		}
		private static string GetSymbolsLexem( string sLine ) {
			// выделение лексемы с начала строки sLine до (,[ или *. Порядок поиска важен!
			int n = sLine.IndexOf( '(' );
			if( n!=-1 ) {
				return sLine.Substring( 0, n );
			}
			n = sLine.IndexOf( '[' );
			if( n!=-1 ) {
				return sLine.Substring( 0, n );
			}
			n = sLine.IndexOf( '*' );
			if( n!=-1 ) {
				return sLine.Substring( 0, n );
			}
			return sLine.Substring( 0, sLine.Length );
		}
		
		public static List<string> GetLexems( string sLine ) {
			// разбивка строки на лексемы для дальнейшего анализа
			if( sLine==null || sLine=="" ) return null;
			string sTemp = sLine;
			List<string> ls = new List<string>();
			List<TP> ltp = new List<TP>();
			string s = "";
			while( sTemp.Length!=0 ) {
				if( sTemp[0]=='[' ) {
					s =  GetTemplateLexem( sTemp, ']' );
					List<TP> t = GetLexemsType( s, true );
					ltp.AddRange( t );
					sTemp = ( s.Length<sTemp.Length ? sTemp.Remove( 0, s.Length+2 )
					         						: sTemp.Remove( 0, s.Length ) );
				} else if( sTemp[0]=='(' ) {
					s =  GetTemplateLexem( sTemp, ')' );
					ltp.AddRange( GetLexemsType( s, false ) );
					sTemp = ( s.Length<sTemp.Length ? sTemp.Remove( 0, s.Length+2 )
					         						: sTemp.Remove( 0, s.Length ) );
				} else if( sTemp[0]=='*' ) {
					s =  GetTemplateLexem( sTemp, '*' );
					ltp.AddRange( GetLexemsType( s, false ) );
					sTemp = ( s.Length<sTemp.Length ? sTemp.Remove( 0, s.Length+2 )
					         						: sTemp.Remove( 0, s.Length ) );
				} else {
					s =  GetSymbolsLexem( sTemp );
					ltp.AddRange( GetLexemsType( s, false ) );
					sTemp = sTemp.Remove( 0, s.Length );
				}
				ls.Add( s );
			}
			
			return ls;
		}
		
		public static List<TP> GetLexemsType( string sLine, bool bIsConditional ) {
			// разбивка строки на лексемы для дальнейшего анализа
			if( sLine==null || sLine=="" ) return null;
			string sTemp = sLine;
			List<TP> ltp = new List<TP>();
			string s = "";
			while( sTemp.Length!=0 ) {
				if( sTemp[0]=='[' ) {
					s =  GetTemplateLexem( sTemp, ']' );
					ltp.Add( new TP( s, bIsConditional ) );
					sTemp = ( s.Length<sTemp.Length ? sTemp.Remove( 0, s.Length+2 )
					         						: sTemp.Remove( 0, s.Length ) );
				} else if( sTemp[0]=='(' ) {
					s =  GetTemplateLexem( sTemp, ')' );
					ltp.Add( new TP( s, bIsConditional ) );
					sTemp = ( s.Length<sTemp.Length ? sTemp.Remove( 0, s.Length+2 )
					         						: sTemp.Remove( 0, s.Length ) );
				} else if( sTemp[0]=='*' ) {
					s =  GetTemplateLexem( sTemp, '*' );
					ltp.Add( new TP( s, bIsConditional ) );
					sTemp = ( s.Length<sTemp.Length ? sTemp.Remove( 0, s.Length+2 )
					         						: sTemp.Remove( 0, s.Length ) );
				} else {
					s =  GetSymbolsLexem( sTemp );
					ltp.Add( new TP( s, bIsConditional ) );
					sTemp = sTemp.Remove( 0, s.Length );
				}
			}
			return ltp;
		}
		
		public static List<string> GetLexems1( string sLine ) {
			if( sLine.IndexOf( '[' )==-1 ) return null;
			List<string> ls = new List<string>();
			for( int i=0; i!=sLine.Length; ++i ) {
				string s = "";
				if(sLine[i]!='[' ) {
					s += sLine[i];
				} else {
					if( s!="" ) ls.Add( s );
					for( int j=i; j!=sLine.Length; ++j ) {
						s += sLine[j];
						if( sLine[j]==']' ) {
							ls.Add( s );
							break;
						}
					}
				}
			}
			return ls;
		}*/
		
	}
}


/*
		private static string GetTemplateLexem( string sLine, char cRChar ) {
			// выделение лексемы для символа cRChar с начала строки sLine
			int n = sLine.IndexOf( cRChar );
			return ( n > 0 ? sLine.Substring( 0, n+1 )
			        		: sLine.Substring( 0, sLine.Length ) );
			
		}
		private static string GetSymbolsLexem( string sLine ) {
			// выделение лексемы с начала строки sLine до (,[ или *. Порядок поиска важен!
			int n = sLine.IndexOf( '(' );
			if( n!=-1 ) {
				return sLine.Substring( 0, n );
			}
			n = sLine.IndexOf( '[' );
			if( n!=-1 ) {
				return sLine.Substring( 0, n );
			}
			n = sLine.IndexOf( '*' );
			if( n!=-1 ) {
				return sLine.Substring( 0, n );
			}
			return sLine.Substring( 0, sLine.Length );
		}
		
		public static List<string> GetLexems( string sLine ) {
			// разбивка строки на лексемы для дальнейшего анализа
			if( sLine==null || sLine=="" ) return null;
			string sTemp = sLine;
			List<string> ls = new List<string>();
			string s = "";
			while( sTemp.Length!=0 ) {
				if( sTemp[0]=='[' ) {
					s =  GetTemplateLexem( sTemp, ']' );
					sTemp = sTemp.Remove( 0, s.Length );
				} else if( sTemp[0]=='(' ) {
					s =  GetTemplateLexem( sTemp, ')' );
					sTemp = sTemp.Remove( 0, s.Length );
				} else if( sTemp[0]=='*' ) {
					s =  GetTemplateLexem( sTemp, '*' );
					sTemp = sTemp.Remove( 0, s.Length );
				} else {
					s =  GetSymbolsLexem( sTemp );
					sTemp = sTemp.Remove( 0, s.Length );
				}
				ls.Add( s );
			}
			
			return ls;
		}
 * */