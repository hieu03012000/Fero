﻿using System;

namespace Reso.Core.Custom
{
    public class ErrorResponse : Exception
    {
        public ErrorDetailResponse Error { get; private set; }

        public ErrorResponse(int errorCode, string message)
        {
            Error = new ErrorDetailResponse
            {
                Code = errorCode,
                Message = message
            };
        }

        public ErrorResponse()
        {
        }
    }

    public class ErrorDetailResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
