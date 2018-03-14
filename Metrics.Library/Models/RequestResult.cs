using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.Library.Models
{
	public class RequestResult
	{
		public string Url { get; set; }
		public long ElapsedMilliseconds { get; set; }
		public bool Successful { get; set; }
	}
}
