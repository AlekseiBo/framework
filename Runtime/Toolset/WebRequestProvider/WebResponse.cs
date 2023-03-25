using System;

namespace Toolset
{
    [Serializable]
    public class MetaResponse
    {
        public int code;
        public string message;

        public MetaResponse(int code, string message)
        {
            this.code = code;
            this.message = message;
        }
    }

    [Serializable]
    public class MetaResponse<T> : MetaResponse
    {
        public T data;

        public MetaResponse(int code, string message) : base(code, message)
        {
        }
    }
}