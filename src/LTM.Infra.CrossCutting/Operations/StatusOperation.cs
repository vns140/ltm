namespace LTM.Infra.CrossCutting.Operations
{
    /// <summary>
    /// Representa as possibilidades de status de uma operação.
    /// </summary>
    public static class StatusOperation
    {
        /// <summary>
        /// Operação ocorreu sem erros.
        /// </summary>
        public const string OKRESULT = "OK";

        /// <summary>
        /// Operação não foi bem sucedida.
        /// </summary>
        public const string ERRORRESULT = "ERROR";
    }
}
