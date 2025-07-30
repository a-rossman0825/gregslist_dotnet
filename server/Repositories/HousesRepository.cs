
using gregslist_dotnet.Interfaces;

namespace gregslist_dotnet.Repositories;

public class HousesRepository : IRepository<House>
{

  private readonly IDbConnection _db;

  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }

  public House Create(House data)
  {
    string sql = @"
    INSERT INTO
    houses (
    sqft,
    bedrooms,
    bathrooms,
    img_url,
    description,
    price,
    creator_id
    )
    VALUES (
    @Sqft,
    @Bedrooms,
    @Bathrooms,
    @ImgUrl,
    @Description,
    @Price,
    @CreatorId
    );
    
    SELECT
    houses.*,
    accounts.*
    FROM houses
    JOIN accounts On houses.creator_id = accounts.id
    WHERE houses.id = LAST_INSERT_ID();";

    House newHouse = _db.Query(sql, (House house, Account account) =>
    {
      house.Creator = account;
      return house;
    }, data).SingleOrDefault();

    return newHouse;
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

  public void Update(House updateData)
  {
    throw new NotImplementedException();
  }
}