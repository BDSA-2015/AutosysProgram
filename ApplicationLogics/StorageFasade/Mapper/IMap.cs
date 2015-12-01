using System.Security.Cryptography.X509Certificates;

namespace ApplicationLogics.StorageFasade.Mapper
{
    /// <summary>
    /// This interface outlines the method used to mutually convert DTOs, 
    /// Objects in application logic and model objects in storage.
    /// This will translate DTOs to objects in application logic 
    /// and application logic objects to model objects in storage.
    /// For mapping use following package through NuGet: Install-Package AutoMapper
    /// 
    /// To map an object do the following:
    /// https://github.com/AutoMapper/AutoMapper/wiki/Getting-started
    /// </summary>
    interface IMap<T, K> 
        where T : class 
        where K : class
    {
        T Map(K item);
        K Map(T item);
    }
}
