



namespace CitizenJournalismNetworkServer.Domain.Models
{


    public abstract class DomainEntity
    {
        public int Id { get; set; }

        public byte[] VersionStamp { get; set; }

    }
}