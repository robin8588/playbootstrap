using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace playbootstrap.Models
{
    public class PageList<T> :List<T>
    {
        public PageInfo PageInfo { get; private set; }
     
        public PageList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            this.PageInfo = new PageInfo(pageIndex, pageSize);
            this.PageInfo.TotalCount = source.Count();
            this.PageInfo.TotalPages = (int)Math.Ceiling(this.PageInfo.TotalCount / (double)pageSize);
            this.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize));
        }
    }


    public class PageInfo
    {
        public PageInfo(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public int PreviousPage
        {
            get
            {
                return PageIndex - 1;
            }
        }

        public int CurrentPage
        {
            get
            {
                return PageIndex + 1;
            }
        }

        public int NextPage
        {
            get
            {
                return PageIndex + 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex + 1 < TotalPages);
            }
        }
    }
}