namespace Domain.IntegrationsCore.Entities.Enums
{
    public enum EnumError
    {
        Undefined = 0,

        Exception = 3,

        Validation = 22,
        LegthValidation = 23,
        ConvertValidation = 24,

        ArgumentConectionStringIsNull = 10,
        ArgumentoInvalido = 21,
        SQLCommand = 26,

        EndPointException = 30,
        EndPointReturnEmpty = 31,
        EndPointFailOnDeserialize = 32,
        CreateClientException = 33,

        SqlInsert = 50,
    }
}
