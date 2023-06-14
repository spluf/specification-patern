using CapOn.Common.Contracts;
using CapOn.Users.Engine.Commands;
using CapOn.Users.Engine.Contracts;
using CapOn.Users.Engine.Events;
using Mapster;

namespace CapOn.Users.Engine.Agregates
{
    public partial class User : IAgregate, IUser
    {
        public Guid Id { get; private set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string? Country { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }

        public List<IEvent> Processed { get; protected set; }
        public List<IEvent> Pending { get; protected set; }
        public int Version { get; protected set; }

        public User()
        {
            new User(Guid.NewGuid(), new List<IEvent>(), new List<IEvent>());
        }

        public User(Guid id, List<IEvent> processed, List<IEvent> pending)
        {
            this.Id = id;
            this.Processed = processed;
            this.Pending = pending;
            this.Version = processed.Any() ? processed.OrderBy(p => p.Version).Last().Version : 0;
        }

        public UserRegisteredEvent Register(RegisterUserCommand registerUser)
        {
            Id = Guid.NewGuid();

            var @event = registerUser.Adapt<UserRegisteredEvent>();
            @event.Id = Id;
            @event.Version = Version++;

            Process(@event);
            Pending.Add(@event);
            return @event;
        }

        public void Rebuild(List<IEvent> events)
        {
            foreach (var @event in events.OrderBy(e => e.Version))
            {
                switch(@event.Type)
                {
                    case UserEvents.UserRegisteredEventType:
                        Process(@event as UserRegisteredEvent);
                        break;
                }
            }
        }

        private void Process(UserRegisteredEvent registerUser)
        {
            this.Id = registerUser.Id;
            this.FirstName = registerUser.FirstName;
            this.LastName = registerUser.LastName;
            this.Address = registerUser.Address;
            this.City = registerUser.City;
            this.County = registerUser.County;
            this.Country = registerUser.Country;
            this.PhoneNo = registerUser.PhoneNo;
            this.Email = registerUser.Email;
            this.Version = registerUser.Version;
        }
    }
}
