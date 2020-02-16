//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace CultureWars.Archive.API.Upload
//{
//	public class ArchiveUploadTemplate
//	{
//		private FileInfo[] _includedFiles;


//		public DateTime AirDate { get; }

//		public Show Show { get; }

//		public string Description => $"description={Show.Value.ShowName} Archive - {AirDate:MMMM yyyy}".HTMLEncode();
//		//Ron%20and%20Fez%20Archive%20-%20April%202003"

//		private string HostList => $"{Show.Value.Hosts.Aggregate("", (current, host) => current + $"{host}, ")}";

//		public string Subject => $"subject={Show.Value.Acronym}, {Show.Value.ShowName}, {HostList}Comedy, Radio".HTMLEncode();
//		//&subject=R&F%2C%20Ron%20and%20Fez%2C%20Ron%2C%20Fez%2C%20Comedy%2C%20Radio

//		public string Creator => $"creator={Show.Value.ShowName}".HTMLEncode();
//		//&creator=Ron%20and%20Fez&date=2004-04

//		public string Date => $"date={AirDate:yyyy-MM}".HTMLEncode();
//		//&date={AirDate:yyyy-MM}

//		public string UploadName => $"{Show.Value.Acronym}-{AirDate:yyyy-MM}";

//		public string UploadUrlSubPath => $"{UploadName.Replace("&", "")}";



//		public ArchiveUploadTemplate(
//			IEnumerable<FileInfo> includedFiles)
//		{
//			AirDate = DateTime.Today;
//			Show = showEntity;
//		}


//		public override string ToString()
//		{
//			//var s = Show.Value.Hosts.Aggregate("", (Current, host) => Current + host);
//			return
//				$"http://archive.org/" +
//				$"upload/" +
//				$"?{Description}" +
//				$"&{Subject}" +
//				$"&{Creator}" +
//				$"&{Date}" +
//				$"&collection=opensource_audio" +
//				$"&language=eng";
//		}
//	}
//}
