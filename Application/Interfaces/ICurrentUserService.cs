using System;

namespace Application.Interfaces
{
    public interface ICurrentUserService
    {
        Guid Position { get; }
    }
}
