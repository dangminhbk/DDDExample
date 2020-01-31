using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Handlers.Response
{
    public class ResponseBase
    {
        public ResponseStatus Status { get; set; }
        public static ResponseBase Success 
        { 
            get 
            {
                return new ResponseBase { Status = ResponseStatus.Success };
            }
        }
        public static ResponseBase Fail
        {
            get
            {
                return new ResponseBase { Status = ResponseStatus.Fail };
            }
        }
    }

    public enum ResponseStatus
    {
        Success,
        Fail
    }
}
