namespace Arta.Framework.Core
{
    public interface IServiceLocator
    {
        T GetInstance<T>();

        void Release(object obj);
    }
}