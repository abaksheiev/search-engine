namespace ScoreEngine.Contracts.Dtos;


[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class ColumnNameAttribute : Attribute
{
    public string ColumnName { get; }
    public ColumnNameAttribute(string name)
    {
        ColumnName = name;
    }
}
