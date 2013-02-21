using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consolve
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseObject foo = new Foo();
            foo.ShowType();
            Console.Read();
        }
       
    }
    public class BaseObject {
        public virtual void ShowType()
        {
            Console.WriteLine("BaseObject.ShowType:"+this.GetType().Name);
        }
    }
    public class Foo : BaseObject {
        public override void ShowType()
        {
            base.ShowType();
            Console.Write("Foo.ShowType:" + this.GetType().Name);
        }
    }

}
