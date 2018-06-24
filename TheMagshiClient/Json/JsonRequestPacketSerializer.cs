using Newtonsoft.Json;
using System;
using System.Collections;
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
            ArrayList arrayBuff = new ArrayList();
            string strRequest = JsonConvert.SerializeObject(request);
            char[] buffer = new char[arrayBuff.Count];

            arrayBuff.Add((byte)Protocols.REQUEST_SIGNIN);
            for (int i = 0; i < 4; i++)
                arrayBuff.Add((char)(strRequest.Length >> ((3 - i) * 8)));
            for (int i = 0; i < strRequest.Length; i++)
                arrayBuff.Add(strRequest[i]);
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToChar(arrayBuff[i]);
            return Encoding.ASCII.GetBytes(buffer);
        }
        public static byte[] serializeRequest(SignupRequest request)
        {
            ArrayList arrayBuff = new ArrayList();
            string strRequest = JsonConvert.SerializeObject(request);
            char[] buffer = new char[arrayBuff.Count];

            arrayBuff.Add((byte)Protocols.REQUEST_SIGNUP);
            for (int i = 0; i < 4; i++)
                arrayBuff.Add((char)(strRequest.Length >> ((3 - i) * 8)));
            for (int i = 0; i < strRequest.Length; i++)
                arrayBuff.Add(strRequest[i]);
            for(int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToChar(arrayBuff[i]);
            return Encoding.ASCII.GetBytes(buffer);
        }
        public static byte[] serializeRequest(JoinRoomRequest request)
        {
            ArrayList arrayBuff = new ArrayList();
            string strRequest = JsonConvert.SerializeObject(request);
            char[] buffer = new char[arrayBuff.Count];

            arrayBuff.Add((byte)Protocols.REQUEST_JOIN_ROOM);
            for (int i = 0; i < 4; i++)
                arrayBuff.Add((char)(strRequest.Length >> ((3 - i) * 8)));
            for (int i = 0; i < strRequest.Length; i++)
                arrayBuff.Add(strRequest[i]);
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToChar(arrayBuff[i]);
            return Encoding.ASCII.GetBytes(buffer);
        }
        public static byte[] serializeRequest(GetPlayersInRoomRequest request)
        {
            ArrayList arrayBuff = new ArrayList();
            string strRequest = JsonConvert.SerializeObject(request);
            char[] buffer = new char[arrayBuff.Count];

            arrayBuff.Add((byte)Protocols.REQUEST_JOIN_ROOM);
            for (int i = 0; i < 4; i++)
                arrayBuff.Add((char)(strRequest.Length >> ((3 - i) * 8)));
            for (int i = 0; i < strRequest.Length; i++)
                arrayBuff.Add(strRequest[i]);
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToChar(arrayBuff[i]);
            return Encoding.ASCII.GetBytes(buffer);
        }
    }
}
