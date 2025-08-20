namespace Domain.Core.Enums
{
    public enum EnumStages
    {
        None = 0,
        GetParameters = 1,
        GetLast7DaysMinTimestamp = 2,
        BuildBodyRequest = 3,
        CreateClient = 4,
        PostAsync = 5,
        CallDbProcMerge = 6,
        CreateSystemDataTable = 7,
        GetB2CCompanys = 8,
        GetMicrovixCompanys = 9,
        InsertRecord = 10,
        ExecuteQueryCommand = 11,
        BulkInsertIntoTableRaw = 12,
        GetRegistersExists = 13,
        DeserializeResponseToXML = 14,
        DeserializeXMLToObject = 15,
        GetMicrovixGroupCompanys = 16,
        Compare = 17
    }
}
