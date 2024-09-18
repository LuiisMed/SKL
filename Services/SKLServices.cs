using SKL.Repositories.IRepository;
using SKL.Services.IServices;
using SKL.Models;
using System.Xml.Linq;

namespace SKL.Services;

public class SKLServices : ISKLServices
{

    private readonly ISKLRepositories _repository;
    public event EventHandler? DataChangeEventHandler;

    public SKLServices(ISKLRepositories repository)
    {

        _repository = repository;

    }

    public async Task<IEnumerable<Department>> GetSKLDepartmentsAsync()
    => await _repository.GetSKLDepartmentsAsync();

    public async Task<IEnumerable<UserType>> GetSKLUserTypeAsync()
    => await _repository.GetSKLUserTypeAsync();

    public async Task<IEnumerable<Shift>> GetSKLShiftsAsync()
    => await _repository.GetSKLShiftsAsync();

    public async Task<IEnumerable<Position>> GetSKLPositionAsync()
    => await _repository.GetSKLPositionAsync();


}
