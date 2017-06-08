using Spectre.Mvvm.Base;

namespace Backend.Entities
{
    public abstract class Entity: PropertyChangedNotification
    {
        public abstract int GetId();
    }
}
