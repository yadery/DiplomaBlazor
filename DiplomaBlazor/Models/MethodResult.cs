﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaBlazor.Models
{
    public readonly record struct MethodResult(bool IsSuccess, string? Error)
    {
        public static MethodResult Success() => new(true, null);
        public static MethodResult Fail(string? error) => new(false, error);
    }

    public class MethodDataResult<TData>
    { 
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public TData Data { get; set; }

        public MethodDataResult(bool isSuccess, string error, TData data)
        { 
            IsSuccess = isSuccess;
            Error = error;
            Data = data;
        }

        public static MethodDataResult<TData> Success(TData data) => 
            new(true, null, data);
        public static MethodDataResult<TData> Fail(string? error) => 
            new(false, error, default);
    }
}
