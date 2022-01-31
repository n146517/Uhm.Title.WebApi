using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uhm.Title.Constants;

namespace Uhm.Title.Helper
{
    public class ApiResponse
    {
        public static ResponseModel CreateResponse<T>(T data, int statusCode)
        {
            bool error = false;
            if (StatusConstants.StatusCode200 != statusCode)
            {
                error = true;
            }
            return new ResponseModel(data, statusCode, StatusConstants.GetStatus(statusCode), error);
        }
    }
}
