namespace Domain.Core.Enums
{
    public enum EnumError
    {
        Undefined = 1,

        Exception = 2,

        Validation = 3,
        LegthValidation = 4,
        ConvertValidation = 5,

        ArgumentConectionStringIsNull = 6,
        ArgumentoInvalido = 7,
        SQLCommand = 8,

        EndPointException = 9,
        EndPointReturnEmpty = 10,
        EndPointFailOnDeserialize = 11,
        CreateClientException = 12,

        SqlInsert = 13,

        Compare = 14,
    }
}
