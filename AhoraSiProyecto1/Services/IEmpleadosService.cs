using AhoraSiProyecto1.Models;

namespace AhoraSiProyecto1.Services
{
    public interface IEmpleadosService
    {
        Task<List<Empleado>> AllUsers();
        Task<int> AddUser(Empleado modelo);
        Task<int> UpdatseUser(Empleado modelo);
        Task<int> DeleteUser(int id);
    }
}
