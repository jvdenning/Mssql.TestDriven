using SqlTestDriven.Model;

namespace SqlTestDriven.Contracts
{
    public interface IApplyNamingConventions
    {
       string PrimaryKeyConstraint(Table table, params Column[] keys);
        string ColumnDefault(Column column);
        string NonClusteredIndex(Index index);
        string ClusteredIndex(ClusteredIndex index);
    }
}
