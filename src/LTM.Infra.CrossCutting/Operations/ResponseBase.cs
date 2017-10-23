
namespace LTM.Infra.CrossCutting.Operations
{
    public class ResponseBase
    {
        public OperationResult OperationResult { get; set; }
        

        public ResponseBase()
        {
            OperationResult = new OperationResult()
            {
                Status = StatusOperation.OKRESULT
            };            
        }        
    }
}
