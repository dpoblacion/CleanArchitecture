using Domain.Commons;

namespace Domain.Models;

public interface IDeviceRepository : IRepository<Device>
{
    Task<List<Device>> FindDevice(
        string name,
        CancellationToken cancellationToken);

    Task<Device?> GetDeviceById(
        Guid id,
        CancellationToken cancellationToken);

    Task<Device?> GetDeviceByName(
        string name,
        CancellationToken cancellationToken);

    Task<bool> CreateDeviceAsync(
        Device device,
        CancellationToken cancellationToken);

    Task<bool> UpdateDeviceAsync(
        Device device,
        CancellationToken cancellationToken);
    Task<bool> DeleteDeviceAsync(
        Device device,
        CancellationToken cancellationToken);
}
