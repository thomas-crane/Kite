namespace LibKite.GameData.DataStructures
{
    public interface IDataStructure<IDType>
    {
        string Name { get; }
        IDType ID { get; }
    }
}
