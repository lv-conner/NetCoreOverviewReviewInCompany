using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NetCoreOverview.Filters
{
    //通用特性过滤器的实现。
    //Genernal filter attribute apply to controller and method
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Parameter)]
    public class FilterAttribute : Attribute, IFilterFactory
    {
        private Type _filterType;
        public FilterAttribute(Type filterType)
        {
            if(!typeof(IFilterMetadata).IsAssignableFrom(filterType))
            {
                throw new ArgumentException("filter type must inherit from ifiltermetadata");
            }
            _filterType = filterType;
        }
        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService(_filterType) as IFilterMetadata;
        }
    }
}
