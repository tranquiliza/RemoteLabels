using RemoteLabels.Core;
using RemoteLabels.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLabels.Sql
{
    public class BitrateRepository : IBitrateRepository
    {
        private readonly ISqlAccess sql;

        public BitrateRepository(IConnectionStringProvider connectionStringProvider)
        {
            sql = SqlAccessBase.Create(connectionStringProvider.ConnectionString);
        }

        public async Task SaveBitrate(RecordedBitrate bitrate)
        {
            try
            {
                using (var command = sql.CreateStoredProcedure("[Core].[InsertBitrate]"))
                {
                    command.WithParameter("bitrate", bitrate.Bitrate)
                        .WithParameter("timestamp", bitrate.Timestamp)
                        .WithParameter("username", bitrate.Username);

                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
