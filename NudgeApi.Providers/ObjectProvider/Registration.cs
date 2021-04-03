using System;
using System.Collections.Generic;
using System.Text;

namespace NudgeApi.Providers.ObjectProvider
{
    public class Registration
    {
        public static Registration AsSingleton(Type interfaceType, Type implType) => new Registration(interfaceType, implType, (Func<object>)null, (string)null, true);

        public static Registration AsSingleton(
          Type interfaceType,
          Type implType,
          string name)
        {
            return new Registration(interfaceType, implType, (Func<object>)null, name, true);
        }

        public static Registration AsSingleton(Type interfaceType, Func<object> constructor) => new Registration(interfaceType, (Type)null, constructor, (string)null, true);

        public static Registration AsSingleton(
          Type interfaceType,
          Func<object> constructor,
          string name)
        {
            return new Registration(interfaceType, (Type)null, constructor, name, true);
        }

        public static Registration AsSingleton<TContract, TImpl>() where TImpl : TContract => Registration.AsSingleton(typeof(TContract), typeof(TImpl));

        public static Registration AsSingleton<TContract, TImpl>(string name) => Registration.AsSingleton(typeof(TContract), typeof(TImpl), name);

        public static Registration AsSingleton<T>(Func<object> constructor) => Registration.AsSingleton(typeof(T), constructor);

        public static Registration AsSingleton<T>(Func<object> constructor, string name) => Registration.AsSingleton(typeof(T), constructor, name);

        public static Registration AsPerCall(Type interfaceType, Type implType) => new Registration(interfaceType, implType, (Func<object>)null, (string)null, false);

        public static Registration AsPerCall(
          Type interfaceType,
          Type implType,
          string name)
        {
            return new Registration(interfaceType, implType, (Func<object>)null, name, false);
        }

        public static Registration AsPerCall(Type interfaceType, Func<object> constructor) => new Registration(interfaceType, (Type)null, constructor, (string)null, false);

        public static Registration AsPerCall(
          Type interfaceType,
          Func<object> constructor,
          string name)
        {
            return new Registration(interfaceType, (Type)null, constructor, name, false);
        }

        public static Registration AsPerCall<TContract, TImpl>() where TImpl : TContract => Registration.AsPerCall(typeof(TContract), typeof(TImpl));

        public static Registration AsPerCall<TContract, TImpl>(string name) => Registration.AsPerCall(typeof(TContract), typeof(TImpl), name);

        public static Registration AsPerCall<T>(Func<object> constructor) => Registration.AsPerCall(typeof(T), constructor);

        public static Registration AsPerCall<T>(Func<object> constructor, string name) => Registration.AsPerCall(typeof(T), constructor, name);

        private Registration(
          Type interfaceType,
          Type implementationType,
          Func<object> constructor,
          string name,
          bool isSingleton)
        {
            this.InterfaceType = interfaceType;
            this.ImplementationType = implementationType;
            this.Constructor = constructor;
            this.Name = name;
            this.IsSingleton = isSingleton;
        }

        public Type InterfaceType { get; }

        public Type ImplementationType { get; }

        public string Name { get; }

        public Func<object> Constructor { get; }

        public bool IsSingleton { get; }
    }
}
