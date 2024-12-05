namespace Application.DatabaseInit.Interfaces
{
    public interface IB2CLinxMicrovixServiceService
    {
        public void InsertParametersIfNotExists();
        public void CreateTablesIfNotExists();
        public void CreateTablesMerges();
    }
}
