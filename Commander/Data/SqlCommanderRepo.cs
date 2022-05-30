using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{

    // this implementation was made for locally hosted sql server
    public class SqlCommanderRepo : ICommanderRepo, IDisposable
    {
        private readonly CommanderDBContext _context;

        public SqlCommanderRepo(CommanderDBContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command command)
        {
            
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Add(command);
            SaveChanges();
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _context.Commands.Remove(command);
            SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(x => x.Id == id);
        }

        public Boolean SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command command)
        {

        }
    }
}
