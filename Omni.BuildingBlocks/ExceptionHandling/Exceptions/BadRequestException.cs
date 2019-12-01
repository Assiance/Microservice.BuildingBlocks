﻿namespace Omni.BuildingBlocks.ExceptionHandling.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException() : base(ErrorCode.BadRequest)
        {
        }

        public BadRequestException(string message) : base(message, ErrorCode.BadRequest)
        {
        }
    }
}