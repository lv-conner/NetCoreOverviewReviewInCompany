using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceScope
{
    public interface IBase
    {
        int Count { get; set; }
    }


    public interface ITransient:IBase
    {

    }
    public interface IScope : IBase
    {

    }
    public interface ISingleton:IBase
    {

    }


    public class BaseClass:IBase
    {
        private int _count;
        public int Count { get => _count; set => _count = value; }
    }

    public class Transient:BaseClass,ITransient
    {

    }
    public class Scope:BaseClass,IScope
    {

    }
    public class Singleton:BaseClass,ISingleton
    {

    }


}
