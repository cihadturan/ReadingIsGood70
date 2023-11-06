using System;
using Microsoft.Extensions.Logging;
using ReadingIsGood70.BusinessLayer.Contracts;
using ReadingIsGood70.DataLayer;
using ReadingIsGood70.DataLayer.Contracts;
using ReadingIsGood70.DataLayer.Repositories;

namespace ReadingIsGood70.BusinessLayer
{
    public class BusinessObject : IBusinessObject
    {
        public BusinessObject(SqlDbContext dbContext, ILoggerFactory loggerFactory)
        {
            Id = Guid.NewGuid();
            DatabaseRepository = new DatabaseRepository(loggerFactory.CreateLogger<DatabaseRepository>(), dbContext);
            AuthRepository = new AuthRepository(loggerFactory.CreateLogger<AuthRepository>(), dbContext);
        }

        public IDatabaseRepository DatabaseRepository { get; }
        public IAuthRepository AuthRepository { get; }


        /// <inheritdoc />
        public Guid Id { get; }

        public bool BulkModeIsEnabled => DatabaseRepository.BulkMode;

        public void EnableBulkMode()
        {
            DatabaseRepository.EnableBulkMode();
        }

        public void DisableBulkMode(bool saveChanges = false)
        {
            DatabaseRepository.DisableBulkMode();
        }

        public void Dispose()
        {
            DatabaseRepository?.Dispose();
        }
    }
}