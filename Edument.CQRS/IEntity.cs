﻿using System;

namespace Edument.CQRS
{
    public interface IEntity
    {
        Guid Id { get; }
    }

    public abstract class AEntity : IEntity
    {
        public AEntity(Guid id)
        {
            Id = id;
        }

        public virtual Guid Id { get; private set; }
    }
}
