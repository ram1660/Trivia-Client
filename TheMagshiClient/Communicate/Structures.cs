using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMagshiClient
{
    public struct LoginRequest
    {
        public string username;
        string password;

        public LoginRequest(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
    public struct SignupRequest
    {
        public string username;
        public string password;
        public string email;

        public SignupRequest(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }
    }
    public struct GetPlayersInRoomRequest
    {
        public int roomId;

        public GetPlayersInRoomRequest(int roomId)
        {
            this.roomId = roomId;
        }
    }
    public struct JoinRoomRequest
    {
        public int roomId;

        public JoinRoomRequest(int roomId)
        {
            this.roomId = roomId;
        }
    }
    public struct LoginResponse
    {
        public int status;

        public LoginResponse(int status)
        {
            this.status = status;
        }
    }
    public struct SignupResponse
    {
        public int status;

        public SignupResponse(int status)
        {
            this.status = status;
        }
    }
    public struct LogoutResponse
    {
        public int status;

        public LogoutResponse(int status)
        {
            this.status = status;
        }
    }
    public struct JoinRoomResponse
    {
        public int status;

        public JoinRoomResponse(int status)
        {
            this.status = status;
        }
    }
    public struct CreateRoomResponse
    {
        public int status;

        public CreateRoomResponse(int status)
        {
            this.status = status;
        }
    }
    public struct HighscoreResponse
    {
        public int status;
        List<Highscore> highscores;

        public HighscoreResponse(int status)
        {
            this.status = status;
            highscores = new List<Highscore>();
        }
    }
    public struct CreateRoomRequest
    {
        public string roomId;
        public int maxPlayers;
        public int questionCount;
        public int answerTimeout;

        public CreateRoomRequest(string roomId, int maxPlayers, int questionCount, int answerTimeout)
        {
            this.roomId = roomId;
            this.maxPlayers = maxPlayers;
            this.questionCount = questionCount;
            this.answerTimeout = answerTimeout;
        }
    }
    public struct ErrorResponse
    {
        public string message;
        public ErrorResponse(string message)
        {
            this.message = message;
        }
    }
    public struct Request
    {
        public int id;
        public DateTime sendingTime;
        public byte[] data;

        public Request(int id, DateTime sendingTime, byte[] data)
        {
            this.id = id;
            this.sendingTime = sendingTime;
            this.data = data;
        }
    }
}
