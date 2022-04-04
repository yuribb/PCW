using System.Data;

namespace PCW.Contracts.Exceptions
{
    public class DataNotFoundException : DataException
    {
        private Type EntityType { get; }
        private long Id { get; }

        public override string Message => $"Entity \"{EntityType.Name}\" with Id = {Id} not found";

        public DataNotFoundException(Type entityType, long id) : base()
        {
            EntityType = entityType;
            Id = id;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
