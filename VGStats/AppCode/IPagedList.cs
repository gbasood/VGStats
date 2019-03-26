using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VGStats.AppCode
{
	public interface IPagedList<T> : IList<T>
	{
		int PageCount { get; }
		int TotalItemCount { get; }
		int PageIndex { get; }
		int PageNumber { get; }
		int PageSize { get; }
		bool HasPreviousPage { get; }
		bool HasNextPage { get; }
		bool IsFirstPage { get; }
		bool IsLastPage { get; }
	}
}
