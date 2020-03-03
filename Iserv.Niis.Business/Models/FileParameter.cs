﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iserv.Niis.Business.Models
{
	public class FileParameter
	{
		public byte[] File { get; set; }
		public string FileName { get; set; }
		public string ContentType { get; set; }
		public FileParameter(byte[] file) : this(file, null) { }
		public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
		public FileParameter(byte[] file, string filename, string contenttype)
		{
			File = file;
			FileName = filename;
			ContentType = contenttype;
		}
	}
}
