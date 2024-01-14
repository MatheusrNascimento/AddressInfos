using Dapper;

namespace Repository
{
    public class AddressRepository
    {
        private DbSession _session;

        public AddressRepository(DbSession session)
        {
            _session = session;
        }

        public IEnumerable<AddressInfosModel> Get()
        {
            return _session.Connection.Query<AddressInfosModel>("SELECT * FROM [AddressInfos]", null, _session.Transaction);
        }

        public void Save(AddressInfosModel model)
        {

            _session.Connection.Execute
                ("INSERT INTO [AddressInfos] " +
                "([Street], [City], [Complement], [ZipCode], [Neighborhood], [StateInitials], [IBGECode], [GIACode], [Unit])" +
                "VALUES( @Street, @City, @Complement, @ZipCode, @Neighborhood, @StateInitials, @IBGECode, @GIACode, @Unit)", model, _session.Transaction);
        }
    }

    public class AddressInfosModel
    {
        public Guid AddressInfosId { get; set; }
        public string Street { get; set; }
        public string? Complement { get; set; }
        public string ZipCode { get; set; }
        public string? Neighborhood { get; set; }
        public string City { get; set; }
        public string? StateInitials { get; set; }
        public int? IBGECode { get; set; }
        public int? GIACode { get; set; }
        public string? Unit { get; set; }

    }
}