namespace LTM.Infra.CrossCutting.Operations
{
    public class ResponseCore<T> : ResponseBase
    {
        public T Data;
        public ResponseCore():base()
        {
            
        }
    }
}
