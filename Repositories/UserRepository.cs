using Microsoft.VisualBasic;
using SKL.Data;
using SKL.Models;
using SKL.Repositories.IRepository;
using System.Xml.Linq;

namespace SKL.Repositories;

public class UserRepository : IUserRepository
{
    public event EventHandler? DataChangeEventHandler;
    private readonly SkipLevelContext _context;
    private readonly string _storedProcedure;

    public UserRepository(SkipLevelContext context)
    {
        _storedProcedure = "[SKL].[SKL_FUNCTIONS]";
        _context = context;
    }

    public async Task<IEnumerable<Department>> GetSKLDepartmentsAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<Department>(_storedProcedure,
        new { Option = "GET_DEPARTMENT" });

    public async Task<IEnumerable<Usuario>> GetSKLUsuarios()
=> await _context.ExecuteStoredProcedureQueryAsync<Usuario>(_storedProcedure,
    new { Option = "GET_USUARIOS" });

    public async Task<IEnumerable<Login>> GetSKLCredentials()
    => await _context.ExecuteStoredProcedureQueryAsync<Login>(_storedProcedure,
    new { Option = "GET_CREDENTIALS" });

    //public async Task<IEnumerable<SPCData>> GetSPCDataAsync(string customer, string line, string shift, string from, string to, int operationId)
    //=> await _context.ExecuteStoredProcedureQueryAsync<SPCData>(_storedProcedure, new
    //{
    //    Option = "GET_DATA",
    //    Param1 = customer,
    //    Param2 = line,
    //    Param3 = shift,
    //    Param4 = from,
    //    Param5 = to,
    //    Param7 = operationId,
    //});


    //public async Task<(bool, string)> InsertDataAsync(SPCData data)
    //{
    //    _context.DataChangeEventHandler += DataChangeEventHandler;
    //    return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
    //        new
    //        {
    //            Option = "INS_DATA",
    //            Param1 = data.Customer,
    //            Param2 = data.Line,
    //            Param3 = data.Shift,
    //            //Param4 = data.Date,
    //            Param5 = data.CategoryId,
    //            Param6 = data.ParameterId,
    //            Param7 = data.OperationId,
    //            Param8 = data.Target,
    //            Param9 = data.LL,
    //            Param10 = data.UP,
    //            Param11 = data.Value,
    //        });
    //}

    //public async Task<(bool, string)> UpdateDataValue(SPCData data)
    //{
    //    _context.DataChangeEventHandler += DataChangeEventHandler;
    //    return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
    //        new
    //        {
    //            Option = "UPD_DATA_VALUE",
    //            Param1 = data.Customer,
    //            Param2 = data.Line,
    //            Param3 = data.Shift,
    //            Param4 = data.CategoryId,
    //            Param5 = data.ParameterId,
    //            Param6 = data.OperationId,
    //            Param7 = data.Value,
    //        });
    //}
}

