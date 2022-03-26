

List<Entity> entities = new List<Entity>()
{
    new Entity(){Id = 1, ParentId = 0, Name = "Root entity"},
    new Entity(){Id = 2, ParentId = 1, Name = "Child of 1 entity"},
    new Entity(){Id = 3, ParentId = 1, Name = "Child of 1 entity"},
    new Entity(){Id = 4, ParentId = 2, Name = "Child of 2 entity"},
    new Entity(){Id = 5, ParentId = 4, Name = "Child of 4 entity"},
};

var entitiesDict=ConverterListToDict(entities);
PrintDict(entitiesDict);


Dictionary<int, List<Entity>> ConverterListToDict<T>(List<T> enti) where T : Entity
{
    var dict = entities
                      .GroupBy(x => x.ParentId)
                      .ToDictionary(key => key.Key, vals => vals.ToList());
    return dict;
}

void PrintDict(Dictionary<int, List<Entity>> dict)
{
    foreach(KeyValuePair<int, List<Entity>> pair in dict)
        Console.WriteLine("Key = " + pair.Key + ", Value = List { " + string.Join(", ", pair.Value.Select(x => "Entity { Id = " + x.Id + " }")) + " }");
}
public class Entity 
{ 
    public int Id; 
    public int ParentId; 
    public string Name;
}

