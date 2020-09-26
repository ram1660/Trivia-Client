using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace TheMagshiClient
{
    class JsonRequestPacketDeserializer
    {
        public static KeepAliveRequest DeserializeKeepAliveRequest(byte[] request)
        {
            string strRequest = Encoding.UTF8.GetString(request);
            KeepAliveRequest keepAliveRequest = JsonConvert.DeserializeObject<KeepAliveRequest>(strRequest);
            return keepAliveRequest;
        }
        public static LoginResponse DeserializeLoginRequest(byte[] request)
        {
            string strRequest = Encoding.UTF8.GetString(request);

            LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(strRequest);
            return loginResponse;
        }
        public static SignupResponse DeserializeSignupRequest(byte[] request)
        {
            string strRequest = Encoding.UTF8.GetString(request);
            SignupResponse signupResponse = JsonConvert.DeserializeObject<SignupResponse>(strRequest);
            return signupResponse;
        }
        public static ErrorResponse DeserializeErrorResponse(byte[] request)
        {
            string strRequest = Encoding.UTF8.GetString(request);
            ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(strRequest);
            return errorResponse;
        }

        public static HighscoreResponse DeserializeHighscoreResponse(byte[] request)
        {
            string strRequest = Encoding.UTF8.GetString(request);
            HighscoreResponse highscoreResponse = JsonConvert.DeserializeObject<HighscoreResponse>(strRequest);
            return highscoreResponse;
        }
    }
}
