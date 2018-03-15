﻿namespace Metrics.Library.Models
{
	/// <summary>
	/// Request Result
	/// </summary>
	public class RequestResult
	{
		/// <summary>
		/// Path URL
		/// </summary>
		public string Url { get; set; }
		/// <summary>
		/// Ellapsed time in milliseconds
		/// </summary>
		public long ElapsedMilliseconds { get; set; }
		/// <summary>
		/// True if successful
		/// </summary>
		public bool Successful { get; set; }
	}
}