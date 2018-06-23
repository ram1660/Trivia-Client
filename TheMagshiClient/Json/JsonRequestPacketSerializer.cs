using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMagshiClient
{
    static class JsonRequestPacketSerializer
    {
        //public static byte[] serializeRequest(ErrorResponse request)
        //{

        //}
        public static byte[] serializeRequest(LoginRequest request)
        {
            string strRequest = JsonConvert.SerializeObject(request);
            int len = strRequest.Length;
            byte code = (byte)Protocols.REQUEST_SIGNIN;
            string strData = code + len + strRequest;
            byte[] data = Encoding.ASCII.GetBytes(strData);
            return data;
        }
        public static byte[] serializeRequest(SignupRequest request)
        {
            string strRequest = JsonConvert.SerializeObject(request);
            int len = strRequest.Length;
            byte code = (byte)Protocols.REQUEST_SIGNUP;
            string strData = code + len + strRequest;
            byte[] data = Encoding.ASCII.GetBytes(strData);
            return data;
        }
        public static byte[] serializeRequest(JoinRoomRequest request)
        {
            string strRequest = JsonConvert.SerializeObject(request);
            int len = strRequest.Length;
            byte code = (byte)Protocols.REQUEST_JOIN_ROOM;
            string strData = code + len + strRequest;
            byte[] data = Encoding.ASCII.GetBytes(strData);
            return data;
        }
    }
}
