using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Mvvm.Base;

namespace Backend.Entities
{
    public abstract class Entity: PropertyChangedNotification
    {
        public abstract int GetId();
    }
}
