using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CustomIOC.Interfaces;
using CustomIOC.Models;
using CustomIOC.Services;

namespace CustomIOC
{
    public class Hub : IDisposable
    {
        public Hub()
        {
            MyIoc.Register<IContext, Context>();
            MyIoc.Register<IPersonService, PersonService>();
            MyIoc.Register<IStudentService, StudentService>();
        }

        private IPersonService _personService;
        public IPersonService PersonService
        {
            get
            {
                if (_personService != null)
                    return _personService;

                _personService = MyIoc.Resolve<IPersonService>();
                return _personService;
            }
        }

        private IStudentService _studentService;
        public IStudentService StudentService
        {
            get
            {
                if (_studentService != null)
                    return _studentService;

                _studentService = MyIoc.Resolve<IStudentService>();
                return _studentService;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
            // free native resources if there are any.
        }


        private static Hub _instance;
        public static Hub Instance
        {
            get { return _instance ?? (_instance = new Hub()); }
            private set { }
        }

        public static void DisposeInstance()
        {
            if (Instance == null) return;

            Instance.Dispose();
            _instance = null;
        }
    }



    public static class MyIoc
    {
        private static readonly IDictionary<Type, Type> types = new Dictionary<Type, Type>();
        private static readonly IDictionary<Type, object> typeInsances = new Dictionary<Type, object>();

        public static void Register<TContract, TImplementation>()
        {
            types[typeof(TContract)] = typeof(TImplementation);
        }

        public static void Register<TContract, TImplementation>(TImplementation instance)
        {
            typeInsances[typeof(TContract)] = instance;
        }

        public static object Resolve(Type contract)
        {
            if (typeInsances.ContainsKey(contract))
            {
                return typeInsances[contract];
            }

            Type implementation = types[contract];
            ConstructorInfo constructor = implementation.GetConstructors()[0];
            ParameterInfo[] constructorParameters = constructor.GetParameters();
            if (constructorParameters.Length == 0)
            {
                return Activator.CreateInstance(implementation);
            }
            List<object> parameters = new List<object>(constructorParameters.Length);
            foreach (ParameterInfo parameterInfo in constructorParameters)
            {
                parameters.Add(Resolve(parameterInfo.ParameterType));
            }
            return constructor.Invoke(parameters.ToArray());
        }

        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }
    }

}
