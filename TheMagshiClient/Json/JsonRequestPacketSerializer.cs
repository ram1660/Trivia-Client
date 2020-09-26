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
        public static byte[] SerializeRequest(LoginRequest request)
        {
            ArrayList arrayBuff = new ArrayList();
            string strRequest = JsonConvert.SerializeObject(request);

            arrayBuff.Add((byte)Protocols.REQUEST_SIGNIN);
            for (int i = 0; i < 4; i++)
                arrayBuff.Add((char)(strRequest.Length >> ((3 - i) * 8)));
            for (int i = 0; i < strRequest.Length; i++)
                arrayBuff.Add(strRequest[i]);
            char[] buffer = new char[arrayBuff.Count];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToChar(arrayBuff[i]);
            byte[] data = Encoding.ASCII.GetBytes(buffer);
            return data;
        }
        public static byte[] SerializeRequest(SignupRequest request)
        {
            ArrayList arrayBuff = new ArrayList();
            string strRequest = JsonConvert.SerializeObject(request);

            arrayBuff.Add((byte)Protocols.REQUEST_SIGNUP);
            for (int i = 0; i < 4; i++)
                arrayBuff.Add((char)(strRequest.Length >> ((3 - i) * 8)));
            for (int i = 0; i < strRequest.Length; i++)
                arrayBuff.Add(strRequest[i]);
            char[] buffer = new char[arrayBuff.Count];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToChar(arrayBuff[i]);
            byte[] data = Encoding.ASCII.GetBytes(buffer);
            return data;
        }
        public static byte[] SerializeRequest(JoinRoomRequest request)
        {
            ArrayList arrayBuff = new ArrayList();
            string strRequest = JsonConvert.SerializeObject(request);

            arrayBuff.Add((byte)Protocols.REQUEST_JOIN_ROOM);
            for (int i = 0; i < 4; i++)
                arrayBuff.Add((char)(strRequest.Length >> ((3 - i) * 8)));
            for (int i = 0; i < strRequest.Length; i++)
                arrayBuff.Add(strRequest[i]);
            char[] buffer = new char[arrayBuff.Count];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToChar(arrayBuff[i]);
            byte[] data = Encoding.ASCII.GetBytes(buffer);
            return data;
        }
        public static byte[] SerializeRequest(GetPlayersInRoomRequest request)
        {
            ArrayList arrayBuff = new ArrayList();
            string strRequest = JsonConvert.SerializeObject(request);

            arrayBuff.Add((byte)Protocols.REQUEST_JOIN_ROOM);
            for (int i = 0; i < 4; i++)
                arrayBuff.Add((char)(strRequest.Length >> ((3 - i) * 8)));
            for (int i = 0; i < strRequest.Length; i++)
                arrayBuff.Add(strRequest[i]);
            char[] buffer = new char[arrayBuff.Count];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToChar(arrayBuff[i]);
            byte[] data = Encoding.ASCII.GetBytes(buffer);
            return data;
        }
        public static byte[] SerializeRequest(DisconnectRequest request)
        {
            ArrayList arrayBuff = new ArrayList();
            string strRequest = JsonConvert.SerializeObject(request);
            arrayBuff.Add((byte)Protocols.REQUEST_SIGNOUT);
            for (int i = 0; i < 4; i++)
                arrayBuff.Add((char)(strRequest.Length >> ((3 - i) * 8)));
            for (int i = 0; i < strRequest.Length; i++)
                arrayBuff.Add(strRequest[i]);
            char[] buffer = new char[arrayBuff.Count];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToChar(arrayBuff[i]);
            byte[] data = Encoding.ASCII.GetBytes(buffer);
            return data;
        }
        public static byte[] SerializeRequest(KeepAliveResponse response)
        {
            ArrayList arrayBuff = new ArrayList();
            string strRequest = JsonConvert.SerializeObject(response);
            arrayBuff.Add((byte)Protocols.RESPONSE_KEEP_ALIVE);
            for (int i = 0; i < 4; i++)
                arrayBuff.Add((char)(strRequest.Length >> ((3 - i) * 8)));
            for (int i = 0; i < strRequest.Length; i++)
                arrayBuff.Add(strRequest[i]);
            char[] buffer = new char[arrayBuff.Count];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToChar(arrayBuff[i]);
            byte[] data = Encoding.ASCII.GetBytes(buffer);
            return data;
        }
        public static byte[] SerializeRequest(HighscoreRequest request)
        {
            ArrayList arrayBuff = new ArrayList();
            string strRequest = JsonConvert.SerializeObject(request);
            arrayBuff.Add((byte)Protocols.REQUEST_SIGNOUT);
            for (int i = 0; i < 4; i++)
                arrayBuff.Add((char)(strRequest.Length >> ((3 - i) * 8)));
            for (int i = 0; i < strRequest.Length; i++)
                arrayBuff.Add(strRequest[i]);
            char[] buffer = new char[arrayBuff.Count];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToChar(arrayBuff[i]);
            byte[] data = Encoding.ASCII.GetBytes(buffer);
            return data;
        }
    }
}
