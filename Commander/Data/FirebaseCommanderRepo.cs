using Commander.Models;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class FirebaseCommanderRepo : ICommanderRepo
    {
        private const String commandsPath = "Commands";
        private readonly IFirebaseClient _client;

        public FirebaseCommanderRepo()
        {
            IFirebaseConfig config = new FirebaseConfig()
            {
                AuthSecret = "QiYMxQ5mD3T83mFLhYxaymbtdExkWmfBNGRlzmOU",
                BasePath = "https://commanderapi-d9e38-default-rtdb.europe-west1.firebasedatabase.app/"
            };

            _client = new FirebaseClient(config);
        }


        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            Int32 id = GenerateID();
            command.Id = id;
            _client.Set($"{commandsPath}/{id}", command);
        }

        private Int32 GenerateID()
        {
            var commands = GetAllCommands()
                ?.Where(x => x != null);

            if (commands != null && commands.Any())
            {
                return commands.Max(x => x.Id) + 1;
            }

            return 1;
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _client.Delete($"{commandsPath}/{command.Id}");
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var fireResult = _client.Get(commandsPath);
            var result = fireResult.ResultAs<List<Command>>();
            return result?.Where(x => x != null);
        }

        public Command GetCommandById(Int32 id)
        {
            return _client.Get($"{commandsPath}/{id}").ResultAs<Command>();
        }

        public bool SaveChanges()
        {
            return true;
        }   

        public void UpdateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var fireCommand = GetCommandById(command.Id);

            if (fireCommand == null)
            {
                throw new Exception("No command found");
            }

            _client.Set($"{commandsPath}/{command.Id}", command);
        }
    }
}
