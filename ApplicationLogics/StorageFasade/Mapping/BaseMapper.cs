using ApplicationLogics.StorageFasade.Mapper;

namespace ApplicationLogics.StorageFasade.Mapping
{
    /// <summary>
    /// This class is used to convert user objects in the logical layer (UserDto, User)
    /// to user objects in the storage layer (StoredUser), vice versa. 
    /// </summary>
    public class BaseMapper<T,K> : IMap<T, K> where T : class where K : class
    {
      
       /// <summary>
       /// Maps source to a destination object
       /// </summary>
       /// <param name="source"> source object</param>
       /// <param name="destination"> destination object</param>
       /// <returns>destination object</returns>
        public K Map(T source, K destination)
        {
            AutoMapper.Mapper.CreateMap(typeof(T), typeof(K));
            return AutoMapper.Mapper.Map(source, destination);
        }
    }
}
