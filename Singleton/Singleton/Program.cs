using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            SingletonLock singletonLock = SingletonLock.GetInstance();
            singletonLock.SayHelle();
        }
        class SingletonObject
        {
            //唯一實例
            private static SingletonObject instance = new SingletonObject();

            //私有構造函數，使其不被實例
            private SingletonObject() { }

            public static SingletonObject GetInstance()
            {
                return instance;
            }
            public void showMessage()
            {
                Console.WriteLine("single hello");
            }
        }
        //簡單模式 : 不考慮 thread
        public class SingletonEasy
        {
            private static SingletonEasy instance;
            private SingletonEasy() { }

            public static SingletonEasy GetSingleton()
            {
                if (instance == null)
                {
                    return new SingletonEasy();
                }
                return instance;
            }
        }
        //Use Lock
        public class SingletonLock
        {
            private static readonly SingletonLock instance;
            private static readonly object alterObj = new();
            private SingletonLock() { }

            public static SingletonLock GetInstance()
            {
                if (instance == null)
                {
                    lock (alterObj)
                    {
                        if (instance == null)
                        {
                            return new SingletonLock();

                        }
                    }
                }
                return instance;
            }

            internal void SayHelle()
            {
                Console.WriteLine("I am Lock");
            }
        }


    }
}
