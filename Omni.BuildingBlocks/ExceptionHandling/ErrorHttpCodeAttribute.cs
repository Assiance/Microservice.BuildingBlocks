﻿using System;
using System.Net;

namespace Omni.BuildingBlocks.ExceptionHandling
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ErrorHttpCodeAttribute : Attribute
    {
        public ErrorHttpCodeAttribute(HttpStatusCode code)
        {
            Code = code;
        }

        public ErrorHttpCodeAttribute(int code)
        {
            Code = (HttpStatusCode) code;
        }

        public HttpStatusCode Code { get; set; }
    }
}