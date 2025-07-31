
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

  public void Delete(int houseId)
  {
    string sql = "DELETE FROM houses WHERE id = @houseId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { HouseId = houseId });

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows deleted forever, you fudged up bro, here come the lawyers 👨🏻‍💼💼");
    }
  }

  public List<House> GetAll()
  {
    string sql = @"
    SELECT
    houses.*,
    accounts.*
    FROM houses
    JOIN accounts ON houses.creator_id = accounts.id
    ORDER BY houses.created_at ASC;";

    List<House> houses = _db.Query(sql, (House house, Account account) =>
    {
      house.Creator = account;
      return house;
    }).ToList();
    return houses;
  }

  public House GetById(int houseId)
  {
    string sql = @"
    SELECT
    houses.*,
    accounts.*
    FROM houses
    JOIN accounts ON houses.creator_id = accounts.id
    WHERE houses.id = @houseId;";
    House house = _db.Query(sql, (House house, Account account) =>
    {
      house.Creator = account;
      return house;
    }, new { houseId }).SingleOrDefault();

    return house;
  }

  public void Update(House updateData)
  {
    string sql = @"
    UPDATE houses
    SET
    sqft = @Sqft,
    bedrooms = @Bedrooms,
    bathrooms = @Bathrooms,
    img_url = @ImgUrl,
    description = @Description,
    price = @Price,
    WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, updateData);

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows have been updated, you done goofed, dude. Go fix it!!");
    }
  }
}