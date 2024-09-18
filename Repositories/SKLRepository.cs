using Microsoft.VisualBasic;
using SKL.Data;
using SKL.Models;
using SKL.Repositories.IRepository;
using System.Xml.Linq;

namespace SKL.Repositories;

public class SKLRepository : ISKLRepositories
{
    public event EventHandler? DataChangeEventHandler;
    private readonly SkipLevelContext _context;
    private readonly string _storedProcedure;

    public SKLRepository(SkipLevelContext context)
    {
        _storedProcedure = "[SKL].[SKL_FUNCTIONS]";
        _context = context;
    }

    public async Task<IEnumerable<Department>> GetSKLDepartmentsAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<Department>(_storedProcedure,
    new { Option = "GET_DEPARTMENT" });

    public async Task<IEnumerable<UserType>> GetSKLUserTypeAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<UserType>(_storedProcedure,
    new { Option = "GET_USERTYPE" });

    public async Task<IEnumerable<Shift>> GetSKLShiftsAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<Shift>(_storedProcedure,
    new { Option = "GET_SHIFTS" });
    public async Task<IEnumerable<Position>> GetSKLPositionAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<Position>(_storedProcedure,
    new { Option = "GET_POSITION" });

}
