using System;
using System.Collections.Generic;
using System.Net;


namespace LTM.Infra.CrossCutting.Operations
{
    /// <summary>
    /// OperationResult representa o conjunto de informações resultantes de uma operação realizada.
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Representa o status da operação . 
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Representa a mensagem correspondente ao status e errocode.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Representa o tempo gasto para realizar a operação.
        /// </summary>
        public string TimeProcess { get; set; }

        public Guid Id { get; set; }

    }
}
