using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    public class SingletonContainer : Container
    {
        private static SingletonContainer instance;

        private SingletonContainer() { }

        public static SingletonContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonContainer();
                }
                return instance;
            }
        }

        public object Get(Type type)
        {
            return this.GetInstance(type);
        }

        public T Get<T>() where T : class
        {
            return this.GetInstance<T>();
        }

    }
}
