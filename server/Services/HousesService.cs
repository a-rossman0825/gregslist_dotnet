
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

  public string Delete(int id, Account userInfo)
  {
    House houseToDelete = GetById(id);
    if (houseToDelete.CreatorId != userInfo.Id)
    {
      throw new Exception($"NOT YOUR HOUSE, SCUMBAG. YOU BETTER RUN, {userInfo.Name.ToUpper()}! COPS ARE ON THEIR WAY 🚓 🚓 🚓 🚓 🚓");
    }

    _housesRepository.Delete(id);

    return $"Your {houseToDelete.Bedrooms} bedroom {houseToDelete.Bathrooms} bathroom house has been deleted!";
  }

  public List<House> GetAll()
  {
    throw new NotImplementedException();
  }

  public House GetById(int id)
  {
    House house = _housesRepository.GetById(id);

    if (house == null)
    {
      throw new Exception($"Invalid id: {id}");
    }

    return house;
  }

  public House Update(int id, House updateData, Account userInfo)
  {
    House originalHouse = GetById(id);

    if (originalHouse.CreatorId != userInfo.Id)
    {
      throw new Exception($"Not your house, bro, stop it, {userInfo.Name}");
    }

    originalHouse.Sqft = updateData.Sqft ?? originalHouse.Sqft;
    originalHouse.Bedrooms = updateData.Bedrooms ?? originalHouse.Bedrooms;
    originalHouse.Bathrooms = updateData.Bathrooms ?? originalHouse.Bathrooms;
    originalHouse.Description = updateData.Description ?? originalHouse.Description;
    originalHouse.Price = updateData.Price ?? originalHouse.Price;
    originalHouse.ImgUrl = updateData.ImgUrl ?? originalHouse.ImgUrl;

    _housesRepository.Update(originalHouse);
    return originalHouse;
  }
}