
using gregslist_dotnet.Interfaces;

namespace gregslist_dotnet.Services;

public class HousesService : IService<House>
{
  private readonly HousesRepository _housesRepository;

  public HousesService(HousesRepository housesRepository)
  {
    _housesRepository = housesRepository;
  }
  public House Create(House updateData)
  {
    House house = _housesRepository.Create(updateData);
    return house;
  }

  public void Delete(int id)
  {
    throw new NotImplementedException();
  }

  public List<House> GetAll()
  {
    throw new NotImplementedException();
  }

  public House GetById(int id)
  {
    throw new NotImplementedException();
  }

  public House Update(House updateData)
  {
    throw new NotImplementedException();
  }
}