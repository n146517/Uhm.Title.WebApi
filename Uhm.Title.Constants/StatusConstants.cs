using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uhm.Title.Constants
{
    public class StatusConstants
    {
        private static readonly Dictionary<int, string> _statusCodes = new Dictionary<int, string>
        {
             { 200, "OK" },
             { 201, "Created" },
             { 202, "Accepted" },
             { 203, "Non-Authoritative Information" },
             { 204, "No Content" },
             { 205, "Reset Content" },
             { 206, "Partial Content" },
             { 400, "Bad Request" },
             { 401, "Unauthorized" },
             { 404, "Not Found" },
             { 409, "Conflict" },
             { 405, "Method Not Allowed" },
             { 500, "Internal Server Error" },
             { 501, "Not Implemented" },
             { 502, "Bad Gateway" },
             { 503, "Service Unavailable" },
        };

        public const int StatusCode200 = 200;
        public const int StatusCode201 = 201;
        public const int StatusCode202 = 202;
        public const int StatusCode404 = 404;
        public const int StatusCode401 = 401;
        public const int StatusCode409 = 409;
        public const int StatusCode500 = 500;
        public static string GetStatus(int statuscode)
        {
            return _statusCodes.Where(x => x.Key == statuscode).FirstOrDefault().Value;
        }
    }
}
