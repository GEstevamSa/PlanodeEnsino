﻿using System;
using System.Data;

namespace LP.Common.Repository.Contracts.Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        void BeginTran();
        void Commit();
        void Rollback();
    }
}