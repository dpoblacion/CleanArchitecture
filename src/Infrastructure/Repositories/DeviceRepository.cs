using Domain.Commons;
using Domain.Models;
using Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DeviceRepository : IDeviceRepository
{
    /// <summary>
    ///
    /// </summary>
    private readonly ApplicationDbContext _applicationDbContext;

    public IUnitOfWork UnitOfWork => throw new NotImplementedException();

    public DeviceRepository(
        ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
    }

    public async Task<List<Device>> FindDevice(
        string name,
        CancellationToken cancellationToken)
    {
        return await _applicationDbContext
            .Devices.AsNoTracking()
            .Where(d => d.Name.Contains(name))
            .ToListAsync(cancellationToken);
    }

    public async Task<Device?> GetDeviceById(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await _applicationDbContext
            .Devices.AsNoTracking()
            .SingleOrDefaultAsync(d => d.Id == id, cancellationToken);
    }

    public async Task<Device?> GetDeviceByName(
        string name,
        CancellationToken cancellationToken)
    {
        return await _applicationDbContext
            .Devices.AsNoTracking()
            .SingleOrDefaultAsync(d => d.Name == name, cancellationToken);
    }

    public async Task<bool> CreateDeviceAsync(
        Device device,
        CancellationToken cancellationToken)
    {
        _applicationDbContext.Devices.Add(device);
        var changes = await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return changes > 0;
    }

    public async Task<bool> UpdateDeviceAsync(
        Device device,
        CancellationToken cancellationToken)
    {
        _applicationDbContext.Devices.Update(device);
        var changes = await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return changes > 0;
    }

    public async Task<bool> DeleteDeviceAsync(
        Device device,
        CancellationToken cancellationToken)
    {
        _applicationDbContext.Devices.Remove(device);
        var changes = await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return changes > 0;
    }
}
