using System.Linq.Expressions;

namespace SKL.Data.IContext;

public interface ISKLContext
{
    event EventHandler? DataChangeEventHandler;

    Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, string sentence);
    Task<(bool, string)> ExecuteNonQueryAsync(string sentence);
    Task<IEnumerable<T>> ExecuteStoredProcedureQueryAsync<T>(string storedProcedure, object parameters);
    Task<(bool, string)> ExecuteStoredProcedureDMLAsync(string storedProcedure, object parameters);
    Task<(bool, string)> ExecuteSP10MinAsync(string storedProcedure, object parameters);
    Task<(bool, string)> BulkInsertAsync<T>(IEnumerable<T> list) where T : class;
    Task<(bool, string)> BulkMergeAsync<T>(IEnumerable<T> list, Expression<Func<T, object>> qualifiers) where T : class;
    Task<(bool, string)> BulkDeleteAsync<T>(IEnumerable<T> list, Expression<Func<T, object>> qualifiers) where T : class;

}
