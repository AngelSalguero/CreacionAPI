using AhoraSiProyecto1.Models;
using Microsoft.EntityFrameworkCore;

namespace AhoraSiProyecto1.Services
{
    public class EmpleadosService : IEmpleadosService
    {

        private readonly PruebaFinalContext _context;
        private readonly DbSet<Empleado> _dbSet;

        public EmpleadosService(PruebaFinalContext context)
        {
            _context = context;
            _dbSet = _context.Set<Empleado>();
        }

        public async Task<int> AddUser(Empleado modelo)
        {
            //Agrega la entidad al ChangeTracker
            await _context.Empleados.AddAsync(modelo);

            //Guarda y captura cuántas filas fueron afectadas
            int filasAfectadas = await _context.SaveChangesAsync();

            //Devuelve el número de filas afectadas
            return filasAfectadas;
        }

        public async Task<List<Empleado>> AllUsers()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> DeleteUser(int id)
        {
            //1) Busca el empleado por su ID
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return 0; // Si no se encuentra, retorna 0 filas afectadas

            //2) Elimina el empleado del contexto
            _context.Empleados.Remove(empleado);

            //3) Guarda los cambios y devolvemos cuántas filas fueron afectadas
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatseUser(Empleado modelo)
        {
            _context.Empleados.Update(modelo);
            return await _context.SaveChangesAsync();
        }
    }
}
